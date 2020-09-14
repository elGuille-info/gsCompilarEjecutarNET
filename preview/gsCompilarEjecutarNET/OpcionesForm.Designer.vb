<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OpcionesForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFic = New System.Windows.Forms.TextBox()
        Me.btnOrdenar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.lstFics = New System.Windows.Forms.ListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.chkCargarUltimo = New System.Windows.Forms.CheckBox()
        Me.chkColorearCargar = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtFic)
        Me.GroupBox1.Controls.Add(Me.btnOrdenar)
        Me.GroupBox1.Controls.Add(Me.btnQuitar)
        Me.GroupBox1.Controls.Add(Me.lstFics)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 229)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista de ficheros abiertos recientemente"
        '
        'txtFic
        '
        Me.txtFic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFic.Location = New System.Drawing.Point(6, 200)
        Me.txtFic.Name = "txtFic"
        Me.txtFic.Size = New System.Drawing.Size(266, 23)
        Me.txtFic.TabIndex = 2
        '
        'btnOrdenar
        '
        Me.btnOrdenar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOrdenar.Location = New System.Drawing.Point(278, 199)
        Me.btnOrdenar.Name = "btnOrdenar"
        Me.btnOrdenar.Size = New System.Drawing.Size(75, 23)
        Me.btnOrdenar.TabIndex = 3
        Me.btnOrdenar.Text = "Ordenar"
        Me.btnOrdenar.UseVisualStyleBackColor = True
        '
        'btnQuitar
        '
        Me.btnQuitar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnQuitar.AutoSize = True
        Me.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnQuitar.Location = New System.Drawing.Point(359, 198)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(127, 25)
        Me.btnQuitar.TabIndex = 4
        Me.btnQuitar.Text = "Quitar seleccionados"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'lstFics
        '
        Me.lstFics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstFics.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lstFics.FormattingEnabled = True
        Me.lstFics.ItemHeight = 14
        Me.lstFics.Location = New System.Drawing.Point(6, 45)
        Me.lstFics.Name = "lstFics"
        Me.lstFics.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstFics.Size = New System.Drawing.Size(480, 144)
        Me.lstFics.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(480, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Selecciona los que quieras borrar o clasifícalos usando los botones"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(429, 276)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Location = New System.Drawing.Point(348, 276)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'chkCargarUltimo
        '
        Me.chkCargarUltimo.AutoSize = True
        Me.chkCargarUltimo.Location = New System.Drawing.Point(18, 241)
        Me.chkCargarUltimo.Name = "chkCargarUltimo"
        Me.chkCargarUltimo.Size = New System.Drawing.Size(233, 19)
        Me.chkCargarUltimo.TabIndex = 1
        Me.chkCargarUltimo.Text = "Al iniciar cargar el último fichero &usado"
        Me.chkCargarUltimo.UseVisualStyleBackColor = True
        '
        'chkColorearCargar
        '
        Me.chkColorearCargar.AutoSize = True
        Me.chkColorearCargar.Location = New System.Drawing.Point(18, 266)
        Me.chkColorearCargar.Name = "chkColorearCargar"
        Me.chkColorearCargar.Size = New System.Drawing.Size(171, 19)
        Me.chkColorearCargar.TabIndex = 2
        Me.chkColorearCargar.Text = "&Colorear al cargar el fichero"
        Me.chkColorearCargar.UseVisualStyleBackColor = True
        '
        'OpcionesForm
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(516, 311)
        Me.Controls.Add(Me.chkColorearCargar)
        Me.Controls.Add(Me.chkCargarUltimo)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(410, 320)
        Me.Name = "OpcionesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private GroupBox1 As GroupBox
    Private btnQuitar As Button
    Private lstFics As ListBox
    Private Label1 As Label
    Private btnCancelar As Button
    Private btnAceptar As Button
    Private btnOrdenar As Button
    Private txtFic As TextBox
    Private chkCargarUltimo As CheckBox
    Private chkColorearCargar As CheckBox
End Class
