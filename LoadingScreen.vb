Public Class LoadingScreen
    Private WithEvents loadTimer As New Timer()

    Private Sub LoadingScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup timer
        loadTimer.Interval = 16
        Guna2CircleProgressBar1.Value = 0
        loadTimer.Start()
    End Sub

    Private Sub LoadTimer_Tick(sender As Object, e As EventArgs) Handles loadTimer.Tick
        Guna2CircleProgressBar1.Value += 1
        Dim percentage As Integer = (Guna2CircleProgressBar1.Value * 100) \ Guna2CircleProgressBar1.Maximum
        lblCount.Text = percentage.ToString() & "%"

        Select Case Guna2CircleProgressBar1.Value
            Case 20
                lblStatus.Text = "Initializing..."
            Case 40
                lblStatus.Text = "Loading components..."
            Case 60
                lblStatus.Text = "Preparing interface..."
            Case 80
                lblStatus.Text = "Almost ready..."
            Case 100
                loadTimer.Stop()
                OpenMainForm()
        End Select
    End Sub

    Private Sub OpenMainForm()
        Try
            Dim mainForm As New MDI_FORM()
            mainForm.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Error opening main form: " & ex.Message, "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If loadTimer IsNot Nothing Then
            loadTimer.Stop()
            loadTimer.Dispose()
        End If
    End Sub
End Class