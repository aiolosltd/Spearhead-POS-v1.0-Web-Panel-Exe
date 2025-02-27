Imports Guna.UI2.WinForms
Public Class MDI_FORM
    Private ReadOnly _userform As UserFrm
    Private ReadOnly _childForms As New Dictionary(Of Type, Form)
    Private ReadOnly _formFactory As New Dictionary(Of Type, Func(Of Form))
    Private ReadOnly _mdiClient As MdiClient
    Private _currentChildForm As Form

    Public Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.UserPaint Or
                ControlStyles.OptimizedDoubleBuffer Or
                ControlStyles.ResizeRedraw, True)

        Me.FormBorderStyle = FormBorderStyle.None
        Me.ShowInTaskbar = True

        InitializeComponent()
        InitializeFormFactory()
        _mdiClient = GetMdiClient()
        SetupDoubleBuffering()
        SetupMDIProperties()
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.ExStyle = cp.ExStyle Or &H2000000
            Return cp
        End Get
    End Property
    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        Me.UpdateStyles()
    End Sub


    Private Sub InitializeFormFactory()
        _formFactory.Add(GetType(UserFrm), Function() New UserFrm())
        _formFactory.Add(GetType(ProductsFrm), Function() New ProductsFrm())
        _formFactory.Add(GetType(CategoryFrm), Function() New CategoryFrm())
        _formFactory.Add(GetType(ActivationFrm), Function() New ActivationFrm())
        _formFactory.Add(GetType(OutletHeaderFrm), Function() New OutletHeaderFrm())
        _formFactory.Add(GetType(ReceiptSettings), Function() New ReceiptSettings())
        _formFactory.Add(GetType(ReceiptDetailsFrm), Function() New ReceiptDetailsFrm())
        _formFactory.Add(GetType(CouponFrm), Function() New CouponFrm())
        _formFactory.Add(GetType(InventoryFrm), Function() New InventoryFrm())
        _formFactory.Add(GetType(PaymentMethodFrm), Function() New PaymentMethodFrm())
        _formFactory.Add(GetType(ModifiersFrm), Function() New ModifiersFrm())
        _formFactory.Add(GetType(SettingsFrm), Function() New SettingsFrm())
        _formFactory.Add(GetType(ScriptRunnerFrm), Function() New ScriptRunnerFrm())
    End Sub

    Private Sub MDI_FORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupMDIProperties()
        ShowFormOfType(Of UserFrm)()
    End Sub

    Private Sub SetupMDIProperties()
        Me.SuspendLayout()
        Me.IsMdiContainer = True
        Me.ControlBox = False
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Normal
        Me.BackColor = Color.FromArgb(45, 45, 45)

        If _mdiClient IsNot Nothing Then
            _mdiClient.BackColor = Me.BackColor
        End If

        Me.Padding = New Padding(0)
        Me.Margin = New Padding(0)
        Me.ResumeLayout()
    End Sub

    Private Sub SetupDoubleBuffering()
        SetStyle(ControlStyles.DoubleBuffer Or
                ControlStyles.UserPaint Or
                ControlStyles.AllPaintingInWmPaint Or
                ControlStyles.OptimizedDoubleBuffer, True)

        If _mdiClient IsNot Nothing Then
            _mdiClient.BackColor = Me.BackColor
            Dim mdiClientType As Type = _mdiClient.GetType()
            Dim pi As System.Reflection.PropertyInfo = mdiClientType.GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.NonPublic)
            pi.SetValue(_mdiClient, True, Nothing)
        End If
    End Sub

    Private Function GetMdiClient() As MdiClient
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                Return DirectCast(ctl, MdiClient)
            End If
        Next
        Return Nothing
    End Function

    Public Sub ShowChildForm(childForm As Form)
        Try
            Me.SuspendLayout()

            If _currentChildForm IsNot Nothing AndAlso Not _currentChildForm.IsDisposed Then
                _currentChildForm.Hide()
                _currentChildForm.Close()
                _currentChildForm.Dispose()
            End If

            _currentChildForm = childForm
            With childForm
                .MdiParent = Me
                .ControlBox = False
                .WindowState = FormWindowState.Normal
                .FormBorderStyle = FormBorderStyle.None
                .Dock = DockStyle.Fill
                .Show()
            End With

            Me.ResumeLayout()
        Catch ex As Exception
            MessageBox.Show($"Error opening form: {ex.Message}")
        End Try
    End Sub

    Public Sub ShowFormOfType(Of T As {Form, New})()
        Try
            Dim formType As Type = GetType(T)
            If _formFactory.ContainsKey(formType) Then
                ShowChildForm(_formFactory(formType).Invoke())
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating form: {ex.Message}", "Error",
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MDI_FORM_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If _currentChildForm IsNot Nothing Then
            _currentChildForm.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        ShowFormOfType(Of UserFrm)()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        ShowFormOfType(Of ProductsFrm)()
    End Sub

    Private Sub Guna2Button3_Click(sender As Object, e As EventArgs) Handles Guna2Button3.Click
        ShowFormOfType(Of CategoryFrm)()
    End Sub

    Private Sub Guna2Button4_Click(sender As Object, e As EventArgs) Handles Guna2Button4.Click
        ShowFormOfType(Of ActivationFrm)()
    End Sub

    Private Sub Guna2Button5_Click(sender As Object, e As EventArgs) Handles Guna2Button5.Click
        ShowFormOfType(Of OutletHeaderFrm)()
    End Sub

    Private Sub Guna2Button6_Click(sender As Object, e As EventArgs) Handles Guna2Button6.Click
        ShowFormOfType(Of ReceiptSettings)()
    End Sub

    Private Sub Guna2Button8_Click(sender As Object, e As EventArgs) Handles Guna2Button8.Click
        ShowFormOfType(Of ReceiptDetailsFrm)()
    End Sub

    Private Sub Guna2Button9_Click(sender As Object, e As EventArgs) Handles Guna2Button9.Click
        ShowFormOfType(Of CouponFrm)()
    End Sub

    Private Sub Guna2Button10_Click(sender As Object, e As EventArgs) Handles Guna2Button10.Click
        ShowFormOfType(Of InventoryFrm)()
    End Sub

    Private Sub Guna2Button14_Click(sender As Object, e As EventArgs) Handles Guna2Button14.Click
        ShowFormOfType(Of PaymentMethodFrm)()
    End Sub

    Private Sub Guna2Button16_Click(sender As Object, e As EventArgs) Handles Guna2Button16.Click
        ShowFormOfType(Of ModifiersFrm)()

    End Sub

    Private Sub Guna2Button13_Click(sender As Object, e As EventArgs) Handles Guna2Button13.Click
        ShowFormOfType(Of SettingsFrm)()
    End Sub

    Private Sub Guna2Button2_Click(sender As Object, e As EventArgs) Handles Guna2Button2.Click
        ShowFormOfType(Of ScriptRunnerFrm)()

    End Sub
End Class