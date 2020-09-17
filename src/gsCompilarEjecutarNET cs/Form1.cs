/*
'------------------------------------------------------------------------------
' gsCompilarEjecutarNET cs                                          (16/Sep/20)
' Utilidad para colorear, compilar y ejecutar código de VB o C#
' Versión usando código de C#
'
' Como aplicación para Windows Forms para .NET 5.0 Preview
'
' Esta aplicación utiliza estas dos DLL compiladas para .NET Standard y .NET Core 3.1
' gsColorearNET .NET Standard 2.0
' gsCompilarNET .NET Core 3.1
'
' (c) Guillermo (elGuille) Som, 2020
'------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//' La clase Colorear
using gsCol = gsColorearNET.Colorear;
//' El espacio de nombres que tiene la definición de Lenguajes
using gsDev = gsColorearNET;
//' La clase de Compilar
using gsCompilarNET;
using System.IO;

namespace gsCompilarEjecutarNET_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void RichTextBox_VScroll(object sender, EventArgs e)
        {
            int nPos = WinAPI.GetScrollPos(rtbCodigo.Handle, (int)WinAPI.ScrollBarType.SbVert);
            nPos <<= 16;
            long wParam = (int)WinAPI.ScrollBarCommands.SB_THUMBPOSITION | nPos;
            WinAPI.SendMessage(txtFilas.Handle, (long)WinAPI.Message.WM_VSCROLL, wParam, 0);
        }

        private (int L, int T, int H, int W) TamForm;
        private string fuenteNombre = gsCol.FuentePre;
        private string fuenteTamaño = gsCol.FuenteTamPre;
        private bool cargarUltimo;
        private bool colorearAlCargar;

        private bool inicializando = true;
        private string codigoNuevo;
        private string codigoAnt;

        private const int maxFicsMenu = 15;
        private const int maxFicsConfig = 100;
        private List<string> colFics = new List<string>();
        private string ficConfig;
        private string ultimoFic;

        private bool _TextoModificado = false;
        private bool TextoModificado
        {
            get
            {
                return _TextoModificado;
            }
            set
            {
                if (value)
                    LabelModificado.Text = "*";
                else
                    LabelModificado.Text = " ";

                _TextoModificado = value;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ficConfig = Path.Combine(Environment.CurrentDirectory, Application.ProductName + ".appconfig.txt");

            AñadirEventos();
            gsCol.AsignarPalabrasClave();

            LeerConfig();
            if (cargarUltimo)
                Abrir(ultimoFic);
            inicializando = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TextoModificado)
                GuardarAs();

            Form1_Resize(null, null);
            GuardarConfig();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (inicializando)
                return;

            if (this.WindowState == FormWindowState.Normal)
                TamForm = (this.Left, this.Top, this.Height, this.Width);
            else
                TamForm = (this.RestoreBounds.Left, this.RestoreBounds.Top,
                           this.RestoreBounds.Height, this.RestoreBounds.Width);
        }

        private void AñadirEventos()
        {
            CompilarMenu.ShortcutKeys = Keys.F5;
            ColorearMenu.ShortcutKeys = Keys.F6;
            NoColorearMenu.ShortcutKeys = Keys.F7;
            SelectAllMenu.ShortcutKeys = (Keys.Control | Keys.A);

            AboutMenu.Click += (object s, EventArgs e) => AcercaDe_Click(null, null);
            ExitMenu.Click += (object s, EventArgs e) => this.Close();
            OpenMenu.Click += (object s, EventArgs e) => Abrir();
            SaveMenu.Click += (object s, EventArgs e) => Guardar();
            SaveAsMenu.Click += (object s, EventArgs e) => GuardarAs();
            ColorearMenu.Click += (object s, EventArgs e) => ColorearCodigo();
            NoColorearMenu.Click += (object s, EventArgs e) => NoColorear();
            NewMenu.Click += (object s, EventArgs e) => Nuevo();

            rtbCodigo.VScroll += RichTextBox_VScroll;
            rtbCodigo.FontChanged += (object s, EventArgs e) =>
                                        {
                                            txtFilas.Font = new Font(rtbCodigo.Font.FontFamily, rtbCodigo.Font.Size);
                                        };
            rtbCodigo.KeyDown += rtbCodigo_KeyDown;
            rtbCodigo.SelectionChanged += rtbCodigo_SelectionChanged;
            rtbCodigo.Leave += rtbCodigo_Leave;
            rtbCodigo.TextChanged += (object s, EventArgs e) =>
                                        {
                                            codigoNuevo = rtbCodigo.Text;
                                            if (codigoNuevo == "")
                                                return;
                                            if (codigoAnt == "")
                                                return;
                                            // Añadir los números de línea               (15/Sep/20)
                                            var lin = codigoNuevo.Split('\r').Length;
                                            txtFilas.Text = "";
                                            for (var i = 1; i <= lin; i++)
                                                txtFilas.Text += i.ToString("0").PadLeft(4) + "\r\n";
                                            // Sincronizar los scrolls
                                            RichTextBox_VScroll(null, null);
                                            TextoModificado = (codigoAnt.Replace("\r", "").Replace("\n", "") != codigoNuevo.Replace("\n", ""));
                                        };

            cboLenguajes.TextChanged += (object s, EventArgs e) => LabelLenguaje.Text = cboLenguajes.Text;
            UndoMenu.Click += (object s, EventArgs e) => { if (rtbCodigo.CanUndo) rtbCodigo.Undo(); };
            RedoMenu.Click += (object s, EventArgs e) => { if (rtbCodigo.CanRedo) rtbCodigo.Redo(); };
            PasteMenu.Click += (object s, EventArgs e) =>
                                    {
                                        if (rtbCodigo.CanPaste(DataFormats.GetFormat("Text")))
                                            rtbCodigo.Paste(DataFormats.GetFormat("Text"));
                                    };
            CopyMenu.Click += (object s, EventArgs e) => rtbCodigo.Copy();
            CutMenu.Click += (object s, EventArgs e) => rtbCodigo.Cut();
            SelectAllMenu.Click += (object s, EventArgs e) => rtbCodigo.SelectAll();
            EditMenu.DropDownOpening += (object s, EventArgs e) =>
                                            {
                                                UndoMenu.Enabled = rtbCodigo.CanUndo;
                                                RedoMenu.Enabled = rtbCodigo.CanRedo;
                                                CopyMenu.Enabled = rtbCodigo.SelectionLength > 0;
                                                CutMenu.Enabled = CopyMenu.Enabled;
                                                PasteMenu.Enabled = rtbCodigo.CanPaste(DataFormats.GetFormat("Text"));
                                            };
            CompilarMenu.Click += (object s, EventArgs e) => CompilarEjecutar();
            RecientesMenu.DropDownOpening += (object s, EventArgs e) =>
                                                {
                                                    for (var i = 0; i <= RecientesMenu.DropDownItems.Count - 1; i++)
                                                    {
                                                        if (RecientesMenu.DropDownItems[i].Text.IndexOf(ultimoFic) > 3)
                                                        {
                                                            RecientesMenu.DropDownItems[i].Select();
                                                            (RecientesMenu.DropDownItems[i] as ToolStripMenuItem).Checked = true;
                                                        }
                                                    }
                                                };
            OpcionesMenu.Click += (object s, EventArgs e) =>
                                        {
                                            // Mostrar la ventana de opciones
                                            var opFrm = new OpcionesForm(colFics);
                                            opFrm.CargarUltimo = cargarUltimo;
                                            opFrm.ColorearAlCargar = colorearAlCargar;
                                            if (opFrm.ShowDialog() == DialogResult.OK)
                                            {
                                                colorearAlCargar = opFrm.ColorearAlCargar;
                                                cargarUltimo = opFrm.CargarUltimo;
                                                colFics.Clear();
                                                colFics.AddRange(opFrm.ColFics);
                                                AsignarRecientes();
                                                GuardarConfig();
                                            }
                                        };
            CopiarPathMenu.Click += (object s, EventArgs e) =>
                                        {
                                            try
                                            {
                                                Clipboard.SetText(ultimoFic);
                                            }
                                            catch {}
                                        };
            RecargarFicheroMenu.Click += (object s, EventArgs e) => Recargar();
            RecargarMenu.Click += (object s, EventArgs e) => Recargar();

            cboFuenteNombre.TextChanged += (object s, EventArgs e) =>
                                                {
                                                    try
                                                    {
                                                        FuenteAceptarMenu.Font = 
                                                            new Font(cboFuenteNombre.Text, 
                                                                    System.Convert.ToSingle(cboFuenteTamaño.Text));
                                                    }
                                                    catch {}
                                                };

            cboFuenteTamaño.TextChanged += (object s, EventArgs e) =>
                                                {
                                                    try
                                                    {
                                                        FuenteAceptarMenu.Font = 
                                                            new Font(cboFuenteNombre.Text, 
                                                                    System.Convert.ToSingle(cboFuenteTamaño.Text));
                                                    }
                                                    catch {}
                                                };

            FuenteAceptarMenu.Click += (object s, EventArgs e) =>
                                            {
                                                fuenteNombre = cboFuenteNombre.Text;
                                                fuenteTamaño = cboFuenteTamaño.Text;
                                                rtbCodigo.Font = new Font(fuenteNombre, System.Convert.ToSingle(fuenteTamaño));
                                                LabelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}";
                                                if (colorearAlCargar)
                                                    ColorearCodigo();
                                                GuardarConfig();
                                            };
        }

        private void GuardarConfig()
        {
            var cfg = new gsColorearNET.Config(ficConfig);
            // Si cargarUltimo es falso no guardar el último fichero     (16/Sep/20)
            cfg.SetValue("Ficheros", "CargarUltimo", cargarUltimo);
            if(cargarUltimo)
                cfg.SetValue("Ficheros", "Ultimo", ultimoFic);
            else
                cfg.SetValue("Ficheros", "Ultimo", "");
            cfg.SetValue("Herramientas", "Lenguaje", cboLenguajes.Text);
            cfg.SetValue("Herramientas", "Colorear", colorearAlCargar);

            // El nombre y tamaño de la fuente                           (11/Sep/20)
            cfg.SetValue("Fuente", "Nombre", fuenteNombre);
            cfg.SetValue("Fuente", "Tamaño", fuenteTamaño);

            // El tamaño y la posición de la ventana
            cfg.SetValue("Ventana", "Left", TamForm.L);
            cfg.SetValue("Ventana", "Top", TamForm.T);
            cfg.SetValue("Ventana", "Height", TamForm.H);
            cfg.SetValue("Ventana", "Width", TamForm.W);

            // Guardar la lista de últimos ficheros
            // solo los maxFicsConfig (100) últimos
            cfg.SetValue("Ficheros", "Count", colFics.Count);
            var j = 0;
            for (var i = colFics.Count - 1; i >= 0; i += -1)
            {
                cfg.SetValue("Ficheros", $"Fichero{j}", colFics[i]);
                j += 1;
                if (j == maxFicsConfig)
                    break;
            }
            cfg.Save();
        }

        private void LeerConfig()
        {
            var cfg = new gsColorearNET.Config(ficConfig);
            // Si cargarUltimo es falso no asignar el último fichero     (16/Sep/20)
            cargarUltimo = cfg.GetValue("Ficheros", "CargarUltimo", false);
            if (cargarUltimo)
                ultimoFic = cfg.GetValue("Ficheros", "Ultimo", "");
            else 
                ultimoFic = "";
            cboLenguajes.Text = cfg.GetValue("Herramientas", "Lenguaje", "VB");
            colorearAlCargar = cfg.GetValue("Herramientas", "Colorear", false);

            // El nombre y tamaño de la fuente                           (11/Sep/20)
            fuenteNombre = cfg.GetValue("Fuente", "Nombre", gsCol.FuentePre);
            fuenteTamaño = cfg.GetValue("Fuente", "Tamaño", gsCol.FuenteTamPre);
            LabelFuente.Text = $"{fuenteNombre}; {fuenteTamaño}";

            cboFuenteNombre.Text = fuenteNombre;
            cboFuenteTamaño.Text = fuenteTamaño;
            rtbCodigo.Font = new Font(fuenteNombre, System.Convert.ToSingle(fuenteTamaño));

            // El tamaño y la posición de la ventana
            TamForm.L = cfg.GetValue("Ventana", "Left", -1);
            TamForm.T = cfg.GetValue("Ventana", "Top", -1);
            TamForm.H = cfg.GetValue("Ventana", "Height", -1);
            TamForm.W = cfg.GetValue("Ventana", "Width", -1);

            if (TamForm.L != -1)
                this.Left = TamForm.L;
            if (TamForm.T != -1)
                this.Top = TamForm.T;
            if (TamForm.H > -1)
                this.Height = TamForm.H;
            if (TamForm.W > -1)
                this.Width = TamForm.W;

            // Leer la lista de últimos ficheros
            var cuantos = cfg.GetValue("Ficheros", "Count", 0);
            colFics.Clear();
            for (var i = 0; i <= maxFicsConfig - 1; i++)
            {
                if (i >= cuantos)
                    break;
                var s = cfg.GetValue("Ficheros", $"Fichero{i}", "-1");
                if (s == "-1")
                    break;
                colFics.Add(s);
            }
            // Mostrar los 15 primeros en el menú Recientes
            AsignarRecientes();
        }

        private void AsignarRecientes()
        {
            RecientesMenu.DropDownItems.Clear();
            for (var i = 0; i <= maxFicsMenu - 1; i++)
            {
                if (colFics.Count < (i + 1))
                    break;

                var s = $"{i + 1} - {colFics[i]}";
                var m = new ToolStripMenuItem(s);
                m.Click += (object s, EventArgs e) => AbrirReciente(m.Text);
                RecientesMenu.DropDownItems.Add(m);
            }
        }

        private void AbrirReciente(string fic)
        {
            // El nombre está después del guión -
            // posición máxima será 4: 1 - Nombre
            // pero si hay 2 cifras, será 5: 10 - Nombre
            // Tomando a partir del la 4ª posición está bien
            if (fic == "")
                return;

            var ficT = fic.Substring(4).Trim();

            // Posicionarlo al principio de la colección
            if (colFics.Contains(ficT))
            {
                colFics.Remove(ficT);
                colFics.Add(ficT);
            }

            // Si es el que está abierto, salir
            // Solo si el texto no está modificado                       (14/Sep/20)
            // por si se quiere re-abrir
            if (ficT == ultimoFic && TextoModificado == false)
                return;

            if (TextoModificado)
                GuardarAs();
            ultimoFic = ficT;
            Abrir(ultimoFic);
        }

        private void NoColorear()
        {
            var temp = TextoModificado;
            var codigo = rtbCodigo.Text;

            rtbCodigo.Rtf = "";
            rtbCodigo.Text = codigo;
            TextoModificado = temp;
        }

        private void ColorearCodigo()
        {
            var temp = TextoModificado;
            var codigo = rtbCodigo.Text;

            // Llamar directamente a gsColorear
            // Le he puesto que use la fuente Consolas,
            // que NO asigne el CASE adecuado a las palabras claves,
            // que indente con 4 espacios
            gsCol.Fuente = fuenteNombre;
            gsCol.FuenteTam = fuenteTamaño;

            var lang = gsDev.Lenguajes.VB;
            if (cboLenguajes.Text == "C#")
                lang = gsDev.Lenguajes.CS;
            else if (cboLenguajes.Text == "VB")
                lang = gsDev.Lenguajes.VB;
            else
                lang = gsDev.Lenguajes.dotNet;
            codigo = gsCol.ColorearCodigo(codigo, 
                                          lang, 
                                          gsCol.FormatosColoreado.RTF, 
                                          asignarCase: false, 
                                          indentar: 4, 
                                          quitarEspaciosIniciales:false, 
                                          coloreandoTodo: gsCol.ComprobacionesRem.Todos);

            rtbCodigo.Rtf = codigo;

            TextoModificado = temp;
        }

        private void Nuevo()
        {
            if (TextoModificado)
                GuardarAs();
            rtbCodigo.Text = "";
            txtFilas.Text = "";
            ultimoFic = "";
            TextoModificado = false;
            LabelInfo.Text = "";
            LabelPos.Text = "";
            LabelTamaño.Text = "";
            codigoAnt = "";
        }

        private void GuardarAs()
        {
            var sFD = new SaveFileDialog();
            sFD.FileName = ultimoFic;
            sFD.Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*";
            sFD.RestoreDirectory = true;
            sFD.Title = "Selecciona el archivo a guardar";
            if (sFD.ShowDialog() == DialogResult.OK)
                Guardar(ultimoFic);
        }

        private void Guardar()
        {
            if (ultimoFic == "")
            {
                GuardarAs();
                return;
            }
            Guardar(ultimoFic);
        }

        private void Guardar(string fic)
        {
            LabelInfo.Text = $"Guardando {ultimoFic}...";

            var sCodigo = rtbCodigo.Text;
            using (var sw = new StreamWriter(fic, append: false, encoding: Encoding.UTF8))
            {
                sw.WriteLine(sCodigo);
            }
            codigoAnt = sCodigo;

            LabelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})";
            LabelTamaño.Text = $"{rtbCodigo.Text.Length} car.";
            TextoModificado = false;
            if (colFics.Contains(fic) == false)
                colFics.Add(fic);
            AsignarRecientes();
        }

        private void Recargar()
        {
            if (ultimoFic != "")
                Abrir(ultimoFic);
        }

        private void Abrir()
        {
            var oFD = new OpenFileDialog();
            oFD.FileName = ultimoFic;
            oFD.Filter = "Código VB y C# (*.vb; *.cs)|*.vb;*.cs|Todos (*.*)|*.*";
            oFD.Multiselect = false;
            oFD.RestoreDirectory = true;
            oFD.Title = "Selecciona el archivo a abrir";
            if (oFD.ShowDialog() == DialogResult.OK)
            {
                ultimoFic = oFD.FileName;
                Abrir(ultimoFic);
            }
        }

        private void Abrir(string fic)
        {
            if (!File.Exists(fic))
            {
                LabelInfo.Text = $"No existe {fic}";
                return;
            }

            LabelInfo.Text = $"Cargando {fic}...";

            var sCodigo = "";
            using (var sr = new StreamReader(fic, detectEncodingFromByteOrderMarks: true, encoding: Encoding.UTF8))
            {
                sCodigo = sr.ReadToEnd();
            }
            codigoAnt = sCodigo;
            rtbCodigo.Text = sCodigo;
            mostrarPosicion(null);

            if (Path.GetExtension(fic).ToLower() == ".cs")
                cboLenguajes.Text = "C#";
            else if (Path.GetExtension(fic).ToLower() == ".vb")
                cboLenguajes.Text = "VB";
            else if (sCodigo.Contains(");"))
                cboLenguajes.Text = "C#";
            else if (sCodigo.ToLower().Contains("end if"))
                cboLenguajes.Text = "VB";
            else
                cboLenguajes.Text = "dotnet";

            LabelInfo.Text = $"{Path.GetFileName(fic)} ({Path.GetDirectoryName(fic)})";
            LabelTamaño.Text = $"{rtbCodigo.Text.Length} car.";
            if (colFics.Contains(ultimoFic) == false)
                colFics.Add(ultimoFic);
            AsignarRecientes();
            if (colorearAlCargar)
                ColorearCodigo();
            TextoModificado = false;
        }

        private void AcercaDe_Click(object sender, EventArgs e)
        {
            // Añadir la versión de esta utilidad                        (15/Sep/20)
            System.Reflection.Assembly ensamblado = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(ensamblado.Location);

            var versionAttr = ensamblado.GetCustomAttributes(typeof(System.Reflection.AssemblyVersionAttribute), false);
            var vers = versionAttr.Length > 0 ? (versionAttr[0] as System.Reflection.AssemblyVersionAttribute).Version 
                                              : "1.0.0.0";

            var prodAttr = ensamblado.GetCustomAttributes(typeof(System.Reflection.AssemblyProductAttribute), false);
            var producto = prodAttr.Length > 0 ? (prodAttr[0] as System.Reflection.AssemblyProductAttribute).Product 
                                               : "gsCompilarEjecutarNET cs";

            var descAttr = ensamblado.GetCustomAttributes(typeof(System.Reflection.AssemblyDescriptionAttribute), false);
            var desc = descAttr.Length > 0 ? (descAttr[0] as System.Reflection.AssemblyDescriptionAttribute).Description 
                                           : "(para .NET 5.0 revisión del 16/Sep/2020)";

            desc = desc.Substring(desc.IndexOf("(para .NET"));


            var verColorear = gsCol.Version(completa: true);
            var verCompilar = Compilar.Version(completa: true);
            var i = verColorear.LastIndexOf(" (");
            if (i > -1)
                verColorear = $"{verColorear.Substring(0, i)}{'\n'}{verColorear.Substring(i + 1)}";

            i = verCompilar.LastIndexOf(" (");
            if (i > -1)
                verCompilar = $"{verCompilar.Substring(0, i)}{'\n'}{verCompilar.Substring(i + 1)}";

            var descL = "Utilidad para .NET 5.0 (.NET Core) para mostrar código en VB o C#, colorearlo y compilarlo.";

            MessageBox.Show($"{producto} v{vers} ({fvi.FileVersion})\r\r"  + 
                            $"{descL}{'\n'}{desc}{'\n'}{'\n'}" + 
                            "Usando las DLL externas:" + "\r\n" + 
                            verColorear + "\r\n" + "\r\n" + 
                            verCompilar, 
                            $"Acerca de {producto}", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rtbCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            mostrarPosicion(e);
        }

        /// <summary>
        /// Saber la línea y columna de la posición del cursor
        /// </summary>
        private void mostrarPosicion(KeyEventArgs e)
        {
            // Saber la línea y columna de la posición del cursor
            int pos = rtbCodigo.SelectionStart + 1;
            int lin = rtbCodigo.GetLineFromCharIndex(pos) + 1;
            int col = pos - rtbCodigo.GetFirstCharIndexOfCurrentLine();
            var fcol = rtbCodigo.GetFirstCharIndexFromLine(lin - 1);
            if (fcol == pos)
                lin -= 1;

            if (e != null)
            {
                if (e.KeyCode == Keys.Tab && e.Modifiers == Keys.Shift)
                    col = 1;
                else if (e.KeyCode == Keys.Home)
                    col = 1;
            }

            LabelPos.Text = $"Lín: {lin}  Car: {col}";
        }

        private void rtbCodigo_SelectionChanged(object sender, EventArgs e)
        {
            mostrarPosicion(null);
        }

        private void rtbCodigo_Leave(object sender, EventArgs e)
        {
            LabelPos.Text = "";
        }

        private void CompilarEjecutar()
        {
            if (TextoModificado)
                GuardarAs();
            
            var filepath = ultimoFic;
            LabelInfo.Text = "Compilando y ejecutando el código...";
            this.Refresh();

            var res = Compilar.CompilarRun(filepath, run: true);
            LabelInfo.Text = res;

            if (Compilar.FallosCompilar() != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var diagnostic in Compilar.FallosCompilar())
                {
                    var lin = diagnostic.Location.GetLineSpan().StartLinePosition.Line + 1;
                    var pos = diagnostic.Location.GetLineSpan().StartLinePosition.Character + 1;
                    sb.AppendFormat("{0}: {1} (en línea {2}, posición {3})", 
                                            diagnostic.Id, diagnostic.GetMessage(), lin, pos);
                    sb.AppendLine();
                }

                MessageBox.Show($"Errores al compilar: {"\r\n"}{sb.ToString()}",
                    "Compilar y ejecutar", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }

    public static class WinAPI
    {
        public enum ScrollBarType : int
        {
            SbHorz = 0,
            SbVert = 1,
            SbCtl = 2,
            SbBoth = 3
        }

        public enum Message : long
        {
            WM_VSCROLL = 0x115
        }

        public enum ScrollBarCommands : long
        {
            SB_THUMBPOSITION = 4
        }

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int GetScrollPos(IntPtr hWnd, int nBar);

        [System.Runtime.InteropServices.DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, long msg, long wParam, long lParam);
    }
}
