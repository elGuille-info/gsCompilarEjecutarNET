<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.RecientesMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.AboutMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.UndoMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedoMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CutMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SelectAllMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompilarMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.NoColorearMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorearMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboLenguajes = New System.Windows.Forms.ToolStripComboBox()
        Me.toolSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.FuenteMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboFuenteNombre = New System.Windows.Forms.ToolStripComboBox()
        Me.cboFuenteTamaño = New System.Windows.Forms.ToolStripComboBox()
        Me.FuenteAceptarMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpcionesMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.rtbCodigo = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarPathMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarFicheroMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelModificado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelTamaño = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelFuente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelLenguaje = New System.Windows.Forms.ToolStripStatusLabel()
        Me.LabelPos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.StatusContextMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu, Me.EditMenu, Me.ToolsMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewMenu, Me.OpenMenu, Me.RecargarMenu, Me.toolSeparator, Me.SaveMenu, Me.SaveAsMenu, Me.toolSeparator1, Me.RecientesMenu, Me.toolSeparator7, Me.AboutMenu, Me.toolSeparator2, Me.ExitMenu})
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(60, 20)
        Me.FileMenu.Text = "&Archivo"
        '
        'NewMenu
        '
        Me.NewMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewMenu.Name = "NewMenu"
        Me.NewMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewMenu.Size = New System.Drawing.Size(161, 22)
        Me.NewMenu.Text = "&Nuevo"
        '
        'OpenMenu
        '
        Me.OpenMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenMenu.Name = "OpenMenu"
        Me.OpenMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenMenu.Size = New System.Drawing.Size(161, 22)
        Me.OpenMenu.Text = "&Abrir..."
        '
        'RecargarMenu
        '
        Me.RecargarMenu.Name = "RecargarMenu"
        Me.RecargarMenu.Size = New System.Drawing.Size(161, 22)
        Me.RecargarMenu.Text = "Recargar fichero"
        Me.RecargarMenu.ToolTipText = "Recargar el fichero actual, si se ha modificado, se perderán los cambios"
        '
        'toolSeparator
        '
        Me.toolSeparator.Name = "toolSeparator"
        Me.toolSeparator.Size = New System.Drawing.Size(158, 6)
        '
        'SaveMenu
        '
        Me.SaveMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveMenu.Name = "SaveMenu"
        Me.SaveMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.SaveMenu.Size = New System.Drawing.Size(161, 22)
        Me.SaveMenu.Text = "&Guardar"
        '
        'SaveAsMenu
        '
        Me.SaveAsMenu.Name = "SaveAsMenu"
        Me.SaveAsMenu.Size = New System.Drawing.Size(161, 22)
        Me.SaveAsMenu.Text = "Guardar &Cómo..."
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'RecientesMenu
        '
        Me.RecientesMenu.Name = "RecientesMenu"
        Me.RecientesMenu.Size = New System.Drawing.Size(161, 22)
        Me.RecientesMenu.Text = "Recientes..."
        '
        'toolSeparator7
        '
        Me.toolSeparator7.Name = "toolSeparator7"
        Me.toolSeparator7.Size = New System.Drawing.Size(158, 6)
        '
        'AboutMenu
        '
        Me.AboutMenu.Name = "AboutMenu"
        Me.AboutMenu.Size = New System.Drawing.Size(161, 22)
        Me.AboutMenu.Text = "&Acerca de..."
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        'ExitMenu
        '
        Me.ExitMenu.Name = "ExitMenu"
        Me.ExitMenu.Size = New System.Drawing.Size(161, 22)
        Me.ExitMenu.Text = "Salir"
        '
        'EditMenu
        '
        Me.EditMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UndoMenu, Me.RedoMenu, Me.toolSeparator3, Me.CutMenu, Me.CopyMenu, Me.PasteMenu, Me.toolSeparator4, Me.SelectAllMenu})
        Me.EditMenu.Name = "EditMenu"
        Me.EditMenu.Size = New System.Drawing.Size(49, 20)
        Me.EditMenu.Text = "&Editar"
        '
        'UndoMenu
        '
        Me.UndoMenu.Name = "UndoMenu"
        Me.UndoMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.UndoMenu.Size = New System.Drawing.Size(204, 22)
        Me.UndoMenu.Text = "&Undo"
        '
        'RedoMenu
        '
        Me.RedoMenu.Name = "RedoMenu"
        Me.RedoMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RedoMenu.Size = New System.Drawing.Size(204, 22)
        Me.RedoMenu.Text = "&Redo"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(201, 6)
        '
        'CutMenu
        '
        Me.CutMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutMenu.Name = "CutMenu"
        Me.CutMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.CutMenu.Size = New System.Drawing.Size(204, 22)
        Me.CutMenu.Text = "Cor&tar"
        '
        'CopyMenu
        '
        Me.CopyMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CopyMenu.Name = "CopyMenu"
        Me.CopyMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopyMenu.Size = New System.Drawing.Size(204, 22)
        Me.CopyMenu.Text = "&Copiar"
        '
        'PasteMenu
        '
        Me.PasteMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PasteMenu.Name = "PasteMenu"
        Me.PasteMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PasteMenu.Size = New System.Drawing.Size(204, 22)
        Me.PasteMenu.Text = "&Pegar"
        '
        'toolSeparator4
        '
        Me.toolSeparator4.Name = "toolSeparator4"
        Me.toolSeparator4.Size = New System.Drawing.Size(201, 6)
        '
        'SelectAllMenu
        '
        Me.SelectAllMenu.Name = "SelectAllMenu"
        Me.SelectAllMenu.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.SelectAllMenu.Size = New System.Drawing.Size(204, 22)
        Me.SelectAllMenu.Text = "Seleccion&ar todo"
        '
        'ToolsMenu
        '
        Me.ToolsMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompilarMenu, Me.toolSeparator5, Me.NoColorearMenu, Me.ColorearMenu, Me.cboLenguajes, Me.toolSeparator6, Me.FuenteMenu, Me.toolSeparator8, Me.OpcionesMenu})
        Me.ToolsMenu.Name = "ToolsMenu"
        Me.ToolsMenu.Size = New System.Drawing.Size(90, 20)
        Me.ToolsMenu.Text = "&Herramientas"
        '
        'CompilarMenu
        '
        Me.CompilarMenu.Name = "CompilarMenu"
        Me.CompilarMenu.Size = New System.Drawing.Size(181, 22)
        Me.CompilarMenu.Text = "C&ompilar y ejecutar"
        '
        'toolSeparator5
        '
        Me.toolSeparator5.Name = "toolSeparator5"
        Me.toolSeparator5.Size = New System.Drawing.Size(178, 6)
        '
        'NoColorearMenu
        '
        Me.NoColorearMenu.Name = "NoColorearMenu"
        Me.NoColorearMenu.Size = New System.Drawing.Size(181, 22)
        Me.NoColorearMenu.Text = "Mostrar sin colorear"
        '
        'ColorearMenu
        '
        Me.ColorearMenu.Name = "ColorearMenu"
        Me.ColorearMenu.Size = New System.Drawing.Size(181, 22)
        Me.ColorearMenu.Text = "&Colorear"
        '
        'cboLenguajes
        '
        Me.cboLenguajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLenguajes.Items.AddRange(New Object() {"C#", "VB"})
        Me.cboLenguajes.Name = "cboLenguajes"
        Me.cboLenguajes.Size = New System.Drawing.Size(121, 23)
        '
        'toolSeparator6
        '
        Me.toolSeparator6.Name = "toolSeparator6"
        Me.toolSeparator6.Size = New System.Drawing.Size(178, 6)
        '
        'FuenteMenu
        '
        Me.FuenteMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cboFuenteNombre, Me.cboFuenteTamaño, Me.FuenteAceptarMenu})
        Me.FuenteMenu.Name = "FuenteMenu"
        Me.FuenteMenu.Size = New System.Drawing.Size(181, 22)
        Me.FuenteMenu.Text = "&Fuente..."
        '
        'cboFuenteNombre
        '
        Me.cboFuenteNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFuenteNombre.Items.AddRange(New Object() {"Courier New", "Consolas", "Segoe UI", "Lucida Console", "Arial", "Verdana", "Comic Sans MS"})
        Me.cboFuenteNombre.Name = "cboFuenteNombre"
        Me.cboFuenteNombre.Size = New System.Drawing.Size(121, 23)
        Me.cboFuenteNombre.Text = "Consolas"
        '
        'cboFuenteTamaño
        '
        Me.cboFuenteTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFuenteTamaño.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14", "16", "18"})
        Me.cboFuenteTamaño.Name = "cboFuenteTamaño"
        Me.cboFuenteTamaño.Size = New System.Drawing.Size(121, 23)
        Me.cboFuenteTamaño.Text = "11"
        '
        'FuenteAceptarMenu
        '
        Me.FuenteAceptarMenu.Name = "FuenteAceptarMenu"
        Me.FuenteAceptarMenu.Size = New System.Drawing.Size(236, 22)
        Me.FuenteAceptarMenu.Text = "Aceptar Fuente: System.Object"
        '
        'toolSeparator8
        '
        Me.toolSeparator8.Name = "toolSeparator8"
        Me.toolSeparator8.Size = New System.Drawing.Size(178, 6)
        '
        'OpcionesMenu
        '
        Me.OpcionesMenu.Name = "OpcionesMenu"
        Me.OpcionesMenu.Size = New System.Drawing.Size(181, 22)
        Me.OpcionesMenu.Text = "Opciones..."
        '
        'rtbCodigo
        '
        Me.rtbCodigo.AcceptsTab = True
        Me.rtbCodigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbCodigo.DetectUrls = False
        Me.rtbCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.rtbCodigo.Location = New System.Drawing.Point(12, 27)
        Me.rtbCodigo.Name = "rtbCodigo"
        Me.rtbCodigo.Size = New System.Drawing.Size(776, 396)
        Me.rtbCodigo.TabIndex = 1
        Me.rtbCodigo.Text = ""
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ContextMenuStrip = Me.StatusContextMenu
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LabelModificado, Me.LabelInfo, Me.LabelTamaño, Me.LabelFuente, Me.LabelLenguaje, Me.LabelPos})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 426)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusContextMenu
        '
        Me.StatusContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarPathMenu, Me.RecargarFicheroMenu})
        Me.StatusContextMenu.Name = "StatusContextMenu"
        Me.StatusContextMenu.ShowImageMargin = False
        Me.StatusContextMenu.Size = New System.Drawing.Size(284, 48)
        '
        'CopiarPathMenu
        '
        Me.CopiarPathMenu.Name = "CopiarPathMenu"
        Me.CopiarPathMenu.Size = New System.Drawing.Size(283, 22)
        Me.CopiarPathMenu.Text = "Copiar PATH completo"
        '
        'RecargarFicheroMenu
        '
        Me.RecargarFicheroMenu.Name = "RecargarFicheroMenu"
        Me.RecargarFicheroMenu.Size = New System.Drawing.Size(283, 22)
        Me.RecargarFicheroMenu.Text = "Recargar el fichero (sin guardar los cambios)"
        '
        'LabelModificado
        '
        Me.LabelModificado.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.LabelModificado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelModificado.Name = "LabelModificado"
        Me.LabelModificado.Size = New System.Drawing.Size(16, 19)
        Me.LabelModificado.Text = "*"
        Me.LabelModificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelInfo
        '
        Me.LabelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelInfo.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(518, 19)
        Me.LabelInfo.Spring = True
        Me.LabelInfo.Text = "LabelInfo"
        Me.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelTamaño
        '
        Me.LabelTamaño.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.LabelTamaño.Name = "LabelTamaño"
        Me.LabelTamaño.Size = New System.Drawing.Size(60, 19)
        Me.LabelTamaño.Text = "4,466 car."
        '
        'LabelFuente
        '
        Me.LabelFuente.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.LabelFuente.Name = "LabelFuente"
        Me.LabelFuente.Size = New System.Drawing.Size(68, 19)
        Me.LabelFuente.Text = "Courier; 10"
        '
        'LabelLenguaje
        '
        Me.LabelLenguaje.AutoSize = False
        Me.LabelLenguaje.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.LabelLenguaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelLenguaje.Name = "LabelLenguaje"
        Me.LabelLenguaje.Size = New System.Drawing.Size(30, 19)
        Me.LabelLenguaje.Text = "C#"
        '
        'LabelPos
        '
        Me.LabelPos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.LabelPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.LabelPos.Name = "LabelPos"
        Me.LabelPos.Size = New System.Drawing.Size(93, 19)
        Me.LabelPos.Text = "Lín: 399  Car: 20"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.rtbCodigo)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compilar para NETCore (WinForms VB)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.StatusContextMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private MenuStrip1 As MenuStrip
    Private FileMenu As ToolStripMenuItem
    Private NewMenu As ToolStripMenuItem
    Private toolSeparator As ToolStripSeparator
    Private toolSeparator1 As ToolStripSeparator
    Private toolSeparator2 As ToolStripSeparator
    Private toolSeparator3 As ToolStripSeparator
    Private toolSeparator4 As ToolStripSeparator
    Private toolSeparator5 As ToolStripSeparator
    Private rtbCodigo As RichTextBox
    Private StatusStrip1 As StatusStrip
    Private LabelInfo As ToolStripStatusLabel
    Private LabelPos As ToolStripStatusLabel
    Private cboLenguajes As ToolStripComboBox
    Private LabelLenguaje As ToolStripStatusLabel
    Private LabelModificado As ToolStripStatusLabel
    Private toolSeparator6 As ToolStripSeparator
    Private toolSeparator7 As ToolStripSeparator
    Private toolSeparator8 As ToolStripSeparator
    Private LabelTamaño As ToolStripStatusLabel
    Private StatusContextMenu As ContextMenuStrip
    Private CopiarPathMenu As ToolStripMenuItem
    Private RecargarFicheroMenu As ToolStripMenuItem
    Private OpenMenu As ToolStripMenuItem
    Private RecargarMenu As ToolStripMenuItem
    Private SaveMenu As ToolStripMenuItem
    Private SaveAsMenu As ToolStripMenuItem
    Private RecientesMenu As ToolStripMenuItem
    Private AboutMenu As ToolStripMenuItem
    Private ExitMenu As ToolStripMenuItem
    Private EditMenu As ToolStripMenuItem
    Private UndoMenu As ToolStripMenuItem
    Private RedoMenu As ToolStripMenuItem
    Private CutMenu As ToolStripMenuItem
    Private CopyMenu As ToolStripMenuItem
    Private PasteMenu As ToolStripMenuItem
    Private SelectAllMenu As ToolStripMenuItem
    Private ToolsMenu As ToolStripMenuItem
    Private CompilarMenu As ToolStripMenuItem
    Private NoColorearMenu As ToolStripMenuItem
    Private ColorearMenu As ToolStripMenuItem
    Private OpcionesMenu As ToolStripMenuItem
    Private FuenteMenu As ToolStripMenuItem
    Private cboFuenteNombre As ToolStripComboBox
    Private cboFuenteTamaño As ToolStripComboBox
    Private FuenteAceptarMenu As ToolStripMenuItem
    Private LabelFuente As ToolStripStatusLabel
End Class
