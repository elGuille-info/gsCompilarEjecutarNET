'------------------------------------------------------------------------------
' gsCompilarEjecutarNET                                             (08/Sep/20)
' Utilidad para colorear, compilar y ejecutar código de VB o C#
'
' Como aplicación para Windows Forms para .NET 5.0 Preview
'
' Esta aplicación utiliza estas dos DLL compiladas para .NET Standard y .NET Core 3.1
' gsColorearNET .NET Standard 2.0
' gsCompilarNET .NET Core 3.1
'
'v1.0.0.9   Opciones de Buscar y Reemplazar.
'           Pongo WordWrap del RichTextBox a False para que no corte las líneas.
'v1.0.0.10  Con panel para buscar y reemplazar y
'           funciones para buscar, buscar siguiente, reemplazar y reemplazar todos.
'           También en el menú de edición están las 5 opciones.
'v1.0.0.11  Nueva opción para compilar sin ejecutar y otras mejoras visuales.
'v1.0.0.12  Se puede indicar la versión de los lenguajes.
'           Se usa Latest para VB y Default (9.0) para C#.
'v1.0.0.13  Añado un menú contextual al editor de código con los comandos de edición.
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports System
Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Text

'Imports vbc = Microsoft.CodeAnalysis.VisualBasic

' La clase Colorear
Imports gsCol = gsColorearNET.Colorear
' El espacio de nombres que tiene la definición de Lenguajes
Imports gsDev = gsColorearNET
' La clase de Compilar
#If CompilarCore = 1 Then ' Asignar en Compile>Advanced Compile Options>Custom constants
Imports gsCompilarCore
#Else
Imports gsCompilarNET
#End If


Public Class Form1

    '   ''' <summary>
    '   ''' Prueba de la versión 16.0 de Visual Basic.
    '   ''' Necesita el package System.Data.SqlClient (4.8.2)
    '   ''' </summary>
    '   Private Sub Prueba()
    '       Dim cmd = New SqlCommand
    '       cmd.CommandText = ' Comment is allowed here without _
    '           "SELECT * FROM Titles JOIN Publishers " _ ' This is a comment
    '           & "ON Publishers.PubId = Titles.PubID " _
    '_ ' This is a comment on a line without code
    '           & "WHERE Publishers.State = 'CA'"
    '   End Sub

