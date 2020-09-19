'------------------------------------------------------------------------------
' Clase definida en la biblioteca para .NET Standard 2.0            (10/Sep/20)
' Basada en gsColorear y gsColorearCore
'
'
#Region " Comentarios sobre las versiones anteriores a .NET Standard 2.0 "
'------------------------------------------------------------------------------
' Clase para colorear el c�digo                                     (27/Nov/05)
' Este c�digo lo ten�a antes en el formulario gsEditorVB
'
' Nota del 25/Ago/06:
' El problema del <pre> es que no usa <br> para el cambio de l�nea,
' por eso al copiar de una p�gina Web y pegarlo en un editor,
' suele pegarse como una sola l�nea y queda mal.
' Voy a probar haciendo ese cambio en el propio formulario que muestra
' el c�digo en lugar de en esta clase.
'
' Versi�n 1.0.3.n
' Revisiones:
'   3.11    31/Mar  Corregido bug en los \cf0\}\par
'   3.12    31/Mar  Se usa el <pre> de la configuraci�n
'   3.13    06/Abr  \viewkind4 puede terminar con \par
'
'   3.16    28/Jul  A�ado nuevas palabras a ~C#, VB y dotNet (y quito ASC y DESC)
'   3.18    28/Jul  Quito los espacios despu�s de color
'
' De la versi�n de VS2005
' 2018:
'   4.0     21/11   Uso el .NET 4.7.2
'   5.0     08/Dic  Modificaciones al colorear desde RTF
'   5.1     08/Dic  A�ado GO a SQL.txt
'
' De la versi�n de Vs2008
' 1.0.5.0   21/Nov/18   Compilado para .NET 4.7.2
' 1.0.6.0   05/Ene/19   A�ado un RichTextbox para usar con
'                       la funci�n ColorearCodigoRtf
'                       A�ado Infer a VB y dotnet
' 1.0.6.1   05/Ene/19   Quito el Form1 con el control RichTextBox
'
' 1.0.6.2   08/Ene/19   Para unificar VS2005 y VS2008
' 1.0.6.3   08/Ene/19   Hab�a que llamar a AsignarPalabrasClave
'                       Desde ColorearCodigo se comprueba si hay que llamarlo
'
' UTILIZAR solo la de VS2008
'
' 1.0.0.0   02/Sep/20   Compilada para .NET Core 5.0 
'           05/Sep/20   Lo cambio a .NET Core 3.1
' 1.0.0.1   09/Sep/20   Si hay comillas dobles despu�s de un comentario, 
'                       no colorear la cadena
' 1.0.0.2   10/Sep/20   A�ado colores oscuros (para el fondo oscuro)
'                       Con m�todos para indicar los 3 colores: (esto a�n no est�)
'                       Claro, Oscuro y Personalizado
'------------------------------------------------------------------------------
#End Region
'
' Versiones para .NET Standard 2.0
' 1.0.0.0   10/Sep/20   Compilada para .NET Standard 2.0
' 1.0.0.1   11/Sep/20   Cambio la funci�n Version
'                       La DLL debe estar compilada con nombre seguro
'                       al menos para que funcione en .NET Framework.
' Publicado en NuGet:
'   https://www.nuget.org/packages/gsColorearNET/#
' 1.0.0.2               Usando el paquete de NuGet no encuentra los archivos
'                       de las palabras claves.
'                       Las convierto en cadenas fijas.
' 1.0.0.3               La versi�n 1.0.0.3 no existe, pas� de la .2 a la .4
' 1.0.0.4 y .5          12/Sep/20   
'                       Definici�n del paquete para publicar en NuGet
'                       Mejoras en el c�digo para colorear desde RTF
' 1.0.0.6   13/Sep/20   Reviso el c�digo de todas las clases
'                       y donde puedo uso inferencia de tipos, quito los ByVal,
'                       declaro las variables lo m�s cerca de su uso
'                       y optimizo un poco el c�digo.
' 1.0.0.7   16/Sep/20   Cambio la funci�n vb.Split para que no quite
'                       las l�neas vac�as si no se indica expresamente.
' 1.0.0.8   17/Sep/20   Se quedaba alg�n \f0 al final del c�digo.
' 1.0.0.9               Ya no se quedaba el \f0 pero
'                       al colorear desde RTF a�ad�a l�neas en blanco de m�s.
' 1.0.0.10  18/Sep/20   A�ado init, record y with a las palabras clave de C#
'           19/Sep/20   A�ado when (de C# 8.0)
'
' �Guillermo 'guille' Som, 2005-2007, 2018-2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports vb = gsColorearNET.VBCompat
Imports System

Imports System.Text
Imports System.Text.RegularExpressions

' NOTA 26/Ago/2006
' ================
' Todas las clases que est�n en esta misma DLL
' deben estar dentro del mismo espacio de nombres
' con idea de que no haya conflictos con otras DLL.
'
' Defino gsColorearNET como RootNamespace

Imports gsc = gsColorearNET


