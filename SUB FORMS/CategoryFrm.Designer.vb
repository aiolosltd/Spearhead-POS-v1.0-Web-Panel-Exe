<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CategoryFrm
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.btnClearProdCat = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveProdCat = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteProdCat = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.cbCatStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.txtCatDesc = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.txtCategoryName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.dgvProductCategory = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvProductCategory, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(1024, 47)
        Me.Panel1.TabIndex = 8
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(188, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Categories"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Guna2Separator1)
        Me.Panel2.Controls.Add(Me.btnClearProdCat)
        Me.Panel2.Controls.Add(Me.btnSaveProdCat)
        Me.Panel2.Controls.Add(Me.btnDeleteProdCat)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 685)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1024, 83)
        Me.Panel2.TabIndex = 9
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator1.TabIndex = 105
        '
        'btnClearProdCat
        '
        Me.btnClearProdCat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearProdCat.BorderRadius = 5
        Me.btnClearProdCat.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearProdCat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearProdCat.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearProdCat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearProdCat.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearProdCat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearProdCat.ForeColor = System.Drawing.Color.White
        Me.btnClearProdCat.Location = New System.Drawing.Point(439, 23)
        Me.btnClearProdCat.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearProdCat.Name = "btnClearProdCat"
        Me.btnClearProdCat.Size = New System.Drawing.Size(175, 47)
        Me.btnClearProdCat.TabIndex = 93
        Me.btnClearProdCat.Text = "Clear Fields"
        '
        'btnSaveProdCat
        '
        Me.btnSaveProdCat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveProdCat.BorderRadius = 5
        Me.btnSaveProdCat.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveProdCat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveProdCat.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveProdCat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveProdCat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProdCat.ForeColor = System.Drawing.Color.White
        Me.btnSaveProdCat.Location = New System.Drawing.Point(622, 23)
        Me.btnSaveProdCat.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveProdCat.Name = "btnSaveProdCat"
        Me.btnSaveProdCat.Size = New System.Drawing.Size(175, 47)
        Me.btnSaveProdCat.TabIndex = 91
        Me.btnSaveProdCat.Text = "Save Category"
        '
        'btnDeleteProdCat
        '
        Me.btnDeleteProdCat.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteProdCat.BorderRadius = 5
        Me.btnDeleteProdCat.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteProdCat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteProdCat.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteProdCat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteProdCat.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteProdCat.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteProdCat.ForeColor = System.Drawing.Color.White
        Me.btnDeleteProdCat.Location = New System.Drawing.Point(256, 23)
        Me.btnDeleteProdCat.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteProdCat.Name = "btnDeleteProdCat"
        Me.btnDeleteProdCat.Size = New System.Drawing.Size(175, 47)
        Me.btnDeleteProdCat.TabIndex = 92
        Me.btnDeleteProdCat.Text = "Delete User"
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator2.TabIndex = 11
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label100)
        Me.Panel3.Controls.Add(Me.cbCatStoreID)
        Me.Panel3.Controls.Add(Me.Label99)
        Me.Panel3.Controls.Add(Me.txtCatDesc)
        Me.Panel3.Controls.Add(Me.Label98)
        Me.Panel3.Controls.Add(Me.txtCategoryName)
        Me.Panel3.Controls.Add(Me.Guna2Separator3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 482)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1024, 203)
        Me.Panel3.TabIndex = 13
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label100.Location = New System.Drawing.Point(310, 33)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(57, 17)
        Me.Label100.TabIndex = 111
        Me.Label100.Text = "Store ID"
        '
        'cbCatStoreID
        '
        Me.cbCatStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbCatStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbCatStoreID.BorderRadius = 5
        Me.cbCatStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbCatStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCatStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCatStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbCatStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbCatStoreID.ForeColor = System.Drawing.Color.Black
        Me.cbCatStoreID.ItemHeight = 30
        Me.cbCatStoreID.Location = New System.Drawing.Point(313, 59)
        Me.cbCatStoreID.Name = "cbCatStoreID"
        Me.cbCatStoreID.Size = New System.Drawing.Size(274, 36)
        Me.cbCatStoreID.TabIndex = 110
        '
        'Label99
        '
        Me.Label99.AutoSize = True
        Me.Label99.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label99.Location = New System.Drawing.Point(17, 111)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(76, 17)
        Me.Label99.TabIndex = 109
        Me.Label99.Text = "Description"
        '
        'txtCatDesc
        '
        Me.txtCatDesc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCatDesc.BorderRadius = 5
        Me.txtCatDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCatDesc.DefaultText = ""
        Me.txtCatDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCatDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCatDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCatDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCatDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCatDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCatDesc.ForeColor = System.Drawing.Color.Black
        Me.txtCatDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCatDesc.Location = New System.Drawing.Point(20, 131)
        Me.txtCatDesc.Multiline = True
        Me.txtCatDesc.Name = "txtCatDesc"
        Me.txtCatDesc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCatDesc.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCatDesc.PlaceholderText = ""
        Me.txtCatDesc.SelectedText = ""
        Me.txtCatDesc.Size = New System.Drawing.Size(567, 46)
        Me.txtCatDesc.TabIndex = 108
        '
        'Label98
        '
        Me.Label98.AutoSize = True
        Me.Label98.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label98.Location = New System.Drawing.Point(17, 33)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(102, 17)
        Me.Label98.TabIndex = 107
        Me.Label98.Text = "Category name"
        '
        'txtCategoryName
        '
        Me.txtCategoryName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCategoryName.BorderRadius = 5
        Me.txtCategoryName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCategoryName.DefaultText = ""
        Me.txtCategoryName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCategoryName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCategoryName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCategoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCategoryName.ForeColor = System.Drawing.Color.Black
        Me.txtCategoryName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCategoryName.Location = New System.Drawing.Point(20, 55)
        Me.txtCategoryName.Name = "txtCategoryName"
        Me.txtCategoryName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCategoryName.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCategoryName.PlaceholderText = ""
        Me.txtCategoryName.SelectedText = ""
        Me.txtCategoryName.Size = New System.Drawing.Size(273, 40)
        Me.txtCategoryName.TabIndex = 106
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator3.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1024, 8)
        Me.Guna2Separator3.TabIndex = 105
        '
        'dgvProductCategory
        '
        Me.dgvProductCategory.AllowUserToAddRows = False
        Me.dgvProductCategory.AllowUserToDeleteRows = False
        Me.dgvProductCategory.AllowUserToResizeColumns = False
        Me.dgvProductCategory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvProductCategory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProductCategory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvProductCategory.ColumnHeadersHeight = 50
        Me.dgvProductCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProductCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvProductCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductCategory.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProductCategory.Location = New System.Drawing.Point(0, 55)
        Me.dgvProductCategory.Name = "dgvProductCategory"
        Me.dgvProductCategory.ReadOnly = True
        Me.dgvProductCategory.RowHeadersVisible = False
        Me.dgvProductCategory.RowHeadersWidth = 60
        Me.dgvProductCategory.RowTemplate.Height = 30
        Me.dgvProductCategory.Size = New System.Drawing.Size(1024, 427)
        Me.dgvProductCategory.TabIndex = 14
        Me.dgvProductCategory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvProductCategory.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvProductCategory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvProductCategory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvProductCategory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvProductCategory.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvProductCategory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvProductCategory.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvProductCategory.ThemeStyle.ReadOnly = True
        Me.dgvProductCategory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvProductCategory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvProductCategory.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvProductCategory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvProductCategory.ThemeStyle.RowsStyle.Height = 30
        Me.dgvProductCategory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvProductCategory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'CategoryFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.dgvProductCategory)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Guna2Separator2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "CategoryFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgvProductCategory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents btnClearProdCat As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveProdCat As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteProdCat As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Label100 As Label
    Friend WithEvents cbCatStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label99 As Label
    Friend WithEvents txtCatDesc As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label98 As Label
    Friend WithEvents txtCategoryName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvProductCategory As Guna.UI2.WinForms.Guna2DataGridView
End Class
