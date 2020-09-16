
using System.Windows.Forms;

namespace gsCompilarEjecutarNET_cs
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RecargarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RecientesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RedoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectAllMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CompilarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.NoColorearMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorearMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cboLenguajes = new System.Windows.Forms.ToolStripComboBox();
            this.toolSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.FuenteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.cboFuenteNombre = new System.Windows.Forms.ToolStripComboBox();
            this.cboFuenteTamaño = new System.Windows.Forms.ToolStripComboBox();
            this.FuenteAceptarMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.OpcionesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbCodigo = new System.Windows.Forms.RichTextBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopiarPathMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RecargarFicheroMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelModificado = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelTamaño = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelFuente = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelLenguaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtFilas = new System.Windows.Forms.RichTextBox();
            this.MenuStrip1.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.StatusContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.EditMenu,
            this.ToolsMenu});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip1.TabIndex = 0;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenu,
            this.OpenMenu,
            this.RecargarMenu,
            this.toolSeparator,
            this.SaveMenu,
            this.SaveAsMenu,
            this.toolSeparator1,
            this.RecientesMenu,
            this.toolSeparator7,
            this.AboutMenu,
            this.toolSeparator2,
            this.ExitMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(60, 20);
            this.FileMenu.Text = "&Archivo";
            // 
            // NewMenu
            // 
            this.NewMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewMenu.Name = "NewMenu";
            this.NewMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewMenu.Size = new System.Drawing.Size(161, 22);
            this.NewMenu.Text = "&Nuevo";
            // 
            // OpenMenu
            // 
            this.OpenMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OpenMenu.Name = "OpenMenu";
            this.OpenMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenMenu.Size = new System.Drawing.Size(161, 22);
            this.OpenMenu.Text = "&Abrir...";
            // 
            // RecargarMenu
            // 
            this.RecargarMenu.Name = "RecargarMenu";
            this.RecargarMenu.Size = new System.Drawing.Size(161, 22);
            this.RecargarMenu.Text = "Recargar fichero";
            this.RecargarMenu.ToolTipText = "Recargar el fichero actual, si se ha modificado, se perderán los cambios";
            // 
            // toolSeparator
            // 
            this.toolSeparator.Name = "toolSeparator";
            this.toolSeparator.Size = new System.Drawing.Size(158, 6);
            // 
            // SaveMenu
            // 
            this.SaveMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveMenu.Name = "SaveMenu";
            this.SaveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveMenu.Size = new System.Drawing.Size(161, 22);
            this.SaveMenu.Text = "&Guardar";
            // 
            // SaveAsMenu
            // 
            this.SaveAsMenu.Name = "SaveAsMenu";
            this.SaveAsMenu.Size = new System.Drawing.Size(161, 22);
            this.SaveAsMenu.Text = "Guardar &Cómo...";
            // 
            // toolSeparator1
            // 
            this.toolSeparator1.Name = "toolSeparator1";
            this.toolSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // RecientesMenu
            // 
            this.RecientesMenu.Name = "RecientesMenu";
            this.RecientesMenu.Size = new System.Drawing.Size(161, 22);
            this.RecientesMenu.Text = "Recientes...";
            // 
            // toolSeparator7
            // 
            this.toolSeparator7.Name = "toolSeparator7";
            this.toolSeparator7.Size = new System.Drawing.Size(158, 6);
            // 
            // AboutMenu
            // 
            this.AboutMenu.Name = "AboutMenu";
            this.AboutMenu.Size = new System.Drawing.Size(161, 22);
            this.AboutMenu.Text = "&Acerca de...";
            // 
            // toolSeparator2
            // 
            this.toolSeparator2.Name = "toolSeparator2";
            this.toolSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(161, 22);
            this.ExitMenu.Text = "Salir";
            // 
            // EditMenu
            // 
            this.EditMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoMenu,
            this.RedoMenu,
            this.toolSeparator3,
            this.CutMenu,
            this.CopyMenu,
            this.PasteMenu,
            this.toolSeparator4,
            this.SelectAllMenu});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(49, 20);
            this.EditMenu.Text = "&Editar";
            // 
            // UndoMenu
            // 
            this.UndoMenu.Name = "UndoMenu";
            this.UndoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.UndoMenu.Size = new System.Drawing.Size(204, 22);
            this.UndoMenu.Text = "&Undo";
            // 
            // RedoMenu
            // 
            this.RedoMenu.Name = "RedoMenu";
            this.RedoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.RedoMenu.Size = new System.Drawing.Size(204, 22);
            this.RedoMenu.Text = "&Redo";
            // 
            // toolSeparator3
            // 
            this.toolSeparator3.Name = "toolSeparator3";
            this.toolSeparator3.Size = new System.Drawing.Size(201, 6);
            // 
            // CutMenu
            // 
            this.CutMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CutMenu.Name = "CutMenu";
            this.CutMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.CutMenu.Size = new System.Drawing.Size(204, 22);
            this.CutMenu.Text = "Cor&tar";
            // 
            // CopyMenu
            // 
            this.CopyMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CopyMenu.Name = "CopyMenu";
            this.CopyMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyMenu.Size = new System.Drawing.Size(204, 22);
            this.CopyMenu.Text = "&Copiar";
            // 
            // PasteMenu
            // 
            this.PasteMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PasteMenu.Name = "PasteMenu";
            this.PasteMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PasteMenu.Size = new System.Drawing.Size(204, 22);
            this.PasteMenu.Text = "&Pegar";
            // 
            // toolSeparator4
            // 
            this.toolSeparator4.Name = "toolSeparator4";
            this.toolSeparator4.Size = new System.Drawing.Size(201, 6);
            // 
            // SelectAllMenu
            // 
            this.SelectAllMenu.Name = "SelectAllMenu";
            this.SelectAllMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAllMenu.Size = new System.Drawing.Size(204, 22);
            this.SelectAllMenu.Text = "Seleccion&ar todo";
            // 
            // ToolsMenu
            // 
            this.ToolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CompilarMenu,
            this.toolSeparator5,
            this.NoColorearMenu,
            this.ColorearMenu,
            this.cboLenguajes,
            this.toolSeparator6,
            this.FuenteMenu,
            this.toolSeparator8,
            this.OpcionesMenu});
            this.ToolsMenu.Name = "ToolsMenu";
            this.ToolsMenu.Size = new System.Drawing.Size(90, 20);
            this.ToolsMenu.Text = "&Herramientas";
            // 
            // CompilarMenu
            // 
            this.CompilarMenu.Name = "CompilarMenu";
            this.CompilarMenu.Size = new System.Drawing.Size(181, 22);
            this.CompilarMenu.Text = "C&ompilar y ejecutar";
            // 
            // toolSeparator5
            // 
            this.toolSeparator5.Name = "toolSeparator5";
            this.toolSeparator5.Size = new System.Drawing.Size(178, 6);
            // 
            // NoColorearMenu
            // 
            this.NoColorearMenu.Name = "NoColorearMenu";
            this.NoColorearMenu.Size = new System.Drawing.Size(181, 22);
            this.NoColorearMenu.Text = "Mostrar sin colorear";
            // 
            // ColorearMenu
            // 
            this.ColorearMenu.Name = "ColorearMenu";
            this.ColorearMenu.Size = new System.Drawing.Size(181, 22);
            this.ColorearMenu.Text = "&Colorear";
            // 
            // cboLenguajes
            // 
            this.cboLenguajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLenguajes.Items.AddRange(new object[] {
            "C#",
            "VB"});
            this.cboLenguajes.Name = "cboLenguajes";
            this.cboLenguajes.Size = new System.Drawing.Size(121, 23);
            // 
            // toolSeparator6
            // 
            this.toolSeparator6.Name = "toolSeparator6";
            this.toolSeparator6.Size = new System.Drawing.Size(178, 6);
            // 
            // FuenteMenu
            // 
            this.FuenteMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboFuenteNombre,
            this.cboFuenteTamaño,
            this.FuenteAceptarMenu});
            this.FuenteMenu.Name = "FuenteMenu";
            this.FuenteMenu.Size = new System.Drawing.Size(181, 22);
            this.FuenteMenu.Text = "&Fuente...";
            // 
            // cboFuenteNombre
            // 
            this.cboFuenteNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuenteNombre.Items.AddRange(new object[] {
            "Courier New",
            "Consolas",
            "Segoe UI",
            "Lucida Console",
            "Arial",
            "Verdana",
            "Comic Sans MS"});
            this.cboFuenteNombre.Name = "cboFuenteNombre";
            this.cboFuenteNombre.Size = new System.Drawing.Size(121, 23);
            this.cboFuenteNombre.Text = "Consolas";
            // 
            // cboFuenteTamaño
            // 
            this.cboFuenteTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFuenteTamaño.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "16",
            "18"});
            this.cboFuenteTamaño.Name = "cboFuenteTamaño";
            this.cboFuenteTamaño.Size = new System.Drawing.Size(121, 23);
            this.cboFuenteTamaño.Text = "11";
            // 
            // FuenteAceptarMenu
            // 
            this.FuenteAceptarMenu.Name = "FuenteAceptarMenu";
            this.FuenteAceptarMenu.Size = new System.Drawing.Size(236, 22);
            this.FuenteAceptarMenu.Text = "Aceptar Fuente: System.Object";
            // 
            // toolSeparator8
            // 
            this.toolSeparator8.Name = "toolSeparator8";
            this.toolSeparator8.Size = new System.Drawing.Size(178, 6);
            // 
            // OpcionesMenu
            // 
            this.OpcionesMenu.Name = "OpcionesMenu";
            this.OpcionesMenu.Size = new System.Drawing.Size(181, 22);
            this.OpcionesMenu.Text = "Opciones...";
            // 
            // rtbCodigo
            // 
            this.rtbCodigo.AcceptsTab = true;
            this.rtbCodigo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCodigo.DetectUrls = false;
            this.rtbCodigo.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtbCodigo.Location = new System.Drawing.Point(43, 27);
            this.rtbCodigo.Name = "rtbCodigo";
            this.rtbCodigo.Size = new System.Drawing.Size(745, 396);
            this.rtbCodigo.TabIndex = 1;
            this.rtbCodigo.Text = "";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ContextMenuStrip = this.StatusContextMenu;
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelModificado,
            this.LabelInfo,
            this.LabelTamaño,
            this.LabelFuente,
            this.LabelLenguaje,
            this.LabelPos});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 426);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(800, 24);
            this.StatusStrip1.TabIndex = 2;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // StatusContextMenu
            // 
            this.StatusContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopiarPathMenu,
            this.RecargarFicheroMenu});
            this.StatusContextMenu.Name = "StatusContextMenu";
            this.StatusContextMenu.ShowImageMargin = false;
            this.StatusContextMenu.Size = new System.Drawing.Size(284, 48);
            // 
            // CopiarPathMenu
            // 
            this.CopiarPathMenu.Name = "CopiarPathMenu";
            this.CopiarPathMenu.Size = new System.Drawing.Size(283, 22);
            this.CopiarPathMenu.Text = "Copiar PATH completo";
            // 
            // RecargarFicheroMenu
            // 
            this.RecargarFicheroMenu.Name = "RecargarFicheroMenu";
            this.RecargarFicheroMenu.Size = new System.Drawing.Size(283, 22);
            this.RecargarFicheroMenu.Text = "Recargar el fichero (sin guardar los cambios)";
            // 
            // LabelModificado
            // 
            this.LabelModificado.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.LabelModificado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LabelModificado.Name = "LabelModificado";
            this.LabelModificado.Size = new System.Drawing.Size(16, 19);
            this.LabelModificado.Text = "*";
            this.LabelModificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelInfo
            // 
            this.LabelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LabelInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(518, 19);
            this.LabelInfo.Spring = true;
            this.LabelInfo.Text = "LabelInfo";
            this.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelTamaño
            // 
            this.LabelTamaño.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LabelTamaño.Name = "LabelTamaño";
            this.LabelTamaño.Size = new System.Drawing.Size(60, 19);
            this.LabelTamaño.Text = "4,466 car.";
            // 
            // LabelFuente
            // 
            this.LabelFuente.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LabelFuente.Name = "LabelFuente";
            this.LabelFuente.Size = new System.Drawing.Size(68, 19);
            this.LabelFuente.Text = "Courier; 10";
            // 
            // LabelLenguaje
            // 
            this.LabelLenguaje.AutoSize = false;
            this.LabelLenguaje.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LabelLenguaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LabelLenguaje.Name = "LabelLenguaje";
            this.LabelLenguaje.Size = new System.Drawing.Size(30, 19);
            this.LabelLenguaje.Text = "C#";
            // 
            // LabelPos
            // 
            this.LabelPos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.LabelPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LabelPos.Name = "LabelPos";
            this.LabelPos.Size = new System.Drawing.Size(93, 19);
            this.LabelPos.Text = "Lín: 399  Car: 20";
            // 
            // txtFilas
            // 
            this.txtFilas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFilas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilas.CausesValidation = false;
            this.txtFilas.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFilas.Location = new System.Drawing.Point(3, 27);
            this.txtFilas.Name = "txtFilas";
            this.txtFilas.ReadOnly = true;
            this.txtFilas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtFilas.ShortcutsEnabled = false;
            this.txtFilas.Size = new System.Drawing.Size(39, 396);
            this.txtFilas.TabIndex = 3;
            this.txtFilas.TabStop = false;
            this.txtFilas.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFilas);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.rtbCodigo);
            this.Controls.Add(this.MenuStrip1);
            this.MainMenuStrip = this.MenuStrip1;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compilar para NET 5.0 (.NET Core) WinForms C#";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.StatusContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuStrip1;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem NewMenu;
        private ToolStripSeparator toolSeparator;
        private ToolStripSeparator toolSeparator1;
        private ToolStripSeparator toolSeparator2;
        private ToolStripSeparator toolSeparator3;
        private ToolStripSeparator toolSeparator4;
        private ToolStripSeparator toolSeparator5;
        private RichTextBox rtbCodigo;
        private StatusStrip StatusStrip1;
        private ToolStripStatusLabel LabelInfo;
        private ToolStripStatusLabel LabelPos;
        private ToolStripComboBox cboLenguajes;
        private ToolStripStatusLabel LabelLenguaje;
        private ToolStripStatusLabel LabelModificado;
        private ToolStripSeparator toolSeparator6;
        private ToolStripSeparator toolSeparator7;
        private ToolStripSeparator toolSeparator8;
        private ToolStripStatusLabel LabelTamaño;
        private ContextMenuStrip StatusContextMenu;
        private ToolStripMenuItem CopiarPathMenu;
        private ToolStripMenuItem RecargarFicheroMenu;
        private ToolStripMenuItem OpenMenu;
        private ToolStripMenuItem RecargarMenu;
        private ToolStripMenuItem SaveMenu;
        private ToolStripMenuItem SaveAsMenu;
        private ToolStripMenuItem RecientesMenu;
        private ToolStripMenuItem AboutMenu;
        private ToolStripMenuItem ExitMenu;
        private ToolStripMenuItem EditMenu;
        private ToolStripMenuItem UndoMenu;
        private ToolStripMenuItem RedoMenu;
        private ToolStripMenuItem CutMenu;
        private ToolStripMenuItem CopyMenu;
        private ToolStripMenuItem PasteMenu;
        private ToolStripMenuItem SelectAllMenu;
        private ToolStripMenuItem ToolsMenu;
        private ToolStripMenuItem CompilarMenu;
        private ToolStripMenuItem NoColorearMenu;
        private ToolStripMenuItem ColorearMenu;
        private ToolStripMenuItem OpcionesMenu;
        private ToolStripMenuItem FuenteMenu;
        private ToolStripComboBox cboFuenteNombre;
        private ToolStripComboBox cboFuenteTamaño;
        private ToolStripMenuItem FuenteAceptarMenu;
        private ToolStripStatusLabel LabelFuente;
        private RichTextBox txtFilas;

    }
}