Public NotInheritable Class Colorear

    ' Evitar crear instancias
    Private Sub New()
    End Sub

    ''' <summary>
    ''' Comprobaciones de los comentarios a colorear
    ''' </summary>
    ''' <remarks>
    ''' Los comentarios XML siempre se colorean
    ''' </remarks>
    <Flags()>
    Public Enum ComprobacionesRem As Byte
        ''' <summary>
        ''' Solo colorea los comentarios simples
        ''' </summary>
        Simple = 1
        ''' <summary>
        ''' Solo colorea los comentarios m�ltiples
        ''' </summary>
        Multiple = 2
        ''' <summary>
        ''' Colorea los comentarios simples y m�ltiples
        ''' </summary>
        Todos = 3
        ''' <summary>
        ''' No colorea los comentarios
        ''' </summary>
        Ninguno = 0
    End Enum

    ''' <summary>
    ''' Formatos en los que se puede colorear el c�digo
    ''' </summary>
    Public Enum FormatosColoreado
        ''' <summary>
        ''' Genera el c�digo coloreado en RTF
        ''' </summary>
        RTF
        ''' <summary>
        ''' Genera el c�digo coloreado en HTML
        ''' </summary>
        HTML
    End Enum

    ''' <summary>
    ''' El formato de salida a usar para el coloreado
    ''' </summary>
    Public Shared FormatoColoreado As FormatosColoreado = FormatosColoreado.HTML

    ' Si es HTML, por si se quiere incluir el Style             (26/Ago/06)
    ' al principio
    ''' <summary>
    ''' Si se usa style en lugar de font para los colores
    ''' </summary>
    Public Shared IncluirStyle As Boolean = True

    Private Shared lineaCompleta As String = ""
    Private Shared keyW As New PalabrasClave
    Private Shared lenguaje As Lenguajes = Lenguajes.dotNet
    Private Shared sintaxCase As Boolean

    ''' <summary>
    ''' Si se comprueba may�sculas / min�sculas
    ''' en las palabras clave.
    ''' </summary>
    Public Shared SyntaxCaseSensitive As Boolean

    ' Ni las comillas dobles ni los retornos se evaluar�n
    ' ya que se hacen por separado, por tanto no es necesario que est�n aqu�
    ' Ni algunos otros, as� que dejaremos los que sint�cticamente son v�lidos

    ''' <summary>
    ''' Los separadores de palabras
    ''' </summary>
    Public Shared ReadOnly Separadores As String = " ,;.:-<>\!@#$%&/()=?'[]*+^{}" & vbTab

    ''' <summary>
    ''' Los separadores a tener en cuenta para colorear mientras se escribe
    ''' </summary>
    Public Shared ReadOnly Separadores2 As String = " ,:-<>\/='*+^"

    '--------------------------------------------------------------------------
    ' Para el coloreo de instrucciones y salida en HTML             (27/Nov/05)
    '--------------------------------------------------------------------------
    ' Los colores y valores predeterminados                         (20/Oct/05)
    Public Const ColorInstruccionesPre As String = "&H0000FF"
    Public Const ColorComentariosPre As String = "&H008000"
    Public Const ColorDocXMLPre As String = "&H5C5C5C"
    Public Const ColorTextoPre As String = "&HB22222"

    ' Color de las clases en C#                                     (08/Feb/07)
    Public Const ColorClasesPre As String = "&H2B91AF"
    Public Const PreTagPre As String = "<pre>"

    ' Para colores oscuros                                          (10/Sep/20)
    Public Const ColorInstruccionesOscuroPre As String = "&H569cd6"
    Public Const ColorComentariosOscuroPre As String = "&H57a64a"
    Public Const ColorDocXMLOscuroPre As String = "&H57a64a"
    Public Const ColorTextoOscuroPre As String = "&Hd69d85"
    Public Const ColorClasesOscuroPre As String = "&H4EC980" ' 78 201 176
    Public Const PreTagOscuroPre As String = "<pre style=""background-color:black;color:#d2d2d2;font-size:medium;"">"

    Public Const PreFinTagPre As String = "</pre>"
    Public Const FuentePre As String = "Courier New"
    Public Const FuenteTamPre As String = "10"
    Public Const UsarSpanStylePre As Boolean = True
    Public Shared UsarSpanStyle As Boolean = UsarSpanStylePre
    '
    Private Shared _FuenteTam As String = FuenteTamPre
    ''' <summary>
    ''' Tama�o de la fuente
    ''' </summary>
    Public Shared Property FuenteTam() As String
        Get
            Return _FuenteTam
        End Get
        Set(value As String)
            _FuenteTam = value
        End Set
    End Property

    Private Shared _Fuente As String = FuentePre
    ''' <summary>
    ''' Nombre de la fuente
    ''' </summary>
    Public Shared Property Fuente() As String
        Get
            Return _Fuente
        End Get
        Set(value As String)
            _Fuente = value
        End Set
    End Property

    Private Shared _ColorInstrucciones As String = ColorInstruccionesPre
    ''' <summary>
    ''' El color de las instrucciones (azul)
    ''' El color para RTF es el \cf2
    ''' </summary>
    Public Shared Property ColorInstrucciones() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                Return _ColorInstrucciones.Substring(2)
            Else
                Dim r As Integer = CInt("&H" & vb.Mid(_ColorInstrucciones, 3, 2))
                Dim g As Integer = CInt("&H" & vb.Mid(_ColorInstrucciones, 5, 2))
                Dim b As Integer = CInt("&H" & vb.Mid(_ColorInstrucciones, 7, 2))
                Return String.Format("\red{0}\green{1}\blue{2}", r, g, b)
            End If
        End Get
        Set(value As String)
            If value.Substring(0, 1) = "&" Then
                _ColorInstrucciones = value
            Else
                _ColorInstrucciones = "&H" & value
            End If
        End Set
    End Property
    Private Shared ReadOnly Property fontBlue() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                If UsarSpanStyle Then
                    Return "<span style=""color:#" & ColorInstrucciones & """>"
                Else
                    Return "<font color=#" & ColorInstrucciones & ">"
                End If
            Else
                Return "\cf2 "
            End If
        End Get
    End Property

    Private Shared _ColorComentarios As String = ColorComentariosPre
    ''' <summary>
    ''' El color de los comentarios (verde)
    ''' El color para RTF es el \cf1
    ''' </summary>
    Public Shared Property ColorComentarios() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                Return _ColorComentarios.Substring(2)
            Else
                Dim r As Integer = CInt("&H" & vb.Mid(_ColorComentarios, 3, 2))
                Dim g As Integer = CInt("&H" & vb.Mid(_ColorComentarios, 5, 2))
                Dim b As Integer = CInt("&H" & vb.Mid(_ColorComentarios, 7, 2))
                Return String.Format("\red{0}\green{1}\blue{2}", r, g, b)
            End If
        End Get
        Set(value As String)
            If value.Substring(0, 1) = "&" Then
                _ColorComentarios = value
            Else
                _ColorComentarios = "&H" & value
            End If
        End Set
    End Property
    Private Shared ReadOnly Property fontGreen() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                If UsarSpanStyle Then
                    Return "<span style=""color:#" & ColorComentarios & """>"
                Else
                    Return "<font color=#" & ColorComentarios & ">"
                End If
            Else
                Return "\cf1 "
            End If
        End Get
    End Property

    Private Shared _ColorDocXML As String = ColorDocXMLPre
    ''' <summary>
    ''' El color de los comentarios XML (gris)
    ''' El color para RTF es el \cf4
    ''' </summary>
    Public Shared Property ColorDocXML() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                Return _ColorDocXML.Substring(2)
            Else
                Dim r As Integer = CInt("&H" & vb.Mid(_ColorDocXML, 3, 2))
                Dim g As Integer = CInt("&H" & vb.Mid(_ColorDocXML, 5, 2))
                Dim b As Integer = CInt("&H" & vb.Mid(_ColorDocXML, 7, 2))
                Return String.Format("\red{0}\green{1}\blue{2}", r, g, b)
            End If
        End Get
        Set(value As String)
            If value.Substring(0, 1) = "&" Then
                _ColorDocXML = value
            Else
                _ColorDocXML = "&H" & value
            End If
        End Set
    End Property
    Private Shared ReadOnly Property fontGray() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                If UsarSpanStyle Then
                    Return "<span style=""color:#" & ColorDocXML & """>"
                Else
                    Return "<font color=#" & ColorDocXML & ">"
                End If
            Else
                Return "\cf4 "
            End If
        End Get
    End Property

    Private Shared _ColorTexto As String = ColorTextoPre
    ''' <summary>
    ''' El color de las cadenas entrecomilladas (rojo)
    ''' El color para RTF es el \cf3
    ''' </summary>
    Public Shared Property ColorTexto() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                Return _ColorTexto.Substring(2)
            Else
                Dim r As Integer = CInt("&H" & vb.Mid(_ColorTexto, 3, 2))
                Dim g As Integer = CInt("&H" & vb.Mid(_ColorTexto, 5, 2))
                Dim b As Integer = CInt("&H" & vb.Mid(_ColorTexto, 7, 2))
                Return String.Format("\red{0}\green{1}\blue{2}", r, g, b)
            End If
        End Get
        Set(value As String)
            If value.Substring(0, 1) = "&" Then
                _ColorTexto = value
            Else
                _ColorTexto = "&H" & value
            End If
        End Set
    End Property
    Private Shared ReadOnly Property fontRed() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                If UsarSpanStyle Then
                    Return "<span style=""color:#" & ColorTexto & """>"
                Else
                    Return "<font color=#" & ColorTexto & ">"
                End If
            Else
                Return "\cf3 "
            End If
        End Get
    End Property

    Private Shared _ColorClases As String = ColorClasesPre
    ''' <summary>
    ''' El color de las clases/tipos de C# (azul verdoso)
    ''' El color para RTF es el \cf5
    ''' </summary>
    ''' <remarks>08/Feb/2007</remarks>
    Public Shared Property ColorClases() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                Return _ColorClases.Substring(2)
            Else
                Dim r As Integer = CInt("&H" & vb.Mid(_ColorClases, 3, 2))
                Dim g As Integer = CInt("&H" & vb.Mid(_ColorClases, 5, 2))
                Dim b As Integer = CInt("&H" & vb.Mid(_ColorClases, 7, 2))
                Return String.Format("\red{0}\green{1}\blue{2}", r, g, b)
            End If
        End Get
        Set(value As String)
            If value.Substring(0, 1) = "&" Then
                _ColorClases = value
            Else
                _ColorClases = "&H" & value
            End If
        End Set
    End Property
    Private Shared ReadOnly Property fontVerdoso() As String
        Get
            If FormatoColoreado = FormatosColoreado.HTML Then
                If UsarSpanStyle Then
                    Return "<span style=""color:#" & ColorClases & """>"
                Else
                    Return "<font color=#" & ColorClases & ">"
                End If
            Else
                Return "\cf5 "
            End If
        End Get
    End Property

    Private Shared _PreTag As String = PreTagPre
    Public Shared Property PreTag() As String
        Get
            Return _PreTag
        End Get
        Set(value As String)
            _PreTag = value
        End Set
    End Property

    Private Shared _PreFinTag As String = PreFinTagPre
    ''' <summary>
    ''' El tag de final del c�digo.
    ''' De forma predeterminada es &lt;/pre&gt;
    ''' </summary>
    ''' <value>Cadena con el tag a asignar</value>
    ''' <remarks>
    ''' Este tag debe estar en consonancia con <seealso cref="PreTag">PreTag</seealso>
    ''' </remarks>
    Public Shared Property PreFinTag() As String
        Get
            Return _PreFinTag
        End Get
        Set(value As String)
            _PreFinTag = value
        End Set
    End Property

    Private Shared ReadOnly Property endFontTag() As String
        Get
            If FormatoColoreado = FormatosColoreado.RTF Then
                Return ""
            Else
                If UsarSpanStyle Then
                    Return "</span>"
                Else
                    Return "</font>"
                End If
            End If
        End Get
    End Property

    Public Shared ReadOnly Property FicRecursos As String = "<UsarRecurso>"

    Public Shared ReadOnly Property KeyWords() As PalabrasClave
        Get
            Return keyW
        End Get
    End Property

    ''' <summary>
    ''' Carga las palabras clave en la colecci�n
    ''' </summary>
    ''' <remarks>
    ''' Si el fichero de palabras no existe,
    ''' se usar�n las palabras definidas en el programa,
    ''' que pueden ser gen�ricas (dotnet), de C#, VB o Java
    ''' Rev. 30/Nov: 
    '''     A�ado: F# y SQL
    ''' Rev 18/Dic:
    '''     A�ado: VB6
    '''     Modifico el de CPP
    ''' </remarks>
    Public Shared Sub AsignarPalabrasClave()
        ' Eliminar todas las instrucciones
        Colorear.KeyWords.Clear()

        ' En principio usar las instrucciones de los recursos   (26/Nov/05)
        For Each le As Lenguajes In System.Enum.GetValues(GetType(Lenguajes))

            ' Seleccionar solo los que est�n en los recursos
            Dim palabras = LangKeyWords(le)

            If palabras IsNot Nothing Then
                Colorear.KeyWords.CargarPalabras(le, palabras)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Busca una palabra completa
    ''' </summary>
    ''' <param name="sep">Par�metro por referencia en el que se incluir� el separador hallado</param>
    ''' <returns>Devuelve la palabra hallada</returns>
    ''' <remarks>
    ''' En realidad busca cualquier cosa que est� entre separadores.
    ''' Si devuelve una cadena y el separador est� vac�o es que es la �ltima palabra.
    ''' Debe estar declarada la variable lineaCompleta,
    ''' que inicialmente tendr� el texto a examinar.
    ''' </remarks>
    Private Shared Function buscarToken(ByRef sep As String) As String
        ' Buscar cada token en el texto incluido en lineaCompleta
        ' Si empieza por separador, se devuelve "" y el separador
        ' sino, se devuelve el token y el separador que le sigue
        Dim res As String
        Dim i = lineaCompleta.IndexOfAny(Separadores.ToCharArray())
        If i > -1 Then
            ' Lo que haya hasta esa posici�n es un token
            ' salvo que sea la posici�n cero
            sep = lineaCompleta.Substring(i, 1)
            If i = 0 Then
                lineaCompleta = lineaCompleta.Substring(i + 1)
                Return ""
            End If
            res = lineaCompleta.Substring(0, i)
            lineaCompleta = lineaCompleta.Substring(i + 1)
            Return res
        Else
            ' No hay separador, devolver lo que queda de texto
            sep = ""
            res = lineaCompleta
            lineaCompleta = ""
            Return res
        End If
    End Function

    ''' <summary>
    ''' Convertir la cadena con formato RTF en coloreado con &lt;span...&gt;
    ''' </summary>
    ''' <param name="texto">
    ''' El texto con el formato RTF a convertir
    ''' </param>
    ''' <param name="indentar">
    ''' </param>
    ''' <param name="quitarEspaciosIniciales">
    ''' </param>
    ''' <returns>
    ''' La cadena &lt;pre&gt; coloreada
    ''' </returns>
    ''' <remarks>
    ''' 08/Feb/2007
    ''' El formato debe ser como el usado por el control RichText
    ''' en la segunda l�nea tendr� la info de los colores usados:
    ''' {\colortbl ;
    ''' \red128\green128\blue128; Gris
    ''' \red0\green128\blue0; Verde
    ''' \red0\green0\blue255; Azul
    ''' \red43\green145\blue175; Cian 
    ''' \red163\green21\blue21;} Rojo
    ''' Para no complicar las cosas, se usar�n esos mismos colores
    ''' creando la definici�n de esos colores y us�ndolos en los span
    ''' </remarks>
    Public Shared Function RTFaSPAN(texto As String, indentar As Integer, quitarEspaciosIniciales As Boolean) As String

        Dim sb As New StringBuilder
        ' Convertir los <, > & en c�digos HTML
        ' NO cambiar \fs para que est� en otra l�nea                (12/Sep/20)
        texto = texto.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;")

        Dim lineas() As String = texto.Split(vbCrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)

        ' La segunda l�nea ser� la definici�n de los colores
        Dim colores() As String
        Dim n As Integer = -1
        Dim j, k As Integer

        ' Usar expresiones regulares para buscar los colores
        Dim re As New Regex("(?<r>(\\red\d{1,3}))(?<g>(\\green\d{1,3}))(?<b>(\\blue\d{1,3}));")
        Dim mc As MatchCollection = re.Matches(texto)
        ReDim colores(0 To mc.Count)
        j = 1
        colores(0) = ""
        ' guardarlos en formato hexadecimal
        For Each m As Match In mc 're.Matches(texto)
            colores(j) = CInt(m.Groups("r").Value.Substring(4)).ToString("X2") &
                             CInt(m.Groups("g").Value.Substring(6)).ToString("X2") &
                             CInt(m.Groups("b").Value.Substring(5)).ToString("X2")
            j += 1
        Next

        ' Los colores 1 a colores.length -1 definen los colores     (12/Sep/20)
        '   \cf1 verde  (comentarios)
        '   \cf2 azul   (instrucciones)
        '   \cf3 rojo   (texto entre comillas)
        '   \cf4 gris   (comentarios XML)
        '   \cf5 cian   (tipos de C#)

        ' La primera l�nea v�lida contendr� \viewkind<n> y otros valores de RTF
        ' tambi�n incluir� la primera definici�n de color, si es que no es normal
        ' y con toda seguridad acabar� con \fsnn (el tama�o * 2 de la fuente)

        ' No s� el formato anterior, pero...                    (08/Dic/18)
        ' ahora se ve que es distinto:
        ' \viewkindN est� en una l�nea como esta:
        '{\*\generator Riched20 10.0.17134}\viewkind4\uc1 
        ' es decir, despu�s de \wiewkind4 termina con \uc1

        Dim bFinSpan As Boolean = False ' Si se ha puesto </span>

        For i = n + 1 To lineas.Length - 1
            If lineas(i).Contains("\rtf") Then
                Continue For
            End If
            If lineas(i).Contains("viewkind") Then
                ' Quitar todo lo que haya antes de \viewkind
                j = lineas(i).IndexOf("viewkind")
                lineas(i) = lineas(i).Substring(j + "wiewkindN".Length).TrimEnd()
            End If

            j = lineas(i).IndexOf("\uc")
            If j > -1 Then
                k = lineas(i).IndexOf(" ", j)
                If k > -1 Then
                    lineas(i) = lineas(i).Remove(j, k - j)
                ElseIf j > 0 Then
                    lineas(i) = lineas(i).Substring(0, j - 1)
                Else
                    lineas(i) = lineas(i).Substring(j + 4)
                End If
            End If
            If String.IsNullOrWhiteSpace(lineas(i)) Then
                Continue For
            End If
            ' Puede que tambi�n esto est� en l�nea diferente        (12/Sep/20)
            ' {\colortbl
            If lineas(i).TrimStart.Contains("{\colortbl") Then
                Continue For
            End If

            ' Buscar primero el \fs
            ' ya que en la misma l�nea puede haber c�digo
            k = lineas(i).IndexOf("\fs")
            Dim c As Integer
            If k > -1 Then
                j = lineas(i).IndexOf("\cf")

                ' Si tiene un color
                If j > -1 AndAlso j < k Then
                    c = CInt(lineas(i).Substring(j + 3, 1))
                    'sColores = colores(c)

                    ' Falla si \fs est� en una l�nea con c�digo     (12/Sep/20)
                    ' ya que puede haber una l�nea como:
                    '   End\cf3  \cf2 If\cf0\f2\fs17\par
                    '
                    ' Se deber�a corregir esto
                    ' ya que realmente no es correcto.

                    ' buscar \cf0 a partir del primer \cf
                    Dim p = lineas(i).IndexOf("\cf0", j)
                    ' si est� antes de \fs
                    If p > -1 AndAlso p < k Then
                        ' y p es mayor que j
                        ' tomar desde el principio hasta p
                        'If k - p > j Then
                        If p > j Then
                            lineas(i) = lineas(i).Substring(0, p)
                        End If
                    End If

                    ' El c�digo RTF debe terminar con "\fsnn "
                    j = lineas(i).IndexOf("\fs")
                    If j > -1 Then
                        k = lineas(i).IndexOf(" ", j)
                        ' Comprobar si k es -1                  (06/Abr/07)
                        ' Aunque si no hay un espacio es que acaba con \par
                        If k = -1 Then
                            k = lineas(i).IndexOf("\par", j)
                            ' Por si las moscas
                            If k = -1 Then
                                k = lineas(i).Length - 1
                            Else
                                k += "\par".Length - 1
                            End If
                        End If
                        lineas(i) = "\cf" & c.ToString & " " & lineas(i).Substring(k + 1)
                    End If

                Else
                    ' El c�digo RTF debe terminar con "\fsnn "
                    j = lineas(i).IndexOf("\fs")
                    k = lineas(i).IndexOf(" ", j)
                    ' Comprobar si k es -1                  (06/Abr/07)
                    ' Aunque si no hay un espacio es que acaba con \par
                    If k = -1 Then
                        k = lineas(i).IndexOf("\par", j)
                        ' Por si las moscas
                        If k = -1 Then
                            k = lineas(i).Length - 1
                        Else
                            k += "\par".Length - 1
                        End If
                    End If
                    lineas(i) = lineas(i).Substring(k + 1)
                End If
                ' Es posible que todo est� en una l�nea
                j = lineas(i).IndexOf("\pard\")
                If j = -1 Then
                    j = lineas(i).IndexOf("\lang")
                End If
                If j > -1 Then
                    lineas(i) = lineas(i).Substring(0, j)
                End If
            End If


            ' Comprobar si la l�nea tiene "\f1?\f0 "            (06/Dic/12)
            ' normalmente con las vocales acentuadas, e�es, etc.
            ' En ese caso, quitar el \f1 y el \f0 con el espacio
            ' Tambi�n me he encontrado l�neas con \f2           (12/Sep/20)
            lineas(i) = lineas(i).Replace("\f1", "") '.Replace("\f0 ", "") '.Replace("\f2", "")
            'lineas(i) = lineas(i).Replace("\f0 ", "")
            ' Las que no le siguen un espacio suelen estar al final (17/Sep/20)
            ' aqu� dejarlo con el espacio
            lineas(i) = lineas(i).Replace("\f0 ", "")

            ' Se supone que lineas(i) contiene lo que haya que colorear
            ' Dejar de analizar cuando se llegue a: \pard\
            ' Aunque puede que acabe con \lang...
            ' porque no haya un final de p�rrafo

            '--------------------------------------------------------------
            ' NOTA del 08/Dic/2018
            ' No s� c�mo ser�a antes el formato de RTF
            ' pero ahora despu�s de \lang hay texto v�lido
            ' Creo que \lang es: "\langN " donde N puede tener varias cifras
            ' pero seg�n parece finaliza con un espacio
            ' Y esa misma l�nea empieza con \pard\
            ' Por ejemplo: 
            ' Creado con TextPad
            '{\*\generator Riched20 10.0.17134}\viewkind4\uc1 
            '\pard\sl240\slmult1\qc\b\f0\fs48\lang9 Gesti\'f3n de Tickets de Venta\par
            ' o creado al pegar desde Visual Studio
            '{\*\generator Riched20 10.0.17134}\viewkind4\uc1 
            '\pard\cf1\f0\fs19\lang3082 '------------------------------------------------------------------------------\cf2\par
            '--------------------------------------------------------------

            ' Por tanto, si empieza con \pard\ y contiene \langN
            ' comprobar si hay \par al final y analizar la l�nea desde
            ' el espacio despu�s de \lang hasta el final
            If lineas(i).TrimStart().StartsWith("\pard\") AndAlso
                        lineas(i).Contains("\lang") Then
                j = lineas(i).IndexOf("\lang")
                k = lineas(i).IndexOf(" ", j)
                lineas(i) = lineas(i).Substring(k + 1)

            End If
            ' Esto es seguro
            If lineas(i).TrimStart().StartsWith("}") Then
                Exit For
            End If
            j = 0
            k = 0
            ' Quitar los \par y cambiarlos por un CrLf
            ' tambi�n los caracteres especiales \, { y }
            ' TODO: El problema es que se coloree una cadena con esos c�digos
            Dim s As String
            s = lineas(i).Replace("\par", vbCrLf) _
                              .Replace("\\", "\") _
                              .Replace("\{", "{") _
                              .Replace("\}", "}")

            ' Puede que haya letras acentuadas, etc. en el formato:
            ' \'NN siendo NN un valor hexa del car�cter
            Do
                k = s.IndexOf("\'")
                If k > -1 Then
                    c = CInt("&H" & s.Substring(k + 2, 2))
                    s = s.Replace("\'" & s.Substring(k + 2, 2), ChrW(c))
                Else
                    Exit Do
                End If
            Loop

            If s.Contains("\f2") Then
                s = s.Replace("\f2", " ")
            End If

            ' Reemplazar los colores por las etiquetas
            Do
                k = s.IndexOf("\cf", 0)
                If k > -1 Then
                    c = CInt(s.Substring(k + 3, 1))
                    sb.Append(s.Substring(0, k))
                    If bFinSpan Then
                        sb.Append("</span>")
                        bFinSpan = False
                    End If
                    If c > 0 Then
                        sb.AppendFormat("<span style='color:#{0}'>", colores(c))
                        bFinSpan = True
                    End If
                    If s.Length < k + 5 Then
                        s = ""
                    Else
                        ' Es posible que no haya espacio        (31/Mar/07)
                        ' despu�s del \cfN
                        If s(k + 4) <> " "c Then
                            s = s.Substring(k + 4)
                        Else
                            s = s.Substring(k + 5)
                        End If
                    End If
                Else
                    ' A�adir lo que resta
                    sb.Append(s)
                    s = ""
                End If
                If String.IsNullOrEmpty(s) Then
                    Exit Do
                End If
            Loop
        Next
        If bFinSpan Then
            sb.Append("</span>")
        End If
        ' Es posible que tenga \tab                                 (17/Abr/07)
        sb.Replace("\tab", vbTab)

        texto = sb.ToString

        ' Quitar el �ltimo \f0 por el final                         (18/Sep/20)
        j = texto.LastIndexOf("\f0")
        If j > -1 Then
            ' No se va a dar este caso, pero...
            If j = 0 Then
                texto = texto.Substring(j + 3)
            Else
                texto = texto.Substring(j - 1) & texto.Substring(j + 3)
            End If
        End If

        ' Quitar los espacios iniciales e indentarlo, si as� se indica
        ' El problema es que al tener los <span no lo hace bien
        ' particularmente con los comentarios
        If indentar > 0 OrElse quitarEspaciosIniciales Then
            ' Comprobar el lenguaje
            If texto.Contains("\\") Then
                Colorear.lenguaje = Lenguajes.CS
            ElseIf texto.Contains("End") Then
                Colorear.lenguaje = Lenguajes.VB
            End If
            texto = indentarQuitarEspacios(texto, indentar, quitarEspaciosIniciales)
        End If

        ' Incluir el <pre indicado en la configuraci�n          (31/Mar/07)
        Return PreTag & texto & "</pre>"
    End Function

    Public Shared Function RTFaSPAN(texto As String) As String
        Return RTFaSPAN(texto, 0, False)
    End Function

    ''' <summary>
    ''' Quitar los espacios iniciales y/o indentar
    ''' </summary>
    ''' <param name="texto">
    ''' El texto a procesar
    ''' </param>
    ''' <param name="indentar">
    ''' Valor entero con los espacios a indentar
    ''' Cero para no indentar
    ''' </param>
    ''' <param name="quitarEspaciosIniciales">
    ''' Valor verdadero o falso para quitar o no los espacios iniciales
    ''' </param>
    ''' <returns>
    ''' La cadena una vez procesada
    ''' </returns>
    ''' <remarks>
    ''' 08/Feb/2007
    ''' Para usar en varias funciones
    ''' </remarks>
    Private Shared Function indentarQuitarEspacios(texto As String,
                                                   indentar As Integer,
                                                   quitarEspaciosIniciales As Boolean) As String
        Dim saCodigo() As String = Nothing
        Dim s As String
        If indentar > 0 OrElse quitarEspaciosIniciales Then
            ' Es posible que solo tenga el vbLf
            If texto.IndexOf(vbCrLf) > -1 Then
                saCodigo = vb.Split(texto, vbCrLf)
            ElseIf texto.IndexOf(vbCr) > -1 Then
                saCodigo = vb.Split(texto, vbCr)
            Else
                saCodigo = vb.Split(texto, vbLf)
            End If
        End If

        If indentar > 0 Then
            ' Si se indenta hay que quitar los espacios iniciales
            quitarEspaciosIniciales = True

            ' Por si se quiere indentar al colorear
            If lenguaje = Lenguajes.CS OrElse lenguaje = Lenguajes.CPP Then
                gsc.Indentar.EsCSharp = True
            Else
                gsc.Indentar.EsCSharp = False
            End If
            gsc.Indentar.EspaciosIndent = indentar
            s = gsc.Indentar.ProcesarLineas(saCodigo)

            ' Es posible que solo tenga el vbLf
            If s.IndexOf(vbCrLf) > -1 Then
                ' Si tiene vbCrLf quitar las repetidas              (16/Sep/20)
                ' Y convertirlas en vbCr
                s = s.Replace(vbCrLf & vbCrLf, vbCr)
                saCodigo = vb.Split(s, vbCrLf, removeEmptyEnties:=False)
            ElseIf s.IndexOf(vbCr) > -1 Then
                saCodigo = vb.Split(s, vbCr)
            Else
                saCodigo = vb.Split(s, vbLf)
            End If

        End If
        ' Al llegar aqu�, si indentar > 0, siempre ser� True
        If quitarEspaciosIniciales Then
            ' Comprobar la cantidad de espacios de la primera l�nea (11/Dic/02)
            Dim sangria As Integer = -1
            ' Esto simplemente es para cambiar los tabs por espacios
            If indentar < 1 Then indentar = 4
            Dim UNTAB As String = New String(" "c, indentar)
            Dim s2 As String
            Dim n As Integer
            For i = 0 To saCodigo.Length - 1
                ' Convertir los tabuladores en "indentar" espacios
                ' Solo si indentar >0                               (26/Ago/06)
                If indentar > 0 Then
                    s = saCodigo(i).Replace(vbTab, UNTAB)
                Else
                    s = saCodigo(i)
                End If
                ' no es lo mismo Nothing que "",                    (29/Dic/02)
                ' y si s es Nothing no se puede comparar usando s.Trim
                If s = Nothing Then
                    s2 = ""
                Else
                    s2 = s.Trim
                End If
                ' Si es una l�nea vacia
                If s2 = "" Then
                    saCodigo(i) = s
                Else
                    ' Quitar la sangr�a inicial, pero dejar las siguientes indentaciones
                    ' (una vez quitados los espacios de la primera indentaci�n)
                    n = s.Length - s.TrimStart.Length
                    ' para saber si es la primera sangr�a
                    If sangria = -1 Then
                        sangria = n
                        n = 0
                    Else
                        ' Si ya est� procesado con los <span,   (08/Feb/07)
                        ' tener en cuenta las etiquets
                        If n = 0 AndAlso s.StartsWith("</span>") Then
                            n = s.Substring("</span>".Length).Length - s.Substring("</span>".Length).TrimStart.Length
                        End If
                        n -= sangria
                        ' por si hay alg�n bloque mal formado       (12/Jun/04)
                        If n < 0 Then n = 0
                    End If
                    If s.StartsWith("</span>") Then
                        s = "</span>" & New String(" "c, n) & s.Substring("</span>".Length).TrimStart
                    Else
                        s = New String(" "c, n) & s.TrimStart
                    End If

                    saCodigo(i) = s

                End If
            Next
            ' Convertir el array en una cadena
            texto = String.Join(vbLf, saCodigo).Trim
        End If

        Return texto
    End Function

    ''' <summary>
    ''' M�todo para colorear el c�digo
    ''' </summary>
    ''' <param name="texto">
    ''' El c�digo a colorear
    ''' </param>
    ''' <param name="leng">
    ''' El lenguaje para las instrucciones
    ''' </param>
    ''' <param name="formato">
    ''' Si se devolver� en formato RTF o HTML
    ''' </param>
    ''' <returns>
    ''' Devuelve el texto ya coloreado</returns>
    ''' <remarks>
    ''' El formato devuelto ser� RTF para mostrarlo en un RichTextBox en la propiedad Rtf
    ''' o en formato HTML entre tags &lt;pre&gt; para usar en una p�gina HTML.
    ''' </remarks>
    Public Shared Function ColorearCodigo(texto As String,
                                          leng As Lenguajes,
                                          formato As FormatosColoreado
                                          ) As String
        Return ColorearCodigo(texto, leng, formato, False, 0, False, ComprobacionesRem.Todos)
    End Function

    ''' <summary>
    ''' Colorea el texto indicado asign�ndolo a un control RichTexBox
    ''' y devuelve el contenido Rtf del control.
    ''' Y lo copia en el portapapeles.
    ''' 
    ''' 08/Ene/19
    ''' No se usa ni el form ni se copia en el portapapeles
    ''' </summary>
    ''' <remarks>05/Ene/2019 11:55</remarks>
    Public Shared Function ColorearCodigoRtf(texto As String,
                                             leng As Lenguajes,
                                             asignarcase As Boolean
                                             ) As String
        Return ColorearCodigo(texto, leng, FormatosColoreado.RTF, asignarcase)
    End Function

    ''' <summary>
    ''' M�todo para colorear el c�digo
    ''' </summary>
    ''' <param name="texto">
    ''' El c�digo a colorear
    ''' </param>
    ''' <param name="leng">
    ''' El lenguaje para las instrucciones
    ''' </param>
    ''' <param name="formato">
    ''' Si se devolver� en formato RTF o HTML
    ''' </param>
    ''' <param name="asignarCase">
    ''' Si se cambiar�n las palabras may�sculas/min�sculas del lenguaje
    ''' </param>
    ''' <returns>
    ''' Devuelve el texto ya coloreado</returns>
    ''' <remarks>
    ''' El formato devuelto ser� RTF para mostrarlo en un RichTextBox en la propiedad Rtf
    ''' o en formato HTML entre tags &lt;pre&gt; para usar en una p�gina HTML.
    ''' </remarks>
    Public Shared Function ColorearCodigo(texto As String,
                                          leng As Lenguajes,
                                          formato As FormatosColoreado,
                                          asignarCase As Boolean
                                          ) As String
        Return ColorearCodigo(texto, leng, formato, asignarCase, 0, False, ComprobacionesRem.Todos)
    End Function

    ''' <summary>
    ''' M�todo para colorear el c�digo
    ''' </summary>
    ''' <param name="texto">
    ''' El c�digo a colorear
    ''' </param>
    ''' <param name="leng">
    ''' El lenguaje para las instrucciones
    ''' </param>
    ''' <param name="formato">
    ''' Si se devolver� en formato RTF o HTML
    ''' </param>
    ''' <param name="asignarCase">
    ''' Si se cambiar�n las palabras may�sculas/min�sculas del lenguaje
    ''' </param>
    ''' <param name="indentar">
    ''' El n�mero de espacios para indentar autom�ticamente
    ''' Cero para no indentar</param>
    ''' <returns>Devuelve el texto ya coloreado</returns>
    ''' <remarks>
    ''' El formato devuelto ser� RTF para mostrarlo en un RichTextBox en la propiedad Rtf
    ''' o en formato HTML entre tags &lt;pre&gt; para usar en una p�gina HTML.
    ''' </remarks>
    Public Shared Function ColorearCodigo(texto As String,
                                          leng As Lenguajes,
                                          formato As FormatosColoreado,
                                          asignarCase As Boolean,
                                          indentar As Integer
                                          ) As String
        Return ColorearCodigo(texto, leng, formato, asignarCase, indentar, False, ComprobacionesRem.Todos)
    End Function

    ''' <summary>
    ''' M�todo para colorear el c�digo
    ''' </summary>
    ''' <param name="texto">
    ''' El c�digo a colorear
    ''' </param>
    ''' <param name="leng">
    ''' El lenguaje para las instrucciones
    ''' </param>
    ''' <param name="formato">
    ''' Si se devolver� en formato RTF o HTML
    ''' </param>
    ''' <param name="asignarCase">
    ''' Si se cambiar�n las palabras may�sculas/min�sculas del lenguaje
    ''' </param>
    ''' <param name="indentar">
    ''' El n�mero de espacios para indentar autom�ticamente
    ''' Cero para no indentar</param>
    ''' <param name="quitarEspaciosIniciales">
    ''' Si se deben quitar los espacios iniciales antes de colorear
    ''' </param>
    ''' <returns>Devuelve el texto ya coloreado</returns>
    ''' <remarks>
    ''' El formato devuelto ser� RTF para mostrarlo en un RichTextBox en la propiedad Rtf
    ''' o en formato HTML entre tags &lt;pre&gt; para usar en una p�gina HTML.
    ''' </remarks>
    Public Shared Function ColorearCodigo(texto As String,
                                          leng As Lenguajes,
                                          formato As FormatosColoreado,
                                          asignarCase As Boolean,
                                          indentar As Integer,
                                          quitarEspaciosIniciales As Boolean
                                          ) As String
        Return ColorearCodigo(texto, leng, formato, asignarCase, indentar, quitarEspaciosIniciales, ComprobacionesRem.Todos)
    End Function


    ''' <summary>
    ''' M�todo para colorear el c�digo
    ''' </summary>
    ''' <param name="texto">
    ''' El c�digo a colorear
    ''' </param>
    ''' <param name="leng">
    ''' El lenguaje para las instrucciones
    ''' </param>
    ''' <param name="formato">
    ''' Si se devolver� en formato RTF o HTML
    ''' </param>
    ''' <param name="asignarCase">
    ''' Si se cambiar�n las palabras may�sculas/min�sculas del lenguaje
    ''' </param>
    ''' <param name="indentar">
    ''' El n�mero de espacios para indentar autom�ticamente.
    ''' Cero para no indentar</param>
    ''' <param name="quitarEspaciosIniciales">
    ''' Si se deben quitar los espacios iniciales antes de colorear
    ''' </param>
    ''' <param name="coloreandoTodo">
    ''' Indica si se interpretan todos los comentarios
    ''' o solo los sencillos o m�ltiples
    ''' </param>
    ''' <returns>Devuelve el texto ya coloreado</returns>
    ''' <remarks>
    ''' El formato devuelto ser� RTF para mostrarlo en un RichTextBox en la propiedad Rtf
    ''' o en formato HTML entre tags &lt;pre&gt; para usar en una p�gina HTML.
    ''' </remarks>
    Public Shared Function ColorearCodigo(texto As String,
                                          leng As Lenguajes,
                                          formato As FormatosColoreado,
                                          asignarCase As Boolean,
                                          indentar As Integer,
                                          quitarEspaciosIniciales As Boolean,
                                          coloreandoTodo As ComprobacionesRem
                                          ) As String
        FormatoColoreado = formato
        lenguaje = leng
        sintaxCase = asignarCase

        ' Comprobar si las palabras claves est�n asignadas      (08/Ene/19)
        ' porque eso era lo que me fallaba...
        ' que no estaban asignadas
        If keyW.CountAll = 0 Then
            AsignarPalabrasClave()
        End If

        ' Si es XML usar la clase para procesar el texto        (28/Ago/06)
        If leng = Lenguajes.XML Then
            ' Solo colorear usando HTML                         (29/Ago/06)
            If formato = FormatosColoreado.HTML Then
                ColorearXML.FormatoColoreado = FormatosColoreado.HTML
                Return ColorearXML.ColorearXml(texto)
            Else
                ' Si es RTF devolver el texto tal cual          (29/Ago/06)
                'Return texto
                ' A ver si lo colorea bien                      (17/Nov/06)
                ColorearXML.FormatoColoreado = FormatosColoreado.RTF
                Return ColorearXML.ColorearXml(texto)
            End If
        End If

        texto = indentarQuitarEspacios(texto, indentar, quitarEspaciosIniciales)

        '------------------------------------------------------------------
        ' Formatear el texto para crearlo en formato RTF o HTML
        '------------------------------------------------------------------
        ' Este sistema es m�s r�pido que la comprobaci�n de cada palabra
        '------------------------------------------------------------------
        ' Los colores son:
        '   \cf0 el normal
        '   \cf1 verde  (comentarios)
        '   \cf2 azul   (instrucciones)
        '   \cf3 rojo   (texto entre comillas)
        '   \cf4 gris   (comentarios XML)
        '   \cf5 cian   (tipos de C#)
        ' Despu�s de cada \cf? va un espacio
        ' Cada l�nea acabar� con \cf0\par

        Dim sbRtf As New StringBuilder

        If formato = FormatosColoreado.RTF Then
            ' Cabecera del fichero RTF
            sbRtf.AppendFormat("{{\rtf1\ansi\ansicpg1252\deff0{{\fonttbl{{\f0\fnil\fcharset0 {0};}}}}", Fuente)
            sbRtf.Append(vbCrLf)
            ' Definici�n de los colores a usar
            ' Incluir el color para las clases/tipos de C#      (08/Feb/07)
            sbRtf.AppendFormat("{{\colortbl ;{0};{1};{2};{3};{4};}}",
                            ColorComentarios, ColorInstrucciones, ColorTexto, ColorDocXML, ColorClases)
            sbRtf.Append(vbCrLf)

            ' Esto el SaveFile del RichControl no lo guarda         (27/Nov/05)
            'sbRtf.AppendFormat("{{\*\generator {0} {1};}}", My.Application.Info.Title, My.Application.Info.Version)

            ' Ni idea de que es esto, pero...
            '------------------------------------------------------------------
            ' \viewkind4 es el estilo de visi�n del documento 4 = normal
            ' \pard Resets to default paragraph properties.
            ' Para m�s info del formato RTF_ http://www.biblioscape.com/rtf15_spec.htm
            '------------------------------------------------------------------
            sbRtf.AppendFormat("\viewkind4\uc1\pard\lang3082\f0\fs{0} ", CInt(FuenteTam) * 2)
        Else
            If IncluirStyle Then
                'sbRtf.AppendFormat("<style>pre{{font-family:{0}; font-size:{1}.0pt;}}</style>{2}", Fuente, FuenteTam, vbCrLf)
                sbRtf.AppendFormat("<style>pre{{font-family:{0}; font-size:{1}.0pt;}}", Fuente, FuenteTam)
                sbRtf.AppendFormat("p.Code{{font-family:{0}; font-size:{1}.0pt;}}", "Fixedsys", "9")
                sbRtf.AppendFormat("</style>{0}", vbCrLf)
            End If
            sbRtf.Append(PreTag)
        End If
        '
        Dim arCod() As String
        '
        ' Si el lenguaje es Ninguno, no hacer nada              (16/Dic/05) 0.40822
        ' salvo usar el tipo de letra indicado.
        If lenguaje = Lenguajes.Ninguno Then
            If formato = FormatosColoreado.RTF Then
                ' En RTF no basta con a�adir el texto...
                arCod = texto.Split(vbCrLf.ToCharArray)
                For i1 As Integer = 0 To arCod.Length - 2
                    sbRtf.AppendFormat("{0}\cf0\par{1}", arCod(i1).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"), vbCrLf)
                Next
                sbRtf.Append(arCod(arCod.Length - 1).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                ' Acaba con } y un valor nulo (Chrw(0))
                sbRtf.Append("}")
                sbRtf.Append(ChrW(0))
            Else
                sbRtf.Append(texto.Replace("<", "&lt;").Replace(">", "&gt;"))
                sbRtf.Append(PreFinTag)
            End If
            Return sbRtf.ToString()
        End If
        '
        ' Si hay dobles comillas dobles primero las quitamos,
        ' cambi�ndolas por un texto que no incluya separadores,
        ' y que aqu� no uso directamente, por si coloreo este c�digo,
        ' Chrw(113) = q
        ' Cuando es SQL las dobles comillas simples,            (16/Ene/07)
        ' cambiarlas por texto que despu�s reemplazaremos
        ' Chrw(115) = s
        If formato = FormatosColoreado.RTF Then
            If lenguaje = Lenguajes.SQL Then
                arCod = texto.Replace(ChrW(34) & ChrW(34), ChrW(113) & "uotquot") _
                                 .Replace(ChrW(39) & ChrW(39), ChrW(115) & "uotsuot") _
                                 .Split(vbCrLf.ToCharArray)
            Else
                arCod = texto.Replace(ChrW(34) & ChrW(34), ChrW(113) & "uotquot").Split(vbCrLf.ToCharArray)
            End If
        Else
            If lenguaje = Lenguajes.SQL Then
                arCod = texto.Replace(ChrW(34) & ChrW(34), ChrW(113) & "uotquot") _
                                 .Replace(ChrW(39) & ChrW(39), ChrW(115) & "uotsuot") _
                                 .Replace("<", "&lt;").Replace(">", "&gt;") _
                                 .Split(vbCrLf.ToCharArray)
            Else
                arCod = texto.Replace(ChrW(34) & ChrW(34), ChrW(113) & "uotquot") _
                                 .Replace("<", "&lt;").Replace(">", "&gt;") _
                                 .Split(vbCrLf.ToCharArray)
            End If
        End If
        Static esRemMult As Boolean '= False
        Static lineaAnt As String = ""
        If coloreandoTodo = ComprobacionesRem.Todos Then
            esRemMult = False
        End If
        ' Para controlar las l�neas m�ltiples entre comillas    (16/Ene/07)
        Dim esMultipleTextoSQL = False
        For i1 As Integer = 0 To arCod.Length - 1
            ' Por si la �ltima l�nea est� en blanco             (16/Dic/05) 0.40824
            ' que no a�ada un retorno extra ---------------------v
            If (arCod(i1) = Nothing OrElse arCod(i1).Length = 0) AndAlso (i1 < arCod.Length - 1) Then
                If formato = FormatosColoreado.RTF Then
                    sbRtf.AppendFormat("\cf0\par{0}", vbCrLf)
                Else
                    sbRtf.AppendFormat("{0}", vbCrLf)
                End If
                Continue For
            End If
            Dim j As Integer '= 0
            Dim arTexto() As String
            Dim esTextoSQL As Boolean = False
            ' Si hay "blancos" al principio, no procesarlos,
            ' as� nos ahorramos comprobar cada uno de los caracteres
            ' que haya al principio, me imagino que algo m�s r�pido ir�.

            ' Creo que esto hace efectos raros                  (14/Abr/06)
            ' al menos en los comentarios m�ltiples

            j = 0
            If j > 0 Then
                If formato = FormatosColoreado.RTF Then
                    sbRtf.Append(arCod(i1).Substring(0, j).Replace(vbTab, "\tab"))
                Else
                    sbRtf.Append(arCod(i1).Substring(0, j))
                End If
                ' Si hay comillas en comentarios m�ltiples      (21/Dic/05) 0.40848
                ' (cuando tiene espacios delante)
                If esRemMult Then
                    ReDim arTexto(0)
                    arTexto(0) = arCod(i1)
                    ' Para quitar el flag                       (14/Abr/06)
                    esRemMult = False
                Else
                    ' Si es SQL se usar�n comillas simples      (15/Dic/05) 0.40806
                    ' para las cadenas.
                    If lenguaje = Lenguajes.SQL Then
                        arTexto = arCod(i1).Substring(j).Split("'"c)
                        ' En SQL puede empezar la l�nea por comilla (01/Abr/06)
                        If arCod(i1).Substring(j, 1) = "'" Then
                            esTextoSQL = True
                        Else
                            esTextoSQL = False
                        End If
                    Else
                        arTexto = arCod(i1).Substring(j).Split(ChrW(34))
                    End If
                End If
            Else
                ' Comprobar si es comentario                        (09/Sep/20)
                ' En ese caso, colorear como comentario
                ' pero no comprobar si hay comillas dobles
                Dim kRem = arCod(i1).TrimStart.IndexOf(PalabrasClave.ComentarioSimple1(lenguaje))

                If kRem > -1 Then
                    ReDim arTexto(0)
                    arTexto(0) = arCod(i1)
                Else
                    ' Si hay comillas en comentarios m�ltiples      (21/Dic/05) 0.40847
                    If esRemMult Then
                        ReDim arTexto(0)
                        arTexto(0) = arCod(i1)
                        ' Para quitar el flag                       (14/Abr/06)
                        ' Si se quita, no colorea los m�ltiples     (27/Ago/06)
                        'esRemMult = False
                    Else
                        ' Si es SQL se usar�n comillas simples      (15/Dic/05) 0.40806
                        ' para las cadenas
                        If lenguaje = Lenguajes.SQL Then
                            arTexto = arCod(i1).Split("'"c)
                            If arCod(i1).StartsWith("'") Then
                                esTextoSQL = True
                            Else
                                esTextoSQL = False
                            End If
                        Else
                            arTexto = arCod(i1).Split(ChrW(34))
                        End If
                    End If
                End If
            End If
            ' Las palabras entre comillas dobles
            ' El �ndice 0 ser� el texto hasta la primera comilla doble
            ' Las l�neas de �ndice impar ser�n las que van entre comillas dobles
            ' (el primer �ndice es el 0 que se considera par)
            ' (""""c) ' esto representa una comilla doble
            ' Pero es m�s evidente si usamos ChrW(34)

            If coloreandoTodo = ComprobacionesRem.Todos Then
                lineaAnt = ""
            End If
            Dim esRem As Boolean = False
            j = 0
            For i = 0 To arTexto.Length - 1
                If j = 0 Then
                    ' Si la l�nea est� vac�a es que hab�a comillas dobles seguidas
                    If arTexto(i) = Nothing AndAlso arTexto(i).Length = 0 Then
                        Continue For
                    End If

                    If lineaAnt <> "" Then
                        lineaCompleta = lineaAnt
                        lineaAnt = ""
                    Else
                        lineaCompleta = arTexto(i)
                    End If

                    ' Comprobar si hay comentarios XML          (27/Nov/05)
                    ' Esto solo ir� bien si est�n al principio,
                    ' es decir, que no haya c�digo delante.
                    ' Hay que comprobarlo antes de              (27/Ago/06)
                    ' los comentario m�ltiples.
                    Dim k = -1
                    If ((lenguaje And Lenguajes.CS) = Lenguajes.CS) Then
                        k = lineaCompleta.IndexOf("///")
                    ElseIf (((lenguaje And Lenguajes.VB) = Lenguajes.VB) OrElse lenguaje = Lenguajes.VB6) Then
                        ' Comprobar si hay de VB
                        k = lineaCompleta.IndexOf("'''")
                    End If
                    If k > -1 Then
                        If k > 0 Then
                            sbRtf.Append(lineaCompleta.Substring(0, k))
                            If formato = FormatosColoreado.RTF Then
                                sbRtf.AppendFormat("\cf4 {0}", lineaCompleta.Substring(k).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                            Else
                                sbRtf.AppendFormat("{0}{1}{2}", fontGray, lineaCompleta.Substring(k), endFontTag)
                            End If
                        Else
                            If formato = FormatosColoreado.RTF Then
                                sbRtf.AppendFormat("\cf4 {0}", lineaCompleta.Substring(0).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                            Else
                                sbRtf.AppendFormat("{0}{1}{2}", fontGray, lineaCompleta.Substring(0), endFontTag)
                            End If
                        End If
                        ' Poner el flag de comentario m�ltiple  (14/Abr/06)
                        ' ���NOOOO!!!                           (27/Ago/06)
                        ' Ya que cada l�nea de documentaci�n XML acaba
                        ' en la misma l�nea
                        'esRemMult = True
                        Continue For
                    End If

                    Dim remMult As String

                    ' Puede que sea un comentario despu�s de comillas dobles
                    ' o que toda la l�nea sea un comentario
                    If esRem Then
                        If formato = FormatosColoreado.RTF Then
                            sbRtf.AppendFormat("\cf1 {0}", lineaCompleta.Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                        Else
                            sbRtf.AppendFormat("{0}{2}{1}", fontGreen, endFontTag, lineaCompleta) '.Substring(0))
                        End If
                        ' Mientras est� analizando una l�nea
                        ' y era un comentario, no quitar la "marca"
                        'esRem = False

                        ' Puede tener el finalizador de         (13/Dic/05)
                        ' rem m�ltiple
                        If esRemMult = False Then Continue For

                        Dim k1 = -1
                        remMult = PalabrasClave.CommentMult1(lenguaje, PalabrasClave.RemMFin)
                        If remMult <> "" Then
                            k1 = lineaCompleta.IndexOf(remMult)
                        End If
                        If k1 = -1 Then
                            remMult = PalabrasClave.CommentMult2(lenguaje, PalabrasClave.RemMFin)
                            If remMult <> "" Then
                                k1 = lineaCompleta.IndexOf(remMult)
                            End If
                        End If

                        If k1 > -1 Then
                            esRemMult = False
                            If j = 0 Then
                                j = 1
                            Else
                                j = 0
                            End If
                            Continue For
                        End If
                    End If

                    ' Comprobar si hay comentario m�ltiple      (27/Nov/05)

                    k = -1
                    If esRemMult = False AndAlso (coloreandoTodo And ComprobacionesRem.Multiple) = ComprobacionesRem.Multiple Then
                        remMult = PalabrasClave.CommentMult1(lenguaje, 0)
                        If remMult <> "" Then
                            k = lineaCompleta.IndexOf(remMult)
                        End If
                        If k = -1 Then
                            remMult = PalabrasClave.CommentMult2(lenguaje, 0)
                            If remMult <> "" Then
                                k = lineaCompleta.IndexOf(remMult)
                            End If
                        End If

                        If k > -1 Then
                            If k > 0 Then
                                ' Habr�a que comprobar el texto que hay delante del /*
                                lineaAnt = lineaCompleta.Substring(k)
                                lineaCompleta = lineaCompleta.Substring(0, k)
                            Else
                                Dim k1 As Integer = -1
                                remMult = PalabrasClave.CommentMult1(lenguaje, 1)
                                If remMult <> "" Then
                                    k1 = lineaCompleta.IndexOf(remMult)
                                End If
                                If k1 = -1 Then
                                    remMult = PalabrasClave.CommentMult2(lenguaje, 1)
                                    If remMult <> "" Then
                                        k1 = lineaCompleta.IndexOf(remMult)
                                    End If
                                End If

                                If k1 > -1 Then
                                    ' El comentario est� entre k y k1
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf1 {0}", lineaCompleta.Substring(k, k1 - k + remMult.Length).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                    Else
                                        sbRtf.AppendFormat("{0}{2}{1}", fontGreen, endFontTag, lineaCompleta.Substring(k, k1 - k + remMult.Length))
                                    End If
                                    lineaCompleta = lineaCompleta.Substring(k1 + remMult.Length)
                                    esRemMult = False
                                Else
                                    esRemMult = True
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf1 {0}", lineaCompleta.Substring(0).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                    Else
                                        sbRtf.AppendFormat("{0}{2}{1}", fontGreen, endFontTag, lineaCompleta.Substring(0))
                                    End If
                                    esRem = True
                                    ' Puede estar entre comillas(13/Dic/05)
                                    j = 1
                                    Continue For
                                End If
                            End If
                        End If
                    ElseIf (coloreandoTodo And ComprobacionesRem.Multiple) = ComprobacionesRem.Multiple Then
                        Dim k1 = -1
                        remMult = PalabrasClave.CommentMult1(lenguaje, 1)
                        If remMult <> "" Then
                            k1 = lineaCompleta.IndexOf(remMult)
                        End If
                        If k1 = -1 Then
                            remMult = PalabrasClave.CommentMult2(lenguaje, 1)
                            If remMult <> "" Then
                                k1 = lineaCompleta.IndexOf(remMult)
                            End If
                        End If

                        If k1 > -1 Then
                            esRemMult = False
                            esRem = False
                            If lineaCompleta.Length > k1 + remMult.Length Then
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf1 {0}", lineaCompleta.Substring(0, k1 + remMult.Length + 1).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                Else
                                    sbRtf.AppendFormat("{0}{1}{2}", fontGreen, lineaCompleta.Substring(0, k1 + remMult.Length + 1), endFontTag)
                                End If
                                lineaCompleta = lineaCompleta.Substring(k1 + remMult.Length)
                            Else
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf1 {0}", lineaCompleta)
                                Else
                                    sbRtf.AppendFormat("{0}{1}{2}", fontGreen, lineaCompleta, endFontTag)
                                End If
                                Continue For
                            End If
                        Else
                            If formato = FormatosColoreado.RTF Then
                                sbRtf.AppendFormat("\cf1 {0}", lineaCompleta.Substring(0).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                            Else
                                sbRtf.AppendFormat("{0}{1}{2}", fontGreen, lineaCompleta.Substring(0).Replace("\", "\\"), endFontTag)
                            End If
                            Continue For
                        End If
                    End If

                    ' Buscar cada token y comprobar si es una palabra clave
                    ' Tambi�n se comprobar�n los comentarios
                    Dim sep = " "
                    ' Para los comentarios de una l�nea de C#   (22/Nov/05)
                    Dim sepAnt = ""
                    esRem = False
                    While sep <> ""
                        Dim token = buscarToken(sep)
                        If token = "" AndAlso sep = "" Then Exit While
                        If token = "" AndAlso sep <> "" Then

                            ' Comprobar si hay {, } o \         (27/Nov/05)
                            ' en los comentarios de l�nea completa
                            If sep = "'" AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple _
                                AndAlso (((lenguaje And Lenguajes.VB) = Lenguajes.VB) OrElse lenguaje = Lenguajes.VB6) Then
                                ' Es un comentario de VB
                                ' A�adir lo que queda en la l�nea
                                ' En realidad hay que a�adir lo que resta en total,
                                ' pero hay que tener en cuenta cuales ir�an entre comillas
                                ' Al "trocear" lo que estaba entre comillas estar�
                                ' en los �ndices impares, porque empieza por cero
                                For i2 As Integer = i + 1 To arTexto.Length - 1
                                    If i2 Mod 2 = 0 Then
                                        lineaCompleta &= arTexto(i2)
                                    Else
                                        lineaCompleta &= ChrW(34) & arTexto(i2) & ChrW(34)
                                    End If
                                Next
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf1 '{0}", lineaCompleta.Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                Else
                                    sbRtf.AppendFormat("{0}'{1}{2}", fontGreen, lineaCompleta, endFontTag)
                                End If
                                esRem = True
                                lineaCompleta = ""
                                Exit For ' del bucle i
                            ElseIf (sep = "/" AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple _
                                AndAlso
                                (
                                    ((lenguaje And Lenguajes.CS) = Lenguajes.CS) _
                                    OrElse (lenguaje = Lenguajes.FSharp) _
                                    OrElse (lenguaje = Lenguajes.Java) _
                                    OrElse (lenguaje = Lenguajes.CPP) _
                                    OrElse (lenguaje = Lenguajes.Pascal) _
                                    OrElse (lenguaje = Lenguajes.IL)
                                )) _
                                OrElse ((lenguaje = Lenguajes.SQL AndAlso sep = "-") AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple) _
                                Then
                                ' Comentarios de una l�nea de C#, Java, F# o SQL
                                If sepAnt = "" Then
                                    sepAnt = sep
                                    Continue While
                                Else
                                    esRem = True
                                    For i2 As Integer = i + 1 To arTexto.Length - 1
                                        If i2 Mod 2 = 0 Then
                                            lineaCompleta &= arTexto(i2)
                                        Else
                                            lineaCompleta &= ChrW(34) & arTexto(i2) & ChrW(34)
                                        End If
                                    Next
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf1 {0}{0}{1}", sep, lineaCompleta.Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                    Else
                                        sbRtf.AppendFormat("{0}{1}{1}{2}{3}", fontGreen, sep, lineaCompleta, endFontTag)
                                    End If
                                    sepAnt = ""
                                    lineaCompleta = ""
                                    Exit For
                                End If
                            ElseIf (sepAnt = "/" AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple AndAlso
                                (
                                    ((lenguaje And Lenguajes.CS) = Lenguajes.CS) _
                                    OrElse (lenguaje = Lenguajes.FSharp) _
                                    OrElse (lenguaje = Lenguajes.Java) _
                                    OrElse (lenguaje = Lenguajes.CPP) _
                                    OrElse (lenguaje = Lenguajes.Pascal) _
                                    OrElse (lenguaje = Lenguajes.IL)
                                )) _
                                OrElse ((lenguaje = Lenguajes.SQL AndAlso sepAnt = "-") AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple) _
                                Then
                                ' Comentarios de una l�nea de C#, Java, F# o SQL
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf0 {0}", sepAnt)
                                Else
                                    sbRtf.AppendFormat("{0}", sepAnt)
                                End If
                                sepAnt = ""
                            End If
                            If sep = vbTab Then
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.Append("\tab")
                                Else
                                    sbRtf.Append("&nbsp;&nbsp;&nbsp;&nbsp;")
                                End If
                                ' {}\ son especiales en RTF     (24/Nov/05)
                            ElseIf formato = FormatosColoreado.RTF AndAlso (sep = "{" OrElse sep = "}" OrElse sep = "\") Then
                                sbRtf.AppendFormat("\cf0 \{0}", sep)
                            Else
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf0 {0}", sep)
                                Else
                                    sbRtf.AppendFormat("{0}", sep)
                                End If
                            End If
                        Else
                            ' Hay veces que se encuentra con un / (16/Nov/06)
                            ' pero no tiene el segundo, y cuando es C#
                            ' ese / se pierde...
                            If (sepAnt = "/" AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple _
                                AndAlso
                                (
                                    ((lenguaje And Lenguajes.CS) = Lenguajes.CS) _
                                    OrElse (lenguaje = Lenguajes.FSharp) _
                                    OrElse (lenguaje = Lenguajes.Java) _
                                    OrElse (lenguaje = Lenguajes.CPP) _
                                    OrElse (lenguaje = Lenguajes.Pascal) _
                                    OrElse (lenguaje = Lenguajes.IL)
                                )) _
                                OrElse ((lenguaje = Lenguajes.SQL AndAlso sepAnt = "-") AndAlso (coloreandoTodo And ComprobacionesRem.Simple) = ComprobacionesRem.Simple) _
                                Then
                                If sepAnt <> "" Then
                                    token = sepAnt & token
                                    sepAnt = ""
                                End If
                            End If

                            ' Comprobar si sep es {, } o \      (27/Nov/05)
                            ' Aunque parece que aqu� no se da
                            If formato = FormatosColoreado.RTF Then
                                If sep = "{" OrElse sep = "}" OrElse sep = "\" Then
                                    sep = "\" & sep
                                End If
                            End If

                            If sintaxCase Then
                                ' Si queremos convertir las palabras
                                ' a may�sculas y min�sculas seg�n se ha definido
                                If (PalabrasClave.CaseSensitive(lenguaje) AndAlso keyW.Contains(lenguaje, token)) _
                                    OrElse (PalabrasClave.CaseSensitive(lenguaje) = False AndAlso keyW.Contains(lenguaje, token.ToLower())) Then
                                    'If keyW.Contains(lenguaje, token.ToLower()) Then
                                    Dim palabra As PalabraClave
                                    If PalabrasClave.CaseSensitive(lenguaje) Then
                                        palabra = keyW.PalabraClave(lenguaje, token)
                                    Else
                                        palabra = keyW.PalabraClave(lenguaje, token.ToLower())
                                    End If
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf2 {0}\cf0 {1}", palabra.Instruccion, sep)
                                    Else
                                        sbRtf.AppendFormat("{2}{0}{3}{1}", palabra.Instruccion, sep, fontBlue, endFontTag)
                                    End If
                                Else
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf0 {0}{1}", token, sep)
                                    Else
                                        sbRtf.AppendFormat("{0}{1}", token, sep)
                                    End If
                                End If
                            Else
                                ' Si es case-sensitive          (15/Dic/05)
                                ' (sensible a may�sculas/min�sculas)
                                If (PalabrasClave.CaseSensitive(lenguaje) AndAlso keyW.Contains(lenguaje, token)) _
                                    OrElse (PalabrasClave.CaseSensitive(lenguaje) = False AndAlso keyW.Contains(lenguaje, token.ToLower())) Then
                                    If formato = FormatosColoreado.RTF Then
                                        sbRtf.AppendFormat("\cf2 {0}\cf0 {1}", token, sep)
                                    Else
                                        sbRtf.AppendFormat("{2}{0}{3}{1}", token, sep, fontBlue, endFontTag)
                                    End If
                                Else
                                    If formato = FormatosColoreado.RTF Then
                                        If esMultipleTextoSQL Then
                                            sbRtf.AppendFormat("\cf3 {0}{1}", token, sep)
                                        Else
                                            sbRtf.AppendFormat("\cf0 {0}{1}", token, sep)
                                        End If
                                        'sbRtf.AppendFormat("\cf0 {0}{1}", token, sep)
                                    Else
                                        sbRtf.AppendFormat("{0}{1}", token, sep)
                                    End If
                                End If
                            End If
                        End If
                    End While
                    j = 1
                Else
                    ' Esto va entre comillas dobles

                    ' Si la l�nea es una cadena vac�a,
                    ' es que era algo con doble comillas dobles
                    If arTexto(i) = "" Then
                        If i < arTexto.Length Then
                            If lenguaje = Lenguajes.SQL Then
                                ' En SQL se permiten m�ltiples  (31/Mar/06)
                                ' l�neas entre comillas
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.Append("\cf3 '")
                                    ' Para que no se siga a�adiendo el rojo
                                    esMultipleTextoSQL = False
                                Else
                                    'sbRtf.AppendFormat("{0}''", fontRed)
                                    If esTextoSQL = False Then
                                        sbRtf.AppendFormat("{0}'", fontRed)
                                        If esMultipleTextoSQL Then
                                            ' cerrar este tag y el anterior
                                            sbRtf.AppendFormat("{0}{0}", endFontTag)
                                        End If
                                    Else
                                        sbRtf.AppendFormat("{0}'{1}", fontRed, endFontTag)
                                    End If
                                    esMultipleTextoSQL = False
                                End If
                            Else
                                If formato = FormatosColoreado.RTF Then
                                    sbRtf.AppendFormat("\cf3 {0}{0}", ChrW(34))
                                Else
                                    sbRtf.AppendFormat("{1}{0}{0}", ChrW(34), fontRed)
                                End If
                            End If
                        End If
                    Else
                        ' Pero si hab�a un comentario, no colorearla,
                        ' aunque esta l�nea puede tener m�s c�digo al final.
                        If esRem = False Then
                            sbRtf.Append(fontRed)
                        Else
                            If formato = FormatosColoreado.HTML Then
                                sbRtf.Append(fontGreen)
                            End If
                        End If
                        ' TODO: 16/Ene/07
                        ' En SQL se permiten textos que ocupen varias l�neas
                        ' por tanto no se debe a�adir directamente la comilla de cierre
                        ' Solo deber�a cerrarse si el siguiente elemento del array
                        ' est� vac�o, pero si no hay m�s elementos, dejarla sin cerrar
                        If lenguaje = Lenguajes.SQL Then
                            If formato = FormatosColoreado.RTF Then
                                If arTexto.Length - 1 > i AndAlso vb.Len(arTexto(i + 1)) = 0 Then
                                    sbRtf.AppendFormat("'{0}'", arTexto(i).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                Else
                                    sbRtf.AppendFormat("'{0}", arTexto(i).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                                    ' Para que cierre el tag    (16/Ene/07)
                                    esMultipleTextoSQL = True
                                End If
                            Else
                                If arTexto.Length - 1 > i AndAlso vb.Len(arTexto(i + 1)) = 0 Then
                                    sbRtf.AppendFormat("'{0}'{1}", arTexto(i), endFontTag)
                                Else
                                    sbRtf.AppendFormat("'{0}", arTexto(i))
                                    ' Para que cierre el tag    (16/Ene/07)
                                    ' al encontrar el siguiente '
                                    esMultipleTextoSQL = True
                                End If
                            End If
                        Else
                            If formato = FormatosColoreado.RTF Then
                                sbRtf.AppendFormat("{0}{1}{0}", ChrW(34), arTexto(i).Replace("\", "\\").Replace("{", "\{").Replace("}", "\}"))
                            Else
                                sbRtf.AppendFormat("{0}{1}{0}{2}", ChrW(34), arTexto(i), endFontTag)
                            End If
                        End If
                    End If
                    j = 0
                End If
                If lineaAnt <> "" Then
                    j = 0
                    i -= 1
                ElseIf esRemMult Then
                    j = 0
                End If
            Next
            If i1 < arCod.Length - 1 Then
                If formato = FormatosColoreado.RTF Then
                    ' Aqu� cerrar el tag al color normal
                    ' el color rojo se a�ade en cada l�nea
                    sbRtf.AppendFormat("\cf0\par{0}", vbCrLf)
                Else
                    sbRtf.AppendFormat("{0}", vbCrLf)
                End If
            End If
        Next
        '
        If formato = FormatosColoreado.RTF Then
            ' Acaba con } y un valor nulo (Chrw(0))
            sbRtf.Append("}")
            sbRtf.Append(ChrW(0))
        Else
            sbRtf.Append("</pre>")
        End If
        If lenguaje = Lenguajes.SQL Then
            Return sbRtf.ToString().Replace(ChrW(113) & "uotquot", ChrW(34) & ChrW(34)) _
                                       .Replace(ChrW(115) & "uotsuot", ChrW(39) & ChrW(39))
        Else
            Return sbRtf.ToString().Replace(ChrW(113) & "uotquot", ChrW(34) & ChrW(34))
        End If
    End Function

    ''' <summary>
    ''' Devuelve la versi�n de la DLL.
    ''' Si completa es True, se devuelve tambi�n el nombre de la DLL:
    ''' gsColorearCore v 1.0.0.0 (para .NET Core 3.1 revisi�n del dd/MMM/yyyy)
    ''' </summary>
    Public Shared Function Version(Optional completa As Boolean = False) As String
        Dim res = ""
        Dim ensamblado = System.Reflection.Assembly.GetExecutingAssembly

        Dim versionAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyVersionAttribute), False)
        Dim vers = If(versionAttr.Length > 0, TryCast(versionAttr(0), System.Reflection.AssemblyVersionAttribute).Version,
                                              "1.0.0.0")
        Dim fileVerAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyFileVersionAttribute), False)
        Dim versF = If(fileVerAttr.Length > 0, TryCast(fileVerAttr(0), System.Reflection.AssemblyFileVersionAttribute).Version,
                                              "1.0.0.1")

        res = $"v {vers} ({versF})"

        If completa Then
            Dim prodAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyProductAttribute), False)
            Dim producto = If(prodAttr.Length > 0, TryCast(prodAttr(0), System.Reflection.AssemblyProductAttribute).Product,
                                                    "gsColorearNET")

            ' La descripci�n, tomar solo el final                   (11/Sep/20)
            Dim descAttr = ensamblado.GetCustomAttributes(GetType(System.Reflection.AssemblyDescriptionAttribute), False)
            Dim desc = If(descAttr.Length > 0, TryCast(descAttr(0), System.Reflection.AssemblyDescriptionAttribute).Description,
                                                "(para .NET Standard 2.0 revisi�n del 13/Sep/2020)")
            desc = desc.Substring(desc.IndexOf("(para .NET"))

            res = $"{producto} {res} {desc}"
        End If
        Return res
    End Function

End Class
