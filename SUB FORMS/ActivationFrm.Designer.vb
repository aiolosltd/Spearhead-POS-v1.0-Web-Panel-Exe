<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ActivationFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.btnNewActivation = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveActivation = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteActivation = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.txtClientContact = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.txtClientName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSubTerminalCount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtTerminalCount = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtEmail = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.dgvActivation = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvActivation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator1.TabIndex = 105
        '
        'btnNewActivation
        '
        Me.btnNewActivation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNewActivation.BorderRadius = 5
        Me.btnNewActivation.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnNewActivation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnNewActivation.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnNewActivation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnNewActivation.FillColor = System.Drawing.Color.DarkGreen
        Me.btnNewActivation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewActivation.ForeColor = System.Drawing.Color.White
        Me.btnNewActivation.Location = New System.Drawing.Point(439, 11)
        Me.btnNewActivation.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewActivation.Name = "btnNewActivation"
        Me.btnNewActivation.Size = New System.Drawing.Size(175, 47)
        Me.btnNewActivation.TabIndex = 93
        Me.btnNewActivation.Text = "Clear Fields"
        '
        'btnSaveActivation
        '
        Me.btnSaveActivation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveActivation.BorderRadius = 5
        Me.btnSaveActivation.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveActivation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveActivation.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveActivation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveActivation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveActivation.ForeColor = System.Drawing.Color.White
        Me.btnSaveActivation.Location = New System.Drawing.Point(622, 11)
        Me.btnSaveActivation.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveActivation.Name = "btnSaveActivation"
        Me.btnSaveActivation.Size = New System.Drawing.Size(175, 47)
        Me.btnSaveActivation.TabIndex = 91
        Me.btnSaveActivation.Text = "Save Activation"
        '
        'btnDeleteActivation
        '
        Me.btnDeleteActivation.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteActivation.BorderRadius = 5
        Me.btnDeleteActivation.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteActivation.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteActivation.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteActivation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteActivation.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteActivation.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteActivation.ForeColor = System.Drawing.Color.White
        Me.btnDeleteActivation.Location = New System.Drawing.Point(256, 11)
        Me.btnDeleteActivation.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteActivation.Name = "btnDeleteActivation"
        Me.btnDeleteActivation.Size = New System.Drawing.Size(175, 47)
        Me.btnDeleteActivation.TabIndex = 92
        Me.btnDeleteActivation.Text = "Delete User"
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator3.TabIndex = 105
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Controls.Add(Me.Label111)
        Me.Panel3.Controls.Add(Me.txtClientContact)
        Me.Panel3.Controls.Add(Me.Label110)
        Me.Panel3.Controls.Add(Me.txtClientName)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.txtSubTerminalCount)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txtTerminalCount)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.txtEmail)
        Me.Panel3.Controls.Add(Me.Guna2Separator3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 442)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1024, 261)
        Me.Panel3.TabIndex = 23
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label111.Location = New System.Drawing.Point(341, 106)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(55, 17)
        Me.Label111.TabIndex = 115
        Me.Label111.Text = "Contact"
        '
        'txtClientContact
        '
        Me.txtClientContact.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtClientContact.BorderRadius = 5
        Me.txtClientContact.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClientContact.DefaultText = ""
        Me.txtClientContact.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtClientContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtClientContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClientContact.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClientContact.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtClientContact.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtClientContact.ForeColor = System.Drawing.Color.Black
        Me.txtClientContact.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtClientContact.Location = New System.Drawing.Point(341, 126)
        Me.txtClientContact.Name = "txtClientContact"
        Me.txtClientContact.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtClientContact.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtClientContact.PlaceholderText = ""
        Me.txtClientContact.SelectedText = ""
        Me.txtClientContact.Size = New System.Drawing.Size(273, 40)
        Me.txtClientContact.TabIndex = 114
        Me.txtClientContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label110.Location = New System.Drawing.Point(341, 21)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(105, 17)
        Me.Label110.TabIndex = 113
        Me.Label110.Text = "Client Full name"
        '
        'txtClientName
        '
        Me.txtClientName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtClientName.BorderRadius = 5
        Me.txtClientName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtClientName.DefaultText = ""
        Me.txtClientName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtClientName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtClientName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClientName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtClientName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtClientName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtClientName.ForeColor = System.Drawing.Color.Black
        Me.txtClientName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtClientName.Location = New System.Drawing.Point(344, 46)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtClientName.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtClientName.PlaceholderText = ""
        Me.txtClientName.SelectedText = ""
        Me.txtClientName.Size = New System.Drawing.Size(273, 40)
        Me.txtClientName.TabIndex = 112
        Me.txtClientName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(17, 185)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(123, 17)
        Me.Label16.TabIndex = 111
        Me.Label16.Text = "SubTerminal Count"
        '
        'txtSubTerminalCount
        '
        Me.txtSubTerminalCount.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSubTerminalCount.BorderRadius = 5
        Me.txtSubTerminalCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSubTerminalCount.DefaultText = "0"
        Me.txtSubTerminalCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSubTerminalCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSubTerminalCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSubTerminalCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSubTerminalCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSubTerminalCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtSubTerminalCount.ForeColor = System.Drawing.Color.Black
        Me.txtSubTerminalCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSubTerminalCount.Location = New System.Drawing.Point(20, 205)
        Me.txtSubTerminalCount.Name = "txtSubTerminalCount"
        Me.txtSubTerminalCount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSubTerminalCount.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSubTerminalCount.PlaceholderText = ""
        Me.txtSubTerminalCount.SelectedText = ""
        Me.txtSubTerminalCount.Size = New System.Drawing.Size(273, 40)
        Me.txtSubTerminalCount.TabIndex = 110
        Me.txtSubTerminalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(17, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 17)
        Me.Label15.TabIndex = 109
        Me.Label15.Text = "Terminal Count"
        '
        'txtTerminalCount
        '
        Me.txtTerminalCount.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTerminalCount.BorderRadius = 5
        Me.txtTerminalCount.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTerminalCount.DefaultText = "1"
        Me.txtTerminalCount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtTerminalCount.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtTerminalCount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTerminalCount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtTerminalCount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTerminalCount.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtTerminalCount.ForeColor = System.Drawing.Color.Black
        Me.txtTerminalCount.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTerminalCount.Location = New System.Drawing.Point(20, 126)
        Me.txtTerminalCount.Name = "txtTerminalCount"
        Me.txtTerminalCount.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTerminalCount.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtTerminalCount.PlaceholderText = ""
        Me.txtTerminalCount.SelectedText = ""
        Me.txtTerminalCount.Size = New System.Drawing.Size(273, 40)
        Me.txtTerminalCount.TabIndex = 108
        Me.txtTerminalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(17, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 17)
        Me.Label14.TabIndex = 107
        Me.Label14.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.BorderRadius = 5
        Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtEmail.DefaultText = ""
        Me.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtEmail.ForeColor = System.Drawing.Color.Black
        Me.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtEmail.Location = New System.Drawing.Point(20, 46)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtEmail.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtEmail.PlaceholderText = ""
        Me.txtEmail.SelectedText = ""
        Me.txtEmail.Size = New System.Drawing.Size(273, 40)
        Me.txtEmail.TabIndex = 106
        Me.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Controls.Add(Me.Guna2Separator1)
        Me.Panel2.Controls.Add(Me.btnNewActivation)
        Me.Panel2.Controls.Add(Me.btnSaveActivation)
        Me.Panel2.Controls.Add(Me.btnDeleteActivation)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 703)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 65)
        Me.Panel2.TabIndex = 21
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator2.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1024, 47)
        Me.Panel1.TabIndex = 25
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(183, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Activation"
        '
        'dgvActivation
        '
        Me.dgvActivation.AllowUserToAddRows = False
        Me.dgvActivation.AllowUserToDeleteRows = False
        Me.dgvActivation.AllowUserToResizeColumns = False
        Me.dgvActivation.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvActivation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvActivation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvActivation.ColumnHeadersHeight = 50
        Me.dgvActivation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvActivation.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvActivation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvActivation.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvActivation.Location = New System.Drawing.Point(0, 55)
        Me.dgvActivation.Name = "dgvActivation"
        Me.dgvActivation.ReadOnly = True
        Me.dgvActivation.RowHeadersVisible = False
        Me.dgvActivation.RowHeadersWidth = 60
        Me.dgvActivation.RowTemplate.Height = 30
        Me.dgvActivation.Size = New System.Drawing.Size(1024, 387)
        Me.dgvActivation.TabIndex = 27
        Me.dgvActivation.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvActivation.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvActivation.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvActivation.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvActivation.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvActivation.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvActivation.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvActivation.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvActivation.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvActivation.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvActivation.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvActivation.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvActivation.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvActivation.ThemeStyle.ReadOnly = True
        Me.dgvActivation.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvActivation.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvActivation.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvActivation.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvActivation.ThemeStyle.RowsStyle.Height = 30
        Me.dgvActivation.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvActivation.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'ActivationFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvActivation)
        Me.Controls.Add(Me.Guna2Separator2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "ActivationFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvActivation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnNewActivation As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveActivation As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteActivation As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Label111 As Label
    Friend WithEvents txtClientContact As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label110 As Label
    Friend WithEvents txtClientName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSubTerminalCount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtTerminalCount As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtEmail As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvActivation As Guna.UI2.WinForms.Guna2DataGridView
End Class
