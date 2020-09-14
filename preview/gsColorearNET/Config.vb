'------------------------------------------------------------------------------
' Clase definida en la biblioteca para .NET Standard 2.0            (10/Sep/20)
' Basada en gsColorear y gsColorearCore
'
' Clase para manejar ficheros de configuraci�n                      (15/Nov/05)
'
'
' Las secciones siempre estar�n dentro de <configuration>
' al menos as� lo guardar� esta clase, aunque permite leer pares key / value.
' Para que se sepa que se lee de configuration,
' en el c�digo se indica expl�citamente.
'
' Basada en mi c�digo publicado el 27/Feb/05 en:
' http://www.elguille.info/NET/dotnet/appSettings2.htm
' Pero para usarla de forma independiente de ConfigurationSettings
'
' Revisado para poder guardar autom�ticamente                       (21/Feb/06)
' Poder leer todas las secciones y las claves de una secci�n        (21/Feb/06)
'
' Nuevas sobrecargas de GetValue y SetValue para el tipo Double     (05/Sep/20)
' Nuevas sobrecargas de GetValue, SetValue y SetKeyValue            (10/Sep/20)
'   para el tipo System.Windows.Forms.CheckState
' .NET standard 2.0 no tiene la definci�n de CheckState             (11/Sep/20)
'   comento estas definiciones.
' Nueva sobrecarga de SetKeyValue para el tipo Double               (11/Sep/20)
'
'
' �Guillermo 'guille' Som, 2005-2006, 2020
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
'Imports vb = Microsoft.VisualBasic
Imports System

Imports System.Collections
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Xml
Imports System.IO


''' <summary>
''' Manejar ficheros de configuraci�n
''' </summary>
Public Class Config

    '----------------------------------------------------------------------
    ' Los campos y m�todos privados
    '----------------------------------------------------------------------
    Private Const configuration As String = "configuration/"
    Private configXml As New XmlDocument

    '
    ''' <summary>
    ''' Si se debe guardar autom�ticamente despu�s de asignar un valor.
    ''' </summary>
    ''' <value>Un valor de tipo Boolean</value>
    ''' <returns>Devuelve el valor actualmente asignado</returns>
    ''' <remarks>
    ''' Si no se guarda autom�ticamente hay que llamar
    ''' al m�todo Save para que se guarden en el fichero.
    ''' </remarks>
    Public Property GuardarAlAsignar() As Boolean = True

    ''' <summary>
    ''' Recupera el valor de la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <returns>
    ''' El contenido de la clave y secci�n.
    ''' </returns>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean
    ''' </remarks>
    Public Function GetValue(seccion As String, clave As String) As String
        Return GetValue(seccion, clave, "")
    End Function

    ''' <summary>
    ''' Recupera el valor de la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="predeterminado">
    ''' El valor predeterminado a devolver si no existe la clave.
    ''' </param>
    ''' <returns>
    ''' El contenido de la clave y secci�n.
    ''' El tipo devuelto depende del tipo del pr�metro predeterminado.
    ''' </returns>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean
    ''' </remarks>
    Public Function GetValue(seccion As String, clave As String, predeterminado As String) As String
        Return cfgGetValue(seccion, clave, predeterminado)
    End Function

    ''' <summary>
    ''' Recupera el valor de la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="predeterminado">
    ''' El valor predeterminado a devolver si no existe la clave.
    ''' </param>
    ''' <returns>
    ''' El contenido de la clave y secci�n.
    ''' El tipo devuelto depende del tipo del pr�metro predeterminado.
    ''' </returns>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean
    ''' </remarks>
    Public Function GetValue(seccion As String, clave As String, predeterminado As Integer) As Integer
        Return CInt(cfgGetValue(seccion, clave, predeterminado.ToString))
    End Function

    ''' <summary>
    ''' Recupera un valor de la calve y secci�n indicados, el valor devuelto es Double.
    ''' </summary>
    ''' <remarks>05/Sep/2020</remarks>
    Public Function GetValue(seccion As String, clave As String, predeterminado As Double) As Double
        Return CDbl(cfgGetValue(seccion, clave, predeterminado.ToString))
    End Function

    ''' <summary>
    ''' Recupera el valor de la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="predeterminado">
    ''' El valor predeterminado a devolver si no existe la clave.
    ''' </param>
    ''' <returns>
    ''' El contenido de la clave y secci�n.
    ''' El tipo devuelto depende del tipo del pr�metro predeterminado.
    ''' </returns>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' Cuando es Boolean, se guarda 1 � 0 seg�n sea True o False.
    ''' </remarks>
    Public Function GetValue(seccion As String, clave As String, predeterminado As Boolean) As Boolean
        Return If(cfgGetValue(seccion, clave, If(predeterminado, "1", "0")) = "1",
                    True, False)
    End Function

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' </remarks>
    Public Sub SetValue(seccion As String, clave As String, valor As String)
        cfgSetValue(seccion, clave, valor)
    End Sub

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' </remarks>
    Public Sub SetValue(seccion As String, clave As String, valor As Integer)
        cfgSetValue(seccion, clave, valor.ToString)
    End Sub

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados usando el valor Double.
    ''' </summary>
    ''' <remarks>05/Sep/20</remarks>
    Public Sub SetValue(seccion As String, clave As String, valor As Double)
        cfgSetValue(seccion, clave, valor.ToString)
    End Sub

    ''' <summary>
    ''' Asigna el valor Double en la clave y la secci�n indicados.
    ''' Usando atributos dentro de la secci�n.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">El valor a asignar</param>
    ''' <remarks>
    ''' 11/Sep/2020
    ''' </remarks>
    Public Sub SetKeyValue(seccion As String, clave As String, valor As Double)
        cfgSetKeyValue(seccion, clave, valor.ToString)
    End Sub

