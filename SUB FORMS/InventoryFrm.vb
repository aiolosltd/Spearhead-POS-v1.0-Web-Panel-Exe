Imports MySql.Data.MySqlClient
Imports System.Text
Imports Guna.UI2.WinForms
Public Class InventoryFrm
    Private IsEditMode As Boolean = False
    Private IsInventoryLoaded As Boolean = False
    Private IsFormulaLoaded As Boolean = False
    Private IsUOMLoaded As Boolean = False

    Private Sub InventoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreID()
        LoadDataForSelectedTab()
    End Sub

    Private Sub Guna2TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2TabControl1.SelectedIndexChanged
        LoadDataForSelectedTab()
    End Sub

    Private Sub LoadDataForSelectedTab()
        Select Case Guna2TabControl1.SelectedIndex
            Case 0
                If Not IsInventoryLoaded Then
                    LoadInventoryData()
                    LoadUOMForInventory()
                    IsInventoryLoaded = True
                End If
            Case 1
                If Not IsFormulaLoaded Then
                    LoadFormulaData()
                    IsFormulaLoaded = True
                End If
            Case 2
                If Not IsUOMLoaded Then
                    LoadUOM()
                    IsUOMLoaded = True
                End If
        End Select
    End Sub

    Private Sub LoadStoreID()
        cbInvStoreID.Items.Clear()
        cbFormulaStoreID.Items.Clear()

        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbInvStoreID.Items.Add(reader("store_id").ToString())
                            cbFormulaStoreID.Items.Add(reader("store_id").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading store IDs: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

#Region "INVENTORY"
    Private SelectedInventoryId As Integer = 0

    Private Sub LoadInventoryData()
        Dim query As String = "SELECT * FROM 02_pos_inventory_item"
        Using conn As New MySqlConnection(ConnectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvInventory.DataSource = table
        End Using
        LoadUOMForInventory()
    End Sub

    Private Sub LoadUOMForInventory()
        cbPrimaryUOM.Items.Clear()
        cbSecondaryUOM.Items.Clear()

        Dim query As String = "SELECT code FROM 02_pos_loc_uom ORDER BY code"
        Using conn = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbPrimaryUOM.Items.Add(reader("code").ToString())
                            cbSecondaryUOM.Items.Add(reader("code").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading UOM codes: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveItem_Click(sender As Object, e As EventArgs) Handles btnSaveItem.Click
        If Not AreFieldsValid(txtItemCode, txtItemName, cbPrimaryUOM, txtPrimaryValue, cbInvStoreID) Then
            Return
        End If

        If Not IsEditMode Then
            If IsDuplicate("02_pos_inventory_item", "item_name", txtItemName.Text) Then
                MessageBox.Show("Item name already exists.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdateInventoryItem()
            Else
                InsertInventoryItem()
            End If

            LoadInventoryData()
            ClearInventory()
            IsEditMode = False
            SelectedInventoryId = 0
            btnSaveItem.Text = "Save Item"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertInventoryItem()
        Dim query As String = "INSERT INTO 02_pos_inventory_item (item_code, item_name, primary_uom, primary_value, " &
                            "secondary_uom, secondary_value, critical_limit, unit_cost, origin, store_id) " &
                            "VALUES (@item_code, @item_name, @primary_uom, @primary_value, @secondary_uom, " &
                            "@secondary_value, @critical_limit, @unit_cost, @origin, @store_id)"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                SetInventoryParameters(cmd)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateInventoryItem()
        Dim query As String = "UPDATE 02_pos_inventory_item SET " &
                            "item_code = @item_code, " &
                            "item_name = @item_name, " &
                            "primary_uom = @primary_uom, " &
                            "primary_value = @primary_value, " &
                            "secondary_uom = @secondary_uom, " &
                            "secondary_value = @secondary_value, " &
                            "critical_limit = @critical_limit, " &
                            "unit_cost = @unit_cost, " &
                            "store_id = @store_id " &
                            "WHERE id = @id"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                SetInventoryParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedInventoryId)
                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetInventoryParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@item_code", txtItemCode.Text.Trim())
        cmd.Parameters.AddWithValue("@item_name", txtItemName.Text.Trim())
        cmd.Parameters.AddWithValue("@primary_uom", cbPrimaryUOM.SelectedItem)
        cmd.Parameters.AddWithValue("@primary_value", Convert.ToDecimal(txtPrimaryValue.Text))
        cmd.Parameters.AddWithValue("@secondary_uom", If(cbSecondaryUOM.SelectedItem IsNot Nothing, cbSecondaryUOM.SelectedItem, DBNull.Value))
        cmd.Parameters.AddWithValue("@secondary_value", If(String.IsNullOrEmpty(txtSecondaryValue.Text), DBNull.Value, Convert.ToDecimal(txtSecondaryValue.Text)))
        cmd.Parameters.AddWithValue("@critical_limit", Convert.ToDecimal(txtCriticalLimit.Text))
        cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtItemUnitCost.Text))
        cmd.Parameters.AddWithValue("@origin", "Local")
        cmd.Parameters.AddWithValue("@store_id", If(cbInvStoreID.SelectedItem IsNot Nothing, cbInvStoreID.SelectedItem.ToString(), DBNull.Value))
    End Sub

    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If SelectedInventoryId = 0 Then
            MessageBox.Show("Please select an item to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_inventory_item WHERE id = @id"
                Using connection = ConnectionModule.GetConnection()
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@id", SelectedInventoryId)
                        connection.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadInventoryData()
                ClearInventory()
                IsEditMode = False
                SelectedInventoryId = 0
                btnSaveItem.Text = "Save Item"

            Catch ex As Exception
                MessageBox.Show("Error deleting item: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvInventory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvInventory.Rows.Count Then
            Dim row As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            SelectedInventoryId = Convert.ToInt32(row.Cells("id").Value)
            txtItemCode.Text = row.Cells("item_code").Value.ToString()
            txtItemName.Text = row.Cells("item_name").Value.ToString()
            cbPrimaryUOM.SelectedItem = row.Cells("primary_uom").Value.ToString()
            txtPrimaryValue.Text = row.Cells("primary_value").Value.ToString()
            cbSecondaryUOM.SelectedItem = If(IsDBNull(row.Cells("secondary_uom").Value), Nothing, row.Cells("secondary_uom").Value.ToString())
            txtSecondaryValue.Text = If(IsDBNull(row.Cells("secondary_value").Value), "", row.Cells("secondary_value").Value.ToString())
            txtCriticalLimit.Text = row.Cells("critical_limit").Value.ToString()
            txtItemUnitCost.Text = row.Cells("unit_cost").Value.ToString()
            cbInvStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnSaveItem.Text = "Update Item"
        End If
    End Sub

    Private Sub btnClearInventory_Click(sender As Object, e As EventArgs) Handles btnClearInventory.Click
        ClearInventory()
        IsEditMode = False
        SelectedInventoryId = 0
        btnSaveItem.Text = "Save Item"
    End Sub

    Private Sub ClearInventory()
        txtItemCode.Clear()
        txtItemName.Clear()
        cbPrimaryUOM.SelectedIndex = -1
        txtPrimaryValue.Clear()
        cbSecondaryUOM.SelectedIndex = -1
        txtSecondaryValue.Clear()
        txtCriticalLimit.Clear()
        txtItemUnitCost.Clear()
        cbInvStoreID.SelectedIndex = -1
    End Sub
#End Region

#Region "FORMULA"
    Private SelectedFormulaId As Integer = 0

    Private Sub LoadFormulaData()
        Dim query As String = "SELECT * FROM 02_pos_formula"
        Using conn As New MySqlConnection(ConnectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvFormula.DataSource = table
        End Using
        LoadProductCodesForFormula()
        LoadItemCodesForFormula()
    End Sub

    Private Sub LoadProductCodesForFormula()
        cbPCodeFormula.Items.Clear()
        Dim query As String = "SELECT product_id FROM 02_pos_products ORDER BY product_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbPCodeFormula.Items.Add(reader("product_id").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading product codes: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadItemCodesForFormula()
        cbItemCodeFormula.Items.Clear()
        Dim query As String = "SELECT item_code FROM 02_pos_inventory_item ORDER BY item_code"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbItemCodeFormula.Items.Add(reader("item_code").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading item codes: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveFormula_Click(sender As Object, e As EventArgs) Handles btnSaveFormula.Click
        If Not AreFieldsValid(cbPCodeFormula, txtServingValue, txtToleranceValue, txtFormulaUnitCost, cbFormulaStoreID) Then
            Return
        End If

        Try
            If IsEditMode Then
                UpdateFormula()
            Else
                InsertFormula()
            End If

            LoadFormulaData()
            ClearFormula()
            IsEditMode = False
            SelectedFormulaId = 0
            btnSaveFormula.Text = "Save Formula"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertFormula()
        Dim query As String = "INSERT INTO 02_pos_formula (product_id, item_code, serving_value, tolerance_value, unit_cost, store_id) " &
                          "VALUES (@product_id, @item_code, @serving_value, @tolerance_value, @unit_cost, @store_id)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetFormulaParameters(cmd)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateFormula()
        Dim query As String = "UPDATE 02_pos_formula SET " &
                            "product_id = @product_id, " &
                            "item_code = @item_code, " &
                            "serving_value = @serving_value, " &
                            "tolerance_value = @tolerance_value, " &
                            "unit_cost = @unit_cost, " &
                            "store_id = @store_id " &
                            "WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetFormulaParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedFormulaId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetFormulaParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@product_id", cbPCodeFormula.SelectedItem)
        cmd.Parameters.AddWithValue("@item_code", cbItemCodeFormula.SelectedItem)
        cmd.Parameters.AddWithValue("@serving_value", Convert.ToDecimal(txtServingValue.Text))
        cmd.Parameters.AddWithValue("@tolerance_value", Convert.ToDecimal(txtToleranceValue.Text))
        cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtFormulaUnitCost.Text))
        cmd.Parameters.AddWithValue("@store_id", If(cbFormulaStoreID.SelectedItem IsNot Nothing,
                                                   cbFormulaStoreID.SelectedItem.ToString(),
                                                   DBNull.Value))
    End Sub

    Private Sub btnDeleteFormula_Click(sender As Object, e As EventArgs) Handles btnDeleteFormula.Click
        If SelectedFormulaId = 0 Then
            MessageBox.Show("Please select a formula to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_formula WHERE id = @id"
                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", SelectedFormulaId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadFormulaData()
                ClearFormula()
                IsEditMode = False
                SelectedFormulaId = 0
                btnSaveFormula.Text = "Save Formula"

            Catch ex As Exception
                MessageBox.Show("Error deleting formula: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvFormula_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFormula.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvFormula.Rows.Count Then
            Dim row As DataGridViewRow = dgvFormula.Rows(e.RowIndex)
            SelectedFormulaId = Convert.ToInt32(row.Cells("id").Value)

            cbPCodeFormula.SelectedItem = row.Cells("product_id").Value.ToString()
            cbItemCodeFormula.SelectedItem = row.Cells("item_code").Value.ToString()
            txtServingValue.Text = row.Cells("serving_value").Value.ToString()
            txtToleranceValue.Text = row.Cells("tolerance_value").Value.ToString()
            txtFormulaUnitCost.Text = row.Cells("unit_cost").Value.ToString()
            cbFormulaStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnSaveFormula.Text = "Update Formula"
        End If
    End Sub

    Private Sub btnClearFormula_Click(sender As Object, e As EventArgs) Handles btnClearFormula.Click
        ClearFormula()
        IsEditMode = False
        SelectedFormulaId = 0
        btnSaveFormula.Text = "Save Formula"
    End Sub

    Private Sub ClearFormula()
        cbPCodeFormula.SelectedIndex = -1
        cbItemCodeFormula.SelectedIndex = -1
        txtServingValue.Clear()
        txtToleranceValue.Clear()
        txtFormulaUnitCost.Clear()
        cbFormulaStoreID.SelectedIndex = -1
    End Sub
#End Region

#Region "UOM"
    Private Sub LoadUOM()
        Dim query As String = "SELECT * FROM 02_pos_loc_uom"
        Using conn As New MySqlConnection(ConnectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvUom.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveuom_Click(sender As Object, e As EventArgs) Handles btnSaveuom.Click
        If Not AreFieldsValid(txtuomCode, txtuomDesc) Then
            Return
        End If

        ' Check if we're updating (row selected) or inserting new
        If dgvUom.SelectedRows.Count > 0 Then
            ' Update existing UOM
            UpdateUOM()
        Else
            ' Check for duplicate code before inserting
            If IsDuplicate("02_pos_loc_uom", "code", txtuomCode.Text.Trim()) Then
                MessageBox.Show("This UOM code already exists. Please use a different code.")
                Return
            End If

            ' Insert new UOM
            Dim query As String = "INSERT INTO 02_pos_loc_uom (code, description, date_modified) VALUES (@code, @description, @date_modified)"

            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@code", txtuomCode.Text.Trim())
                    cmd.Parameters.AddWithValue("@description", txtuomDesc.Text.Trim())
                    cmd.Parameters.AddWithValue("@date_modified", DateTime.Now)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("UOM saved successfully!")
                    Catch ex As MySqlException
                        MessageBox.Show("An error occurred while saving the UOM: " & ex.Message)
                    Finally
                        conn.Close()
                    End Try
                End Using
            End Using
        End If

        LoadUOM()
        ClearUOM()
    End Sub

    Private Sub UpdateUOM()
        Dim selectedId As Integer = Convert.ToInt32(dgvUom.SelectedRows(0).Cells("id").Value)

        ' Check for duplicate code, excluding the current record
        Dim duplicateQuery As String = "SELECT COUNT(*) FROM 02_pos_loc_uom WHERE code = @code AND id <> @id"
        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(duplicateQuery, conn)
                cmd.Parameters.AddWithValue("@code", txtuomCode.Text.Trim())
                cmd.Parameters.AddWithValue("@id", selectedId)
                conn.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    MessageBox.Show("This UOM code already exists. Please use a different code.")
                    Return
                End If
            End Using
        End Using

        ' Proceed with update
        Dim query As String = "UPDATE 02_pos_loc_uom SET code = @code, description = @description, date_modified = @date_modified WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", txtuomCode.Text.Trim())
                cmd.Parameters.AddWithValue("@description", txtuomDesc.Text.Trim())
                cmd.Parameters.AddWithValue("@date_modified", DateTime.Now)
                cmd.Parameters.AddWithValue("@id", selectedId)

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("UOM updated successfully!")
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while updating the UOM: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnDeleteuom_Click(sender As Object, e As EventArgs) Handles btnDeleteuom.Click
        If dgvUom.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvUom.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this UOM?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_loc_uom WHERE id = @id"

                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", selectedId)

                        Try
                            conn.Open()
                            cmd.ExecuteNonQuery()
                            MessageBox.Show("UOM deleted successfully!")
                        Catch ex As MySqlException
                            MessageBox.Show("An error occurred while deleting the UOM: " & ex.Message)
                        Finally
                            conn.Close()
                        End Try
                    End Using
                End Using

                LoadUOM()
                ClearUOM()
            End If
        Else
            MessageBox.Show("Please select a UOM to delete.")
        End If
    End Sub

    Private Sub btnClearuom_Click(sender As Object, e As EventArgs) Handles btnClearuom.Click
        ClearUOM()
    End Sub

    Private Sub ClearUOM()
        txtuomCode.Clear()
        txtuomDesc.Clear()
        dgvUom.ClearSelection()
    End Sub

    Private Sub dgvuom_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUOm.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvUOm.Rows.Count Then
            Dim row As DataGridViewRow = dgvUOm.Rows(e.RowIndex)
            txtuomCode.Text = row.Cells("code").Value.ToString()
            txtuomDesc.Text = row.Cells("description").Value.ToString()
        End If
    End Sub

    Private Sub txtuomcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtuomCode.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso e.KeyChar <> ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
#End Region
End Class