#Region " Para sincronizar los scrollbar de los richtextbox (15/Sep/20) "

    ' Adaptado de un ejemplo para C# de este foro:
    ' https://social.msdn.microsoft.com/Forums/windows/en-US/161d1636-aea3-4fee-beb4-52370663d44c/
    ' synchronize-scrolling-in-2-richtextboxes-in-c?forum=winforms
    Public Enum ScrollBarType As Integer
        SbHorz = 0
        SbVert = 1
        SbCtl = 2
        SbBoth = 3
    End Enum

    Public Enum Message As Long
        WM_VSCROLL = &H115
    End Enum

    Public Enum ScrollBarCommands As Long
        SB_THUMBPOSITION = 4
    End Enum

    <System.Runtime.InteropServices.DllImport("User32.dll")>
    Public Shared Function GetScrollPos(hWnd As IntPtr, nBar As Integer) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("User32.dll")>
    Public Shared Function SendMessage(hWnd As IntPtr, msg As Long, wParam As Long, lParam As Long) As Integer
    End Function

    ''' <summary>
    ''' Sincroniza los scrollbar de los dos richtextbox
    ''' </summary>
    Private Sub RichTextBox_VScroll(sender As Object, e As EventArgs)
        Dim nPos As Integer = GetScrollPos(richTextBoxCodigo.Handle, ScrollBarType.SbVert)
        nPos <<= 16
        Dim wParam As Long = ScrollBarCommands.SB_THUMBPOSITION Or nPos
        SendMessage(richTextBoxtFilas.Handle, Message.WM_VSCROLL, wParam, 0)
    End Sub

#End Region

    ''' <summary>
    ''' Tupla para guardar el tamaño y posición del formulario
    ''' </summary>
    Private tamForm As (L As Integer, T As Integer, H As Integer, W As Integer)

    ''' <summary>
    ''' Si se pulsa Ctrl+F o Ctrl+H para indicar 
    ''' los datos a buscar o reemplazar
    ''' </summary>
    Private esCtrlF As Boolean = True
    ''' <summary>
    ''' La posición desde la que se está buscando
    ''' </summary>
    Private buscarPos As Integer
    ''' <summary>
    ''' La posición en que está la primera coincidencia
    ''' al buscar
    ''' </summary>
    Private buscarPosIni As Integer
    ''' <summary>
    ''' Para indicar que se está buscando
    ''' la primera coincidencia de la búsqueda
    ''' </summary>
    Private buscarPrimeraCoincidencia As Boolean = True
    ''' <summary>
    ''' La cadena a buscar
    ''' </summary>
    Private buscarQueBuscar As String
    ''' <summary>
    ''' La cadena a poner cuando se reemplaza
    ''' </summary>
    Private buscarQueReemplazar As String
    ''' <summary>
    ''' Si se busca teniendo en cuenta las mayúsculas y minúsculas
    ''' </summary>
    Private buscarMatchCase As Boolean
    ''' <summary>
    ''' Si se busca la palabra completa
    ''' </summary>
    Private buscarWholeWord As Boolean
    ''' <summary>
    ''' El número máximo de items en buscar y reemplazar
    ''' </summary>
    Private Const BuscarMaxItems As Integer = 20
    ''' <summary>
    ''' El nombre de la fuente a usar en el editor
    ''' </summary>
    Private fuenteNombre As String = gsCol.FuentePre
    ''' <summary>
    ''' El tamaño de la fuente a usar en el editor
    ''' </summary>
    Private fuenteTamaño As String = gsCol.FuenteTamPre
    ''' <summary>
    ''' Si se debe cargar el último fichero abierto 
    ''' cuando se cerróa la aplicación
    ''' </summary>
    Private cargarUltimo As Boolean
    ''' <summary>
    ''' Si se debe colorear el código al abrir el fichero
    ''' </summary>
    Private colorearAlCargar As Boolean
    ''' <summary>
    ''' Si se está inicializando.
    ''' Usado para que no se provoquen eventos en cadena
    ''' </summary>
    Private inicializando As Boolean = True
    ''' <summary>
    ''' El nuevo código del editor
    ''' </summary>
    Private codigoNuevo As String
    ''' <summary>
    ''' El código anterior del editor.
    ''' Usado para comparar si ha habido cambios
    ''' </summary>
    Private codigoAnterior As String
    ''' <summary>
    ''' El número máximo de ficheros en el menú recientes
    ''' </summary>
    Private Const MaxFicsMenu As Integer = 15
    ''' <summary>
    ''' El número máximo de ficheros a guardar en la configuración
    ''' </summary>
    Private Const MaxFicsConfig As Integer = 50
    ''' <summary>
    ''' Colección de los ficheros recientes
    ''' </summary>
    Private colFics As New List(Of String)
    ''' <summary>
    ''' El nombre del fichero de configuración
    ''' </summary>
    Private ficheroConfiguracion As String
    ''' <summary>
    ''' Nombre del último fichero usado
    ''' </summary>
    Private nombreUltimoFichero As String

    Private _TextoModificado As Boolean = False
    ''' <summary>
    ''' Indica si se ha modificado el texto.
    ''' Cuando cambia el texto actual (<see cref="codigoNuevo"/>)
    ''' se comprueba con <see cref="codigoAnterior"/> por si hay cambios
    ''' </summary>
    Private Property TextoModificado As Boolean
        Get
            Return _TextoModificado
        End Get
        Set(value As Boolean)
            If value Then
                labelModificado.Text = "*"
            Else
                labelModificado.Text = " "
            End If
            _TextoModificado = value
        End Set
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' guardarlo en Documentos del usuario                       (18/Sep/20)
        ' para que sea accesible siempre, por si se reinstala la aplicación
        ' o se usa en desarrollo y se usan versiones Debug y Release
        'ficheroConfiguracion = Path.Combine(Environment.CurrentDirectory, Application.ProductName & ".appconfig.txt")
        Dim extension = ".appconfig.txt"
        Dim documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        ficheroConfiguracion = Path.Combine(documentos, Application.ProductName & extension)

        AsignaMetodosDeEventos()

        gsCol.AsignarPalabrasClave()

        LeerConfig()
        If cargarUltimo Then
            Abrir(nombreUltimoFichero)

            ' BUG: Al cargar el formulario no se produce el evento  (18/Sep/20)
            ' TextChanged del richTextBoxCodigo porque inicializando es True

            ' BUG: No llamar a este método                          (18/Sep/20)
            ' si no se ha abierto el fichero

            ' Mostrar los números de línea
            If nombreUltimoFichero <> "" Then _
                AñadirNumerosDeLinea()

        End If

        ' Iniciar la posición al principio
        mostrarPosicion(New KeyEventArgs(Keys.Home))
        inicializando = False

        ComboBuscar_Validating()
        ComboReemplazar_Validating()

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' BUG: Si se pulsa en nuevo, se pega texto y no se guarda   (18/Sep/20)
        ' al cerrar no pregunta si se quiere guardar.
        ' Esto está solucionado en el evento de richTextBoxCodigo.TextChanged
        If TextoModificado OrElse nombreUltimoFichero = "" Then
            GuardarAs()
        End If
        Form1_Resize(Nothing, Nothing)
        GuardarConfig()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If inicializando Then Return

        If Me.WindowState = FormWindowState.Normal Then
            tamForm = (Me.Left, Me.Top, Me.Height, Me.Width)
        Else
            tamForm = (Me.RestoreBounds.Left, Me.RestoreBounds.Top,
                       Me.RestoreBounds.Height, Me.RestoreBounds.Width)
        End If
    End Sub

    ''' <summary>
    ''' Asigna los métodos de eventos a los controles.
    ''' Esto es así porque .NET 5.0 Preview 8 no añade
    ''' los manejadores de eventos a los controles.
    ''' Ni en Visual Basic ni en C#.
    ''' </summary>
    Private Sub AsignaMetodosDeEventos()

        AddHandler menuAbout.Click, AddressOf AcercaDe_Click
        AddHandler menuExit.Click, Sub() Me.Close()
        AddHandler menuOpen.Click, Sub() Abrir()
        AddHandler menuSave.Click, Sub() Guardar()
        AddHandler menuSaveAs.Click, Sub() GuardarAs()
        AddHandler menuColorear.Click, Sub() ColorearCodigo()
        AddHandler menuNoColorear.Click, Sub() NoColorear()
        AddHandler menuNew.Click, Sub() Nuevo()

        AddHandler richTextBoxCodigo.VScroll, AddressOf RichTextBox_VScroll
        AddHandler richTextBoxCodigo.FontChanged,
                    Sub()
                        richTextBoxtFilas.Font = New Font(richTextBoxCodigo.Font.FontFamily, richTextBoxCodigo.Font.Size)
                    End Sub
        AddHandler richTextBoxCodigo.KeyDown, AddressOf RichTextBoxCodigo_KeyDown
        AddHandler richTextBoxCodigo.SelectionChanged, AddressOf RichTextBoxCodigo_SelectionChanged
        AddHandler richTextBoxCodigo.TextChanged,
                    Sub()
                        If inicializando Then Return
                        codigoNuevo = richTextBoxCodigo.Text
                        If codigoNuevo = "" Then Return

                        ' BUG: Añadir los números de línea         (18/Sep/20)
                        ' antes de la comparación de codigoAnterior

                        ' Añadir los números de línea               (15/Sep/20)
                        AñadirNumerosDeLinea()

                        If codigoAnterior = "" Then
                            ' BUG: ya se ha pegado el texto         (18/Sep/20)
                            ' y si no hay código anterior no se asigna TextoModificado
                            TextoModificado = True
                            Return
                        End If

                        ' En realidad no hace falta quitar los vbCr (18/Sep/20)
                        'TextoModificado = (codigoAnterior.Replace(vbCr, "").Replace(vbLf, "") <> codigoNuevo.Replace(vbLf, ""))
                        TextoModificado = (codigoAnterior <> codigoNuevo)
                    End Sub

        AddHandler comboLenguajes.SelectedIndexChanged, Sub()
                                                            If comboLenguajes.Text = "VB" Then
                                                                buttonLenguaje.Image = buttonLenguaje.DropDownItems(0).Image
                                                            Else
                                                                buttonLenguaje.Image = buttonLenguaje.DropDownItems(1).Image
                                                            End If
                                                        End Sub
        AddHandler menuVB.Click, Sub() comboLenguajes.Text = menuVB.Text
        AddHandler menuCS.Click, Sub() comboLenguajes.Text = menuCS.Text

        AddHandler menuUndo.Click, Sub() If richTextBoxCodigo.CanUndo Then richTextBoxCodigo.Undo()
        AddHandler menuRedo.Click, Sub() If richTextBoxCodigo.CanRedo Then richTextBoxCodigo.Redo()
        AddHandler menuPaste.Click, Sub() Pegar()
        AddHandler menuCopy.Click, Sub() richTextBoxCodigo.Copy()
        AddHandler menuCut.Click, Sub() richTextBoxCodigo.Cut()
        AddHandler menuSelectAll.Click, Sub() richTextBoxCodigo.SelectAll()
        AddHandler menuEdit.DropDownOpening, Sub() menuEditDropDownOpenning()

        AddHandler menuCompilar.Click, Sub() Build()
        AddHandler menuCompilarEjecutar.Click, Sub() CompilarEjecutar()

        AddHandler menuRecientes.DropDownOpening,
                    Sub()
                        For i = 0 To menuRecientes.DropDownItems.Count - 1
                            If menuRecientes.DropDownItems(i).Text.IndexOf(nombreUltimoFichero) > 3 Then
                                menuRecientes.DropDownItems(i).Select()
                                TryCast(menuRecientes.DropDownItems(i), ToolStripMenuItem).Checked = True
                            End If
                        Next
                    End Sub
        AddHandler menuOpciones.Click,
                    Sub()
                        ' Mostrar la ventana de opciones
                        Dim opFrm As New FormOpciones(colFics)
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
        AddHandler menuCopiarPath.Click,
                    Sub()
                        Try
                            Clipboard.SetText(nombreUltimoFichero)
                        Catch ex As Exception
                        End Try
                    End Sub
        AddHandler menuRecargarFichero.Click, Sub() Recargar()
        AddHandler menuRecargar.Click, Sub() Recargar()

        AddHandler comboFuenteNombre.TextChanged,
                    Sub()
                        If inicializando Then Return
                        Try
                            menuFuenteAceptar.Font = New Font(comboFuenteNombre.Text, CSng(comboFuenteTamaño.Text))
                        Catch ex As Exception
                        End Try
                    End Sub

        AddHandler comboFuenteTamaño.TextChanged,
                    Sub()
                        If inicializando Then Return
                        Try
                            menuFuenteAceptar.Font = New Font(comboFuenteNombre.Text, CSng(comboFuenteTamaño.Text))
                        Catch ex As Exception
                        End Try
                    End Sub

        AddHandler menuFuenteAceptar.Click,
                    Sub()
                        fuenteNombre = comboFuenteNombre.Text
                        fuenteTamaño = comboFuenteTamaño.Text
                        richTextBoxCodigo.Font = New Font(fuenteNombre, CSng(fuenteTamaño))
                        labelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}"
                        If colorearAlCargar Then ColorearCodigo()
                        GuardarConfig()
                    End Sub

        ' Buscar y reemplazar                                       (17/Sep/20)
        AddHandler menuBuscar.Click, Sub() BuscarReemplazar(True)
        AddHandler menuReemplazar.Click, Sub() BuscarReemplazar(esBuscar:=False)
        AddHandler buttonBuscarSiguiente.Click, Sub() BuscarSiguiente()
        AddHandler menuBuscarSiguiente.Click, Sub() BuscarSiguiente()
        AddHandler buttonReemplazarSiguiente.Click, Sub() ReemplazarSiguiente()
        AddHandler menuReemplazarSiguiente.Click, Sub() ReemplazarSiguiente()
        AddHandler buttonReemplazarTodos.Click, Sub() ReemplazarTodos()
        AddHandler menuReemplazarTodos.Click, Sub() ReemplazarTodos()
        AddHandler buttonCerrarPanel.Click, Sub() MostrarPanelBuscar(False)

        AddHandler comboBuscar.Validating, Sub() ComboBuscar_Validating()
        AddHandler comboReemplazar.Validating, Sub() ComboReemplazar_Validating()

        ' Para palabras completas y case sensitive                  (17/Sep/20)
        AddHandler chkMatchCase.Click, Sub() buscarMatchCase = chkMatchCase.Checked
        AddHandler chkWholeWord.Click, Sub() buscarWholeWord = chkWholeWord.Checked

        ' Crear un context menú para el richTextBox del código      (18/Sep/20)
        CrearContextMenuCodigo()
        AddHandler rtbCodigoContextMenu.Opening, Sub() menuEditDropDownOpenning()

    End Sub

    ''' <summary>
    ''' Cuando se abre el menú de edición
    ''' asignar si están o no habilitados.
    ''' </summary>
    Private Sub menuEditDropDownOpenning()
        menuUndo.Enabled = richTextBoxCodigo.CanUndo
        menuRedo.Enabled = richTextBoxCodigo.CanRedo
        menuCopy.Enabled = richTextBoxCodigo.SelectionLength > 0
        menuCut.Enabled = menuCopy.Enabled
        menuPaste.Enabled = richTextBoxCodigo.CanPaste(DataFormats.GetFormat("Text"))
    End Sub

    ''' <summary>
    ''' Crear un menú contextual para richTextBoxCodigo
    ''' para los comandos de edición
    ''' </summary>
    Private Sub CrearContextMenuCodigo()
        rtbCodigoContextMenu.Items.Clear()
        rtbCodigoContextMenu.Items.AddRange({menuUndo, menuRedo, toolSeparator,
                                            menuCopy, menuPaste, menuCut, toolSeparator1,
                                            menuSelectAll})
        richTextBoxCodigo.ContextMenuStrip = rtbCodigoContextMenu
    End Sub

    ''' <summary>
    ''' Añadir los números de línea
    ''' </summary>
    ''' <remarks>Como método separado 18/Sep/20</remarks>
    Private Sub AñadirNumerosDeLinea()
        ' BUG: Comprobar que codigoNuevo no esté vacio              (18/Sep/20)
        ' Usar richTextBoxCodigo.Text en lugar de codigoNuevo
        If richTextBoxCodigo.Text = "" Then Return

        Dim lin = richTextBoxCodigo.Text.Split(vbCr).Length
        richTextBoxtFilas.Text = ""
        For i = 1 To lin
            richTextBoxtFilas.Text &= i.ToString("0").PadLeft(4) & vbCrLf
        Next
        ' Sincronizar los scrolls
        RichTextBox_VScroll(Nothing, Nothing)
    End Sub

    ''' <summary>
    ''' Se produce cuando cambia el texto o se selecciona
    ''' del combo de reemplazar
    ''' </summary>
    Private Sub ComboReemplazar_Validating()
        If inicializando Then Return
        inicializando = True
        ' En reemplazar aceptar cadenas vacías
        ' FindStringExact no diferencia las mayúsculas y minúsculas
        Dim i = comboReemplazar.FindStringExact(comboReemplazar.Text)
        If i = -1 Then
            comboReemplazar.Items.Add(comboReemplazar.Text)
        End If
        inicializando = False
    End Sub

    ''' <summary>
    ''' Se produce cuando cambia el texto o se selecciona
    ''' del combo de buscar
    ''' </summary>
    Private Sub ComboBuscar_Validating()
        If inicializando Then Return
        inicializando = True
        ' En buscar no aceptar cadenas vacías
        ' FindStringExact no diferencia las mayúsculas y minúsculas
        Dim i = If(comboBuscar.Text = "", -1, comboBuscar.FindStringExact(comboBuscar.Text))
        If i = -1 Then
            comboBuscar.Items.Add(comboBuscar.Text)
        End If
        inicializando = False

        ' Si ha cambiado el texto a buscar                          (18/Sep/20)
        ' será como si se pulsase CtrlF
        If buscarQueBuscar <> comboBuscar.Text Then
            esCtrlF = True
        End If
    End Sub

    ''' <summary>
    ''' Pega el texto del portapapeles en el editor
    ''' </summary>
    Private Sub Pegar()
        If richTextBoxCodigo.CanPaste(DataFormats.GetFormat("Text")) Then
            richTextBoxCodigo.Paste(DataFormats.GetFormat("Text"))
            ' BUG: obligar a poner las líneas                       (18/Sep/20)
            AñadirNumerosDeLinea()
        End If
    End Sub

    ''' <summary>
    ''' Muestra el panel de buscar/reemplazar
    ''' y reinicia la posición de búsqueda
    ''' </summary>
    ''' <param name="esBuscar">True si es Buscar, false si es Reemplazar</param>
    Private Sub BuscarReemplazar(esBuscar As Boolean)
        ' Mostrar el panel de buscar/reemplazar
        MostrarPanelBuscar(True)
        esCtrlF = True
        If esBuscar Then
            comboBuscar.Focus()
        Else
            comboReemplazar.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Muestra u oculta el panel de buscar/reemplazar
    ''' </summary>
    ''' <param name="mostrar">True si se debe mostrar, false si se oculta</param>
    Private Sub MostrarPanelBuscar(mostrar As Boolean)
        panelBuscar.Visible = mostrar
        If mostrar Then
            richTextBoxCodigo.Location = New Point(43, 55)
            richTextBoxCodigo.Height = Me.Height - 121
            richTextBoxtFilas.Location = New Point(3, 55)
            richTextBoxtFilas.Height = richTextBoxCodigo.Height
        Else
            richTextBoxCodigo.Location = New Point(43, 28)
            richTextBoxCodigo.Height = Me.Height - 121 + 28
            richTextBoxtFilas.Location = New Point(3, 28)
            richTextBoxtFilas.Height = richTextBoxCodigo.Height
        End If
    End Sub

    ''' <summary>
    ''' Buscar siguiente coincidencia
    ''' </summary>
    Private Sub BuscarSiguiente()
        ' Buscar en el texto lo indicado
        ' Se empieza desde la posición actual del texto

        buscarQueBuscar = comboBuscar.Text

        If buscarQueBuscar = "" Then
            If panelBuscar.Visible = False Then
                BuscarReemplazar(True)
            End If
            Return
        End If

        If esCtrlF Then
            buscarPosIni = richTextBoxCodigo.SelectionStart
            buscarPos = buscarPosIni
            buscarPrimeraCoincidencia = True
            esCtrlF = False
        End If

        Dim rtbFinds = RichTextBoxFinds.None
        If buscarMatchCase Then rtbFinds = RichTextBoxFinds.MatchCase
        If buscarWholeWord Then rtbFinds = rtbFinds Or RichTextBoxFinds.WholeWord

        If buscarPos >= richTextBoxCodigo.Text.Length Then
            buscarPos = 0
        ElseIf buscarPos < 0 Then
            buscarPos = 0
        End If

        buscarPos = richTextBoxCodigo.Find(buscarQueBuscar, buscarPos, rtbFinds)
        If buscarPos = -1 Then
            buscarPos = 0
            BuscarSiguiente()
        Else
            If buscarPrimeraCoincidencia Then
                buscarPrimeraCoincidencia = False
                buscarPosIni = buscarPos
            Else
                richTextBoxCodigo.SelectionStart = buscarPos
                richTextBoxCodigo.SelectionLength = buscarQueBuscar.Length

                If buscarPos = buscarPosIni Then
                    MessageBox.Show("No hay más coincidencias, se ha llegado al inicio de la búsqueda.",
                            "Buscar siguiente",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
                    esCtrlF = True
                    Return
                End If
            End If

            buscarPos += buscarQueBuscar.Length
        End If
    End Sub

    ''' <summary>
    ''' Reemplaza el texto si la selección es lo buscado y
    ''' sigue buscando
    ''' </summary>
    Private Sub ReemplazarSiguiente()
        buscarQueReemplazar = comboReemplazar.Text
        buscarQueBuscar = comboBuscar.Text

        If buscarPos < 0 Then
            buscarPos = 0
        Else
            buscarPos = richTextBoxCodigo.SelectionStart + 1
        End If
        ' si hay texto seleccionado y es lo que se busca
        If richTextBoxCodigo.SelectedText = buscarQueBuscar Then
            ' reemplazar la actual
            richTextBoxCodigo.SelectedText = buscarQueReemplazar
            buscarPos += buscarQueReemplazar.Length
        End If
        ' y buscar la siguiente
        BuscarSiguiente()

    End Sub

    ''' <summary>
    ''' Reemplaza (cambia) todas las coincidencias
    ''' del texto buscado (<see cref="buscarQueBuscar"/>)
    ''' por el indicado en reemplazar (<see cref="buscarQueReemplazar"/>
    ''' </summary>
    ''' <remarks>Se empieza buscando desde el principio del texto</remarks>
    Private Sub ReemplazarTodos()
        buscarQueReemplazar = comboReemplazar.Text
        buscarQueBuscar = comboBuscar.Text

        Dim rtbFinds = RichTextBoxFinds.None
        If buscarMatchCase Then rtbFinds = RichTextBoxFinds.MatchCase
        If buscarWholeWord Then rtbFinds = rtbFinds Or RichTextBoxFinds.WholeWord

        Dim t = 0
        buscarPos = 0
        Do While buscarPos > -1
            buscarPos = richTextBoxCodigo.Find(buscarQueBuscar, buscarPos, rtbFinds)
            If buscarPos > -1 Then
                t += 1
                If richTextBoxCodigo.SelectedText <> "" Then
                    richTextBoxCodigo.SelectedText = buscarQueReemplazar
                    buscarPos += buscarQueReemplazar.Length
                Else
                    Exit Do
                End If
            End If
        Loop
        ' motrar todos los cambios realizados
        If t > 0 Then
            Dim plural = If(t > 1, "s", "")
            MessageBox.Show($"{t} cambio{plural} realizado{plural}.",
                            "Reemplazar todos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show($"No se encontró el texto especificado:{vbCrLf}{buscarQueBuscar}",
                            "Reemplazar todos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ''' <summary>
    ''' Guardar los datos de configuración
    ''' </summary>
    Private Sub GuardarConfig()
        Dim cfg = New gsColorearNET.Config(ficheroConfiguracion)

        ' Si cargarUltimo es falso no guardar el último fichero     (16/Sep/20)
        cfg.SetValue("Ficheros", "CargarUltimo", cargarUltimo)
        If cargarUltimo Then
            cfg.SetValue("Ficheros", "Ultimo", nombreUltimoFichero)
        Else
            cfg.SetValue("Ficheros", "Ultimo", "")
        End If
        cfg.SetValue("Herramientas", "Lenguaje", comboLenguajes.Text)
        cfg.SetValue("Herramientas", "Colorear", colorearAlCargar)

        ' El nombre y tamaño de la fuente                           (11/Sep/20)
        cfg.SetValue("Fuente", "Nombre", fuenteNombre)
        cfg.SetValue("Fuente", "Tamaño", fuenteTamaño)

        ' El tamaño y la posición de la ventana
        cfg.SetValue("Ventana", "Left", tamForm.L)
        cfg.SetValue("Ventana", "Top", tamForm.T)
        cfg.SetValue("Ventana", "Height", tamForm.H)
        cfg.SetValue("Ventana", "Width", tamForm.W)

        ' Guardar la lista de últimos ficheros
        ' solo los maxFicsConfig (100) últimos
        cfg.SetValue("Ficheros", "Count", colFics.Count)
        Dim j = 0
        For i = colFics.Count - 1 To 0 Step -1
            cfg.SetValue("Ficheros", $"Fichero{j}", colFics(i))
            j += 1
            If j = MaxFicsConfig Then Exit For
        Next

        ' Para buscar y reemplazar y CaseSensitive y WholeWord      (17/Sep/20)
        cfg.SetValue("Buscar", "Buscar", buscarQueBuscar)
        cfg.SetValue("Reemplazar", "Reemplazar", buscarQueReemplazar)
        cfg.SetValue("Buscar", "MatchCase", buscarMatchCase)
        cfg.SetValue("Buscar", "WholeWord", buscarWholeWord)
        cfg.SetKeyValue("Buscar", "Buscar-Items-Count", comboBuscar.Items.Count)
        cfg.SetKeyValue("Reemplazar", "Reemplazar-Items-Count", comboReemplazar.Items.Count)
        j = 0
        For i = 0 To comboBuscar.Items.Count - 1
            cfg.SetKeyValue("Buscar", $"Buscar-Items{j}", comboBuscar.Items(i).ToString)
            j += 1
            If j = BuscarMaxItems Then Exit For
        Next
        j = 0
        For i = 0 To comboReemplazar.Items.Count - 1
            cfg.SetKeyValue("Reemplazar", $"Reemplazar-Items{j}", comboReemplazar.Items(i).ToString)
            j += 1
            If j = BuscarMaxItems Then Exit For
        Next

        ' No guardar si está o no visible el panel de buscar/reemplazar
        ' al iniciar siempre estará oculto
        cfg.SetValue("Buscar", "MostrarPanel", panelBuscar.Visible)

        cfg.Save()
    End Sub

    ''' <summary>
    ''' Leer el fichero de configuración
    ''' y asignar los valores usados anteriormente.
    ''' </summary>
    Private Sub LeerConfig()
        Dim cfg = New gsColorearNET.Config(ficheroConfiguracion)

        ' Si cargarUltimo es falso no asignar el último fichero     (16/Sep/20)
        cargarUltimo = cfg.GetValue("Ficheros", "CargarUltimo", False)
        If cargarUltimo Then
            nombreUltimoFichero = cfg.GetValue("Ficheros", "Ultimo", "")
        Else
            nombreUltimoFichero = ""
        End If
        comboLenguajes.Text = cfg.GetValue("Herramientas", "Lenguaje", "VB")
        If comboLenguajes.Text = "VB" Then
            buttonLenguaje.Image = buttonLenguaje.DropDownItems(0).Image
        Else
            buttonLenguaje.Image = buttonLenguaje.DropDownItems(1).Image
        End If
        colorearAlCargar = cfg.GetValue("Herramientas", "Colorear", False)

        ' El nombre y tamaño de la fuente                           (11/Sep/20)
        fuenteNombre = cfg.GetValue("Fuente", "Nombre", gsCol.FuentePre)
        fuenteTamaño = cfg.GetValue("Fuente", "Tamaño", gsCol.FuenteTamPre)
        labelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}"

        comboFuenteNombre.Text = fuenteNombre
        comboFuenteTamaño.Text = fuenteTamaño
        richTextBoxCodigo.Font = New Font(fuenteNombre, CSng(fuenteTamaño))

        ' El tamaño y la posición de la ventana
        tamForm.L = cfg.GetValue("Ventana", "Left", -1)
        tamForm.T = cfg.GetValue("Ventana", "Top", -1)
        tamForm.H = cfg.GetValue("Ventana", "Height", -1)
        tamForm.W = cfg.GetValue("Ventana", "Width", -1)

        If tamForm.L <> -1 Then Me.Left = tamForm.L
        If tamForm.T <> -1 Then Me.Top = tamForm.T
        If tamForm.H > -1 Then Me.Height = tamForm.H
        If tamForm.W > -1 Then Me.Width = tamForm.W

        ' Leer la lista de últimos ficheros
        Dim cuantos = cfg.GetValue("Ficheros", "Count", 0)
        colFics.Clear()
        For i = 0 To MaxFicsConfig - 1
            If i >= cuantos Then Exit For
            Dim s = cfg.GetValue("Ficheros", $"Fichero{i}", "-1")
            If s = "-1" Then Exit For
            colFics.Add(s)
        Next

        ' Los datos de configuración para buscar y reemplazar       (17/Sep/20)
        ' y valores de MatchCase, WholeWord
        buscarQueBuscar = cfg.GetValue("Buscar", "Buscar", "")
        buscarQueReemplazar = cfg.GetValue("Reemplazar", "Reemplazar", "")

        buscarMatchCase = cfg.GetValue("Buscar", "MatchCase", False)
        chkMatchCase.Checked = buscarMatchCase

        buscarWholeWord = cfg.GetValue("Buscar", "WholeWord", False)
        chkWholeWord.Checked = buscarWholeWord

        cuantos = cfg.GetValue("Buscar", "Buscar-Items-Count", 0)
        comboBuscar.Items.Clear()
        For i = 0 To BuscarMaxItems - 1
            If i >= cuantos Then Exit For
            Dim s = cfg.GetValue("Buscar", $"Buscar-Items{i}", "-1")
            If s = "-1" Then Exit For
            comboBuscar.Items.Add(s)
        Next
        cuantos = cfg.GetValue("Reemplazar", "Reemplazar-Items-Count", 0)
        comboReemplazar.Items.Clear()
        For i = 0 To BuscarMaxItems - 1
            If i >= cuantos Then Exit For
            Dim s = cfg.GetValue("Reemplazar", $"Reemplazar-Items{i}", "-1")
            If s = "-1" Then Exit For
            comboReemplazar.Items.Add(s)
        Next
        comboBuscar.Text = buscarQueBuscar
        comboReemplazar.Text = buscarQueReemplazar

        ' No mostrar el panel al iniciar
        'Dim mostrar = cfg.GetValue("Buscar", "MostrarPanel", False)
        MostrarPanelBuscar(False)

        ' Mostrar los 15 primeros en el menú Recientes
        AsignarRecientes()
    End Sub

    ''' <summary>
    ''' Asigna los ficheros al menú recientes
    ''' </summary>
    Private Sub AsignarRecientes()
        menuRecientes.DropDownItems.Clear()
        For i = 0 To MaxFicsMenu - 1
            If colFics.Count < (i + 1) Then Exit For

            Dim s = $"{i + 1} - {colFics(i)}"
            Dim m = New ToolStripMenuItem(s)
            AddHandler m.Click, Sub() AbrirReciente(m.Text)
            menuRecientes.DropDownItems.Add(m)
        Next
    End Sub

    ''' <summary>
    ''' Abre el fichero seleccionado del menú recientes
    ''' </summary>
    ''' <param name="fic">Path completo del fichero a abrir</param>
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
        If ficT = nombreUltimoFichero AndAlso TextoModificado = False Then Return

        If TextoModificado Then
            GuardarAs()
        End If
        nombreUltimoFichero = ficT
        Abrir(nombreUltimoFichero)
    End Sub

    ''' <summary>
    ''' Mostrar el código sin colorear
    ''' </summary>
    Private Sub NoColorear()
        Dim temp = TextoModificado
        Dim codigo = richTextBoxCodigo.Text

        richTextBoxCodigo.Rtf = ""
        richTextBoxCodigo.Text = codigo
        TextoModificado = temp
    End Sub

    ''' <summary>
    ''' Colorea el código en el editor.
    ''' Los lenguajes usados son Visual Basic y C#
    ''' </summary>
    Private Sub ColorearCodigo()
        Dim temp = TextoModificado
        Dim codigo = richTextBoxCodigo.Text

        ' Llamar directamente a gsColorear
        ' Le he puesto que use la fuente de la configuración,
        '   que NO asigne el CASE adecuado a las palabras claves,
        '   que indente con 4 espacios
        gsCol.Fuente = fuenteNombre
        gsCol.FuenteTam = fuenteTamaño
        Dim lang = gsDev.Lenguajes.VB
        If comboLenguajes.Text = "C#" Then
            lang = gsDev.Lenguajes.CS
        ElseIf comboLenguajes.Text = "VB" Then
            lang = gsDev.Lenguajes.VB
        Else
            lang = gsDev.Lenguajes.dotNet
        End If
        codigo = gsCol.ColorearCodigo(codigo,
                                      lang,
                                      gsCol.FormatosColoreado.RTF,
                                      asignarCase:=False,
                                      indentar:=4,
                                      quitarEspaciosIniciales:=False,
                                      gsCol.ComprobacionesRem.Todos)

        richTextBoxCodigo.Rtf = codigo

        TextoModificado = temp

    End Sub

    ''' <summary>
    ''' Borra la ventana de código y deja en blanco el <see cref="nombreUltimoFichero"/>.
    ''' Si se ha modificado el que había, pregunta si lo quieres guardar
    ''' </summary>
    Private Sub Nuevo()
        If TextoModificado Then GuardarAs()
        richTextBoxCodigo.Text = ""
        richTextBoxtFilas.Text = ""
        nombreUltimoFichero = ""
        TextoModificado = False
        labelInfo.Text = ""
        labelPos.Text = ""
        labelTamaño.Text = ""
        codigoAnterior = ""
    End Sub

    ''' <summary>
    ''' Muestra el cuadro de diálogo de Guardar como.
    ''' </summary>
    Private Sub GuardarAs()
        With New SaveFileDialog
            .FileName = nombreUltimoFichero
            .Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*"
            .RestoreDirectory = True
            .Title = "Selecciona el archivo a guardar"
            If .ShowDialog() = DialogResult.OK Then
                ' BUG: ¿faltaba esta asignación?                    (18/Sep/20)
                nombreUltimoFichero = .FileName
                Guardar(nombreUltimoFichero)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Guarda el fichero actual.
    ''' Si no tiene nombre muestra el diálogo de guardar como
    ''' </summary>
    Private Sub Guardar()
        If nombreUltimoFichero = "" Then
            GuardarAs()
            Return
        End If
        Guardar(nombreUltimoFichero)
    End Sub

    ''' <summary>
    ''' Guarda el fichero indicado en el parámetro
    ''' </summary>
    ''' <param name="fic">El path completo del fichero a guardar</param>
    Private Sub Guardar(fic As String)
        labelInfo.Text = $"Guardando {nombreUltimoFichero}..."

        Dim sCodigo = richTextBoxCodigo.Text
        Using sw As New StreamWriter(fic, append:=False, encoding:=Encoding.UTF8)
            sw.WriteLine(sCodigo)
        End Using
        codigoAnterior = sCodigo

        labelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})"
        labelTamaño.Text = $"{richTextBoxCodigo.Text.Length:#,##0} car."
        TextoModificado = False
        If colFics.Contains(fic) = False Then
            colFics.Add(fic)
        End If
        AsignarRecientes()

    End Sub

    ''' <summary>
    ''' Abre nuevamente el último fichero
    ''' desechando los datos realizados
    ''' </summary>
    Private Sub Recargar()
        If nombreUltimoFichero <> "" Then _
            Abrir(nombreUltimoFichero)
    End Sub

    ''' <summary>
    ''' Muestra el cuadro de diálogos de abrir ficheros
    ''' </summary>
    Private Sub Abrir()
        With New OpenFileDialog
            .FileName = nombreUltimoFichero
            .Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*"
            .Multiselect = False
            .RestoreDirectory = True
            .Title = "Selecciona el fichero a abrir"
            If .ShowDialog() = DialogResult.OK Then
                nombreUltimoFichero = .FileName
                Abrir(nombreUltimoFichero)
            End If
        End With
    End Sub

    ''' <summary>
    ''' Abre el fichero indicado en el parámetro
    ''' </summary>
    ''' <param name="fic">El path completo del fichero a abrir</param>
    Private Sub Abrir(fic As String)
        If Not File.Exists(fic) Then
            labelInfo.Text = $"No existe {fic}"
            Return
        End If

        labelInfo.Text = $"Cargando {fic}..."

        Dim sCodigo = ""
        Using sr As New StreamReader(fic, detectEncodingFromByteOrderMarks:=True, encoding:=Encoding.UTF8)
            sCodigo = sr.ReadToEnd()
        End Using
        codigoAnterior = sCodigo
        richTextBoxCodigo.Text = sCodigo
        mostrarPosicion(Nothing)

        If Path.GetExtension(fic).ToLower = ".cs" Then
            comboLenguajes.Text = "C#"
        ElseIf Path.GetExtension(fic).ToLower = ".vb" Then
            comboLenguajes.Text = "VB"
        Else
            If sCodigo.Contains(");") Then
                comboLenguajes.Text = "C#"
            ElseIf sCodigo.ToLower().Contains("end if") Then
                comboLenguajes.Text = "VB"
            Else
                comboLenguajes.Text = "dotnet"
            End If
        End If

        labelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})"
        labelTamaño.Text = $"{richTextBoxCodigo.Text.Length:#,##0} car."
        If colFics.Contains(nombreUltimoFichero) = False Then
            colFics.Add(nombreUltimoFichero)
        End If
        AsignarRecientes()
        If colorearAlCargar Then
            ColorearCodigo()
        End If
        TextoModificado = False
    End Sub

    ''' <summary>
    ''' Muestra la ventana informativa sobre esta utilidad
    ''' y las DLL que utiliza
    ''' </summary>
    Private Sub AcercaDe_Click(sender As Object, e As EventArgs)
        ' Añadir la versión de esta utilidad                        (15/Sep/20)
        Dim ensamblado As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location)
        'Dim vers = $" v{My.Application.Info.Version} ({fvi.FileVersion})"
        Dim versionAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyVersionAttribute), False)
        Dim vers = If(versionAttr.Length > 0,
                                (TryCast(versionAttr(0), System.Reflection.AssemblyVersionAttribute)).Version,
                                "1.0.0.0")
        Dim prodAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyProductAttribute), False)
        Dim producto = If(prodAttr.Length > 0,
                                (TryCast(prodAttr(0), System.Reflection.AssemblyProductAttribute)).Product,
                                "gsCompilarEjecutarNET")
        Dim descAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyDescriptionAttribute), False)
        Dim desc = If(descAttr.Length > 0,
                                (TryCast(descAttr(0), System.Reflection.AssemblyDescriptionAttribute)).Description,
                                "(para .NET 5.0 revisión del 16/Sep/2020)")
        desc = desc.Substring(desc.IndexOf("(para .NET"))


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

        Dim descL = "Utilidad para .NET 5.0 (.NET Core) para mostrar código en VB o C#, colorearlo y compilarlo."

        MessageBox.Show($"{producto} v{vers} ({fvi.FileVersion})" & vbCrLf & vbCrLf &
                        $"{descL}" & vbCrLf &
                        $"{desc}" & vbCrLf & vbCrLf &
                        "Usando las DLL externas:" & vbCrLf &
                        verColorear & vbCrLf & vbCrLf &
                        verCompilar,
                        $"Acerca de {producto}",
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RichTextBoxCodigo_KeyDown(sender As Object, e As KeyEventArgs)
        mostrarPosicion(e)
    End Sub

    ''' <summary>
    '''  Saber la línea y columna de la posición del cursor
    ''' </summary>
    Private Sub mostrarPosicion(e As KeyEventArgs)
        Dim pos As Integer = richTextBoxCodigo.SelectionStart + 1
        Dim lin As Integer = richTextBoxCodigo.GetLineFromCharIndex(pos) + 1
        Dim col As Integer = pos - richTextBoxCodigo.GetFirstCharIndexOfCurrentLine()
        Dim fcol = richTextBoxCodigo.GetFirstCharIndexFromLine(lin - 1)
        If fcol = pos Then lin -= 1

        If e IsNot Nothing Then
            If e.KeyCode = Keys.Tab AndAlso e.Modifiers = Keys.Shift Then
                col = 1
            ElseIf e.KeyCode = Keys.Home Then
                col = 1
            End If
        End If

        labelPos.Text = $"Lín: {lin}  Car: {col}"
    End Sub

    Private Sub RichTextBoxCodigo_SelectionChanged(sender As Object, e As EventArgs)
        mostrarPosicion(Nothing)
    End Sub

    ''' <summary>
    ''' Compila y ejecuta el código actual.
    ''' Si se producen errores muestra la información con los errores.
    ''' </summary>
    Private Sub CompilarEjecutar()
        If TextoModificado Then
            GuardarAs()
        End If
        Dim filepath = nombreUltimoFichero
        labelInfo.Text = "Compilando y ejecutando el código..."
        Me.Refresh()

        ' Para VB no hay Preview, usar siempre Latest o Default
        '   en .NET 5.0 RC1 Default es la 16,
        '   puede que en otros compiladores haya que usar la 15.5,
        '   por eso es mejor usar Latest
        ' Asignar la versión Preview o Latest para C#
        '   en .NET 5.0 RC1 Default es la 9.0
        If comboLenguajes.Text = "VB" Then
            Compilar.LanguageVersionVB = Microsoft.CodeAnalysis.VisualBasic.LanguageVersion.Default
        Else
            ' poner opción para uar Latest, Default o Preview usará la 9.0 en .NET 5.0
            Compilar.LanguageVersionCS = Microsoft.CodeAnalysis.CSharp.LanguageVersion.Default
        End If

        Dim res = Compilar.CompilarRun(filepath, run:=True)
        labelInfo.Text = res

        MostrarErroresCompilar()

    End Sub

    ''' <summary>
    ''' Compilar el código sin ejecutar
    ''' </summary>
    Private Sub Build()
        If TextoModificado Then
            GuardarAs()
        End If
        Dim filepath = nombreUltimoFichero
        labelInfo.Text = "Compilando el código..."
        Me.Refresh()

        ' Para VB no hay Preview, usar siempre Latest o Default
        '   en .NET 5.0 RC1 Default es la 16,
        '   puede que en otros compiladores haya que usar la 15.5,
        '   por eso es mejor usar Latest
        ' Asignar la versión Preview o Latest para C#
        '   en .NET 5.0 RC1 Default es la 9.0
        If comboLenguajes.Text = "VB" Then
            Compilar.LanguageVersionVB = Microsoft.CodeAnalysis.VisualBasic.LanguageVersion.Default
        Else
            ' poner opción para uar Latest, Default o Preview usará la 9.0 en .NET 5.0
            Compilar.LanguageVersionCS = Microsoft.CodeAnalysis.CSharp.LanguageVersion.Default
        End If

        Dim res = Compilar.CompilarGuardar(filepath, run:=False)
        labelInfo.Text = res

        If res <> "" Then
            MessageBox.Show("Se ha compilado satisfactoriamente el código." & vbCrLf & vbCrLf &
                            $"Nombre de la DLL compilada:{vbCrLf}{res}",
                            "Compilar (Build)",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        MostrarErroresCompilar()
    End Sub

    ''' <summary>
    ''' Mostrar los errores al compilar, si es que los hay
    ''' </summary>
    Private Sub MostrarErroresCompilar()
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