#Region " En .NET Standard 2.0 no hay definici�n de System.Windows.Forms.CheckState "

    '''' <summary>
    '''' Devuelve el valor del tipo System.Windows.Forms.CheckState
    '''' Los valores pueden ser: Checked, Unchecked, Indeterminate
    '''' </summary>
    '''' <remarks>10/Sep/2020</remarks>
    'Public Function GetValue(seccion As String, clave As String, predeterminado As System.Windows.Forms.CheckState) As System.Windows.Forms.CheckState
    '    Dim def As String = predeterminado.ToString
    '    def = cfgGetValue(seccion, clave, def)
    '    If def = "Checked" Then
    '        Return CheckState.Checked
    '    ElseIf def = "Unchecked" Then
    '        Return System.Windows.Forms.CheckState.Unchecked
    '    Else
    '        Return System.Windows.Forms.CheckState.Indeterminate
    '    End If
    'End Function

    '''' <summary>
    '''' Asigna el valor en la clave y secci�n indicados.
    '''' El tipo es System.Windows.Forms.CheckState
    '''' </summary>
    '''' <remarks>10/Sep/2020</remarks>
    'Public Sub SetValue(seccion As String, clave As String, valor As System.Windows.Forms.CheckState)
    '    cfgSetValue(seccion, clave, valor.ToString)
    'End Sub

    '''' <summary>
    '''' Asigna el valor en la clave y la secci�n indicados.
    '''' Usando atributos dentro de la secci�n.
    '''' El tipo es System.Windows.Forms.CheckState
    '''' </summary>
    '''' <remarks>10/Sep/2020</remarks>
    'Public Sub SetKeyValue(seccion As String, clave As String, valor As System.Windows.Forms.CheckState)
    '    cfgSetKeyValue(seccion, clave, valor.ToString)
    'End Sub
