/*
'------------------------------------------------------------------------------
' Punto de entrada de la aplicación de compilar y ejecutar
'
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gsCompilarEjecutarNET_cs
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
