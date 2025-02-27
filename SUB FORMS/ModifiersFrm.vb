Imports MySql.Data.MySqlClient
Public Class ModifiersFrm
    Private Sub ModifiersFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreID()
        LoadDataForCurrentTab()
    End Sub

    Private Sub LoadDataForCurrentTab()
        Select Case Guna2TabControl1.SelectedIndex
            Case 0
                LoadModifierGroups()
            Case 1
                LoadProductIDsForModifier()
                LoadModifierGroupstoCombobox()
                LoadProductModifier()
        End Select
    End Sub

    Private Sub Guna2TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Guna2TabControl1.SelectedIndexChanged
        LoadDataForCurrentTab()
    End Sub

    Private Sub LoadStoreID()
        cbModStoreID.Items.Clear()
        cbProdStoreID.Items.Clear()

        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbProdStoreID.Items.Add(reader("store_id").ToString())
                            cbModStoreID.Items.Add(reader("store_id").ToString())
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

#Region "MODIFIER GROUP"
    Private IsEditMode As Boolean = False
    Private SelectedModId As Integer = 0

    Private Sub ModifierGroupFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadModifierGroups()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadModifierGroups()
        Dim query As String = "SELECT * FROM 02_pos_modifiergroup"
        Using conn As New MySqlConnection(ConnectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvModifier.DataSource = table
        End Using
    End Sub

    Private Sub btnModSave_Click(sender As Object, e As EventArgs) Handles btnModSave.Click
        If Not AreFieldsValid(txtModGroup, txtModName, txtModPrice, cbModStoreID) Then
            Return
        End If

        Try
            If IsEditMode Then
                UpdateModifier()
            Else
                InsertModifier()
            End If

            LoadModifierGroups()
            ClearModifierFields()
            IsEditMode = False
            SelectedModId = 0
            btnModSave.Text = "Save Modifier"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertModifier()
        Dim nextArrangement As Integer = 1
        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand("SELECT COALESCE(MAX(arrangement), 0) + 1 FROM 02_pos_modifiergroup", conn)
                conn.Open()
                nextArrangement = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using

        Dim query As String = "INSERT INTO 02_pos_modifiergroup (arrangement, modifier_group, modifier_name, price_, store_id) " &
                             "VALUES (@arrangement, @modifier_group, @modifier_name, @price, @store_id)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetModifierParameters(cmd)
                cmd.Parameters.AddWithValue("@arrangement", nextArrangement)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateModifier()
        Dim query As String = "UPDATE 02_pos_modifiergroup SET " &
                             "modifier_group = @modifier_group, " &
                             "modifier_name = @modifier_name, " &
                             "price_ = @price, " &
                             "store_id = @store_id " &
                             "WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetModifierParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedModId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetModifierParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@modifier_group", txtModGroup.Text.Trim())
        cmd.Parameters.AddWithValue("@modifier_name", txtModName.Text.Trim())
        cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtModPrice.Text))
        cmd.Parameters.AddWithValue("@store_id", cbModStoreID.SelectedItem)
    End Sub

    Private Sub btnModDelete_Click(sender As Object, e As EventArgs) Handles btnModDelete.Click
        If SelectedModId = 0 Then
            MessageBox.Show("Please select a modifier group to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this modifier group?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_modifiergroup WHERE id = @id"
                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", SelectedModId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadModifierGroups()
                ClearModifierFields()
                IsEditMode = False
                SelectedModId = 0
                btnModSave.Text = "Save Modifier"

            Catch ex As Exception
                MessageBox.Show("Error deleting modifier group: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvModifier_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModifier.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvModifier.Rows.Count Then
            Dim row As DataGridViewRow = dgvModifier.Rows(e.RowIndex)
            SelectedModId = Convert.ToInt32(row.Cells("id").Value)
            txtModGroup.Text = row.Cells("modifier_group").Value.ToString()
            txtModName.Text = row.Cells("modifier_name").Value.ToString()
            txtModPrice.Text = row.Cells("price_").Value.ToString()
            cbModStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnModSave.Text = "Update Modifier"
        End If
    End Sub

    Private Sub btnModClear_Click(sender As Object, e As EventArgs) Handles btnModClear.Click
        ClearModifierFields()
        IsEditMode = False
        SelectedModId = 0
        btnModSave.Text = "Save Modifier"
    End Sub

    Private Sub ClearModifierFields()
        txtModGroup.Clear()
        txtModName.Clear()
        txtModPrice.Clear()
        cbModStoreID.SelectedIndex = -1
    End Sub

    Private Sub btnModUp_Click(sender As Object, e As EventArgs) Handles btnModUP.Click
        If dgvModifier.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to move.")
            Return
        End If

        Dim currentRow As DataGridViewRow = dgvModifier.SelectedRows(0)
        Dim currentId As Integer = Convert.ToInt32(currentRow.Cells("id").Value)
        Dim currentArrangement As Integer = Convert.ToInt32(currentRow.Cells("arrangement").Value)

        If currentArrangement <= 1 Then Return

        Dim query As String = "UPDATE 02_pos_modifiergroup SET " &
                             "arrangement = CASE " &
                             "WHEN arrangement = @curr THEN @curr - 1 " &
                             "WHEN arrangement = @curr - 1 THEN @curr " &
                             "END " &
                             "WHERE arrangement IN (@curr, @curr - 1)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@curr", currentArrangement)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadModifierGroups()
                Catch ex As Exception
                    MessageBox.Show("Error moving item: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnModDown_Click(sender As Object, e As EventArgs) Handles btnModDown.Click
        If dgvModifier.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select an item to move.")
            Return
        End If

        Dim currentRow As DataGridViewRow = dgvModifier.SelectedRows(0)
        Dim currentId As Integer = Convert.ToInt32(currentRow.Cells("id").Value)
        Dim currentArrangement As Integer = Convert.ToInt32(currentRow.Cells("arrangement").Value)

        Dim maxArrangement As Integer = dgvModifier.Rows.Cast(Of DataGridViewRow)() _
            .Max(Function(r) Convert.ToInt32(r.Cells("arrangement").Value))

        If currentArrangement >= maxArrangement Then Return

        Dim query As String = "UPDATE 02_pos_modifiergroup SET " &
                             "arrangement = CASE " &
                             "WHEN arrangement = @curr THEN @curr + 1 " &
                             "WHEN arrangement = @curr + 1 THEN @curr " &
                             "END " &
                             "WHERE arrangement IN (@curr, @curr + 1)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@curr", currentArrangement)
                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    LoadModifierGroups()
                Catch ex As Exception
                    MessageBox.Show("Error moving item: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub
#End Region

#Region "PRODUCT MODIFIER"
    Private SelectedProductModifierId As Integer = 0

    Private Sub LoadProductIDsForModifier()
        cbProdModID.Items.Clear()
        Dim query As String = "SELECT product_id FROM 02_pos_products ORDER BY product_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbProdModID.Items.Add(reader("product_id").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading product IDs: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadModifierGroupstoCombobox()
        cbProdModGroup.Items.Clear()
        Dim query As String = "SELECT DISTINCT modifier_group FROM 02_pos_modifiergroup ORDER BY modifier_group"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbProdModGroup.Items.Add(reader("modifier_group").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading modifier groups: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadProductModifier()
        Dim query As String = "SELECT * FROM 02_pos_productmodifier"
        Using conn As New MySqlConnection(ConnectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvProdMod.DataSource = table
        End Using
    End Sub

    ' Keep LoadProductIDsForModifier and LoadModifierGroupstoCombobox as they are

    Private Sub btnSaveProductModifier_Click(sender As Object, e As EventArgs) Handles btnSaveProductModifier.Click
        If Not AreFieldsValid(cbProdModGroup, cbProdModID, cbProdStoreID) Then
            Return
        End If

        Try
            If Not IsEditMode Then
                Dim isDuplicate As Boolean = False
                Using conn As New MySqlConnection(ConnectionString)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM 02_pos_productmodifier " &
                                             "WHERE product_id = @product_id AND modifier_group = @modifier_group AND store_id = @store_id"
                    Using cmd As New MySqlCommand(checkQuery, conn)
                        cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))
                        cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString())
                        cmd.Parameters.AddWithValue("@store_id", Convert.ToInt32(cbProdStoreID.SelectedItem))
                        conn.Open()
                        isDuplicate = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                    End Using
                End Using

                If isDuplicate Then
                    MessageBox.Show("This product modifier combination already exists for this store.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If

            If IsEditMode Then
                UpdateProductModifier()
            Else
                InsertProductModifier()
            End If

            LoadProductModifier()
            ClearProductModifierFields()
            IsEditMode = False
            SelectedProductModifierId = 0
            btnSaveProductModifier.Text = "Save Product Modifier"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertProductModifier()
        Dim query As String = "INSERT INTO 02_pos_productmodifier (product_id, modifier_group, store_id, modified_date) " &
                             "VALUES (@product_id, @modifier_group, @store_id, @modified_date)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetProductModifierParameters(cmd)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateProductModifier()
        Dim query As String = "UPDATE 02_pos_productmodifier SET " &
                             "product_id = @product_id, " &
                             "modifier_group = @modifier_group, " &
                             "store_id = @store_id, " &
                             "modified_date = @modified_date " &
                             "WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetProductModifierParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedProductModifierId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetProductModifierParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))
        cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@store_id", Convert.ToInt32(cbProdStoreID.SelectedItem))
        cmd.Parameters.AddWithValue("@modified_date", DateTime.Now)
    End Sub

    Private Sub btnDeleteProductModifier_Click(sender As Object, e As EventArgs) Handles btnDeleteProductModifier.Click
        If SelectedProductModifierId = 0 Then
            MessageBox.Show("Please select a record to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this product modifier?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_productmodifier WHERE id = @id"
                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", SelectedProductModifierId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadProductModifier()
                ClearProductModifierFields()
                IsEditMode = False
                SelectedProductModifierId = 0
                btnSaveProductModifier.Text = "Save Product Modifier"

            Catch ex As Exception
                MessageBox.Show("Error deleting product modifier: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvProdMod_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProdMod.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvProdMod.Rows.Count Then
            Dim row As DataGridViewRow = dgvProdMod.Rows(e.RowIndex)
            SelectedProductModifierId = Convert.ToInt32(row.Cells("id").Value)
            cbProdModID.SelectedItem = row.Cells("product_id").Value.ToString()
            cbProdModGroup.SelectedItem = row.Cells("modifier_group").Value.ToString()
            cbProdStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnSaveProductModifier.Text = "Update Product Modifier"
        End If
    End Sub

    Private Sub btnClearProductModifier_Click(sender As Object, e As EventArgs) Handles btnClearProductModifier.Click
        ClearProductModifierFields()
        IsEditMode = False
        SelectedProductModifierId = 0
        btnSaveProductModifier.Text = "Save Product Modifier"
    End Sub

    Private Sub ClearProductModifierFields()
        cbProdModID.SelectedIndex = -1
        cbProdModGroup.SelectedIndex = -1
        cbProdStoreID.SelectedIndex = -1
    End Sub
#End Region
End Class