<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaymentMethodFrm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearPayment = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSavePayment = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeletePayment = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.cbPaymentStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPaymentType = New Guna.UI2.WinForms.Guna2TextBox()
        Me.dgvPaymentMethod = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.Guna2Panel2.SuspendLayout()
        CType(Me.dgvPaymentMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1022, 8)
        Me.Guna2Separator1.TabIndex = 135
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.Controls.Add(Me.Guna2HtmlLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1022, 47)
        Me.Panel1.TabIndex = 134
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(252, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Payment Method"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClearPayment)
        Me.Guna2Panel1.Controls.Add(Me.btnSavePayment)
        Me.Guna2Panel1.Controls.Add(Me.btnDeletePayment)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Separator3)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 701)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1022, 65)
        Me.Guna2Panel1.TabIndex = 137
        '
        'btnClearPayment
        '
        Me.btnClearPayment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearPayment.BorderRadius = 5
        Me.btnClearPayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearPayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearPayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearPayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearPayment.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearPayment.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearPayment.ForeColor = System.Drawing.Color.White
        Me.btnClearPayment.Location = New System.Drawing.Point(423, 10)
        Me.btnClearPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearPayment.Name = "btnClearPayment"
        Me.btnClearPayment.Size = New System.Drawing.Size(213, 47)
        Me.btnClearPayment.TabIndex = 317
        Me.btnClearPayment.Text = "Clear Fields"
        '
        'btnSavePayment
        '
        Me.btnSavePayment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSavePayment.BorderRadius = 5
        Me.btnSavePayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSavePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSavePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSavePayment.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePayment.ForeColor = System.Drawing.Color.White
        Me.btnSavePayment.Location = New System.Drawing.Point(644, 10)
        Me.btnSavePayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSavePayment.Name = "btnSavePayment"
        Me.btnSavePayment.Size = New System.Drawing.Size(213, 47)
        Me.btnSavePayment.TabIndex = 315
        Me.btnSavePayment.Text = "Save Type"
        '
        'btnDeletePayment
        '
        Me.btnDeletePayment.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeletePayment.BorderRadius = 5
        Me.btnDeletePayment.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeletePayment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeletePayment.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeletePayment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeletePayment.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeletePayment.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletePayment.ForeColor = System.Drawing.Color.White
        Me.btnDeletePayment.Location = New System.Drawing.Point(202, 10)
        Me.btnDeletePayment.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeletePayment.Name = "btnDeletePayment"
        Me.btnDeletePayment.Size = New System.Drawing.Size(213, 47)
        Me.btnDeletePayment.TabIndex = 316
        Me.btnDeletePayment.Text = "Delete Type"
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1022, 10)
        Me.Guna2Separator3.TabIndex = 135
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.Guna2Separator2)
        Me.Guna2Panel2.Controls.Add(Me.Label80)
        Me.Guna2Panel2.Controls.Add(Me.cbPaymentStoreID)
        Me.Guna2Panel2.Controls.Add(Me.Label2)
        Me.Guna2Panel2.Controls.Add(Me.txtPaymentType)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel2.Location = New System.Drawing.Point(0, 518)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1022, 183)
        Me.Guna2Panel2.TabIndex = 139
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1022, 8)
        Me.Guna2Separator2.TabIndex = 171
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label80.Location = New System.Drawing.Point(27, 90)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(53, 17)
        Me.Label80.TabIndex = 170
        Me.Label80.Text = "StoreID"
        '
        'cbPaymentStoreID
        '
        Me.cbPaymentStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbPaymentStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbPaymentStoreID.BorderRadius = 5
        Me.cbPaymentStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPaymentStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPaymentStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPaymentStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPaymentStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbPaymentStoreID.ForeColor = System.Drawing.Color.Black
        Me.cbPaymentStoreID.ItemHeight = 30
        Me.cbPaymentStoreID.Location = New System.Drawing.Point(30, 110)
        Me.cbPaymentStoreID.Name = "cbPaymentStoreID"
        Me.cbPaymentStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbPaymentStoreID.TabIndex = 169
        Me.cbPaymentStoreID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(27, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 17)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "Payment Type"
        '
        'txtPaymentType
        '
        Me.txtPaymentType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPaymentType.BorderRadius = 5
        Me.txtPaymentType.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaymentType.DefaultText = ""
        Me.txtPaymentType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPaymentType.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPaymentType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaymentType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPaymentType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaymentType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtPaymentType.ForeColor = System.Drawing.Color.Black
        Me.txtPaymentType.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPaymentType.Location = New System.Drawing.Point(30, 34)
        Me.txtPaymentType.Name = "txtPaymentType"
        Me.txtPaymentType.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPaymentType.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPaymentType.PlaceholderText = ""
        Me.txtPaymentType.SelectedText = ""
        Me.txtPaymentType.Size = New System.Drawing.Size(239, 40)
        Me.txtPaymentType.TabIndex = 167
        Me.txtPaymentType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvPaymentMethod
        '
        Me.dgvPaymentMethod.AllowUserToAddRows = False
        Me.dgvPaymentMethod.AllowUserToDeleteRows = False
        Me.dgvPaymentMethod.AllowUserToResizeColumns = False
        Me.dgvPaymentMethod.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvPaymentMethod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentMethod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPaymentMethod.ColumnHeadersHeight = 50
        Me.dgvPaymentMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentMethod.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPaymentMethod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPaymentMethod.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPaymentMethod.Location = New System.Drawing.Point(0, 55)
        Me.dgvPaymentMethod.Name = "dgvPaymentMethod"
        Me.dgvPaymentMethod.ReadOnly = True
        Me.dgvPaymentMethod.RowHeadersVisible = False
        Me.dgvPaymentMethod.RowHeadersWidth = 60
        Me.dgvPaymentMethod.RowTemplate.Height = 30
        Me.dgvPaymentMethod.Size = New System.Drawing.Size(1022, 463)
        Me.dgvPaymentMethod.TabIndex = 140
        Me.dgvPaymentMethod.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPaymentMethod.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvPaymentMethod.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvPaymentMethod.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvPaymentMethod.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvPaymentMethod.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvPaymentMethod.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvPaymentMethod.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvPaymentMethod.ThemeStyle.ReadOnly = True
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.Height = 30
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvPaymentMethod.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'PaymentMethodFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1022, 766)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvPaymentMethod)
        Me.Controls.Add(Me.Guna2Panel2)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "PaymentMethodFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        CType(Me.dgvPaymentMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearPayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSavePayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeletePayment As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Label80 As Label
    Friend WithEvents cbPaymentStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPaymentType As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents dgvPaymentMethod As Guna.UI2.WinForms.Guna2DataGridView
End Class
