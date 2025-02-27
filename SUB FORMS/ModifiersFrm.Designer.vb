<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifiersFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModifiersFrm))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2TabControl1 = New Guna.UI2.WinForms.Guna2TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvModifier = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator5 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnModDown = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.btnModUP = New Guna.UI2.WinForms.Guna2ImageButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbModStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtModGroup = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.txtModPrice = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.txtModName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnModClear = New Guna.UI2.WinForms.Guna2Button()
        Me.btnModSave = New Guna.UI2.WinForms.Guna2Button()
        Me.btnModDelete = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvProdMod = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbProdStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProdModGroup = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.cbProdModID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearProductModifier = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveProductModifier = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteProductModifier = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator6 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvModifier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvProdMod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2TabControl1
        '
        Me.Guna2TabControl1.Controls.Add(Me.TabPage1)
        Me.Guna2TabControl1.Controls.Add(Me.TabPage2)
        Me.Guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2TabControl1.ItemSize = New System.Drawing.Size(180, 40)
        Me.Guna2TabControl1.Location = New System.Drawing.Point(0, 55)
        Me.Guna2TabControl1.Name = "Guna2TabControl1"
        Me.Guna2TabControl1.SelectedIndex = 0
        Me.Guna2TabControl1.Size = New System.Drawing.Size(1024, 713)
        Me.Guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.SteelBlue
        Me.Guna2TabControl1.TabButtonHoverState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.White
        Me.Guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.SteelBlue
        Me.Guna2TabControl1.TabButtonIdleState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.White
        Me.Guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty
        Me.Guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.SlateBlue
        Me.Guna2TabControl1.TabButtonSelectedState.Font = New System.Drawing.Font("Segoe UI Semibold", 10.0!)
        Me.Guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.White
        Me.Guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.Guna2TabControl1.TabButtonSize = New System.Drawing.Size(180, 40)
        Me.Guna2TabControl1.TabIndex = 17
        Me.Guna2TabControl1.TabMenuBackColor = System.Drawing.Color.SteelBlue
        Me.Guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.dgvModifier)
        Me.TabPage1.Controls.Add(Me.Guna2Separator5)
        Me.TabPage1.Controls.Add(Me.Guna2Panel4)
        Me.TabPage1.Controls.Add(Me.Guna2Panel1)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage1.Location = New System.Drawing.Point(4, 44)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1016, 665)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Modifier Group"
        '
        'dgvModifier
        '
        Me.dgvModifier.AllowUserToAddRows = False
        Me.dgvModifier.AllowUserToDeleteRows = False
        Me.dgvModifier.AllowUserToResizeColumns = False
        Me.dgvModifier.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvModifier.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvModifier.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvModifier.ColumnHeadersHeight = 50
        Me.dgvModifier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvModifier.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvModifier.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvModifier.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvModifier.Location = New System.Drawing.Point(3, 3)
        Me.dgvModifier.Name = "dgvModifier"
        Me.dgvModifier.ReadOnly = True
        Me.dgvModifier.RowHeadersVisible = False
        Me.dgvModifier.RowHeadersWidth = 60
        Me.dgvModifier.RowTemplate.Height = 30
        Me.dgvModifier.Size = New System.Drawing.Size(1010, 402)
        Me.dgvModifier.TabIndex = 19
        Me.dgvModifier.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvModifier.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvModifier.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvModifier.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvModifier.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvModifier.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvModifier.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvModifier.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvModifier.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvModifier.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvModifier.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvModifier.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvModifier.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvModifier.ThemeStyle.ReadOnly = True
        Me.dgvModifier.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvModifier.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvModifier.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvModifier.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvModifier.ThemeStyle.RowsStyle.Height = 30
        Me.dgvModifier.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvModifier.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator5
        '
        Me.Guna2Separator5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Separator5.Location = New System.Drawing.Point(3, 405)
        Me.Guna2Separator5.Name = "Guna2Separator5"
        Me.Guna2Separator5.Size = New System.Drawing.Size(1010, 8)
        Me.Guna2Separator5.TabIndex = 18
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.Controls.Add(Me.btnModDown)
        Me.Guna2Panel4.Controls.Add(Me.btnModUP)
        Me.Guna2Panel4.Controls.Add(Me.Label2)
        Me.Guna2Panel4.Controls.Add(Me.Label1)
        Me.Guna2Panel4.Controls.Add(Me.cbModStoreID)
        Me.Guna2Panel4.Controls.Add(Me.txtModGroup)
        Me.Guna2Panel4.Controls.Add(Me.Label117)
        Me.Guna2Panel4.Controls.Add(Me.Label126)
        Me.Guna2Panel4.Controls.Add(Me.txtModPrice)
        Me.Guna2Panel4.Controls.Add(Me.Label128)
        Me.Guna2Panel4.Controls.Add(Me.txtModName)
        Me.Guna2Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel4.Location = New System.Drawing.Point(3, 413)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(1010, 184)
        Me.Guna2Panel4.TabIndex = 17
        '
        'btnModDown
        '
        Me.btnModDown.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnModDown.CheckedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModDown.HoverState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModDown.Image = CType(resources.GetObject("btnModDown.Image"), System.Drawing.Image)
        Me.btnModDown.ImageOffset = New System.Drawing.Point(0, 0)
        Me.btnModDown.ImageRotate = 0!
        Me.btnModDown.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnModDown.Location = New System.Drawing.Point(688, 77)
        Me.btnModDown.Name = "btnModDown"
        Me.btnModDown.PressedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModDown.Size = New System.Drawing.Size(64, 54)
        Me.btnModDown.TabIndex = 158
        '
        'btnModUP
        '
        Me.btnModUP.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnModUP.CheckedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModUP.HoverState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModUP.Image = CType(resources.GetObject("btnModUP.Image"), System.Drawing.Image)
        Me.btnModUP.ImageOffset = New System.Drawing.Point(0, 0)
        Me.btnModUP.ImageRotate = 0!
        Me.btnModUP.ImageSize = New System.Drawing.Size(32, 32)
        Me.btnModUP.Location = New System.Drawing.Point(609, 77)
        Me.btnModUP.Name = "btnModUP"
        Me.btnModUP.PressedState.ImageSize = New System.Drawing.Size(64, 64)
        Me.btnModUP.Size = New System.Drawing.Size(64, 54)
        Me.btnModUP.TabIndex = 157
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(640, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 17)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Arrangment"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(295, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Store ID"
        '
        'cbModStoreID
        '
        Me.cbModStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbModStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbModStoreID.BorderRadius = 5
        Me.cbModStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbModStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbModStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbModStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbModStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbModStoreID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbModStoreID.ItemHeight = 30
        Me.cbModStoreID.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbModStoreID.Location = New System.Drawing.Point(298, 114)
        Me.cbModStoreID.Name = "cbModStoreID"
        Me.cbModStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbModStoreID.TabIndex = 154
        Me.cbModStoreID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtModGroup
        '
        Me.txtModGroup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModGroup.BorderRadius = 5
        Me.txtModGroup.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModGroup.DefaultText = ""
        Me.txtModGroup.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtModGroup.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtModGroup.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModGroup.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModGroup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModGroup.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtModGroup.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtModGroup.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModGroup.Location = New System.Drawing.Point(28, 49)
        Me.txtModGroup.MaxLength = 40
        Me.txtModGroup.Name = "txtModGroup"
        Me.txtModGroup.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtModGroup.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModGroup.PlaceholderText = ""
        Me.txtModGroup.SelectedText = ""
        Me.txtModGroup.Size = New System.Drawing.Size(239, 35)
        Me.txtModGroup.TabIndex = 153
        Me.txtModGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label117
        '
        Me.Label117.AutoSize = True
        Me.Label117.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label117.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label117.Location = New System.Drawing.Point(25, 29)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(100, 17)
        Me.Label117.TabIndex = 152
        Me.Label117.Text = "Modifier Group"
        '
        'Label126
        '
        Me.Label126.AutoSize = True
        Me.Label126.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label126.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label126.Location = New System.Drawing.Point(295, 29)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(37, 17)
        Me.Label126.TabIndex = 151
        Me.Label126.Text = "Price"
        '
        'txtModPrice
        '
        Me.txtModPrice.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModPrice.BorderRadius = 5
        Me.txtModPrice.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModPrice.DefaultText = ""
        Me.txtModPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtModPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtModPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModPrice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtModPrice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtModPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModPrice.Location = New System.Drawing.Point(298, 49)
        Me.txtModPrice.MaxLength = 40
        Me.txtModPrice.Name = "txtModPrice"
        Me.txtModPrice.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtModPrice.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModPrice.PlaceholderText = ""
        Me.txtModPrice.SelectedText = ""
        Me.txtModPrice.Size = New System.Drawing.Size(239, 35)
        Me.txtModPrice.TabIndex = 150
        Me.txtModPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label128.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label128.Location = New System.Drawing.Point(25, 94)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(95, 17)
        Me.Label128.TabIndex = 149
        Me.Label128.Text = "Modfier Name"
        '
        'txtModName
        '
        Me.txtModName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModName.BorderRadius = 5
        Me.txtModName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtModName.DefaultText = ""
        Me.txtModName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtModName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtModName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtModName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtModName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtModName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtModName.Location = New System.Drawing.Point(28, 114)
        Me.txtModName.MaxLength = 40
        Me.txtModName.Name = "txtModName"
        Me.txtModName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtModName.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtModName.PlaceholderText = ""
        Me.txtModName.SelectedText = ""
        Me.txtModName.Size = New System.Drawing.Size(239, 35)
        Me.txtModName.TabIndex = 148
        Me.txtModName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnModClear)
        Me.Guna2Panel1.Controls.Add(Me.btnModSave)
        Me.Guna2Panel1.Controls.Add(Me.btnModDelete)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Separator2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(3, 597)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1010, 65)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnModClear
        '
        Me.btnModClear.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnModClear.BorderRadius = 5
        Me.btnModClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnModClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnModClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnModClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnModClear.FillColor = System.Drawing.Color.DarkGreen
        Me.btnModClear.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModClear.ForeColor = System.Drawing.Color.White
        Me.btnModClear.Location = New System.Drawing.Point(412, 11)
        Me.btnModClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModClear.Name = "btnModClear"
        Me.btnModClear.Size = New System.Drawing.Size(213, 47)
        Me.btnModClear.TabIndex = 320
        Me.btnModClear.Text = "Clear Fields"
        '
        'btnModSave
        '
        Me.btnModSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnModSave.BorderRadius = 5
        Me.btnModSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnModSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnModSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnModSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnModSave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModSave.ForeColor = System.Drawing.Color.White
        Me.btnModSave.Location = New System.Drawing.Point(633, 11)
        Me.btnModSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModSave.Name = "btnModSave"
        Me.btnModSave.Size = New System.Drawing.Size(213, 47)
        Me.btnModSave.TabIndex = 318
        Me.btnModSave.Text = "Save Modifier"
        '
        'btnModDelete
        '
        Me.btnModDelete.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnModDelete.BorderRadius = 5
        Me.btnModDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnModDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnModDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnModDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnModDelete.FillColor = System.Drawing.Color.DarkRed
        Me.btnModDelete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModDelete.ForeColor = System.Drawing.Color.White
        Me.btnModDelete.Location = New System.Drawing.Point(191, 11)
        Me.btnModDelete.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModDelete.Name = "btnModDelete"
        Me.btnModDelete.Size = New System.Drawing.Size(213, 47)
        Me.btnModDelete.TabIndex = 319
        Me.btnModDelete.Text = "Delete Modifier"
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1010, 8)
        Me.Guna2Separator2.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.dgvProdMod)
        Me.TabPage2.Controls.Add(Me.Guna2Separator3)
        Me.TabPage2.Controls.Add(Me.Guna2Panel2)
        Me.TabPage2.Controls.Add(Me.Guna2Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 44)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1016, 665)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Product Modifier"
        '
        'dgvProdMod
        '
        Me.dgvProdMod.AllowUserToAddRows = False
        Me.dgvProdMod.AllowUserToDeleteRows = False
        Me.dgvProdMod.AllowUserToResizeColumns = False
        Me.dgvProdMod.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvProdMod.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProdMod.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProdMod.ColumnHeadersHeight = 50
        Me.dgvProdMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProdMod.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvProdMod.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProdMod.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProdMod.Location = New System.Drawing.Point(3, 3)
        Me.dgvProdMod.Name = "dgvProdMod"
        Me.dgvProdMod.ReadOnly = True
        Me.dgvProdMod.RowHeadersVisible = False
        Me.dgvProdMod.RowHeadersWidth = 60
        Me.dgvProdMod.RowTemplate.Height = 30
        Me.dgvProdMod.Size = New System.Drawing.Size(1010, 410)
        Me.dgvProdMod.TabIndex = 22
        Me.dgvProdMod.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvProdMod.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvProdMod.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvProdMod.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvProdMod.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvProdMod.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvProdMod.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProdMod.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProdMod.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProdMod.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProdMod.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvProdMod.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvProdMod.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvProdMod.ThemeStyle.ReadOnly = True
        Me.dgvProdMod.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvProdMod.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvProdMod.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProdMod.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvProdMod.ThemeStyle.RowsStyle.Height = 30
        Me.dgvProdMod.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProdMod.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Separator3.Location = New System.Drawing.Point(3, 413)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1010, 10)
        Me.Guna2Separator3.TabIndex = 21
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.Label4)
        Me.Guna2Panel2.Controls.Add(Me.cbProdStoreID)
        Me.Guna2Panel2.Controls.Add(Me.Label3)
        Me.Guna2Panel2.Controls.Add(Me.cbProdModGroup)
        Me.Guna2Panel2.Controls.Add(Me.Label80)
        Me.Guna2Panel2.Controls.Add(Me.cbProdModID)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel2.Location = New System.Drawing.Point(3, 423)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1010, 174)
        Me.Guna2Panel2.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(287, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 165
        Me.Label4.Text = "StoreID"
        '
        'cbProdStoreID
        '
        Me.cbProdStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbProdStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbProdStoreID.BorderRadius = 5
        Me.cbProdStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbProdStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProdStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbProdStoreID.ForeColor = System.Drawing.Color.Black
        Me.cbProdStoreID.ItemHeight = 30
        Me.cbProdStoreID.Location = New System.Drawing.Point(290, 40)
        Me.cbProdStoreID.Name = "cbProdStoreID"
        Me.cbProdStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbProdStoreID.TabIndex = 164
        Me.cbProdStoreID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(21, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 17)
        Me.Label3.TabIndex = 163
        Me.Label3.Text = "Modifier Type"
        '
        'cbProdModGroup
        '
        Me.cbProdModGroup.BackColor = System.Drawing.Color.Transparent
        Me.cbProdModGroup.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbProdModGroup.BorderRadius = 5
        Me.cbProdModGroup.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbProdModGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProdModGroup.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdModGroup.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdModGroup.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbProdModGroup.ForeColor = System.Drawing.Color.Black
        Me.cbProdModGroup.ItemHeight = 30
        Me.cbProdModGroup.Location = New System.Drawing.Point(24, 111)
        Me.cbProdModGroup.Name = "cbProdModGroup"
        Me.cbProdModGroup.Size = New System.Drawing.Size(239, 36)
        Me.cbProdModGroup.TabIndex = 162
        Me.cbProdModGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label80.Location = New System.Drawing.Point(21, 20)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(73, 17)
        Me.Label80.TabIndex = 161
        Me.Label80.Text = "Product ID"
        '
        'cbProdModID
        '
        Me.cbProdModID.BackColor = System.Drawing.Color.Transparent
        Me.cbProdModID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbProdModID.BorderRadius = 5
        Me.cbProdModID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbProdModID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbProdModID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdModID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbProdModID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbProdModID.ForeColor = System.Drawing.Color.Black
        Me.cbProdModID.ItemHeight = 30
        Me.cbProdModID.Location = New System.Drawing.Point(24, 40)
        Me.cbProdModID.Name = "cbProdModID"
        Me.cbProdModID.Size = New System.Drawing.Size(239, 36)
        Me.cbProdModID.TabIndex = 160
        Me.cbProdModID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.Controls.Add(Me.btnClearProductModifier)
        Me.Guna2Panel5.Controls.Add(Me.btnSaveProductModifier)
        Me.Guna2Panel5.Controls.Add(Me.btnDeleteProductModifier)
        Me.Guna2Panel5.Controls.Add(Me.Guna2Separator6)
        Me.Guna2Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel5.Location = New System.Drawing.Point(3, 597)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(1010, 65)
        Me.Guna2Panel5.TabIndex = 19
        '
        'btnClearProductModifier
        '
        Me.btnClearProductModifier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearProductModifier.BorderRadius = 5
        Me.btnClearProductModifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearProductModifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearProductModifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearProductModifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearProductModifier.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearProductModifier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearProductModifier.ForeColor = System.Drawing.Color.White
        Me.btnClearProductModifier.Location = New System.Drawing.Point(428, 11)
        Me.btnClearProductModifier.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearProductModifier.Name = "btnClearProductModifier"
        Me.btnClearProductModifier.Size = New System.Drawing.Size(213, 47)
        Me.btnClearProductModifier.TabIndex = 320
        Me.btnClearProductModifier.Text = "Clear Fields"
        '
        'btnSaveProductModifier
        '
        Me.btnSaveProductModifier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveProductModifier.BorderRadius = 5
        Me.btnSaveProductModifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveProductModifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveProductModifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveProductModifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveProductModifier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProductModifier.ForeColor = System.Drawing.Color.White
        Me.btnSaveProductModifier.Location = New System.Drawing.Point(649, 11)
        Me.btnSaveProductModifier.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveProductModifier.Name = "btnSaveProductModifier"
        Me.btnSaveProductModifier.Size = New System.Drawing.Size(213, 47)
        Me.btnSaveProductModifier.TabIndex = 318
        Me.btnSaveProductModifier.Text = "Save Product Modifiers"
        '
        'btnDeleteProductModifier
        '
        Me.btnDeleteProductModifier.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteProductModifier.BorderRadius = 5
        Me.btnDeleteProductModifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteProductModifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteProductModifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteProductModifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteProductModifier.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteProductModifier.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProductModifier.ForeColor = System.Drawing.Color.White
        Me.btnDeleteProductModifier.Location = New System.Drawing.Point(207, 11)
        Me.btnDeleteProductModifier.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteProductModifier.Name = "btnDeleteProductModifier"
        Me.btnDeleteProductModifier.Size = New System.Drawing.Size(213, 47)
        Me.btnDeleteProductModifier.TabIndex = 319
        Me.btnDeleteProductModifier.Text = "Delete Product Modifier"
        '
        'Guna2Separator6
        '
        Me.Guna2Separator6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator6.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator6.Name = "Guna2Separator6"
        Me.Guna2Separator6.Size = New System.Drawing.Size(1010, 8)
        Me.Guna2Separator6.TabIndex = 11
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator1.TabIndex = 16
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
        Me.Panel1.TabIndex = 15
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(258, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Product Modifiers"
        '
        'ModifiersFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.ControlBox = False
        Me.Controls.Add(Me.Guna2TabControl1)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ModifiersFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Guna2TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvModifier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvProdMod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2TabControl1 As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Guna2Separator5 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnModClear As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnModSave As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnModDelete As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearProductModifier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveProductModifier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteProductModifier As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator6 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents cbModStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtModGroup As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label117 As Label
    Friend WithEvents Label126 As Label
    Friend WithEvents txtModPrice As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label128 As Label
    Friend WithEvents txtModName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnModDown As Guna.UI2.WinForms.Guna2ImageButton
    Friend WithEvents btnModUP As Guna.UI2.WinForms.Guna2ImageButton
    Friend WithEvents Label4 As Label
    Friend WithEvents cbProdStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cbProdModGroup As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label80 As Label
    Friend WithEvents cbProdModID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents dgvModifier As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents dgvProdMod As Guna.UI2.WinForms.Guna2DataGridView
End Class
