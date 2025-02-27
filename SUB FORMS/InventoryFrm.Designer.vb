<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryFrm
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Guna2TabControl1 = New Guna.UI2.WinForms.Guna2TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvInventory = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator5 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel4 = New Guna.UI2.WinForms.Guna2Panel()
        Me.cbPrimaryUOM = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbSecondaryUOM = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.txtItemCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.cbInvStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtItemUnitCost = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtCriticalLimit = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtSecondaryValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtPrimaryValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtItemName = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Guna2Panel1 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearInventory = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveItem = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteItem = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator2 = New Guna.UI2.WinForms.Guna2Separator()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvFormula = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator3 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel2 = New Guna.UI2.WinForms.Guna2Panel()
        Me.cbItemCodeFormula = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.cbPCodeFormula = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.cbFormulaStoreID = New Guna.UI2.WinForms.Guna2ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.txtFormulaUnitCost = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.txtToleranceValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtServingValue = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Guna2Panel5 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearFormula = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveFormula = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteFormula = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator6 = New Guna.UI2.WinForms.Guna2Separator()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvUOm = New Guna.UI2.WinForms.Guna2DataGridView()
        Me.Guna2Separator4 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Panel3 = New Guna.UI2.WinForms.Guna2Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtuomDesc = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtuomCode = New Guna.UI2.WinForms.Guna2TextBox()
        Me.Guna2Panel6 = New Guna.UI2.WinForms.Guna2Panel()
        Me.btnClearuom = New Guna.UI2.WinForms.Guna2Button()
        Me.btnSaveuom = New Guna.UI2.WinForms.Guna2Button()
        Me.btnDeleteuom = New Guna.UI2.WinForms.Guna2Button()
        Me.Guna2Separator7 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Guna2Separator1 = New Guna.UI2.WinForms.Guna2Separator()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Guna2HtmlLabel1 = New Guna.UI2.WinForms.Guna2HtmlLabel()
        Me.Guna2TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel4.SuspendLayout()
        Me.Guna2Panel1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel2.SuspendLayout()
        Me.Guna2Panel5.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvUOm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Guna2Panel3.SuspendLayout()
        Me.Guna2Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Guna2TabControl1
        '
        Me.Guna2TabControl1.Controls.Add(Me.TabPage1)
        Me.Guna2TabControl1.Controls.Add(Me.TabPage2)
        Me.Guna2TabControl1.Controls.Add(Me.TabPage3)
        Me.Guna2TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Guna2TabControl1.ItemSize = New System.Drawing.Size(180, 40)
        Me.Guna2TabControl1.Location = New System.Drawing.Point(0, 55)
        Me.Guna2TabControl1.Name = "Guna2TabControl1"
        Me.Guna2TabControl1.SelectedIndex = 0
        Me.Guna2TabControl1.Size = New System.Drawing.Size(1022, 711)
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
        Me.Guna2TabControl1.TabIndex = 14
        Me.Guna2TabControl1.TabMenuBackColor = System.Drawing.Color.SteelBlue
        Me.Guna2TabControl1.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.dgvInventory)
        Me.TabPage1.Controls.Add(Me.Guna2Separator5)
        Me.TabPage1.Controls.Add(Me.Guna2Panel4)
        Me.TabPage1.Controls.Add(Me.Guna2Panel1)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TabPage1.Location = New System.Drawing.Point(4, 44)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1014, 663)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Inventory Item"
        '
        'dgvInventory
        '
        Me.dgvInventory.AllowUserToAddRows = False
        Me.dgvInventory.AllowUserToDeleteRows = False
        Me.dgvInventory.AllowUserToResizeColumns = False
        Me.dgvInventory.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        Me.dgvInventory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInventory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInventory.ColumnHeadersHeight = 50
        Me.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInventory.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInventory.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvInventory.Location = New System.Drawing.Point(3, 3)
        Me.dgvInventory.Name = "dgvInventory"
        Me.dgvInventory.ReadOnly = True
        Me.dgvInventory.RowHeadersVisible = False
        Me.dgvInventory.RowHeadersWidth = 60
        Me.dgvInventory.RowTemplate.Height = 30
        Me.dgvInventory.Size = New System.Drawing.Size(1008, 290)
        Me.dgvInventory.TabIndex = 19
        Me.dgvInventory.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvInventory.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvInventory.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvInventory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvInventory.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvInventory.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvInventory.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvInventory.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvInventory.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvInventory.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvInventory.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvInventory.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvInventory.ThemeStyle.ReadOnly = True
        Me.dgvInventory.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvInventory.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvInventory.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvInventory.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvInventory.ThemeStyle.RowsStyle.Height = 30
        Me.dgvInventory.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvInventory.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator5
        '
        Me.Guna2Separator5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Separator5.Location = New System.Drawing.Point(3, 293)
        Me.Guna2Separator5.Name = "Guna2Separator5"
        Me.Guna2Separator5.Size = New System.Drawing.Size(1008, 8)
        Me.Guna2Separator5.TabIndex = 18
        '
        'Guna2Panel4
        '
        Me.Guna2Panel4.Controls.Add(Me.cbPrimaryUOM)
        Me.Guna2Panel4.Controls.Add(Me.cbSecondaryUOM)
        Me.Guna2Panel4.Controls.Add(Me.txtItemCode)
        Me.Guna2Panel4.Controls.Add(Me.Label79)
        Me.Guna2Panel4.Controls.Add(Me.cbInvStoreID)
        Me.Guna2Panel4.Controls.Add(Me.Label34)
        Me.Guna2Panel4.Controls.Add(Me.Label27)
        Me.Guna2Panel4.Controls.Add(Me.txtItemUnitCost)
        Me.Guna2Panel4.Controls.Add(Me.Label28)
        Me.Guna2Panel4.Controls.Add(Me.txtCriticalLimit)
        Me.Guna2Panel4.Controls.Add(Me.Label29)
        Me.Guna2Panel4.Controls.Add(Me.txtSecondaryValue)
        Me.Guna2Panel4.Controls.Add(Me.Label30)
        Me.Guna2Panel4.Controls.Add(Me.Label31)
        Me.Guna2Panel4.Controls.Add(Me.txtPrimaryValue)
        Me.Guna2Panel4.Controls.Add(Me.Label32)
        Me.Guna2Panel4.Controls.Add(Me.txtItemName)
        Me.Guna2Panel4.Controls.Add(Me.Label33)
        Me.Guna2Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel4.Location = New System.Drawing.Point(3, 301)
        Me.Guna2Panel4.Name = "Guna2Panel4"
        Me.Guna2Panel4.Size = New System.Drawing.Size(1008, 294)
        Me.Guna2Panel4.TabIndex = 17
        '
        'cbPrimaryUOM
        '
        Me.cbPrimaryUOM.AllowDrop = True
        Me.cbPrimaryUOM.BackColor = System.Drawing.Color.Transparent
        Me.cbPrimaryUOM.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbPrimaryUOM.BorderRadius = 5
        Me.cbPrimaryUOM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPrimaryUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPrimaryUOM.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPrimaryUOM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPrimaryUOM.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbPrimaryUOM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbPrimaryUOM.ItemHeight = 30
        Me.cbPrimaryUOM.Location = New System.Drawing.Point(13, 174)
        Me.cbPrimaryUOM.Name = "cbPrimaryUOM"
        Me.cbPrimaryUOM.Size = New System.Drawing.Size(239, 36)
        Me.cbPrimaryUOM.TabIndex = 210
        Me.cbPrimaryUOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbSecondaryUOM
        '
        Me.cbSecondaryUOM.AllowDrop = True
        Me.cbSecondaryUOM.BackColor = System.Drawing.Color.Transparent
        Me.cbSecondaryUOM.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbSecondaryUOM.BorderRadius = 5
        Me.cbSecondaryUOM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSecondaryUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSecondaryUOM.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbSecondaryUOM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbSecondaryUOM.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbSecondaryUOM.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbSecondaryUOM.ItemHeight = 30
        Me.cbSecondaryUOM.Location = New System.Drawing.Point(273, 23)
        Me.cbSecondaryUOM.Name = "cbSecondaryUOM"
        Me.cbSecondaryUOM.Size = New System.Drawing.Size(239, 36)
        Me.cbSecondaryUOM.TabIndex = 209
        Me.cbSecondaryUOM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtItemCode
        '
        Me.txtItemCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemCode.BorderRadius = 5
        Me.txtItemCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItemCode.DefaultText = ""
        Me.txtItemCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtItemCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtItemCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtItemCode.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtItemCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemCode.Location = New System.Drawing.Point(13, 23)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemCode.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemCode.PlaceholderText = ""
        Me.txtItemCode.SelectedText = ""
        Me.txtItemCode.Size = New System.Drawing.Size(239, 36)
        Me.txtItemCode.TabIndex = 208
        Me.txtItemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label79.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label79.Location = New System.Drawing.Point(531, 3)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(53, 17)
        Me.Label79.TabIndex = 207
        Me.Label79.Text = "StoreID"
        '
        'cbInvStoreID
        '
        Me.cbInvStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbInvStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbInvStoreID.BorderRadius = 5
        Me.cbInvStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbInvStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbInvStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbInvStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbInvStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbInvStoreID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cbInvStoreID.ItemHeight = 30
        Me.cbInvStoreID.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbInvStoreID.Location = New System.Drawing.Point(534, 23)
        Me.cbInvStoreID.Name = "cbInvStoreID"
        Me.cbInvStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbInvStoreID.TabIndex = 206
        Me.cbInvStoreID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label34.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label34.Location = New System.Drawing.Point(10, 79)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(76, 17)
        Me.Label34.TabIndex = 205
        Me.Label34.Text = "Item Name"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label27.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label27.Location = New System.Drawing.Point(271, 229)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 17)
        Me.Label27.TabIndex = 204
        Me.Label27.Text = "Unit Cost"
        '
        'txtItemUnitCost
        '
        Me.txtItemUnitCost.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemUnitCost.BorderRadius = 5
        Me.txtItemUnitCost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItemUnitCost.DefaultText = ""
        Me.txtItemUnitCost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtItemUnitCost.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtItemUnitCost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemUnitCost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemUnitCost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemUnitCost.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtItemUnitCost.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtItemUnitCost.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemUnitCost.Location = New System.Drawing.Point(273, 249)
        Me.txtItemUnitCost.Name = "txtItemUnitCost"
        Me.txtItemUnitCost.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemUnitCost.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemUnitCost.PlaceholderText = ""
        Me.txtItemUnitCost.SelectedText = ""
        Me.txtItemUnitCost.Size = New System.Drawing.Size(239, 36)
        Me.txtItemUnitCost.TabIndex = 203
        Me.txtItemUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label28.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label28.Location = New System.Drawing.Point(271, 154)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 17)
        Me.Label28.TabIndex = 202
        Me.Label28.Text = "Critical Limit"
        '
        'txtCriticalLimit
        '
        Me.txtCriticalLimit.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCriticalLimit.BorderRadius = 5
        Me.txtCriticalLimit.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtCriticalLimit.DefaultText = ""
        Me.txtCriticalLimit.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtCriticalLimit.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtCriticalLimit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCriticalLimit.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtCriticalLimit.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCriticalLimit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtCriticalLimit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtCriticalLimit.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtCriticalLimit.Location = New System.Drawing.Point(273, 174)
        Me.txtCriticalLimit.Name = "txtCriticalLimit"
        Me.txtCriticalLimit.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtCriticalLimit.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtCriticalLimit.PlaceholderText = ""
        Me.txtCriticalLimit.SelectedText = ""
        Me.txtCriticalLimit.Size = New System.Drawing.Size(239, 36)
        Me.txtCriticalLimit.TabIndex = 201
        Me.txtCriticalLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label29.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label29.Location = New System.Drawing.Point(270, 79)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(108, 17)
        Me.Label29.TabIndex = 200
        Me.Label29.Text = "Secondary Value"
        '
        'txtSecondaryValue
        '
        Me.txtSecondaryValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSecondaryValue.BorderRadius = 5
        Me.txtSecondaryValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSecondaryValue.DefaultText = ""
        Me.txtSecondaryValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtSecondaryValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtSecondaryValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSecondaryValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtSecondaryValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSecondaryValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtSecondaryValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtSecondaryValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSecondaryValue.Location = New System.Drawing.Point(273, 99)
        Me.txtSecondaryValue.Name = "txtSecondaryValue"
        Me.txtSecondaryValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtSecondaryValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtSecondaryValue.PlaceholderText = ""
        Me.txtSecondaryValue.SelectedText = ""
        Me.txtSecondaryValue.Size = New System.Drawing.Size(239, 36)
        Me.txtSecondaryValue.TabIndex = 199
        Me.txtSecondaryValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label30.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label30.Location = New System.Drawing.Point(271, 3)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(107, 17)
        Me.Label30.TabIndex = 198
        Me.Label30.Text = "Secondary UOM"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label31.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label31.Location = New System.Drawing.Point(10, 229)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(92, 17)
        Me.Label31.TabIndex = 197
        Me.Label31.Text = "Primary Value"
        '
        'txtPrimaryValue
        '
        Me.txtPrimaryValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPrimaryValue.BorderRadius = 5
        Me.txtPrimaryValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPrimaryValue.DefaultText = ""
        Me.txtPrimaryValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtPrimaryValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPrimaryValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrimaryValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtPrimaryValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPrimaryValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtPrimaryValue.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPrimaryValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtPrimaryValue.Location = New System.Drawing.Point(13, 249)
        Me.txtPrimaryValue.Name = "txtPrimaryValue"
        Me.txtPrimaryValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtPrimaryValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtPrimaryValue.PlaceholderText = ""
        Me.txtPrimaryValue.SelectedText = ""
        Me.txtPrimaryValue.Size = New System.Drawing.Size(239, 36)
        Me.txtPrimaryValue.TabIndex = 196
        Me.txtPrimaryValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label32.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label32.Location = New System.Drawing.Point(10, 154)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 17)
        Me.Label32.TabIndex = 195
        Me.Label32.Text = "Primary UOM"
        '
        'txtItemName
        '
        Me.txtItemName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemName.BorderRadius = 5
        Me.txtItemName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtItemName.DefaultText = ""
        Me.txtItemName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtItemName.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtItemName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtItemName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtItemName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtItemName.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtItemName.Location = New System.Drawing.Point(13, 99)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtItemName.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtItemName.PlaceholderText = ""
        Me.txtItemName.SelectedText = ""
        Me.txtItemName.Size = New System.Drawing.Size(239, 36)
        Me.txtItemName.TabIndex = 194
        Me.txtItemName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label33.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label33.Location = New System.Drawing.Point(10, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(71, 17)
        Me.Label33.TabIndex = 193
        Me.Label33.Text = "Item Code"
        '
        'Guna2Panel1
        '
        Me.Guna2Panel1.Controls.Add(Me.btnClearInventory)
        Me.Guna2Panel1.Controls.Add(Me.btnSaveItem)
        Me.Guna2Panel1.Controls.Add(Me.btnDeleteItem)
        Me.Guna2Panel1.Controls.Add(Me.Guna2Separator2)
        Me.Guna2Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel1.Location = New System.Drawing.Point(3, 595)
        Me.Guna2Panel1.Name = "Guna2Panel1"
        Me.Guna2Panel1.Size = New System.Drawing.Size(1008, 65)
        Me.Guna2Panel1.TabIndex = 0
        '
        'btnClearInventory
        '
        Me.btnClearInventory.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearInventory.BorderRadius = 5
        Me.btnClearInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearInventory.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearInventory.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearInventory.ForeColor = System.Drawing.Color.White
        Me.btnClearInventory.Location = New System.Drawing.Point(411, 11)
        Me.btnClearInventory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearInventory.Name = "btnClearInventory"
        Me.btnClearInventory.Size = New System.Drawing.Size(213, 47)
        Me.btnClearInventory.TabIndex = 320
        Me.btnClearInventory.Text = "Clear Fields"
        '
        'btnSaveItem
        '
        Me.btnSaveItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveItem.BorderRadius = 5
        Me.btnSaveItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveItem.ForeColor = System.Drawing.Color.White
        Me.btnSaveItem.Location = New System.Drawing.Point(632, 11)
        Me.btnSaveItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveItem.Name = "btnSaveItem"
        Me.btnSaveItem.Size = New System.Drawing.Size(213, 47)
        Me.btnSaveItem.TabIndex = 318
        Me.btnSaveItem.Text = "Save Item"
        '
        'btnDeleteItem
        '
        Me.btnDeleteItem.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteItem.BorderRadius = 5
        Me.btnDeleteItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteItem.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteItem.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteItem.ForeColor = System.Drawing.Color.White
        Me.btnDeleteItem.Location = New System.Drawing.Point(190, 11)
        Me.btnDeleteItem.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteItem.Name = "btnDeleteItem"
        Me.btnDeleteItem.Size = New System.Drawing.Size(213, 47)
        Me.btnDeleteItem.TabIndex = 319
        Me.btnDeleteItem.Text = "Delete Item"
        '
        'Guna2Separator2
        '
        Me.Guna2Separator2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator2.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator2.Name = "Guna2Separator2"
        Me.Guna2Separator2.Size = New System.Drawing.Size(1008, 8)
        Me.Guna2Separator2.TabIndex = 11
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.dgvFormula)
        Me.TabPage2.Controls.Add(Me.Guna2Separator3)
        Me.TabPage2.Controls.Add(Me.Guna2Panel2)
        Me.TabPage2.Controls.Add(Me.Guna2Panel5)
        Me.TabPage2.Location = New System.Drawing.Point(4, 44)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1014, 663)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Formula"
        '
        'dgvFormula
        '
        Me.dgvFormula.AllowUserToAddRows = False
        Me.dgvFormula.AllowUserToDeleteRows = False
        Me.dgvFormula.AllowUserToResizeColumns = False
        Me.dgvFormula.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        Me.dgvFormula.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFormula.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvFormula.ColumnHeadersHeight = 50
        Me.dgvFormula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFormula.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFormula.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFormula.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFormula.Location = New System.Drawing.Point(3, 3)
        Me.dgvFormula.Name = "dgvFormula"
        Me.dgvFormula.ReadOnly = True
        Me.dgvFormula.RowHeadersVisible = False
        Me.dgvFormula.RowHeadersWidth = 60
        Me.dgvFormula.RowTemplate.Height = 30
        Me.dgvFormula.Size = New System.Drawing.Size(1008, 348)
        Me.dgvFormula.TabIndex = 22
        Me.dgvFormula.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvFormula.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvFormula.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvFormula.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvFormula.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvFormula.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvFormula.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFormula.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFormula.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvFormula.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFormula.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvFormula.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvFormula.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvFormula.ThemeStyle.ReadOnly = True
        Me.dgvFormula.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvFormula.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvFormula.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvFormula.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvFormula.ThemeStyle.RowsStyle.Height = 30
        Me.dgvFormula.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvFormula.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator3
        '
        Me.Guna2Separator3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Separator3.Location = New System.Drawing.Point(3, 351)
        Me.Guna2Separator3.Name = "Guna2Separator3"
        Me.Guna2Separator3.Size = New System.Drawing.Size(1008, 8)
        Me.Guna2Separator3.TabIndex = 21
        '
        'Guna2Panel2
        '
        Me.Guna2Panel2.Controls.Add(Me.cbItemCodeFormula)
        Me.Guna2Panel2.Controls.Add(Me.cbPCodeFormula)
        Me.Guna2Panel2.Controls.Add(Me.Label80)
        Me.Guna2Panel2.Controls.Add(Me.cbFormulaStoreID)
        Me.Guna2Panel2.Controls.Add(Me.Label39)
        Me.Guna2Panel2.Controls.Add(Me.txtFormulaUnitCost)
        Me.Guna2Panel2.Controls.Add(Me.Label35)
        Me.Guna2Panel2.Controls.Add(Me.Label36)
        Me.Guna2Panel2.Controls.Add(Me.txtToleranceValue)
        Me.Guna2Panel2.Controls.Add(Me.Label37)
        Me.Guna2Panel2.Controls.Add(Me.txtServingValue)
        Me.Guna2Panel2.Controls.Add(Me.Label38)
        Me.Guna2Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel2.Location = New System.Drawing.Point(3, 359)
        Me.Guna2Panel2.Name = "Guna2Panel2"
        Me.Guna2Panel2.Size = New System.Drawing.Size(1008, 236)
        Me.Guna2Panel2.TabIndex = 20
        '
        'cbItemCodeFormula
        '
        Me.cbItemCodeFormula.BackColor = System.Drawing.Color.Transparent
        Me.cbItemCodeFormula.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbItemCodeFormula.BorderRadius = 5
        Me.cbItemCodeFormula.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbItemCodeFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbItemCodeFormula.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbItemCodeFormula.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbItemCodeFormula.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbItemCodeFormula.ForeColor = System.Drawing.Color.Black
        Me.cbItemCodeFormula.ItemHeight = 30
        Me.cbItemCodeFormula.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbItemCodeFormula.Location = New System.Drawing.Point(25, 109)
        Me.cbItemCodeFormula.Name = "cbItemCodeFormula"
        Me.cbItemCodeFormula.Size = New System.Drawing.Size(239, 36)
        Me.cbItemCodeFormula.TabIndex = 2
        Me.cbItemCodeFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cbPCodeFormula
        '
        Me.cbPCodeFormula.BackColor = System.Drawing.Color.Transparent
        Me.cbPCodeFormula.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbPCodeFormula.BorderRadius = 5
        Me.cbPCodeFormula.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbPCodeFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPCodeFormula.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPCodeFormula.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbPCodeFormula.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbPCodeFormula.ForeColor = System.Drawing.Color.Black
        Me.cbPCodeFormula.ItemHeight = 30
        Me.cbPCodeFormula.Items.AddRange(New Object() {"1", "2", "3"})
        Me.cbPCodeFormula.Location = New System.Drawing.Point(25, 35)
        Me.cbPCodeFormula.Name = "cbPCodeFormula"
        Me.cbPCodeFormula.Size = New System.Drawing.Size(239, 36)
        Me.cbPCodeFormula.TabIndex = 1
        Me.cbPCodeFormula.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label80.Location = New System.Drawing.Point(291, 163)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(53, 17)
        Me.Label80.TabIndex = 159
        Me.Label80.Text = "StoreID"
        '
        'cbFormulaStoreID
        '
        Me.cbFormulaStoreID.BackColor = System.Drawing.Color.Transparent
        Me.cbFormulaStoreID.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbFormulaStoreID.BorderRadius = 5
        Me.cbFormulaStoreID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbFormulaStoreID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbFormulaStoreID.FocusedColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbFormulaStoreID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cbFormulaStoreID.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbFormulaStoreID.ForeColor = System.Drawing.Color.Black
        Me.cbFormulaStoreID.ItemHeight = 30
        Me.cbFormulaStoreID.Location = New System.Drawing.Point(294, 183)
        Me.cbFormulaStoreID.Name = "cbFormulaStoreID"
        Me.cbFormulaStoreID.Size = New System.Drawing.Size(239, 36)
        Me.cbFormulaStoreID.TabIndex = 6
        Me.cbFormulaStoreID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label39.Location = New System.Drawing.Point(291, 89)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(62, 17)
        Me.Label39.TabIndex = 157
        Me.Label39.Text = "Unit cost"
        '
        'txtFormulaUnitCost
        '
        Me.txtFormulaUnitCost.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFormulaUnitCost.BorderRadius = 5
        Me.txtFormulaUnitCost.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtFormulaUnitCost.DefaultText = ""
        Me.txtFormulaUnitCost.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtFormulaUnitCost.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtFormulaUnitCost.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFormulaUnitCost.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtFormulaUnitCost.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFormulaUnitCost.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtFormulaUnitCost.ForeColor = System.Drawing.Color.Black
        Me.txtFormulaUnitCost.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtFormulaUnitCost.Location = New System.Drawing.Point(294, 109)
        Me.txtFormulaUnitCost.Name = "txtFormulaUnitCost"
        Me.txtFormulaUnitCost.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtFormulaUnitCost.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtFormulaUnitCost.PlaceholderText = ""
        Me.txtFormulaUnitCost.SelectedText = ""
        Me.txtFormulaUnitCost.Size = New System.Drawing.Size(239, 40)
        Me.txtFormulaUnitCost.TabIndex = 5
        Me.txtFormulaUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label35.Location = New System.Drawing.Point(22, 89)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(71, 17)
        Me.Label35.TabIndex = 155
        Me.Label35.Text = "Item Code"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label36.Location = New System.Drawing.Point(291, 15)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(101, 17)
        Me.Label36.TabIndex = 154
        Me.Label36.Text = "Tolerance Value"
        '
        'txtToleranceValue
        '
        Me.txtToleranceValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtToleranceValue.BorderRadius = 5
        Me.txtToleranceValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToleranceValue.DefaultText = ""
        Me.txtToleranceValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtToleranceValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtToleranceValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtToleranceValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtToleranceValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtToleranceValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtToleranceValue.ForeColor = System.Drawing.Color.Black
        Me.txtToleranceValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtToleranceValue.Location = New System.Drawing.Point(294, 35)
        Me.txtToleranceValue.Name = "txtToleranceValue"
        Me.txtToleranceValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtToleranceValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtToleranceValue.PlaceholderText = ""
        Me.txtToleranceValue.SelectedText = ""
        Me.txtToleranceValue.Size = New System.Drawing.Size(239, 40)
        Me.txtToleranceValue.TabIndex = 4
        Me.txtToleranceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label37.Location = New System.Drawing.Point(22, 162)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(90, 17)
        Me.Label37.TabIndex = 152
        Me.Label37.Text = "Serving Value"
        '
        'txtServingValue
        '
        Me.txtServingValue.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtServingValue.BorderRadius = 5
        Me.txtServingValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtServingValue.DefaultText = ""
        Me.txtServingValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtServingValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtServingValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServingValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtServingValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServingValue.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtServingValue.ForeColor = System.Drawing.Color.Black
        Me.txtServingValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtServingValue.Location = New System.Drawing.Point(25, 182)
        Me.txtServingValue.Name = "txtServingValue"
        Me.txtServingValue.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtServingValue.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtServingValue.PlaceholderText = ""
        Me.txtServingValue.SelectedText = ""
        Me.txtServingValue.Size = New System.Drawing.Size(239, 40)
        Me.txtServingValue.TabIndex = 3
        Me.txtServingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label38.Location = New System.Drawing.Point(22, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(73, 17)
        Me.Label38.TabIndex = 150
        Me.Label38.Text = "Product ID"
        '
        'Guna2Panel5
        '
        Me.Guna2Panel5.Controls.Add(Me.btnClearFormula)
        Me.Guna2Panel5.Controls.Add(Me.btnSaveFormula)
        Me.Guna2Panel5.Controls.Add(Me.btnDeleteFormula)
        Me.Guna2Panel5.Controls.Add(Me.Guna2Separator6)
        Me.Guna2Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel5.Location = New System.Drawing.Point(3, 595)
        Me.Guna2Panel5.Name = "Guna2Panel5"
        Me.Guna2Panel5.Size = New System.Drawing.Size(1008, 65)
        Me.Guna2Panel5.TabIndex = 19
        '
        'btnClearFormula
        '
        Me.btnClearFormula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearFormula.BorderRadius = 5
        Me.btnClearFormula.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFormula.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearFormula.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearFormula.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearFormula.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearFormula.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFormula.ForeColor = System.Drawing.Color.White
        Me.btnClearFormula.Location = New System.Drawing.Point(411, 11)
        Me.btnClearFormula.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearFormula.Name = "btnClearFormula"
        Me.btnClearFormula.Size = New System.Drawing.Size(213, 47)
        Me.btnClearFormula.TabIndex = 320
        Me.btnClearFormula.Text = "Clear Fields"
        '
        'btnSaveFormula
        '
        Me.btnSaveFormula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveFormula.BorderRadius = 5
        Me.btnSaveFormula.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveFormula.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveFormula.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveFormula.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveFormula.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveFormula.ForeColor = System.Drawing.Color.White
        Me.btnSaveFormula.Location = New System.Drawing.Point(632, 11)
        Me.btnSaveFormula.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveFormula.Name = "btnSaveFormula"
        Me.btnSaveFormula.Size = New System.Drawing.Size(213, 47)
        Me.btnSaveFormula.TabIndex = 318
        Me.btnSaveFormula.Text = "Save Formula"
        '
        'btnDeleteFormula
        '
        Me.btnDeleteFormula.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteFormula.BorderRadius = 5
        Me.btnDeleteFormula.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteFormula.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteFormula.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteFormula.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteFormula.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteFormula.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteFormula.ForeColor = System.Drawing.Color.White
        Me.btnDeleteFormula.Location = New System.Drawing.Point(190, 11)
        Me.btnDeleteFormula.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteFormula.Name = "btnDeleteFormula"
        Me.btnDeleteFormula.Size = New System.Drawing.Size(213, 47)
        Me.btnDeleteFormula.TabIndex = 319
        Me.btnDeleteFormula.Text = "Delete Formula"
        '
        'Guna2Separator6
        '
        Me.Guna2Separator6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator6.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator6.Name = "Guna2Separator6"
        Me.Guna2Separator6.Size = New System.Drawing.Size(1008, 8)
        Me.Guna2Separator6.TabIndex = 11
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TabPage3.Controls.Add(Me.dgvUOm)
        Me.TabPage3.Controls.Add(Me.Guna2Separator4)
        Me.TabPage3.Controls.Add(Me.Guna2Panel3)
        Me.TabPage3.Controls.Add(Me.Guna2Panel6)
        Me.TabPage3.Location = New System.Drawing.Point(4, 44)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1014, 663)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Unit of Measure (UOM)"
        '
        'dgvUOm
        '
        Me.dgvUOm.AllowUserToAddRows = False
        Me.dgvUOm.AllowUserToDeleteRows = False
        Me.dgvUOm.AllowUserToResizeColumns = False
        Me.dgvUOm.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        Me.dgvUOm.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUOm.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvUOm.ColumnHeadersHeight = 50
        Me.dgvUOm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUOm.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvUOm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUOm.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUOm.Location = New System.Drawing.Point(0, 0)
        Me.dgvUOm.Name = "dgvUOm"
        Me.dgvUOm.ReadOnly = True
        Me.dgvUOm.RowHeadersVisible = False
        Me.dgvUOm.RowHeadersWidth = 60
        Me.dgvUOm.RowTemplate.Height = 30
        Me.dgvUOm.Size = New System.Drawing.Size(1014, 415)
        Me.dgvUOm.TabIndex = 25
        Me.dgvUOm.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvUOm.ThemeStyle.AlternatingRowsStyle.Font = Nothing
        Me.dgvUOm.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty
        Me.dgvUOm.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty
        Me.dgvUOm.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty
        Me.dgvUOm.ThemeStyle.BackColor = System.Drawing.Color.White
        Me.dgvUOm.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUOm.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(88, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUOm.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvUOm.ThemeStyle.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUOm.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White
        Me.dgvUOm.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        Me.dgvUOm.ThemeStyle.HeaderStyle.Height = 50
        Me.dgvUOm.ThemeStyle.ReadOnly = True
        Me.dgvUOm.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White
        Me.dgvUOm.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgvUOm.ThemeStyle.RowsStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvUOm.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.dgvUOm.ThemeStyle.RowsStyle.Height = 30
        Me.dgvUOm.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvUOm.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(94, Byte), Integer))
        '
        'Guna2Separator4
        '
        Me.Guna2Separator4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Separator4.Location = New System.Drawing.Point(0, 415)
        Me.Guna2Separator4.Name = "Guna2Separator4"
        Me.Guna2Separator4.Size = New System.Drawing.Size(1014, 8)
        Me.Guna2Separator4.TabIndex = 24
        '
        'Guna2Panel3
        '
        Me.Guna2Panel3.Controls.Add(Me.Label1)
        Me.Guna2Panel3.Controls.Add(Me.txtuomDesc)
        Me.Guna2Panel3.Controls.Add(Me.Label2)
        Me.Guna2Panel3.Controls.Add(Me.txtuomCode)
        Me.Guna2Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel3.Location = New System.Drawing.Point(0, 423)
        Me.Guna2Panel3.Name = "Guna2Panel3"
        Me.Guna2Panel3.Size = New System.Drawing.Size(1014, 175)
        Me.Guna2Panel3.TabIndex = 23
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(28, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 161
        Me.Label1.Text = "Description"
        '
        'txtuomDesc
        '
        Me.txtuomDesc.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtuomDesc.BorderRadius = 5
        Me.txtuomDesc.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtuomDesc.DefaultText = ""
        Me.txtuomDesc.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtuomDesc.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtuomDesc.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuomDesc.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuomDesc.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuomDesc.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtuomDesc.ForeColor = System.Drawing.Color.Black
        Me.txtuomDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuomDesc.Location = New System.Drawing.Point(31, 112)
        Me.txtuomDesc.Name = "txtuomDesc"
        Me.txtuomDesc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtuomDesc.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtuomDesc.PlaceholderText = ""
        Me.txtuomDesc.SelectedText = ""
        Me.txtuomDesc.Size = New System.Drawing.Size(239, 40)
        Me.txtuomDesc.TabIndex = 159
        Me.txtuomDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(28, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 17)
        Me.Label2.TabIndex = 160
        Me.Label2.Text = "Code"
        '
        'txtuomCode
        '
        Me.txtuomCode.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtuomCode.BorderRadius = 5
        Me.txtuomCode.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtuomCode.DefaultText = ""
        Me.txtuomCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.txtuomCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtuomCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuomCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(138, Byte), Integer))
        Me.txtuomCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuomCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txtuomCode.ForeColor = System.Drawing.Color.Black
        Me.txtuomCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(CType(CType(94, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtuomCode.Location = New System.Drawing.Point(31, 38)
        Me.txtuomCode.Name = "txtuomCode"
        Me.txtuomCode.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtuomCode.PlaceholderForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtuomCode.PlaceholderText = ""
        Me.txtuomCode.SelectedText = ""
        Me.txtuomCode.Size = New System.Drawing.Size(239, 40)
        Me.txtuomCode.TabIndex = 158
        Me.txtuomCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Guna2Panel6
        '
        Me.Guna2Panel6.Controls.Add(Me.btnClearuom)
        Me.Guna2Panel6.Controls.Add(Me.btnSaveuom)
        Me.Guna2Panel6.Controls.Add(Me.btnDeleteuom)
        Me.Guna2Panel6.Controls.Add(Me.Guna2Separator7)
        Me.Guna2Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Guna2Panel6.Location = New System.Drawing.Point(0, 598)
        Me.Guna2Panel6.Name = "Guna2Panel6"
        Me.Guna2Panel6.Size = New System.Drawing.Size(1014, 65)
        Me.Guna2Panel6.TabIndex = 22
        '
        'btnClearuom
        '
        Me.btnClearuom.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnClearuom.BorderRadius = 5
        Me.btnClearuom.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnClearuom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnClearuom.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnClearuom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnClearuom.FillColor = System.Drawing.Color.DarkGreen
        Me.btnClearuom.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearuom.ForeColor = System.Drawing.Color.White
        Me.btnClearuom.Location = New System.Drawing.Point(414, 11)
        Me.btnClearuom.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClearuom.Name = "btnClearuom"
        Me.btnClearuom.Size = New System.Drawing.Size(213, 47)
        Me.btnClearuom.TabIndex = 320
        Me.btnClearuom.Text = "Clear Fields"
        '
        'btnSaveuom
        '
        Me.btnSaveuom.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSaveuom.BorderRadius = 5
        Me.btnSaveuom.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveuom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnSaveuom.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnSaveuom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnSaveuom.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveuom.ForeColor = System.Drawing.Color.White
        Me.btnSaveuom.Location = New System.Drawing.Point(635, 11)
        Me.btnSaveuom.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSaveuom.Name = "btnSaveuom"
        Me.btnSaveuom.Size = New System.Drawing.Size(213, 47)
        Me.btnSaveuom.TabIndex = 318
        Me.btnSaveuom.Text = "Save UOM"
        '
        'btnDeleteuom
        '
        Me.btnDeleteuom.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnDeleteuom.BorderRadius = 5
        Me.btnDeleteuom.DisabledState.BorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteuom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray
        Me.btnDeleteuom.DisabledState.FillColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer), CType(CType(169, Byte), Integer))
        Me.btnDeleteuom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer), CType(CType(141, Byte), Integer))
        Me.btnDeleteuom.FillColor = System.Drawing.Color.DarkRed
        Me.btnDeleteuom.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteuom.ForeColor = System.Drawing.Color.White
        Me.btnDeleteuom.Location = New System.Drawing.Point(193, 11)
        Me.btnDeleteuom.Margin = New System.Windows.Forms.Padding(4)
        Me.btnDeleteuom.Name = "btnDeleteuom"
        Me.btnDeleteuom.Size = New System.Drawing.Size(213, 47)
        Me.btnDeleteuom.TabIndex = 319
        Me.btnDeleteuom.Text = "Delete UOM"
        '
        'Guna2Separator7
        '
        Me.Guna2Separator7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator7.Location = New System.Drawing.Point(0, 0)
        Me.Guna2Separator7.Name = "Guna2Separator7"
        Me.Guna2Separator7.Size = New System.Drawing.Size(1014, 8)
        Me.Guna2Separator7.TabIndex = 11
        '
        'Guna2Separator1
        '
        Me.Guna2Separator1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Guna2Separator1.Location = New System.Drawing.Point(0, 47)
        Me.Guna2Separator1.Name = "Guna2Separator1"
        Me.Guna2Separator1.Size = New System.Drawing.Size(1022, 8)
        Me.Guna2Separator1.TabIndex = 13
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
        Me.Panel1.TabIndex = 12
        '
        'Guna2HtmlLabel1
        '
        Me.Guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent
        Me.Guna2HtmlLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Guna2HtmlLabel1.ForeColor = System.Drawing.Color.White
        Me.Guna2HtmlLabel1.Location = New System.Drawing.Point(20, 7)
        Me.Guna2HtmlLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Guna2HtmlLabel1.Name = "Guna2HtmlLabel1"
        Me.Guna2HtmlLabel1.Size = New System.Drawing.Size(178, 32)
        Me.Guna2HtmlLabel1.TabIndex = 0
        Me.Guna2HtmlLabel1.Text = "Manage Inventory "
        '
        'InventoryFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 766)
        Me.ControlBox = False
        Me.Controls.Add(Me.Guna2TabControl1)
        Me.Controls.Add(Me.Guna2Separator1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "InventoryFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Guna2TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvInventory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel4.ResumeLayout(False)
        Me.Guna2Panel4.PerformLayout()
        Me.Guna2Panel1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvFormula, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel2.ResumeLayout(False)
        Me.Guna2Panel2.PerformLayout()
        Me.Guna2Panel5.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvUOm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Guna2Panel3.ResumeLayout(False)
        Me.Guna2Panel3.PerformLayout()
        Me.Guna2Panel6.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Guna2TabControl1 As Guna.UI2.WinForms.Guna2TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Guna2Panel1 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Separator2 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Guna2Separator1 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Guna2HtmlLabel1 As Guna.UI2.WinForms.Guna2HtmlLabel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Guna2Panel4 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Separator5 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents cbPrimaryUOM As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cbSecondaryUOM As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents txtItemCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents cbInvStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label34 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents txtItemUnitCost As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtCriticalLimit As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents txtSecondaryValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtPrimaryValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtItemName As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents btnClearInventory As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteItem As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator3 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel2 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel5 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearFormula As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveFormula As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteFormula As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator6 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents cbItemCodeFormula As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents cbPCodeFormula As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label80 As Label
    Friend WithEvents cbFormulaStoreID As Guna.UI2.WinForms.Guna2ComboBox
    Friend WithEvents Label39 As Label
    Friend WithEvents txtFormulaUnitCost As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents txtToleranceValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents txtServingValue As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label38 As Label
    Friend WithEvents Guna2Separator4 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Guna2Panel3 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents Guna2Panel6 As Guna.UI2.WinForms.Guna2Panel
    Friend WithEvents btnClearuom As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnSaveuom As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents btnDeleteuom As Guna.UI2.WinForms.Guna2Button
    Friend WithEvents Guna2Separator7 As Guna.UI2.WinForms.Guna2Separator
    Friend WithEvents Label1 As Label
    Friend WithEvents txtuomDesc As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtuomCode As Guna.UI2.WinForms.Guna2TextBox
    Friend WithEvents dgvInventory As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents dgvFormula As Guna.UI2.WinForms.Guna2DataGridView
    Friend WithEvents dgvUOm As Guna.UI2.WinForms.Guna2DataGridView
End Class
