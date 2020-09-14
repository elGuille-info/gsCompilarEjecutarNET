'------------------------------------------------------------------------------
' Compilar NETCore WinF                                             (08/Sep/20)
' Utilidad para colorear, compilar y ejecutar código de VB o C#
'
' Esta aplicación utiliza estas dos DLL compiladas para .NET core 3.1
' (en espera que salga la versión final de .NET 5.0)
' ColorearCore  (código de VB)
' CompilarCore (código de C#)
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text

Imports vbc = Microsoft.CodeAnalysis.VisualBasic

' La clase Colorear
Imports gsCol = gsColorearNET.Colorear ' gsColorearCore.Colorear 'elGuille.Util.Developer.Colorear
' El espacio de nombres Developer (tiene la definición de Lenguajes)
Imports gsDev = gsColorearNET ' gsColorearCore ' elGuille.Util.Developer
Imports gsCompilarNET 'Core

Public Class Form1

    Private fuenteNombre As String = gsCol.FuentePre
    Private fuenteTamaño As String = gsCol.FuenteTamPre
    Private cargarUltimo As Boolean
    Private colorearAlCargar As Boolean

    Private inicializando As Boolean = True
    Private codigoNuevo As String
    Private codigoAnt As String
    Private TamForm As (L As Integer, T As Integer, H As Integer, W As Integer)
    Private Const maxFicsMenu As Integer = 15
    Private Const maxFicsConfig As Integer = 100
    Private colFics As New List(Of String)
    Private ficConfig As String
    Private ultimoFic As String

    Private _TextoModificado As Boolean = False
    Private Property TextoModificado As Boolean
        Get
            Return _TextoModificado
        End Get
        Set(value As Boolean)
            If value Then
                LabelModificado.Text = "*"
            Else
                LabelModificado.Text = " "
            End If
            _TextoModificado = value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ficConfig = Path.Combine(Environment.CurrentDirectory, Application.ProductName & ".appconfig.txt")

        AñadirEventos()
        gsCol.AsignarPalabrasClave()

        LeerConfig()
        If cargarUltimo Then
            Abrir(ultimoFic)
        End If
        inicializando = False
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If TextoModificado Then
            GuardarAs()
        End If
        Form1_Resize(Nothing, Nothing)
        GuardarConfig()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If inicializando Then Return

        If Me.WindowState = FormWindowState.Normal Then
            TamForm = (Me.Left, Me.Top, Me.Height, Me.Width)
        Else
            TamForm = (Me.RestoreBounds.Left, Me.RestoreBounds.Top,
                       Me.RestoreBounds.Height, Me.RestoreBounds.Width)
        End If
    End Sub

    Private Sub AñadirEventos()
        CompilarMenu.ShortcutKeys = Keys.F5
        ColorearMenu.ShortcutKeys = Keys.F6
        NoColorearMenu.ShortcutKeys = Keys.F7
        SelectAllMenu.ShortcutKeys = (Keys.Control Or Keys.A)

        AddHandler AboutMenu.Click, AddressOf AcercaDe_Click
        AddHandler ExitMenu.Click, Sub() Me.Close()
        AddHandler OpenMenu.Click, Sub() Abrir()
        AddHandler SaveMenu.Click, Sub() Guardar()
        AddHandler SaveAsMenu.Click, Sub() GuardarAs()
        AddHandler ColorearMenu.Click, Sub() ColorearCodigo()
        AddHandler NoColorearMenu.Click, Sub() NoColorear()

        AddHandler rtbCodigo.KeyDown, AddressOf rtbCodigo_KeyDown
        AddHandler rtbCodigo.SelectionChanged, AddressOf rtbCodigo_SelectionChanged
        AddHandler rtbCodigo.Leave, AddressOf rtbCodigo_Leave
        AddHandler rtbCodigo.TextChanged, Sub()
                                              codigoNuevo = rtbCodigo.Text
                                              If codigoNuevo = "" Then Return
                                              If codigoAnt = "" Then Return
                                              TextoModificado = (codigoAnt.Replace(Microsoft.VisualBasic.Constants.vbCr, "").Replace(Microsoft.VisualBasic.Constants.vbLf, "") <> codigoNuevo.Replace(Microsoft.VisualBasic.Constants.vbLf, ""))
                                              'TextoModificado = (codigoAnt.Replace(Microsoft.VisualBasic.Constants.vbCr, "") <> codigoNuevo)
                                          End Sub

        AddHandler cboLenguajes.TextChanged, Sub() LabelLenguaje.Text = cboLenguajes.Text

        AddHandler UndoMenu.Click, Sub() If rtbCodigo.CanUndo Then rtbCodigo.Undo()
        AddHandler RedoMenu.Click, Sub() If rtbCodigo.CanRedo Then rtbCodigo.Redo()
        AddHandler PasteMenu.Click, Sub()
                                        If rtbCodigo.CanPaste(DataFormats.GetFormat("Text")) Then
                                            rtbCodigo.Paste(DataFormats.GetFormat("Text"))
                                        End If
                                    End Sub
        AddHandler CopyMenu.Click, Sub() rtbCodigo.Copy()
        AddHandler CutMenu.Click, Sub() rtbCodigo.Cut()
        AddHandler SelectAllMenu.Click, Sub() rtbCodigo.SelectAll()
        AddHandler EditMenu.DropDownOpening, Sub()
                                                 UndoMenu.Enabled = rtbCodigo.CanUndo
                                                 RedoMenu.Enabled = rtbCodigo.CanRedo
                                                 CopyMenu.Enabled = rtbCodigo.SelectionLength > 0
                                                 CutMenu.Enabled = CopyMenu.Enabled
                                                 PasteMenu.Enabled = rtbCodigo.CanPaste(DataFormats.GetFormat("Text"))
                                             End Sub
        AddHandler CompilarMenu.Click, Sub() CompilarEjecutar()
        AddHandler RecientesMenu.DropDownOpening, Sub()
                                                      For i = 0 To RecientesMenu.DropDownItems.Count - 1
                                                          If RecientesMenu.DropDownItems(i).Text.IndexOf(ultimoFic) > 3 Then
                                                              RecientesMenu.DropDownItems(i).Select()
                                                              TryCast(RecientesMenu.DropDownItems(i), ToolStripMenuItem).Checked = True
                                                          End If
                                                      Next
                                                  End Sub
        AddHandler OpcionesMenu.Click, Sub()
                                           ' Mostrar la ventana de opciones
                                           Dim opFrm As New OpcionesForm(colFics)
                                           With opFrm
                                               .CargarUltimo = cargarUltimo
                                               .ColorearAlCargar = colorearAlCargar
                                               If .ShowDialog() = DialogResult.OK Then
                                                   colorearAlCargar = .ColorearAlCargar
                                                   cargarUltimo = .CargarUltimo
                                                   colFics.Clear()
                                                   colFics.AddRange(.ColFics)
                                                   AsignarRecientes()
                                                   GuardarConfig()
                                               End If
                                           End With
                                       End Sub
        AddHandler CopiarPathMenu.Click, Sub()
                                             Try
                                                 Clipboard.SetText(ultimoFic)
                                             Catch ex As Exception
                                             End Try
                                         End Sub
        AddHandler RecargarFicheroMenu.Click, Sub() Recargar()
        AddHandler RecargarMenu.Click, Sub() Recargar()

        AddHandler cboFuenteNombre.TextChanged, Sub()
                                                    Try
                                                        FuenteAceptarMenu.Font = New Font(cboFuenteNombre.Text, CSng(cboFuenteTamaño.Text))
                                                    Catch ex As Exception
                                                    End Try
                                                End Sub

        AddHandler cboFuenteTamaño.TextChanged, Sub()
                                                    Try
                                                        FuenteAceptarMenu.Font = New Font(cboFuenteNombre.Text, CSng(cboFuenteTamaño.Text))
                                                    Catch ex As Exception
                                                    End Try
                                                End Sub

        AddHandler FuenteAceptarMenu.Click, Sub()
                                                fuenteNombre = cboFuenteNombre.Text
                                                fuenteTamaño = cboFuenteTamaño.Text
                                                rtbCodigo.Font = New Font(fuenteNombre, CSng(fuenteTamaño))
                                                LabelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}"
                                                If colorearAlCargar Then ColorearCodigo()
                                                GuardarConfig()
                                            End Sub
    End Sub

    Private Sub GuardarConfig()
        Dim cfg = New gsColorearNET.Config(ficConfig)
        cfg.SetValue("Ficheros", "Ultimo", ultimoFic)
        cfg.SetValue("Ficheros", "CargarUltimo", cargarUltimo)
        cfg.SetValue("Herramientas", "Lenguaje", cboLenguajes.Text)
        cfg.SetValue("Herramientas", "Colorear", colorearAlCargar)

        ' El nombre y tamaño de la fuente                           (11/Sep/20)
        cfg.SetValue("Fuente", "Nombre", fuenteNombre)
        cfg.SetValue("Fuente", "Tamaño", fuenteTamaño)

        ' El tamaño y la posición de la ventana
        cfg.SetValue("Ventana", "Left", TamForm.L)
        cfg.SetValue("Ventana", "Top", TamForm.T)
        cfg.SetValue("Ventana", "Height", TamForm.H)
        cfg.SetValue("Ventana", "Width", TamForm.W)

        ' Guardar la lista de últimos ficheros
        ' solo los maxFicsConfig (100) últimos
        cfg.SetValue("Ficheros", "Count", colFics.Count)
        Dim j = 0
        For i = colFics.Count - 1 To 0 Step -1
            cfg.SetValue("Ficheros", $"Fichero{j}", colFics(i))
            j += 1
            If j = maxFicsConfig Then Exit For
        Next
        cfg.Save()
    End Sub

    Private Sub LeerConfig()
        Dim cfg = New gsColorearNET.Config(ficConfig)
        ultimoFic = cfg.GetValue("Ficheros", "Ultimo", "")
        cargarUltimo = cfg.GetValue("Ficheros", "CargarUltimo", False)
        cboLenguajes.Text = cfg.GetValue("Herramientas", "Lenguaje", "VB")
        colorearAlCargar = cfg.GetValue("Herramientas", "Colorear", False)

        ' El nombre y tamaño de la fuente                           (11/Sep/20)
        fuenteNombre = cfg.GetValue("Fuente", "Nombre", gsCol.FuentePre)
        fuenteTamaño = cfg.GetValue("Fuente", "Tamaño", gsCol.FuenteTamPre)
        LabelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}"

        cboFuenteNombre.Text = fuenteNombre
        cboFuenteTamaño.Text = fuenteTamaño
        rtbCodigo.Font = New Font(fuenteNombre, CSng(fuenteTamaño))

        ' El tamaño y la posición de la ventana
        TamForm.L = cfg.GetValue("Ventana", "Left", -1)
        TamForm.T = cfg.GetValue("Ventana", "Top", -1)
        TamForm.H = cfg.GetValue("Ventana", "Height", -1)
        TamForm.W = cfg.GetValue("Ventana", "Width", -1)

        If TamForm.L <> -1 Then Me.Left = TamForm.L
        If TamForm.T <> -1 Then Me.Top = TamForm.T
        If TamForm.H > -1 Then Me.Height = TamForm.H
        If TamForm.W > -1 Then Me.Width = TamForm.W

        ' Leer la lista de últimos ficheros
        Dim cuantos = cfg.GetValue("Ficheros", "Count", 0)
        colFics.Clear()
        For i = 0 To maxFicsConfig - 1
            If i >= cuantos Then Exit For
            Dim s = cfg.GetValue("Ficheros", $"Fichero{i}", "-1")
            If s = "-1" Then Exit For
            colFics.Add(s)
        Next
        ' Mostrar los 15 primeros en el menú Recientes
        AsignarRecientes()
    End Sub

    Private Sub AsignarRecientes()
        RecientesMenu.DropDownItems.Clear()
        For i = 0 To maxFicsMenu - 1
            If colFics.Count < (i + 1) Then Exit For

            Dim s = $"{i + 1} - {colFics(i)}"
            Dim m = New ToolStripMenuItem(s)
            AddHandler m.Click, Sub() AbrirReciente(m.Text)
            RecientesMenu.DropDownItems.Add(m)
        Next
    End Sub

    Private Sub AbrirReciente(fic As String)
        ' El nombre está después del guión -
        ' posición máxima será 4: 1 - Nombre
        ' pero si hay 2 cifras, será 5: 10 - Nombre
        ' Tomando a partir del la 4ª posición está bien
        If fic = "" Then Return

        Dim ficT = fic.Substring(4).Trim()

        ' Posicionarlo al principio de la colección
        If colFics.Contains(ficT) Then
            colFics.Remove(ficT)
            colFics.Add(ficT)
        End If

        ' Si es el que está abierto, salir
        ' Solo si el texto no está modificado                       (14/Sep/20)
        ' por si se quiere re-abrir
        If ficT = ultimoFic AndAlso TextoModificado = False Then Return

        If TextoModificado Then
            GuardarAs()
        End If
        ultimoFic = ficT
        Abrir(ultimoFic)
    End Sub

    Private Sub NoColorear()
        Dim temp = TextoModificado
        Dim codigo = rtbCodigo.Text

        rtbCodigo.Rtf = ""
        rtbCodigo.Text = codigo
        TextoModificado = temp
    End Sub

    Private Sub ColorearCodigo()
        Dim temp = TextoModificado
        Dim codigo = rtbCodigo.Text

        ' Llamar directamente a gsColorear
        ' Le he puesto que use la fuente Consolas,
        '   que NO asigne el CASE adecuado a las palabras claves,
        '   que indente con 4 espacios
        gsCol.Fuente = fuenteNombre ' "Consolas"
        gsCol.FuenteTam = fuenteTamaño ' "11"
        Dim lang = gsDev.Lenguajes.VB
        If cboLenguajes.Text = "C#" Then
            lang = gsDev.Lenguajes.CS
        ElseIf cboLenguajes.Text = "VB" Then
            lang = gsDev.Lenguajes.VB
        Else
            lang = gsDev.Lenguajes.dotNet
        End If
        codigo = gsCol.ColorearCodigo(codigo,
                                      lang,
                                      gsCol.FormatosColoreado.RTF,
                                      asignarCase:=False,
                                      indentar:=4)

        rtbCodigo.Rtf = codigo

        TextoModificado = temp

    End Sub

    Private Sub Nuevo()
        If TextoModificado Then GuardarAs()
        rtbCodigo.Text = ""
        ultimoFic = ""
        TextoModificado = False
        LabelInfo.Text = ""
        LabelPos.Text = ""
        codigoAnt = ""
    End Sub

    Private Sub GuardarAs()
        With New SaveFileDialog
            .FileName = ultimoFic
            .Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*"
            .RestoreDirectory = True
            .Title = "Selecciona el archivo a guardar"
            If .ShowDialog() = DialogResult.OK Then
                Guardar(ultimoFic)
            End If
        End With
    End Sub

    Private Sub Guardar()
        If ultimoFic = "" Then
            GuardarAs()
            Return
        End If
        Guardar(ultimoFic)
    End Sub

    Private Sub Guardar(fic As String)
        LabelInfo.Text = $"Guardando {ultimoFic}..."

        Dim sCodigo = rtbCodigo.Text
        Using sw As New StreamWriter(fic, append:=False, encoding:=Encoding.UTF8)
            sw.WriteLine(sCodigo)
        End Using
        codigoAnt = sCodigo

        'LabelInfo.Text = $"{Path.GetFileName(fic)} con {rtbCodigo.Text.Length} caracteres."
        LabelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})"
        LabelTamaño.Text = $"{rtbCodigo.Text.Length:#,##0} car."
        TextoModificado = False
        If colFics.Contains(fic) = False Then
            colFics.Add(fic)
        End If
        AsignarRecientes()

    End Sub

    Private Sub Recargar()
        If ultimoFic = "" Then Return
        Abrir(ultimoFic)
    End Sub

    Private Sub Abrir()
        With New OpenFileDialog
            .FileName = ultimoFic
            .Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*"
            .Multiselect = False
            .RestoreDirectory = True
            .Title = "Selecciona el archivo a abrir"
            If .ShowDialog() = DialogResult.OK Then
                ultimoFic = .FileName
                Abrir(ultimoFic)
            End If
        End With
    End Sub

    Private Sub Abrir(fic As String)
        LabelInfo.Text = $"Cargando {fic}..."

        Dim sCodigo = ""
        Using sr As New StreamReader(fic, detectEncodingFromByteOrderMarks:=True, encoding:=Encoding.UTF8)
            sCodigo = sr.ReadToEnd()
        End Using
        codigoAnt = sCodigo
        rtbCodigo.Text = sCodigo
        mostrarPosicion(Nothing)

        If Path.GetExtension(fic).ToLower = ".cs" Then
            cboLenguajes.Text = "C#"
        ElseIf Path.GetExtension(fic).ToLower = ".vb" Then
            cboLenguajes.Text = "VB"
        Else
            If sCodigo.Contains(");") Then
                cboLenguajes.Text = "C#"
            ElseIf sCodigo.ToLower().Contains("end if") Then
                cboLenguajes.Text = "VB"
            Else
                cboLenguajes.Text = "dotnet"
            End If
        End If

        'LabelInfo.Text = $"{Path.GetFileName(fic)} con {rtbCodigo.Text.Length} caracteres."
        LabelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})"
        LabelTamaño.Text = $"{rtbCodigo.Text.Length:#,##0} car."
        If colFics.Contains(ultimoFic) = False Then
            colFics.Add(ultimoFic)
        End If
        AsignarRecientes()
        If colorearAlCargar Then
            ColorearCodigo()
        End If
        TextoModificado = False
    End Sub

    Private Sub AcercaDe_Click(sender As Object, e As EventArgs)
        Dim verColorear = gsCol.Version(completa:=True)
        Dim verCompilar = Compilar.Version(completa:=True)
        Dim i = verColorear.LastIndexOf(" (")
        If i > -1 Then
            verColorear = $"{verColorear.Substring(0, i)}{vbCrLf}{verColorear.Substring(i + 1)}"
        End If
        i = verCompilar.LastIndexOf(" (")
        If i > -1 Then
            verCompilar = $"{verCompilar.Substring(0, i)}{vbCrLf}{verCompilar.Substring(i + 1)}"
        End If

        MessageBox.Show("Utilidad para .NET 5.0 (.NET Core) para mostrar código en VB o C#, " &
                        "colorearlo y compilarlo." & vbCrLf & vbCrLf &
                        "Usando las DLL externas:" & vbCrLf &
                        verColorear & vbCrLf & vbCrLf &
                        verCompilar,
                        "Acerca de Compilar NETCore WinForms VB",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub rtbCodigo_KeyDown(sender As Object, e As KeyEventArgs)
        mostrarPosicion(e)
    End Sub

    ''' <summary>
    '''  Saber la línea y columna de la posición del cursor
    ''' </summary>
    Private Sub mostrarPosicion(e As KeyEventArgs)
        ' Saber la línea y columna de la posición del cursor        (11/Abr/19)
        Dim pos As Integer = rtbCodigo.SelectionStart + 1
        Dim lin As Integer = rtbCodigo.GetLineFromCharIndex(pos) + 1
        Dim col As Integer = pos - rtbCodigo.GetFirstCharIndexOfCurrentLine()
        Dim fcol = rtbCodigo.GetFirstCharIndexFromLine(lin - 1)
        If fcol = pos Then lin -= 1

        If e IsNot Nothing Then
            If e.KeyCode = Keys.Tab AndAlso e.Modifiers = Keys.Shift Then
                col = 1
            ElseIf e.KeyCode = Keys.Home Then
                col = 1
            End If
        End If

        'LabelPos.Text = $"Línea: {lin}  Carácter: {col}"
        LabelPos.Text = $"Lín: {lin}  Car: {col}"
    End Sub

    Private Sub rtbCodigo_SelectionChanged(sender As Object, e As EventArgs)
        mostrarPosicion(Nothing)
    End Sub

    Private Sub rtbCodigo_Leave(sender As Object, e As EventArgs)
        LabelPos.Text = ""
    End Sub

    Private Sub CompilarEjecutar()
        If TextoModificado Then
            GuardarAs()
        End If
        Dim filepath = ultimoFic
        LabelInfo.Text = "Compilando y ejecutando el código..."
        Me.Refresh()
        Dim res = Compilar.CompilarRun(filepath, run:=True)
        LabelInfo.Text = res

        If Compilar.FallosCompilar IsNot Nothing Then
            Dim sb As New StringBuilder

            For Each diagnostic In Compilar.FallosCompilar
                Dim lin = diagnostic.Location.GetLineSpan().StartLinePosition.Line + 1
                Dim pos = diagnostic.Location.GetLineSpan().StartLinePosition.Character + 1
                sb.AppendFormat("{0}: {1} (en línea {2}, posición {3})",
                                      diagnostic.Id,
                                      diagnostic.GetMessage(),
                                      lin, pos)
                sb.AppendLine()
            Next

            MessageBox.Show($"Errores al compilar: {vbCrLf}{sb.ToString}",
                            "Compilar y ejecutar",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

End Class