#End Region

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' Cuando es Boolean, se guarda 1 � 0 seg�n sea True o False.
    ''' </remarks>
    Public Sub SetValue(seccion As String, clave As String, valor As Boolean)
        cfgSetValue(seccion, clave, If(valor, "1", "0"))
    End Sub

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' Usando atributos dentro de la secci�n.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' </remarks>
    Public Sub SetKeyValue(seccion As String, clave As String, valor As String)
        cfgSetKeyValue(seccion, clave, valor)
    End Sub

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' Usando atributos dentro de la secci�n.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' </remarks>
    Public Sub SetKeyValue(seccion As String, clave As String, valor As Integer)
        cfgSetKeyValue(seccion, clave, valor.ToString)
    End Sub

    ''' <summary>
    ''' Asigna el valor en la clave y la secci�n indicados.
    ''' Usando atributos dentro de la secci�n.
    ''' </summary>
    ''' <param name="seccion">La secci�n</param>
    ''' <param name="clave">La clave dentro de la secci�n</param>
    ''' <param name="valor">
    ''' El valor a asignar.
    ''' </param>
    ''' <remarks>
    ''' Existen sobrecargas para los tipos String, Integer y Boolean.
    ''' Cuando es Boolean, se guarda 1 � 0 seg�n sea True o False.
    ''' </remarks>
    Public Sub SetKeyValue(seccion As String, clave As String, valor As Boolean)
        cfgSetValue(seccion, clave, If(valor, "1", "0"))
    End Sub

    ''' <summary>
    ''' Elimina la secci�n, en realidad la deja vac�a,
    ''' </summary>
    ''' <param name="seccion">La secci�n a eliminar</param>
    Public Sub RemoveSection(seccion As String)
        Dim n = configXml.SelectSingleNode(configuration & seccion)
        If n IsNot Nothing Then
            n.RemoveAll()
            If GuardarAlAsignar Then
                Me.Save()
            End If
        End If
    End Sub

    ''' <summary>
    ''' Devuelve una colecci�n con los nombres de las secciones.
    ''' </summary>
    ''' <returns>
    ''' Devuelve una colecci�n de tipo List(Of String)
    ''' con las secciones del fichero de configuraci�n.
    ''' </returns>
    Public Function Secciones() As List(Of String)
        Dim d As New List(Of String)
        Dim root = configXml.SelectSingleNode("configuration")
        If root IsNot Nothing Then
            For Each n As XmlNode In root.ChildNodes
                d.Add(n.Name)
            Next
        End If
        Return d
    End Function

    ''' <summary>
    ''' Devuelve una colecci�n con las claves de la secci�n indicada.
    ''' </summary>
    ''' <param name="seccion">
    ''' Secci�n de la que se quieren las claves
    ''' </param>
    ''' <returns>
    ''' Devuelve una colecci�n de tipo Dictionary(Of String, String)
    ''' con las claves de la secci�n indicada.
    ''' </returns>
    Public Function Claves(seccion As String) As Dictionary(Of String, String)
        Dim d As New Dictionary(Of String, String)
        seccion = seccion.Replace(" ", "_")
        Dim root = configXml.SelectSingleNode(configuration & seccion)
        If root IsNot Nothing Then
            For Each n As XmlNode In root.ChildNodes
                If d.ContainsKey(n.Name) = False Then
                    d.Add(n.Name, n.InnerText)
                End If
            Next
        End If
        Return d
    End Function

    ''' <summary>
    ''' Guardar los datos en el fichero de configuraci�n.
    ''' </summary>
    ''' <remarks>
    ''' Si no se llama a este m�todo, no se guardar� de forma permanente.
    ''' </remarks>
    Public Sub Save()
        configXml.Save(FileName)
    End Sub

    ''' <summary>
    ''' Lee el contenido del fichero de configuraci�n.
    ''' Si no existe, se crea uno nuevo
    ''' </summary>
    Public Sub Read()
        Dim fic = FileName
        Const revDate As String = "Sun, 13 Sep 2020 13:25:00 GMT"
        If File.Exists(fic) Then
            configXml.Load(fic)
            ' Actualizar los datos de la informaci�n de esta clase
            Dim b = GuardarAlAsignar
            GuardarAlAsignar = False
            Me.SetValue("configXml_Info", "info", "Generado con Config para Visual Basic 2005")
            Me.SetValue("configXml_Info", "revision", revDate)
            Me.SetValue("configXml_Info", "formatoUTF8", "El formato de este fichero debe ser UTF-8")
            GuardarAlAsignar = b
            Me.Save()
        Else
            ' Crear el XML de configuraci�n con la secci�n General
            Dim sb As New System.Text.StringBuilder
            sb.Append("<?xml version=""1.0"" encoding=""utf-8"" ?>")
            sb.Append("<configuration>")
            ' Por si es un fichero appSetting
            sb.Append("<configSections>")
            sb.Append("<section name=""General"" type=""System.Configuration.DictionarySectionHandler"" />")
            sb.Append("</configSections>")
            sb.Append("<General>")
            sb.Append("<!-- Los valores ir�n dentro del elemento indicado por la clave -->")
            sb.Append("<!-- Aunque tambi�n se podr�n indicar como pares key / value -->")
            sb.AppendFormat("<add key=""Revisi�n"" value=""{0}"" />", revDate)
            sb.Append("<!-- La clase siempre los a�ade como un elemento -->")
            sb.Append("<Copyright>�Guillermo 'guille' Som, 2005-2006</Copyright>")
            sb.Append("</General>")

            sb.AppendFormat("<configXml_Info>{0}", vbCrLf)
            sb.AppendFormat("<info>Generado con Config para Visual Basic 2005</info>{0}", vbCrLf)
            sb.AppendFormat("<copyright>�Guillermo 'guille' Som, 2005-2006</copyright>{0}", vbCrLf)
            sb.AppendFormat("<revision>{0}</revision>{1}", revDate, vbCrLf)
            sb.AppendFormat("<formatoUTF8>El formato de este fichero debe ser UTF-8</formatoUTF8>{0}", vbCrLf)
            sb.AppendFormat("</configXml_Info>{0}", vbCrLf)

            sb.Append("</configuration>")
            ' Asignamos la cadena al objeto
            configXml.LoadXml(sb.ToString)

            ' Guardamos el contenido de configXml y creamos el fichero
            configXml.Save(FileName)
        End If
    End Sub

    ''' <summary>
    ''' El nombre del fichero de configuraci�n.
    ''' </summary>
    ''' <value>El nuevo nombre a asignar.</value>
    ''' <returns>
    ''' Una cadena con el nombre del fichero de configuraci�n
    ''' </returns>
    ''' <remarks>
    ''' Al asignarlo, NO se lee el contenido del fichero,
    ''' habr� que llamar al m�todo <seealso cref="Read">Read</seealso>
    ''' </remarks>
    Public Property FileName() As String = ""

    ''' <summary>
    ''' Constructor indicando el nombre del fichero a usar.
    ''' </summary>
    ''' <param name="fic">Nombre del fichero a usar</param>
    Public Sub New(fic As String)
        FileName = fic
        ' Por defecto se guarda al asignar los valores
        GuardarAlAsignar = True
        Read()
    End Sub

    ''' <summary>
    ''' Constructor con el nombre del fichero y si se guarda al asignar
    ''' </summary>
    ''' <param name="fic">Nombre del fichero ausar</param>
    ''' <param name="guardarAlAsignar">
    ''' True si se guarda autom�ticamente al asignar,
    ''' ver <seealso cref="GuardarAlAsignar">GuardarAlAsignar</seealso>.
    ''' </param>
    Public Sub New(fic As String, guardarAlAsignar As Boolean)
        FileName = fic
        Me.GuardarAlAsignar = guardarAlAsignar
        Read()
    End Sub

    '
    '----------------------------------------------------------------------
    ' Los m�todos privados
    '----------------------------------------------------------------------
    '

    ' El m�todo interno para guardar los valores
    ' Este m�todo siempre guardar� en el formato <seccion><clave>valor</clave></seccion>
    Private Sub cfgSetValue(seccion As String, clave As String, valor As String)
        ' Filtrar los caracteres no v�lidos
        ' en principio solo comprobamos el espacio
        seccion = seccion.Replace(" ", "_")
        clave = clave.Replace(" ", "_")

        ' Se comrpueba si es un elemento de la secci�n:
        '   <seccion><clave>valor</clave></seccion>
        Dim n = configXml.SelectSingleNode(configuration & seccion & "/" & clave)
        If n IsNot Nothing Then
            n.InnerText = valor
        Else
            Dim elem As XmlElement
            Dim root = configXml.SelectSingleNode(configuration & seccion)
            If root Is Nothing Then
                ' Si no existe el elemento principal,
                ' lo a�adimos a <configuration>
                elem = configXml.CreateElement(seccion)
                configXml.DocumentElement.AppendChild(elem)
                root = configXml.SelectSingleNode(configuration & seccion)
            End If
            If root IsNot Nothing Then
                ' Crear el elemento
                elem = configXml.CreateElement(clave)
                elem.InnerText = valor
                ' A�adirlo al nodo indicado
                root.AppendChild(elem)
            End If
        End If

        If GuardarAlAsignar Then
            Me.Save()
        End If
    End Sub

    ' Asigna un atributo a una secci�n
    ' Por ejemplo: <Seccion clave=valor>...</Seccion>
    ' Tambi�n se usar� para el formato de appSettings: <add key=clave value=valor />
    '   Aunque en este caso, debe existir el elemento a asignar.
    Private Sub cfgSetKeyValue(seccion As String, clave As String, valor As String)
        ' Filtrar los caracteres no v�lidos
        ' en principio solo comprobamos el espacio
        seccion = seccion.Replace(" ", "_")
        clave = clave.Replace(" ", "_")

        Dim n = configXml.SelectSingleNode(configuration & seccion & "/add[@key=""" & clave & """]")
        If n IsNot Nothing Then
            n.Attributes("value").InnerText = valor
        Else
            Dim elem As XmlElement
            Dim root = configXml.SelectSingleNode(configuration & seccion)
            If root Is Nothing Then
                ' Si no existe el elemento principal,
                ' lo a�adimos a <configuration>
                elem = configXml.CreateElement(seccion)
                configXml.DocumentElement.AppendChild(elem)
                root = configXml.SelectSingleNode(configuration & seccion)
            End If
            If root IsNot Nothing Then
                Dim a As XmlAttribute = CType(configXml.CreateNode(XmlNodeType.Attribute, clave, Nothing), XmlAttribute)
                a.InnerText = valor
                root.Attributes.Append(a)
            End If
        End If

        If GuardarAlAsignar Then
            Me.Save()
        End If
    End Sub

    ' Devolver el valor de la clave indicada
    Private Function cfgGetValue(seccion As String, clave As String, valor As String) As String
        ' Filtrar los caracteres no v�lidos
        ' en principio solo comprobamos el espacio
        seccion = seccion.Replace(" ", "_")
        clave = clave.Replace(" ", "_")

        ' Primero comprobar si est�n el formato de appSettings: <add key = clave value = valor />
        Dim n = configXml.SelectSingleNode(configuration & seccion & "/add[@key=""" & clave & """]")
        If n IsNot Nothing Then
            Return n.Attributes("value").InnerText
        End If

        ' Despu�s se comprueba si est� en el formato <Seccion clave = valor>
        n = configXml.SelectSingleNode(configuration & seccion)
        If n IsNot Nothing Then
            Dim a As XmlAttribute = n.Attributes(clave)
            If a IsNot Nothing Then
                Return a.InnerText
            End If
        End If

        ' Por �ltimo se comprueba si es un elemento de seccion:
        '   <seccion><clave>valor</clave></seccion>
        n = configXml.SelectSingleNode(configuration & seccion & "/" & clave)
        If n IsNot Nothing Then
            Return n.InnerText
        End If

        ' Si no existe, se devuelve el valor predeterminado
        Return valor
    End Function
End Class
