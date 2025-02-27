Imports MySql.Data.MySqlClient
Imports System.IO
Imports ClosedXML.Excel

Public Class ProductsFrm
    Private Async Sub ProductsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Await LoadProductsAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Function LoadProductsAsync() As Task
        Dim query As String = "SELECT * FROM 02_pos_products"
        Using conn As New MySqlConnection(ConnectionString)
            Dim table As New DataTable()
            Await conn.OpenAsync()

            Using cmd As New MySqlCommand(query, conn)
                Using reader = Await cmd.ExecuteReaderAsync()
                    table.Load(reader)
                End Using
            End Using

            dgvProducts.DataSource = table
        End Using
    End Function

    Private Async Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to edit.")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvProducts.SelectedRows(0)
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

        Dim addProductForm As New AddProduct(productId)
        If addProductForm.ShowDialog() = DialogResult.OK Then
            Await LoadProductsAsync()
        End If
    End Sub

    Private Async Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim addProductForm As New AddProduct()
        If addProductForm.ShowDialog() = DialogResult.OK Then
            Await LoadProductsAsync()
        End If
    End Sub

    Private Async Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to delete.")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvProducts.SelectedRows(0)
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this product?",
                                                    "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_products WHERE id=@id"
                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@id", productId)
                        Await conn.OpenAsync()
                        Await cmd.ExecuteNonQueryAsync()
                    End Using
                End Using

                Await LoadProductsAsync()
                MessageBox.Show("Product deleted successfully!")
            Catch ex As Exception
                MessageBox.Show("Error deleting product: " & ex.Message)
            End Try
        End If
    End Sub

#Region "EXCEL IMPORT"
    Private Async Function GetLastProductIdAsync() As Task(Of Integer)
        Dim lastId As Integer = 0
        Try
            Using conn As New MySqlConnection(ConnectionString)
                Await conn.OpenAsync()
                Dim query As String = "SELECT MAX(id) FROM 02_pos_products"
                Using cmd As New MySqlCommand(query, conn)
                    Dim result = Await cmd.ExecuteScalarAsync()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        lastId = Convert.ToInt32(result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error getting last product ID: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return lastId
    End Function

    Private Async Sub ImportExcelDataAsync()
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
            openFileDialog.Title = "Select an Excel File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim excelFile As String = openFileDialog.FileName
                    Using workbook As New XLWorkbook(excelFile)
                        Dim worksheet = workbook.Worksheet(1)
                        Dim lastRow As Integer = worksheet.LastRowUsed().RowNumber()
                        Dim nextProductId As Integer = Await GetLastProductIdAsync() + 1

                        For row As Integer = 2 To lastRow
                            Try
                                ' Read values based on column arrangement
                                Dim productCode As String = worksheet.Cell(row, 1).Value.ToString()
                                Dim productName As String = worksheet.Cell(row, 2).Value.ToString()
                                Dim category As String = worksheet.Cell(row, 3).Value.ToString()
                                Dim description As String = worksheet.Cell(row, 4).Value.ToString()

                                Dim price As Decimal = 0
                                Decimal.TryParse(worksheet.Cell(row, 5).Value.ToString(), price)

                                Dim barcode As String = worksheet.Cell(row, 6).Value.ToString()
                                Dim qrCode As String = worksheet.Cell(row, 7).Value.ToString()
                                Dim addonType As String = worksheet.Cell(row, 8).Value.ToString()

                                Dim productType As Integer = 0
                                Integer.TryParse(worksheet.Cell(row, 9).Value.ToString(), productType)

                                Dim unitCost As Decimal = 0
                                Decimal.TryParse(worksheet.Cell(row, 12).Value.ToString(), unitCost)

                                Dim kitchen As Integer = 0
                                Integer.TryParse(worksheet.Cell(row, 15).Value.ToString(), kitchen)

                                Dim bar As Integer = 0
                                Integer.TryParse(worksheet.Cell(row, 16).Value.ToString(), bar)

                                Dim station1 As Integer = 0
                                Integer.TryParse(worksheet.Cell(row, 17).Value.ToString(), station1)

                                Dim station2 As Integer = 0
                                Integer.TryParse(worksheet.Cell(row, 18).Value.ToString(), station2)

                                Dim tax As Decimal = 0
                                Decimal.TryParse(worksheet.Cell(row, 19).Value.ToString(), tax)

                                If String.IsNullOrEmpty(productName) Then
                                    Continue For
                                End If

                                Dim insertQuery As String = "INSERT INTO 02_pos_products (" &
                                    "product_id, product_code, name_, category_, desc_, reg_price, " &
                                    "barcode_, QRCode, addon_type, product_type, " &
                                    "arrangement_, unit_cost, origin_, " &
                                    "kitchen_, bar_, station_1, station_2, tax_) " &
                                    "VALUES (" &
                                    "@product_id, @product_code, @name, @category, @desc, @reg_price, " &
                                    "@barcode, @qrcode, @addon_type, @product_type, " &
                                    "@arrangement, @unit_cost, @origin, " &
                                    "@kitchen, @bar, @station_1, @station_2, @tax)"

                                Using conn As New MySqlConnection(ConnectionString)
                                    Using cmd As New MySqlCommand(insertQuery, conn)
                                        cmd.Parameters.AddWithValue("@product_id", nextProductId)
                                        cmd.Parameters.AddWithValue("@product_code", If(String.IsNullOrEmpty(productCode), DBNull.Value, productCode))
                                        cmd.Parameters.AddWithValue("@name", If(String.IsNullOrEmpty(productName), DBNull.Value, productName))
                                        cmd.Parameters.AddWithValue("@category", If(String.IsNullOrEmpty(category), DBNull.Value, category))
                                        cmd.Parameters.AddWithValue("@desc", If(String.IsNullOrEmpty(description), DBNull.Value, description))
                                        cmd.Parameters.AddWithValue("@reg_price", price)
                                        cmd.Parameters.AddWithValue("@barcode", If(String.IsNullOrEmpty(barcode), DBNull.Value, barcode))
                                        cmd.Parameters.AddWithValue("@qrcode", If(String.IsNullOrEmpty(qrCode), DBNull.Value, qrCode))
                                        cmd.Parameters.AddWithValue("@addon_type", If(String.IsNullOrEmpty(addonType), "Regular", addonType))
                                        cmd.Parameters.AddWithValue("@product_type", productType)
                                        cmd.Parameters.AddWithValue("@arrangement", "1")
                                        cmd.Parameters.AddWithValue("@unit_cost", unitCost)
                                        cmd.Parameters.AddWithValue("@origin", "Server")
                                        cmd.Parameters.AddWithValue("@kitchen", kitchen)
                                        cmd.Parameters.AddWithValue("@bar", bar)
                                        cmd.Parameters.AddWithValue("@station_1", station1)
                                        cmd.Parameters.AddWithValue("@station_2", station2)
                                        cmd.Parameters.AddWithValue("@tax", tax)

                                        Await conn.OpenAsync()
                                        Await cmd.ExecuteNonQueryAsync()
                                        nextProductId += 1
                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show($"Error processing row {row}: {ex.Message}", "Row Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Continue For
                            End Try
                        Next

                        MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Await LoadProductsAsync()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error importing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Async Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        Await Task.Run(AddressOf ImportExcelDataAsync)
    End Sub
#End Region

End Class