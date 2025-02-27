<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CouponFrm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearCoupon = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveCoupon = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteCoupon = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.cbCouponStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpExpiryDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.dtpEffectiveDate = New Guna.UI2.WinForms.Guna2DateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtBPValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtBundlePromo = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtBBValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtBundleBase = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cbCouponType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtReferenceValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtDiscValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtCouponDesc = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtCouponName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbDisplayType = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.dgvCoupons = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel1.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        CType(Me.dgvCoupons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.Panel1.TabIndex = 10
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(162, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Coupon"
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1022, 8)
        Me.Guna2Separator1.TabIndex = 11
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClearCoupon)
        Me.Guna2Panel1.Controls.Add(Me.btnSaveCoupon)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteCoupon)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Separator3)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(0, 701)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1022, 65)
        Me.Guna2Panel1.TabIndex = 135
        '
        'btnClearCoupon
        '
        Me.btnClearCoupon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearCoupon.BorderRadius = 5
        Me.btnClearCoupon.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearCoupon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearCoupon.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearCoupon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearCoupon.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearCoupon.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearCoupon.ForeColor = System.Drawing.Color.White
        Me.btnClearCoupon.Location = New System.Drawing.Point(423, 10)
        Me.btnClearCoupon.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearCoupon.Name = "btnClearCoupon"
        Me.btnClearCoupon.Size = New System.Drawing.Size(213, 47)
        Me.btnClearCoupon.TabIndex = 317
        Me.btnClearCoupon.Text = "Clear Fields"
        '
        'btnSaveCoupon
        '
        Me.btnSaveCoupon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveCoupon.BorderRadius = 5
        Me.btnSaveCoupon.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveCoupon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveCoupon.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveCoupon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveCoupon.FillColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnSaveCoupon.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveCoupon.ForeColor = System.Drawing.Color.White
        Me.btnSaveCoupon.Location = New System.Drawing.Point(644, 10)
        Me.btnSaveCoupon.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveCoupon.Name = "btnSaveCoupon"
        Me.btnSaveCoupon.Size = New System.Drawing.Size(213, 47)
        Me.btnSaveCoupon.TabIndex = 315
        Me.btnSaveCoupon.Text = "Save Coupon"
        '
        'btnDeleteCoupon
        '
        Me.btnDeleteCoupon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteCoupon.BorderRadius = 5
        Me.btnDeleteCoupon.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteCoupon.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteCoupon.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteCoupon.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteCoupon.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteCoupon.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteCoupon.ForeColor = System.Drawing.Color.White
        Me.btnDeleteCoupon.Location = New System.Drawing.Point(202, 10)
        Me.btnDeleteCoupon.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteCoupon.Name = "btnDeleteCoupon"
        Me.btnDeleteCoupon.Size = New System.Drawing.Size(213, 47)
        Me.btnDeleteCoupon.TabIndex = 316
        Me.btnDeleteCoupon.Text = "Delete Coupon"
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1022, 10)
        Me.Guna2Separator3.TabIndex = 135
        '
        'Label78
        '
        Me.Label78.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label78.AutoSize = True
        Me.Label78.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label78.Location = New System.Drawing.Point(641, 434)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(53, 17)
        Me.Label78.TabIndex = 159
        Me.Label78.Text = "StoreID"
        '
        'cbCouponStoreID
        '
        Me.cbCouponStoreID.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbCouponStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbCouponStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbCouponStoreID.BorderRadius = 5
        Me.cbCouponStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbCouponStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCouponStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCouponStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCouponStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbCouponStoreID.ForeColor = System.Drawing.Color.Black
        Me.cbCouponStoreID.ItemHeight = 30
        Me.cbCouponStoreID.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbCouponStoreID.Location = New System.Drawing.Point(644, 459)
        Me.cbCouponStoreID.Name = "cbCouponStoreID"
        Me.cbCouponStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbCouponStoreID.TabIndex = 158
        '
        'Label26
        '
        Me.Label26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(641, 640)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 17)
        Me.Label26.TabIndex = 157
        Me.Label26.Text = "Expiry Date"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(641, 577)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(90, 17)
        Me.Label11.TabIndex = 156
        Me.Label11.Text = "Effective Date"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpExpiryDate.BorderRadius = 5
        Me.dtpExpiryDate.Checked = True
        Me.dtpExpiryDate.FillColor = System.Drawing.Color.LightSteelBlue
        Me.dtpExpiryDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpExpiryDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpExpiryDate.Location = New System.Drawing.Point(644, 658)
        Me.dtpExpiryDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpExpiryDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.Size = New System.Drawing.Size(239, 36)
        Me.dtpExpiryDate.TabIndex = 155
        Me.dtpExpiryDate.Value = New Date(2024, 9, 10, 18, 41, 23, 227)
        '
        'dtpEffectiveDate
        '
        Me.dtpEffectiveDate.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.dtpEffectiveDate.BorderRadius = 5
        Me.dtpEffectiveDate.Checked = True
        Me.dtpEffectiveDate.FillColor = System.Drawing.Color.LightSteelBlue
        Me.dtpEffectiveDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.dtpEffectiveDate.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.[Long]
        Me.dtpEffectiveDate.Location = New System.Drawing.Point(644, 597)
        Me.dtpEffectiveDate.MaxDate = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.dtpEffectiveDate.MinDate = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.dtpEffectiveDate.Name = "dtpEffectiveDate"
        Me.dtpEffectiveDate.Size = New System.Drawing.Size(239, 36)
        Me.dtpEffectiveDate.TabIndex = 154
        Me.dtpEffectiveDate.Value = New Date(2024, 9, 10, 18, 41, 23, 227)
        '
        'Label22
        '
        Me.Label22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(379, 577)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 17)
        Me.Label22.TabIndex = 153
        Me.Label22.Text = "BPValue"
        '
        'txtBPValue
        '
        Me.txtBPValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBPValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBPValue.BorderRadius = 5
        Me.txtBPValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBPValue.DefaultText = ""
        Me.txtBPValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBPValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBPValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBPValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBPValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBPValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtBPValue.ForeColor = System.Drawing.Color.Black
        Me.txtBPValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBPValue.Location = New System.Drawing.Point(382, 597)
        Me.txtBPValue.Name = "txtBPValue"
        Me.txtBPValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBPValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBPValue.PlaceholderText = ""
        Me.txtBPValue.SelectedText = ""
        Me.txtBPValue.Size = New System.Drawing.Size(239, 40)
        Me.txtBPValue.TabIndex = 152
        '
        'Label23
        '
        Me.Label23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label23.Location = New System.Drawing.Point(379, 507)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(91, 17)
        Me.Label23.TabIndex = 151
        Me.Label23.Text = "BundlePromo"
        '
        'txtBundlePromo
        '
        Me.txtBundlePromo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBundlePromo.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBundlePromo.BorderRadius = 5
        Me.txtBundlePromo.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBundlePromo.DefaultText = ""
        Me.txtBundlePromo.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBundlePromo.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBundlePromo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBundlePromo.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBundlePromo.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBundlePromo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtBundlePromo.ForeColor = System.Drawing.Color.Black
        Me.txtBundlePromo.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBundlePromo.Location = New System.Drawing.Point(382, 527)
        Me.txtBundlePromo.Name = "txtBundlePromo"
        Me.txtBundlePromo.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBundlePromo.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBundlePromo.PlaceholderText = ""
        Me.txtBundlePromo.SelectedText = ""
        Me.txtBundlePromo.Size = New System.Drawing.Size(239, 40)
        Me.txtBundlePromo.TabIndex = 150
        '
        'Label24
        '
        Me.Label24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label24.Location = New System.Drawing.Point(379, 434)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 17)
        Me.Label24.TabIndex = 149
        Me.Label24.Text = "BBValue"
        '
        'txtBBValue
        '
        Me.txtBBValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBBValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBBValue.BorderRadius = 5
        Me.txtBBValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBBValue.DefaultText = ""
        Me.txtBBValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBBValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBBValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBBValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBBValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBBValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtBBValue.ForeColor = System.Drawing.Color.Black
        Me.txtBBValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBBValue.Location = New System.Drawing.Point(382, 459)
        Me.txtBBValue.Name = "txtBBValue"
        Me.txtBBValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBBValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBBValue.PlaceholderText = ""
        Me.txtBBValue.SelectedText = ""
        Me.txtBBValue.Size = New System.Drawing.Size(239, 40)
        Me.txtBBValue.TabIndex = 148
        '
        'Label25
        '
        Me.Label25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(379, 363)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(78, 17)
        Me.Label25.TabIndex = 147
        Me.Label25.Text = "BundleBase"
        '
        'txtBundleBase
        '
        Me.txtBundleBase.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtBundleBase.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBundleBase.BorderRadius = 5
        Me.txtBundleBase.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBundleBase.DefaultText = ""
        Me.txtBundleBase.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtBundleBase.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtBundleBase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBundleBase.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtBundleBase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBundleBase.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtBundleBase.ForeColor = System.Drawing.Color.Black
        Me.txtBundleBase.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtBundleBase.Location = New System.Drawing.Point(382, 383)
        Me.txtBundleBase.Name = "txtBundleBase"
        Me.txtBundleBase.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtBundleBase.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtBundleBase.PlaceholderText = ""
        Me.txtBundleBase.SelectedText = ""
        Me.txtBundleBase.Size = New System.Drawing.Size(239, 40)
        Me.txtBundleBase.TabIndex = 146
        '
        'Label21
        '
        Me.Label21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(641, 363)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 17)
        Me.Label21.TabIndex = 145
        Me.Label21.Text = "Type"
        '
        'cbCouponType
        '
        Me.cbCouponType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbCouponType.BackColor = System.Drawing.Color.Transparent
        Me.cbCouponType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbCouponType.BorderRadius = 5
        Me.cbCouponType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbCouponType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCouponType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCouponType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCouponType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbCouponType.ForeColor = System.Drawing.Color.Black
        Me.cbCouponType.ItemHeight = 30
        Me.cbCouponType.Items.AddRange(New Object() {"Percentage(w/o vat)", "Percentage(w/ vat)", "Percentage(w/ vat-2)", "Fix-1", "Fix-2", "Bundle-1", "Bundle-2", "Bundle-3(%)"})
        Me.cbCouponType.Location = New System.Drawing.Point(644, 383)
        Me.cbCouponType.Name = "cbCouponType"
        Me.cbCouponType.Size = New System.Drawing.Size(239, 36)
        Me.cbCouponType.TabIndex = 144
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(122, 577)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(103, 17)
        Me.Label20.TabIndex = 143
        Me.Label20.Text = "Reference Value"
        '
        'txtReferenceValue
        '
        Me.txtReferenceValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtReferenceValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtReferenceValue.BorderRadius = 5
        Me.txtReferenceValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtReferenceValue.DefaultText = ""
        Me.txtReferenceValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtReferenceValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtReferenceValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtReferenceValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtReferenceValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtReferenceValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtReferenceValue.ForeColor = System.Drawing.Color.Black
        Me.txtReferenceValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtReferenceValue.Location = New System.Drawing.Point(125, 597)
        Me.txtReferenceValue.Name = "txtReferenceValue"
        Me.txtReferenceValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtReferenceValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtReferenceValue.PlaceholderText = ""
        Me.txtReferenceValue.SelectedText = ""
        Me.txtReferenceValue.Size = New System.Drawing.Size(239, 40)
        Me.txtReferenceValue.TabIndex = 142
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(122, 507)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(97, 17)
        Me.Label19.TabIndex = 141
        Me.Label19.Text = "Discount Value"
        '
        'txtDiscValue
        '
        Me.txtDiscValue.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtDiscValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDiscValue.BorderRadius = 5
        Me.txtDiscValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDiscValue.DefaultText = ""
        Me.txtDiscValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtDiscValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtDiscValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtDiscValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtDiscValue.ForeColor = System.Drawing.Color.Black
        Me.txtDiscValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtDiscValue.Location = New System.Drawing.Point(125, 527)
        Me.txtDiscValue.Name = "txtDiscValue"
        Me.txtDiscValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtDiscValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtDiscValue.PlaceholderText = ""
        Me.txtDiscValue.SelectedText = ""
        Me.txtDiscValue.Size = New System.Drawing.Size(239, 40)
        Me.txtDiscValue.TabIndex = 140
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(122, 434)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(36, 17)
        Me.Label18.TabIndex = 139
        Me.Label18.Text = "Desc"
        '
        'txtCouponDesc
        '
        Me.txtCouponDesc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCouponDesc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCouponDesc.BorderRadius = 5
        Me.txtCouponDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCouponDesc.DefaultText = ""
        Me.txtCouponDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCouponDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCouponDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCouponDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCouponDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCouponDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCouponDesc.ForeColor = System.Drawing.Color.Black
        Me.txtCouponDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCouponDesc.Location = New System.Drawing.Point(125, 459)
        Me.txtCouponDesc.Name = "txtCouponDesc"
        Me.txtCouponDesc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCouponDesc.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCouponDesc.PlaceholderText = ""
        Me.txtCouponDesc.SelectedText = ""
        Me.txtCouponDesc.Size = New System.Drawing.Size(239, 40)
        Me.txtCouponDesc.TabIndex = 138
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(122, 363)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 17)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Coupon Name"
        '
        'txtCouponName
        '
        Me.txtCouponName.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txtCouponName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCouponName.BorderRadius = 5
        Me.txtCouponName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCouponName.DefaultText = ""
        Me.txtCouponName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCouponName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCouponName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCouponName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCouponName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCouponName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCouponName.ForeColor = System.Drawing.Color.Black
        Me.txtCouponName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCouponName.Location = New System.Drawing.Point(125, 383)
        Me.txtCouponName.Name = "txtCouponName"
        Me.txtCouponName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCouponName.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCouponName.PlaceholderText = ""
        Me.txtCouponName.SelectedText = ""
        Me.txtCouponName.Size = New System.Drawing.Size(239, 40)
        Me.txtCouponName.TabIndex = 136
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(641, 507)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 17)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Display Type"
        '
        'cbDisplayType
        '
        Me.cbDisplayType.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cbDisplayType.BackColor = System.Drawing.Color.Transparent
        Me.cbDisplayType.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbDisplayType.BorderRadius = 5
        Me.cbDisplayType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbDisplayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbDisplayType.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbDisplayType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbDisplayType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbDisplayType.ForeColor = System.Drawing.Color.Black
        Me.cbDisplayType.ItemHeight = 30
        Me.cbDisplayType.Items.AddRange(New Object() {"Standard", "Percentage", "GC", "Coupon"})
        Me.cbDisplayType.Location = New System.Drawing.Point(644, 527)
        Me.cbDisplayType.Name = "cbDisplayType"
        Me.cbDisplayType.Size = New System.Drawing.Size(239, 36)
        Me.cbDisplayType.TabIndex = 160
        '
        'dgvCoupons
        '
        Me.dgvCoupons.AllowUserToAddRows = False
        Me.dgvCoupons.AllowUserToDeleteRows = False
        Me.dgvCoupons.AllowUserToResizeColumns = False
        Me.dgvCoupons.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvCoupons.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCoupons.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCoupons.ColumnHeadersHeight = 50
        Me.dgvCoupons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCoupons.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCoupons.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCoupons.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCoupons.Location = New System.Drawing.Point(0, 55)
        Me.dgvCoupons.Name = "dgvCoupons"
        Me.dgvCoupons.ReadOnly = True
        Me.dgvCoupons.RowHeadersVisible = False
        Me.dgvCoupons.RowHeadersWidth = 60
        Me.dgvCoupons.RowTemplate.Height = 30
        Me.dgvCoupons.Size = New System.Drawing.Size(1022, 284)
        Me.dgvCoupons.TabIndex = 162
        Me.dgvCoupons.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCoupons.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvCoupons.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvCoupons.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvCoupons.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvCoupons.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvCoupons.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCoupons.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCoupons.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvCoupons.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCoupons.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvCoupons.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvCoupons.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvCoupons.ThemeStyle.ReadOnly = True
        Me.dgvCoupons.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvCoupons.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvCoupons.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvCoupons.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvCoupons.ThemeStyle.RowsStyle.Height = 30
        Me.dgvCoupons.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCoupons.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 339)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1022, 10)
        Me.Guna2Separator2.TabIndex = 163
        '
        'CouponFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1022, 766)
        Me.ControlBox = False
        Me.Controls.Add(Me.Guna2Separator2)
        Me.Controls.Add(Me.dgvCoupons)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDisplayType)
        Me.Controls.Add(Me.Label78)
        Me.Controls.Add(Me.cbCouponStoreID)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpExpiryDate)
        Me.Controls.Add(Me.dtpEffectiveDate)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.txtBPValue)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtBundlePromo)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtBBValue)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txtBundleBase)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.cbCouponType)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtReferenceValue)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.txtDiscValue)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtCouponDesc)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtCouponName)
        Me.Controls.Add(Me.Guna2Panel1)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "CouponFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        CType(Me.dgvCoupons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnClearCoupon As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveCoupon As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteCoupon As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Label78 As Label
    Friend WithEvents cbCouponStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpExpiryDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents dtpEffectiveDate As Guna.UI2.WinForms.Guna2DateTimePicker
    Friend WithEvents Label22 As Label
    Friend WithEvents txtBPValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label23 As Label
    Friend WithEvents txtBundlePromo As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtBBValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents txtBundleBase As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cbCouponType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents txtReferenceValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents txtDiscValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtCouponDesc As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtCouponName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbDisplayType As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dgvCoupons As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
End Class
