'------------------------------------------------------------------------------
' Clase definida en la biblioteca para .NET Standard 2.0            (10/Sep/20)
' Basada en gsColorear y gsColorearCore
'
' M�todos de ayuda para las clases                                  (28/Ago/06)
'
' �Guillermo 'guille' Som, 2006, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
'Imports vb = Microsoft.VisualBasic
Imports System
'Imports System.Collections.Generic

''' <summary>
''' Utilidades varias
''' </summary>
Friend NotInheritable Class Utilidades

    ' No crear instancias de esta clase
    Private Sub New()
    End Sub
    '
    ' Este ser� el formato a usar para crear el n�mero de niveles en los pares
    ' el m�ximo por tanto es 10000 (de 0 a 9999), espero que sea suficiente!!!
    Friend Const formatoNivel As String = "0000"
    Friend Const lenFormato As Integer = 4
    '
    Friend Shared Function agruparPares(ByRef cod As String,
                                        simbolo As Char,
                                        parIni As String,
                                        Optional parFin As String = ""
                                        ) As String()
        ' cada palabra que est� entre los caracteres indicados,
        ' estar� en un �ndice del array,
        ' en la cadena original se sustituyen por [?nnn?], (? es el s�mbolo)
        ' donde nnn es el n�mero del �ndice del array
        ' (la cantidad de ns est� indicada en maxNiveles)
        ' En el simbolo es importante que no se usen caracteres repetidos...
        ' es decir si se usa @ para los par�ntesis, no usarlo para otra cosa,
        ' adem�s de que no se deber�an usar caracteres que despu�s se puedan usar.

        '' Si el parFin es [EOF] se procesar� desde parIni hasta fin de l�nea
        '' (esto es para los comentarios)
        Dim niveles() As String
        Dim s1 As String
        Dim sp1 = "s�" & simbolo
        Dim sp2 = simbolo & "�s"
        Dim i As Integer
        Dim j As Integer
        Dim n = -1
        ReDim niveles(0)

        If parFin = "" Then parFin = parIni

        ' Si son iguales, hay que hacerlo de otra forma...
        If parIni = parFin Then
            Do
                i = cod.IndexOf(parIni)
                If i > -1 Then
                    j = cod.IndexOf(parFin, i + 1)
                    If j > -1 Then
                        n = n + 1
                        ReDim Preserve niveles(n)
                        niveles(n) = cod.Substring(i, j - i + 1)
                        s1 = sp1 & n.ToString(formatoNivel) & sp2
                        ' quitar lo hallado
                        cod = cod.Remove(i, j - i + 1)
                        ' insertar la variable
                        cod = cod.Insert(i, s1)
                    Else
                        Exit Do
                    End If
                Else
                    Exit Do
                End If
            Loop
        Else
            Do
                ' Buscar el �ltimo
                i = cod.LastIndexOf(parIni)
                If i > -1 Then
                    ' buscar el siguiente
                    j = cod.IndexOf(parFin, i + 1)
                    ' si no est� el de cierre, se supone el final...
                    ' aunque se deber�a producir un error
                    If j = -1 Then
                        j = cod.Length
                        s1 = "Los pares indicados no est�n emparejados. Falta el del final." '& s
                        Throw New Exception(s1)
                        Exit Do
                    End If
                    n = n + 1
                    ReDim Preserve niveles(n)
                    niveles(n) = cod.Substring(i, j - i + parFin.Length)
                    s1 = sp1 & n.ToString(formatoNivel) & sp2
                    ' quitar lo hallado
                    cod = cod.Remove(i, j - i + parFin.Length)
                    ' insertar la variable
                    cod = cod.Insert(i, s1)
                Else
                    Exit Do
                End If
            Loop
        End If

        ' Si no se ha procesado nada, 
        ' asignar la cadena entera
        If niveles.Length = 1 AndAlso niveles(0) = "" Then
            niveles(0) = " "
        End If

        Return niveles
    End Function
    '
    Friend Shared Function reagruparPares(niveles() As String,
                                          s As String,
                                          simbolo As Char
                                          ) As String
        ' Devuelve la cadena con los caracteres que antes se agruparon
        Dim i As Integer
        Dim sp1 = "s�" & simbolo
        Dim sp2 = simbolo & "�s"

        Dim j = niveles.Length - 1
        For n = 0 To j
            If niveles(n) <> "" Then
                Dim sVar = sp1 & n.ToString(formatoNivel) & sp2
                ' Comprobar si esta variable est� en alguno de los elementos del array
                ' si es as�, sustituirla por el valor correspondiente
                For i = 0 To j
                    While (niveles(i).IndexOf(sVar) > -1 AndAlso i <> n)
                        niveles(i) = niveles(i).Replace(sVar, niveles(n))
                    End While
                Next
                s = s.Replace(sVar, niveles(n))
            End If
        Next

        Return s
    End Function

End Class
