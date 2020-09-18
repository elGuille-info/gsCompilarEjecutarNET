<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuNew = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRecargar = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.menuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuRecientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuUndo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRedo = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuBuscar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuBuscarSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuReemplazar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuReemplazarSiguiente = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuReemplazarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolEditSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuTools = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCompilar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCompilarEjecutar = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuNoColorear = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuColorear = New System.Windows.Forms.ToolStripMenuItem()
        Me.comboLenguajes = New System.Windows.Forms.ToolStripComboBox()
        Me.toolSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuFuente = New System.Windows.Forms.ToolStripMenuItem()
        Me.comboFuenteNombre = New System.Windows.Forms.ToolStripComboBox()
        Me.comboFuenteTamaño = New System.Windows.Forms.ToolStripComboBox()
        Me.menuFuenteAceptar = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuOpciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.richTextBoxCodigo = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusContextMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuCopiarPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuRecargarFichero = New System.Windows.Forms.ToolStripMenuItem()
        Me.labelModificado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelTamaño = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelFuente = New System.Windows.Forms.ToolStripStatusLabel()
        Me.buttonLenguaje = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuVB = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuCS = New System.Windows.Forms.ToolStripMenuItem()
        Me.labelPos = New System.Windows.Forms.ToolStripStatusLabel()
        Me.richTextBoxtFilas = New System.Windows.Forms.RichTextBox()
        Me.labelBuscar = New System.Windows.Forms.Label()
        Me.comboBuscar = New System.Windows.Forms.ComboBox()
        Me.buttonBuscarSiguiente = New System.Windows.Forms.Button()
        Me.labelSeparator1 = New System.Windows.Forms.Label()
        Me.labelReemplazar = New System.Windows.Forms.Label()
        Me.comboReemplazar = New System.Windows.Forms.ComboBox()
        Me.buttonReemplazarSiguiente = New System.Windows.Forms.Button()
        Me.chkMatchCase = New System.Windows.Forms.CheckBox()
        Me.chkWholeWord = New System.Windows.Forms.CheckBox()
        Me.panelBuscar = New System.Windows.Forms.Panel()
        Me.buttonCerrarPanel = New System.Windows.Forms.Button()
        Me.labelSeparator2 = New System.Windows.Forms.Label()
        Me.buttonReemplazarTodos = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.menuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.StatusContextMenu.SuspendLayout()
        Me.panelBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuFile, Me.menuEdit, Me.menuTools})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "MenuStrip1"
        '
        'menuFile
        '
        Me.menuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuNew, Me.menuOpen, Me.menuRecargar, Me.toolSeparator, Me.menuSave, Me.menuSaveAs, Me.toolSeparator1, Me.menuRecientes, Me.toolSeparator7, Me.menuAbout, Me.toolSeparator2, Me.menuExit})
        Me.menuFile.Name = "menuFile"
        Me.menuFile.Size = New System.Drawing.Size(60, 20)
        Me.menuFile.Text = "&Archivo"
        '
        'menuNew
        '
        Me.menuNew.Image = CType(resources.GetObject("menuNew.Image"), System.Drawing.Image)
        Me.menuNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuNew.Name = "menuNew"
        Me.menuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.menuNew.Size = New System.Drawing.Size(161, 22)
        Me.menuNew.Text = "&Nuevo"
        '
        'menuOpen
        '
        Me.menuOpen.Image = CType(resources.GetObject("menuOpen.Image"), System.Drawing.Image)
        Me.menuOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuOpen.Name = "menuOpen"
        Me.menuOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.menuOpen.Size = New System.Drawing.Size(161, 22)
        Me.menuOpen.Text = "&Abrir..."
        '
        'menuRecargar
        '
        Me.menuRecargar.Image = CType(resources.GetObject("menuRecargar.Image"), System.Drawing.Image)
        Me.menuRecargar.Name = "menuRecargar"
        Me.menuRecargar.Size = New System.Drawing.Size(161, 22)
        Me.menuRecargar.Text = "Recargar fichero"
        Me.menuRecargar.ToolTipText = "Recargar el fichero actual, si se ha modificado, se perderán los cambios"
        '
        'toolSeparator
        '
        Me.toolSeparator.Name = "toolSeparator"
        Me.toolSeparator.Size = New System.Drawing.Size(158, 6)
        '
        'menuSave
        '
        Me.menuSave.Image = CType(resources.GetObject("menuSave.Image"), System.Drawing.Image)
        Me.menuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuSave.Name = "menuSave"
        Me.menuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.menuSave.Size = New System.Drawing.Size(161, 22)
        Me.menuSave.Text = "&Guardar"
        '
        'menuSaveAs
        '
        Me.menuSaveAs.Image = CType(resources.GetObject("menuSaveAs.Image"), System.Drawing.Image)
        Me.menuSaveAs.Name = "menuSaveAs"
        Me.menuSaveAs.Size = New System.Drawing.Size(161, 22)
        Me.menuSaveAs.Text = "Guardar &Cómo..."
        '
        'toolSeparator1
        '
        Me.toolSeparator1.Name = "toolSeparator1"
        Me.toolSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'menuRecientes
        '
        Me.menuRecientes.Image = CType(resources.GetObject("menuRecientes.Image"), System.Drawing.Image)
        Me.menuRecientes.Name = "menuRecientes"
        Me.menuRecientes.Size = New System.Drawing.Size(161, 22)
        Me.menuRecientes.Text = "Recientes..."
        '
        'toolSeparator7
        '
        Me.toolSeparator7.Name = "toolSeparator7"
        Me.toolSeparator7.Size = New System.Drawing.Size(158, 6)
        '
        'menuAbout
        '
        Me.menuAbout.Image = CType(resources.GetObject("menuAbout.Image"), System.Drawing.Image)
        Me.menuAbout.Name = "menuAbout"
        Me.menuAbout.Size = New System.Drawing.Size(161, 22)
        Me.menuAbout.Text = "&Acerca de..."
        '
        'toolSeparator2
        '
        Me.toolSeparator2.Name = "toolSeparator2"
        Me.toolSeparator2.Size = New System.Drawing.Size(158, 6)
        '
        'menuExit
        '
        Me.menuExit.Image = CType(resources.GetObject("menuExit.Image"), System.Drawing.Image)
        Me.menuExit.Name = "menuExit"
        Me.menuExit.Size = New System.Drawing.Size(161, 22)
        Me.menuExit.Text = "Salir"
        '
        'menuEdit
        '
        Me.menuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuUndo, Me.menuRedo, Me.toolSeparator3, Me.menuCut, Me.menuCopy, Me.menuPaste, Me.toolSeparator4, Me.menuBuscar, Me.menuBuscarSiguiente, Me.menuReemplazar, Me.menuReemplazarSiguiente, Me.menuReemplazarTodos, Me.toolEditSeparator3, Me.menuSelectAll})
        Me.menuEdit.Name = "menuEdit"
        Me.menuEdit.Size = New System.Drawing.Size(49, 20)
        Me.menuEdit.Text = "&Editar"
        '
        'menuUndo
        '
        Me.menuUndo.Image = CType(resources.GetObject("menuUndo.Image"), System.Drawing.Image)
        Me.menuUndo.Name = "menuUndo"
        Me.menuUndo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.menuUndo.Size = New System.Drawing.Size(223, 22)
        Me.menuUndo.Text = "&Undo"
        '
        'menuRedo
        '
        Me.menuRedo.Image = CType(resources.GetObject("menuRedo.Image"), System.Drawing.Image)
        Me.menuRedo.Name = "menuRedo"
        Me.menuRedo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.menuRedo.Size = New System.Drawing.Size(223, 22)
        Me.menuRedo.Text = "&Redo"
        '
        'toolSeparator3
        '
        Me.toolSeparator3.Name = "toolSeparator3"
        Me.toolSeparator3.Size = New System.Drawing.Size(220, 6)
        '
        'menuCut
        '
        Me.menuCut.Image = CType(resources.GetObject("menuCut.Image"), System.Drawing.Image)
        Me.menuCut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuCut.Name = "menuCut"
        Me.menuCut.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.menuCut.Size = New System.Drawing.Size(223, 22)
        Me.menuCut.Text = "Cor&tar"
        '
        'menuCopy
        '
        Me.menuCopy.Image = CType(resources.GetObject("menuCopy.Image"), System.Drawing.Image)
        Me.menuCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuCopy.Name = "menuCopy"
        Me.menuCopy.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.menuCopy.Size = New System.Drawing.Size(223, 22)
        Me.menuCopy.Text = "&Copiar"
        '
        'menuPaste
        '
        Me.menuPaste.Image = CType(resources.GetObject("menuPaste.Image"), System.Drawing.Image)
        Me.menuPaste.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuPaste.Name = "menuPaste"
        Me.menuPaste.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.menuPaste.Size = New System.Drawing.Size(223, 22)
        Me.menuPaste.Text = "&Pegar"
        '
        'toolSeparator4
        '
        Me.toolSeparator4.Name = "toolSeparator4"
        Me.toolSeparator4.Size = New System.Drawing.Size(220, 6)
        '
        'menuBuscar
        '
        Me.menuBuscar.Image = CType(resources.GetObject("menuBuscar.Image"), System.Drawing.Image)
        Me.menuBuscar.Name = "menuBuscar"
        Me.menuBuscar.ShortcutKeyDisplayString = "Ctrl+F"
        Me.menuBuscar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.menuBuscar.Size = New System.Drawing.Size(223, 22)
        Me.menuBuscar.Text = "Buscar..."
        '
        'menuBuscarSiguiente
        '
        Me.menuBuscarSiguiente.Image = CType(resources.GetObject("menuBuscarSiguiente.Image"), System.Drawing.Image)
        Me.menuBuscarSiguiente.Name = "menuBuscarSiguiente"
        Me.menuBuscarSiguiente.ShortcutKeyDisplayString = "F3"
        Me.menuBuscarSiguiente.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.menuBuscarSiguiente.Size = New System.Drawing.Size(223, 22)
        Me.menuBuscarSiguiente.Text = "Buscar siguiente"
        '
        'menuReemplazar
        '
        Me.menuReemplazar.Image = CType(resources.GetObject("menuReemplazar.Image"), System.Drawing.Image)
        Me.menuReemplazar.Name = "menuReemplazar"
        Me.menuReemplazar.ShortcutKeyDisplayString = "Ctrl+H"
        Me.menuReemplazar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.menuReemplazar.Size = New System.Drawing.Size(223, 22)
        Me.menuReemplazar.Text = "Reemplazar..."
        '
        'menuReemplazarSiguiente
        '
        Me.menuReemplazarSiguiente.Image = CType(resources.GetObject("menuReemplazarSiguiente.Image"), System.Drawing.Image)
        Me.menuReemplazarSiguiente.Name = "menuReemplazarSiguiente"
        Me.menuReemplazarSiguiente.ShortcutKeyDisplayString = "Alt+R"
        Me.menuReemplazarSiguiente.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.menuReemplazarSiguiente.Size = New System.Drawing.Size(223, 22)
        Me.menuReemplazarSiguiente.Text = "Reemplazar siguiente"
        '
        'menuReemplazarTodos
        '
        Me.menuReemplazarTodos.Image = CType(resources.GetObject("menuReemplazarTodos.Image"), System.Drawing.Image)
        Me.menuReemplazarTodos.Name = "menuReemplazarTodos"
        Me.menuReemplazarTodos.ShortcutKeyDisplayString = "Alt+A"
        Me.menuReemplazarTodos.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.menuReemplazarTodos.Size = New System.Drawing.Size(223, 22)
        Me.menuReemplazarTodos.Text = "Reemplazar todos"
        '
        'toolEditSeparator3
        '
        Me.toolEditSeparator3.Name = "toolEditSeparator3"
        Me.toolEditSeparator3.Size = New System.Drawing.Size(220, 6)
        '
        'menuSelectAll
        '
        Me.menuSelectAll.Image = CType(resources.GetObject("menuSelectAll.Image"), System.Drawing.Image)
        Me.menuSelectAll.Name = "menuSelectAll"
        Me.menuSelectAll.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.menuSelectAll.Size = New System.Drawing.Size(223, 22)
        Me.menuSelectAll.Text = "Seleccion&ar todo"
        '
        'menuTools
        '
        Me.menuTools.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCompilar, Me.menuCompilarEjecutar, Me.toolSeparator5, Me.menuNoColorear, Me.menuColorear, Me.comboLenguajes, Me.toolSeparator6, Me.menuFuente, Me.toolSeparator8, Me.menuOpciones})
        Me.menuTools.Name = "menuTools"
        Me.menuTools.Size = New System.Drawing.Size(90, 20)
        Me.menuTools.Text = "&Herramientas"
        '
        'menuCompilar
        '
        Me.menuCompilar.Image = CType(resources.GetObject("menuCompilar.Image"), System.Drawing.Image)
        Me.menuCompilar.Name = "menuCompilar"
        Me.menuCompilar.ShortcutKeyDisplayString = "Ctrl+B"
        Me.menuCompilar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.menuCompilar.Size = New System.Drawing.Size(235, 22)
        Me.menuCompilar.Text = "Compilar (sin ejecutar)"
        '
        'menuCompilarEjecutar
        '
        Me.menuCompilarEjecutar.Image = CType(resources.GetObject("menuCompilarEjecutar.Image"), System.Drawing.Image)
        Me.menuCompilarEjecutar.Name = "menuCompilarEjecutar"
        Me.menuCompilarEjecutar.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.menuCompilarEjecutar.Size = New System.Drawing.Size(235, 22)
        Me.menuCompilarEjecutar.Text = "C&ompilar y ejecutar"
        '
        'toolSeparator5
        '
        Me.toolSeparator5.Name = "toolSeparator5"
        Me.toolSeparator5.Size = New System.Drawing.Size(232, 6)
        '
        'menuNoColorear
        '
        Me.menuNoColorear.Image = CType(resources.GetObject("menuNoColorear.Image"), System.Drawing.Image)
        Me.menuNoColorear.Name = "menuNoColorear"
        Me.menuNoColorear.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.menuNoColorear.Size = New System.Drawing.Size(235, 22)
        Me.menuNoColorear.Text = "Mostrar sin colorear"
        '
        'menuColorear
        '
        Me.menuColorear.Image = CType(resources.GetObject("menuColorear.Image"), System.Drawing.Image)
        Me.menuColorear.Name = "menuColorear"
        Me.menuColorear.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.menuColorear.Size = New System.Drawing.Size(235, 22)
        Me.menuColorear.Text = "&Colorear"
        '
        'comboLenguajes
        '
        Me.comboLenguajes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboLenguajes.Items.AddRange(New Object() {"C#", "VB"})
        Me.comboLenguajes.Name = "comboLenguajes"
        Me.comboLenguajes.Size = New System.Drawing.Size(121, 23)
        '
        'toolSeparator6
        '
        Me.toolSeparator6.Name = "toolSeparator6"
        Me.toolSeparator6.Size = New System.Drawing.Size(232, 6)
        '
        'menuFuente
        '
        Me.menuFuente.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.comboFuenteNombre, Me.comboFuenteTamaño, Me.menuFuenteAceptar})
        Me.menuFuente.Image = CType(resources.GetObject("menuFuente.Image"), System.Drawing.Image)
        Me.menuFuente.Name = "menuFuente"
        Me.menuFuente.Size = New System.Drawing.Size(235, 22)
        Me.menuFuente.Text = "&Fuente..."
        '
        'comboFuenteNombre
        '
        Me.comboFuenteNombre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFuenteNombre.Items.AddRange(New Object() {"Courier New", "Consolas", "Segoe UI", "Lucida Console", "Arial", "Verdana", "Comic Sans MS"})
        Me.comboFuenteNombre.Name = "comboFuenteNombre"
        Me.comboFuenteNombre.Size = New System.Drawing.Size(121, 23)
        Me.comboFuenteNombre.Text = "Consolas"
        '
        'comboFuenteTamaño
        '
        Me.comboFuenteTamaño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFuenteTamaño.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "13", "14", "16", "18"})
        Me.comboFuenteTamaño.Name = "comboFuenteTamaño"
        Me.comboFuenteTamaño.Size = New System.Drawing.Size(121, 23)
        Me.comboFuenteTamaño.Text = "11"
        '
        'menuFuenteAceptar
        '
        Me.menuFuenteAceptar.Name = "menuFuenteAceptar"
        Me.menuFuenteAceptar.Size = New System.Drawing.Size(235, 22)
        Me.menuFuenteAceptar.Text = "Asignar Fuente: System.Object"
        '
        'toolSeparator8
        '
        Me.toolSeparator8.Name = "toolSeparator8"
        Me.toolSeparator8.Size = New System.Drawing.Size(232, 6)
        '
        'menuOpciones
        '
        Me.menuOpciones.Image = CType(resources.GetObject("menuOpciones.Image"), System.Drawing.Image)
        Me.menuOpciones.Name = "menuOpciones"
        Me.menuOpciones.ShortcutKeyDisplayString = "F10"
        Me.menuOpciones.ShortcutKeys = System.Windows.Forms.Keys.F10
        Me.menuOpciones.Size = New System.Drawing.Size(235, 22)
        Me.menuOpciones.Text = "Opciones..."
        '
        'richTextBoxCodigo
        '
        Me.richTextBoxCodigo.AcceptsTab = True
        Me.richTextBoxCodigo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.richTextBoxCodigo.DetectUrls = False
        Me.richTextBoxCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.richTextBoxCodigo.HideSelection = False
        Me.richTextBoxCodigo.Location = New System.Drawing.Point(43, 55)
        Me.richTextBoxCodigo.Name = "richTextBoxCodigo"
        Me.richTextBoxCodigo.Size = New System.Drawing.Size(750, 368)
        Me.richTextBoxCodigo.TabIndex = 1
        Me.richTextBoxCodigo.Text = ""
        Me.richTextBoxCodigo.WordWrap = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ContextMenuStrip = Me.StatusContextMenu
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelModificado, Me.labelInfo, Me.labelTamaño, Me.labelFuente, Me.buttonLenguaje, Me.labelPos})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 426)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 24)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusContextMenu
        '
        Me.StatusContextMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuCopiarPath, Me.menuRecargarFichero})
        Me.StatusContextMenu.Name = "StatusContextMenu"
        Me.StatusContextMenu.Size = New System.Drawing.Size(309, 48)
        '
        'menuCopiarPath
        '
        Me.menuCopiarPath.Image = CType(resources.GetObject("menuCopiarPath.Image"), System.Drawing.Image)
        Me.menuCopiarPath.Name = "menuCopiarPath"
        Me.menuCopiarPath.Size = New System.Drawing.Size(308, 22)
        Me.menuCopiarPath.Text = "Copiar PATH completo"
        Me.menuCopiarPath.ToolTipText = "Copia en el portapapeles la ruta completa del fichero actual"
        '
        'menuRecargarFichero
        '
        Me.menuRecargarFichero.Image = CType(resources.GetObject("menuRecargarFichero.Image"), System.Drawing.Image)
        Me.menuRecargarFichero.Name = "menuRecargarFichero"
        Me.menuRecargarFichero.Size = New System.Drawing.Size(308, 22)
        Me.menuRecargarFichero.Text = "Recargar el fichero (sin guardar los cambios)"
        Me.menuRecargarFichero.ToolTipText = "Abre nuevamente el fichero actual desechando los cambios realizados"
        '
        'labelModificado
        '
        Me.labelModificado.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.labelModificado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.labelModificado.Name = "labelModificado"
        Me.labelModificado.Size = New System.Drawing.Size(16, 19)
        Me.labelModificado.Text = "*"
        Me.labelModificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelInfo
        '
        Me.labelInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.labelInfo.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.labelInfo.Name = "labelInfo"
        Me.labelInfo.Size = New System.Drawing.Size(507, 19)
        Me.labelInfo.Spring = True
        Me.labelInfo.Text = "LabelInfo"
        Me.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelTamaño
        '
        Me.labelTamaño.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.labelTamaño.Name = "labelTamaño"
        Me.labelTamaño.Size = New System.Drawing.Size(60, 19)
        Me.labelTamaño.Text = "4,466 car."
        '
        'labelFuente
        '
        Me.labelFuente.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.labelFuente.Name = "labelFuente"
        Me.labelFuente.Size = New System.Drawing.Size(77, 19)
        Me.labelFuente.Text = "Consolas; 10"
        '
        'buttonLenguaje
        '
        Me.buttonLenguaje.AutoToolTip = False
        Me.buttonLenguaje.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonLenguaje.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuVB, Me.menuCS})
        Me.buttonLenguaje.Image = CType(resources.GetObject("buttonLenguaje.Image"), System.Drawing.Image)
        Me.buttonLenguaje.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonLenguaje.Name = "buttonLenguaje"
        Me.buttonLenguaje.Size = New System.Drawing.Size(32, 22)
        Me.buttonLenguaje.Text = "Lenguajes"
        Me.buttonLenguaje.ToolTipText = "Lenguajes"
        '
        'menuVB
        '
        Me.menuVB.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.menuVB.Image = CType(resources.GetObject("menuVB.Image"), System.Drawing.Image)
        Me.menuVB.Name = "menuVB"
        Me.menuVB.Size = New System.Drawing.Size(89, 22)
        Me.menuVB.Text = "VB"
        '
        'menuCS
        '
        Me.menuCS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.menuCS.Image = CType(resources.GetObject("menuCS.Image"), System.Drawing.Image)
        Me.menuCS.Name = "menuCS"
        Me.menuCS.Size = New System.Drawing.Size(89, 22)
        Me.menuCS.Text = "C#"
        '
        'labelPos
        '
        Me.labelPos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.labelPos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.labelPos.Name = "labelPos"
        Me.labelPos.Size = New System.Drawing.Size(93, 19)
        Me.labelPos.Text = "Lín: 399  Car: 20"
        '
        'richTextBoxtFilas
        '
        Me.richTextBoxtFilas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.richTextBoxtFilas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.richTextBoxtFilas.CausesValidation = False
        Me.richTextBoxtFilas.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.richTextBoxtFilas.Location = New System.Drawing.Point(3, 55)
        Me.richTextBoxtFilas.Name = "richTextBoxtFilas"
        Me.richTextBoxtFilas.ReadOnly = True
        Me.richTextBoxtFilas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.richTextBoxtFilas.ShortcutsEnabled = False
        Me.richTextBoxtFilas.Size = New System.Drawing.Size(39, 368)
        Me.richTextBoxtFilas.TabIndex = 3
        Me.richTextBoxtFilas.TabStop = False
        Me.richTextBoxtFilas.Text = ""
        '
        'labelBuscar
        '
        Me.labelBuscar.Location = New System.Drawing.Point(3, 1)
        Me.labelBuscar.Name = "labelBuscar"
        Me.labelBuscar.Size = New System.Drawing.Size(42, 22)
        Me.labelBuscar.TabIndex = 0
        Me.labelBuscar.Text = "Buscar"
        Me.labelBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboBuscar
        '
        Me.comboBuscar.Location = New System.Drawing.Point(51, 3)
        Me.comboBuscar.Name = "comboBuscar"
        Me.comboBuscar.Size = New System.Drawing.Size(100, 23)
        Me.comboBuscar.TabIndex = 1
        '
        'buttonBuscarSiguiente
        '
        Me.buttonBuscarSiguiente.Image = CType(resources.GetObject("buttonBuscarSiguiente.Image"), System.Drawing.Image)
        Me.buttonBuscarSiguiente.Location = New System.Drawing.Point(416, 3)
        Me.buttonBuscarSiguiente.Name = "buttonBuscarSiguiente"
        Me.buttonBuscarSiguiente.Size = New System.Drawing.Size(23, 22)
        Me.buttonBuscarSiguiente.TabIndex = 7
        Me.ToolTip1.SetToolTip(Me.buttonBuscarSiguiente, "Buscar siguiente (F3)")
        '
        'labelSeparator1
        '
        Me.labelSeparator1.Location = New System.Drawing.Point(395, 1)
        Me.labelSeparator1.Name = "labelSeparator1"
        Me.labelSeparator1.Size = New System.Drawing.Size(15, 25)
        Me.labelSeparator1.TabIndex = 6
        Me.labelSeparator1.Text = " | "
        Me.labelSeparator1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'labelReemplazar
        '
        Me.labelReemplazar.Location = New System.Drawing.Point(157, 1)
        Me.labelReemplazar.Name = "labelReemplazar"
        Me.labelReemplazar.Size = New System.Drawing.Size(68, 22)
        Me.labelReemplazar.TabIndex = 2
        Me.labelReemplazar.Text = "Reemplazar"
        Me.labelReemplazar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'comboReemplazar
        '
        Me.comboReemplazar.Location = New System.Drawing.Point(231, 3)
        Me.comboReemplazar.Name = "comboReemplazar"
        Me.comboReemplazar.Size = New System.Drawing.Size(100, 23)
        Me.comboReemplazar.TabIndex = 3
        '
        'buttonReemplazarSiguiente
        '
        Me.buttonReemplazarSiguiente.Image = CType(resources.GetObject("buttonReemplazarSiguiente.Image"), System.Drawing.Image)
        Me.buttonReemplazarSiguiente.Location = New System.Drawing.Point(466, 3)
        Me.buttonReemplazarSiguiente.Name = "buttonReemplazarSiguiente"
        Me.buttonReemplazarSiguiente.Size = New System.Drawing.Size(23, 22)
        Me.buttonReemplazarSiguiente.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.buttonReemplazarSiguiente, "Reemplazar siguiente (Alt+R)")
        '
        'chkMatchCase
        '
        Me.chkMatchCase.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMatchCase.Image = CType(resources.GetObject("chkMatchCase.Image"), System.Drawing.Image)
        Me.chkMatchCase.Location = New System.Drawing.Point(337, 3)
        Me.chkMatchCase.Name = "chkMatchCase"
        Me.chkMatchCase.Size = New System.Drawing.Size(23, 22)
        Me.chkMatchCase.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.chkMatchCase, "Distinguir mayúsculas de minúsculas")
        '
        'chkWholeWord
        '
        Me.chkWholeWord.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkWholeWord.Image = CType(resources.GetObject("chkWholeWord.Image"), System.Drawing.Image)
        Me.chkWholeWord.Location = New System.Drawing.Point(366, 3)
        Me.chkWholeWord.Name = "chkWholeWord"
        Me.chkWholeWord.Size = New System.Drawing.Size(23, 22)
        Me.chkWholeWord.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.chkWholeWord, "Palabra completa")
        '
        'panelBuscar
        '
        Me.panelBuscar.Controls.Add(Me.buttonCerrarPanel)
        Me.panelBuscar.Controls.Add(Me.labelSeparator2)
        Me.panelBuscar.Controls.Add(Me.buttonReemplazarTodos)
        Me.panelBuscar.Controls.Add(Me.labelBuscar)
        Me.panelBuscar.Controls.Add(Me.comboBuscar)
        Me.panelBuscar.Controls.Add(Me.buttonBuscarSiguiente)
        Me.panelBuscar.Controls.Add(Me.labelSeparator1)
        Me.panelBuscar.Controls.Add(Me.labelReemplazar)
        Me.panelBuscar.Controls.Add(Me.comboReemplazar)
        Me.panelBuscar.Controls.Add(Me.buttonReemplazarSiguiente)
        Me.panelBuscar.Controls.Add(Me.chkMatchCase)
        Me.panelBuscar.Controls.Add(Me.chkWholeWord)
        Me.panelBuscar.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelBuscar.Location = New System.Drawing.Point(0, 24)
        Me.panelBuscar.Name = "panelBuscar"
        Me.panelBuscar.Size = New System.Drawing.Size(800, 27)
        Me.panelBuscar.TabIndex = 5
        '
        'buttonCerrarPanel
        '
        Me.buttonCerrarPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonCerrarPanel.Image = CType(resources.GetObject("buttonCerrarPanel.Image"), System.Drawing.Image)
        Me.buttonCerrarPanel.Location = New System.Drawing.Point(776, 3)
        Me.buttonCerrarPanel.Name = "buttonCerrarPanel"
        Me.buttonCerrarPanel.Size = New System.Drawing.Size(23, 22)
        Me.buttonCerrarPanel.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.buttonCerrarPanel, "Ocultar el panel de búsqueda")
        '
        'labelSeparator2
        '
        Me.labelSeparator2.Location = New System.Drawing.Point(445, 1)
        Me.labelSeparator2.Name = "labelSeparator2"
        Me.labelSeparator2.Size = New System.Drawing.Size(15, 25)
        Me.labelSeparator2.TabIndex = 8
        Me.labelSeparator2.Text = " | "
        Me.labelSeparator2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonReemplazarTodos
        '
        Me.buttonReemplazarTodos.Image = CType(resources.GetObject("buttonReemplazarTodos.Image"), System.Drawing.Image)
        Me.buttonReemplazarTodos.Location = New System.Drawing.Point(495, 3)
        Me.buttonReemplazarTodos.Name = "buttonReemplazarTodos"
        Me.buttonReemplazarTodos.Size = New System.Drawing.Size(23, 22)
        Me.buttonReemplazarTodos.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.buttonReemplazarTodos, "Reemplazar todos (Alt+A)")
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.panelBuscar)
        Me.Controls.Add(Me.richTextBoxtFilas)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.richTextBoxCodigo)
        Me.Controls.Add(Me.menuStrip1)
        Me.MainMenuStrip = Me.menuStrip1
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Compilar para NETCore (WinForms VB)"
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.StatusContextMenu.ResumeLayout(False)
        Me.panelBuscar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents menuStrip1 As MenuStrip
    Private WithEvents menuFile As ToolStripMenuItem
    Private WithEvents menuNew As ToolStripMenuItem
    Private WithEvents toolSeparator As ToolStripSeparator
    Private WithEvents toolSeparator1 As ToolStripSeparator
    Private WithEvents toolSeparator2 As ToolStripSeparator
    Private WithEvents toolSeparator3 As ToolStripSeparator
    Private WithEvents toolSeparator4 As ToolStripSeparator
    Private WithEvents toolSeparator5 As ToolStripSeparator
    Private WithEvents richTextBoxCodigo As RichTextBox
    Private WithEvents StatusStrip1 As StatusStrip
    Private WithEvents labelModificado As ToolStripStatusLabel
    Private WithEvents toolSeparator6 As ToolStripSeparator
    Private WithEvents toolSeparator7 As ToolStripSeparator
    Private WithEvents toolSeparator8 As ToolStripSeparator
    Private WithEvents StatusContextMenu As ContextMenuStrip
    Private WithEvents menuCopiarPath As ToolStripMenuItem
    Private WithEvents menuUndo As ToolStripMenuItem
    Private WithEvents menuCompilar As ToolStripMenuItem
    Private WithEvents menuNoColorear As ToolStripMenuItem
    Private WithEvents comboFuenteNombre As ToolStripComboBox
    Private WithEvents comboFuenteTamaño As ToolStripComboBox
    Private WithEvents menuFuenteAceptar As ToolStripMenuItem
    Private WithEvents richTextBoxtFilas As RichTextBox
    Private WithEvents labelBuscar As Label
    Private WithEvents comboBuscar As ComboBox
    Private WithEvents buttonBuscarSiguiente As Button
    Private WithEvents labelSeparator1 As Label
    Private WithEvents labelReemplazar As Label
    Private WithEvents comboReemplazar As ComboBox
    Private WithEvents buttonReemplazarSiguiente As Button
    Private WithEvents chkMatchCase As CheckBox
    Private WithEvents chkWholeWord As CheckBox
    Private WithEvents toolEditSeparator3 As ToolStripSeparator
    Private WithEvents panelBuscar As Panel
    Private WithEvents buttonReemplazarTodos As Button
    Private WithEvents ToolTip1 As ToolTip
    Private WithEvents labelSeparator2 As Label
    Private WithEvents buttonCerrarPanel As Button
    Private WithEvents labelInfo As ToolStripStatusLabel
    Private WithEvents labelPos As ToolStripStatusLabel
    Private WithEvents labelTamaño As ToolStripStatusLabel
    Private WithEvents labelFuente As ToolStripStatusLabel
    Private WithEvents menuEdit As ToolStripMenuItem
    Private WithEvents menuTools As ToolStripMenuItem
    Private WithEvents menuOpen As ToolStripMenuItem
    Private WithEvents menuRecargar As ToolStripMenuItem
    Private WithEvents menuSave As ToolStripMenuItem
    Private WithEvents menuSaveAs As ToolStripMenuItem
    Private WithEvents menuRecientes As ToolStripMenuItem
    Private WithEvents menuAbout As ToolStripMenuItem
    Private WithEvents menuExit As ToolStripMenuItem
    Private WithEvents menuRedo As ToolStripMenuItem
    Private WithEvents menuCut As ToolStripMenuItem
    Private WithEvents menuCopy As ToolStripMenuItem
    Private WithEvents menuPaste As ToolStripMenuItem
    Private WithEvents menuBuscar As ToolStripMenuItem
    Private WithEvents menuBuscarSiguiente As ToolStripMenuItem
    Private WithEvents menuReemplazar As ToolStripMenuItem
    Private WithEvents menuReemplazarSiguiente As ToolStripMenuItem
    Private WithEvents menuReemplazarTodos As ToolStripMenuItem
    Private WithEvents menuSelectAll As ToolStripMenuItem
    Private WithEvents menuCompilarEjecutar As ToolStripMenuItem
    Private WithEvents menuColorear As ToolStripMenuItem
    Private WithEvents comboLenguajes As ToolStripComboBox
    Private WithEvents menuFuente As ToolStripMenuItem
    Private WithEvents menuOpciones As ToolStripMenuItem
    Private WithEvents menuRecargarFichero As ToolStripMenuItem
    Private WithEvents buttonLenguaje As ToolStripSplitButton
    Private WithEvents menuVB As ToolStripMenuItem
    Private WithEvents menuCS As ToolStripMenuItem
End Class
