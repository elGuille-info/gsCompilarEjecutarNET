Public Class OpcionesForm

    Public CargarUltimo As Boolean
    Public ColorearAlCargar As Boolean

    Public Sub New(colFics As List(Of String))

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.ColFics.AddRange(colFics)

    End Sub

    Public Property ColFics As New List(Of String)

    Private Sub OpcionesForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        chkCargarUltimo.Checked = CargarUltimo
        chkColorearCargar.Checked = ColorearAlCargar
        AñadirEventos()
        AsignarItems()

    End Sub

    Private Sub OpcionesForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If e.CloseReason = CloseReason.UserClosing Then
            Me.DialogResult = DialogResult.Cancel
        End If
    End Sub

    Private Sub AsignarItems()
        lstFics.Items.Clear()
        For i = 0 To ColFics.Count - 1
            lstFics.Items.Add(ColFics(i))
        Next
    End Sub

    Private Sub AñadirEventos()
        AddHandler lstFics.KeyDown, AddressOf lstFics_KeyDown
        AddHandler btnCancelar.Click, Sub() Me.DialogResult = DialogResult.Cancel
        AddHandler btnAceptar.Click, Sub()
                                         Me.CargarUltimo = chkCargarUltimo.Checked
                                         Me.ColorearAlCargar = chkColorearCargar.Checked
                                         Me.DialogResult = DialogResult.OK
                                     End Sub
        AddHandler btnQuitar.Click, Sub() QuitarSeleccionados()
        AddHandler btnOrdenar.Click, Sub()
                                         ColFics.Sort()
                                         AsignarItems()
                                     End Sub
        AddHandler lstFics.SelectedIndexChanged, Sub() txtFic.Text = If(lstFics.SelectedItem Is Nothing, txtFic.Text, lstFics.SelectedItem.ToString)

    End Sub

    Private Sub lstFics_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
            QuitarSeleccionados()
        End If
    End Sub

    Private Sub QuitarSeleccionados()
        If lstFics.SelectedIndices.Count = 0 Then Return
        For i = lstFics.SelectedIndices.Count - 1 To 0 Step -1
            lstFics.Items.RemoveAt(lstFics.SelectedIndices(i))
        Next
        ColFics.Clear()
        For i = 0 To lstFics.Items.Count - 1
            ColFics.Add(lstFics.Items(i).ToString)
        Next
    End Sub

End Class