'------------------------------------------------------------------------------
' Punto de entrada de la aplicación de compilar y ejecutar
'
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
Option Strict On
Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms

Friend Module Program

    <STAThread()>
    Friend Sub Main(args As String())
        Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Try
            Application.Run(New Form1)
        Catch ex As Exception
            Debug.Assert(False, ex.Message)
        End Try

    End Sub

End Module
