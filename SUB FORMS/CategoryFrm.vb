Imports MySql.Data.MySqlClient

Public Class CategoryFrm
    Private IsEditMode As Boolean = False
    Private SelectedCategoryId As Integer = 0

    Private Sub CategoryFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadProductCategory()
            LoadStoreID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStoreID()
        cbCatStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            cbCatStoreID.Items.Add(reader("store_id").ToString())
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

    Private Sub LoadProductCategory()
        Dim query As String = "SELECT * FROM 02_pos_category"
        Using conn = ConnectionModule.GetConnection()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvProductCategory.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveProdCat_Click(sender As Object, e As EventArgs) Handles btnSaveProdCat.Click
        If Not AreFieldsValid(txtCategoryName, txtCatDesc, cbCatStoreID) Then
            Return
        End If

        If Not IsEditMode Then
            If IsDuplicate("02_pos_category", "category_name", txtCategoryName.Text) Then
                MessageBox.Show("Category name already exists. Please enter a unique category name.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdateCategory()
            Else
                InsertCategory()
            End If

            LoadProductCategory()
            ClearCategoryField()
            IsEditMode = False
            SelectedCategoryId = 0
            btnSaveProdCat.Text = "Save Category"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertCategory()
        Dim query As String = "INSERT INTO 02_pos_category (category_name, description, store_id, status) VALUES (@category_name, @description, @store_id, @status)"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@description", txtCatDesc.Text.Trim())
                cmd.Parameters.AddWithValue("@store_id", cbCatStoreID.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@status", 1)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateCategory()
        Dim query As String = "UPDATE 02_pos_category SET category_name=@category_name, description=@description, store_id=@store_id WHERE id=@id"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text.Trim())
                cmd.Parameters.AddWithValue("@description", txtCatDesc.Text.Trim())
                cmd.Parameters.AddWithValue("@store_id", cbCatStoreID.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", SelectedCategoryId)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub btnDeleteProdCat_Click(sender As Object, e As EventArgs) Handles btnDeleteProdCat.Click
        If dgvProductCategory.SelectedRows.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Try
                    Dim query As String = "DELETE FROM 02_pos_category WHERE id = @Id"

                    Using connection = ConnectionModule.GetConnection()
                        Using cmd As New MySqlCommand(query, connection)
                            cmd.Parameters.AddWithValue("@Id", SelectedCategoryId)
                            connection.Open()
                            cmd.ExecuteNonQuery()
                        End Using
                    End Using

                    LoadProductCategory()
                    ClearCategoryField()
                    IsEditMode = False
                    SelectedCategoryId = 0
                    btnSaveProdCat.Text = "Save Category"

                Catch ex As Exception
                    MessageBox.Show("Error deleting category: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub dgvProductCategory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductCategory.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvProductCategory.Rows.Count Then
            Dim row As DataGridViewRow = dgvProductCategory.Rows(e.RowIndex)
            SelectedCategoryId = Convert.ToInt32(row.Cells("id").Value)
            txtCategoryName.Text = row.Cells("category_name").Value.ToString()
            txtCatDesc.Text = row.Cells("description").Value.ToString()
            cbCatStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnSaveProdCat.Text = "Update Category"
        End If
    End Sub

    Private Sub btnClearProdCat_Click(sender As Object, e As EventArgs) Handles btnClearProdCat.Click
        ClearCategoryField()
        IsEditMode = False
        SelectedCategoryId = 0
        btnSaveProdCat.Text = "Save Category"
    End Sub

    Private Sub ClearCategoryField()
        txtCategoryName.Clear()
        txtCatDesc.Clear()
        cbCatStoreID.SelectedIndex = -1
    End Sub

End Class