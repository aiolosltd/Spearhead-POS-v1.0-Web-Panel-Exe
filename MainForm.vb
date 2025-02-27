Imports System.IO
Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient
Imports System.Text
Imports ClosedXML.Excel
Public Class MainForm

    Dim startupPathCert As String = Path.Combine(Application.StartupPath, "certificate.pem")
    Private connectionString = $"server=pos-aws-cloud.cnk01mqwsyxf.ap-southeast-1.rds.amazonaws.com;user=localuser2;password=password.2023;database=posrev;sslmode=Required;sslca={startupPathCert};CharSet=utf8mb4;Convert Zero Datetime=True"
    Private connection As New MySqlConnection(connectionString)

    Private LocalConn As New MySqlConnection(LocalconnectionString)
    Private LocalconnectionString As String = "server=localhost;user=root;password=00000000;database=dgposv2;charset=utf8mb4;"


    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProducts()
        LoadActivation()
        LoadInventoryData()
        LoadFormulaData()
        LoadServerProfiles()
        LoadSettings()
        LoadCoupons()
        LoadUsers()
        LoadOtherSettings()
        LoadProductCategory()
        LoadProductCategoryToProduct()
        LoadPaymentMethod()
        LoadUOM()
        LoadClientIDs()
        LoadStoreIDs()
        LoadStoreIDsForReceipt()
        LoadModifierGroups()
        LoadModifierGroupstoCombobox()
        LoadProductIDsForModifier()
    End Sub

#Region "INPUTS"
    Private Sub NumericOnly_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _
    txtProductPrice.KeyPress, txtProductUnitCost.KeyPress, txtBBValue.KeyPress, txtBPValue.KeyPress,
    txtReferenceValue.KeyPress, txtDiscValue.KeyPress, txtPrimaryValue.KeyPress,
    txtSecondaryValue.KeyPress, txtItemUnitCost.KeyPress, txtCriticalLimit.KeyPress,
    txtServingValue.KeyPress, txtToleranceValue.KeyPress, txtFormulaUnitCost.KeyPress,
    txtLocConnPort.KeyPress, txtCloudConnPort.KeyPress, txtFTPPort.KeyPress,
    txtSalesInvoiceFormat.KeyPress, txtMEMCValue.KeyPress, txtSubTerminalCount.KeyPress,
    txtSubTerminalCount.KeyPress, txtPin.KeyPress, txtTerminalCount.KeyPress, txtSubTerminalCount.KeyPress, txtModPrice.KeyPress

        Dim textBox As Guna2TextBox = DirectCast(sender, Guna2TextBox)
        Dim decimalSeparator As String = Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator

        If e.KeyChar = ChrW(Keys.Back) Then
            Exit Sub
        End If

        Dim allowDecimals As Boolean = {txtProductPrice, txtProductUnitCost, txtBBValue, txtBPValue,
                                    txtReferenceValue, txtDiscValue, txtPrimaryValue, txtSecondaryValue,
                                    txtItemUnitCost, txtServingValue, txtToleranceValue, txtFormulaUnitCost}.Contains(textBox)

        If allowDecimals Then
            If (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) _
            AndAlso e.KeyChar.ToString() <> decimalSeparator _
            AndAlso e.KeyChar <> "-"c Then
                e.Handled = True
            End If

            If e.KeyChar.ToString() = decimalSeparator AndAlso textBox.Text.IndexOf(decimalSeparator) > -1 Then
                e.Handled = True
            End If

            If e.KeyChar = "-"c AndAlso textBox.SelectionStart <> 0 Then
                e.Handled = True
            End If
        Else
            If Not Char.IsDigit(e.KeyChar) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Function AreFieldsValid(ByVal ParamArray controls() As Object) As Boolean
        For Each ctrl As Object In controls
            If TypeOf ctrl Is TextBox Then
                If String.IsNullOrWhiteSpace(CType(ctrl, TextBox).Text) Then
                    MessageBox.Show("All fields are required. Please fill in all the information.", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            ElseIf TypeOf ctrl Is ComboBox Then
                If CType(ctrl, ComboBox).SelectedItem Is Nothing Then
                    MessageBox.Show("All fields are required. Please fill in all the information.", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Function IsDuplicate(tableName As String, columnName As String, value As String) As Boolean
        Dim exists As Boolean = False
        Dim query As String = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value"

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@value", value)
                connection.Open()
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                connection.Close()

                exists = (count > 0)
            End Using
        End Using

        Return exists
    End Function
#End Region

#Region "PRODUCTS"
    Private imagePath As String = ""
    Private selectedProductId As Integer = 0

    Private Sub LoadProducts()
        Dim query As String = "SELECT * FROM 02_pos_products"
        Using adapter As New MySqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvProducts.DataSource = table
        End Using
    End Sub

    Private Sub LoadProductCategoryToProduct()
        Dim query As String = "SELECT category_name FROM 02_pos_category"

        Using connection As New MySqlConnection(connectionString)
            Dim command As New MySqlCommand(query, connection)
            Try
                connection.Open()
                Dim reader As MySqlDataReader = command.ExecuteReader()

                While reader.Read()
                    cbProductCategory.Items.Add(reader("category_name").ToString())
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub btnSaveProduct_Click(sender As Object, e As EventArgs) Handles btnProductSave.Click
        If Not AreFieldsValid(txtPCode, txtProductName, txtProductDesc, txtProductPrice, txtProductBarCode, txtProductUnitCost,
                      cbProductCategory, cbProductAddonType, cbProductPartners, cbProdType, cbProductStoreID, cbKitchen, cbBar, cbStation1, cbStation2, cbTaxValue) Then
            Return
        End If

        If IsDuplicate("02_pos_products", "product_code", txtPCode.Text.Trim()) Then
            MessageBox.Show("The product code already exists. Please choose a different product code.")
            Return
        End If

        If IsDuplicate("02_pos_products", "name_", txtProductName.Text.Trim()) Then
            MessageBox.Show("The product name already exists. Please use a different product name.")
            Return
        End If

        Dim lastProductId As Integer = 0
        Dim retrieveQuery As String = "SELECT COALESCE(MAX(product_id), 0) FROM 02_pos_products"

        Using retrieveCmd As New MySqlCommand(retrieveQuery, connection)
            connection.Open()
            lastProductId = Convert.ToInt32(retrieveCmd.ExecuteScalar())
            connection.Close()
        End Using

        Dim newProductId As Integer = lastProductId + 1
        Dim productTypeValue As Integer = If(cbProdType.SelectedItem.ToString() = "Kitchen", 0, 1)

        Dim insertQuery As String = "INSERT INTO 02_pos_products (" &
        "product_id, product_code, name_, category_, desc_, image_, reg_price, " &
        "barcode_, QRCode, addon_type, partners_, product_type, arrangement_, " &
        "unit_cost, origin_, store_id, kitchen_, bar_, station_1, station_2, tax_) " &
        "VALUES (" &
        "@product_id, @product_code, @name, @category, @desc, @image, @reg_price, " &
        "@barcode, @qrcode, @addon_type, @partners, @product_type, @arrangement, " &
        "@unit_cost, @origin, @store_id, @kitchen_, @bar_, @station_1, @station_2, tax_)"

        Using cmd As New MySqlCommand(insertQuery, connection)
            Try
                cmd.Parameters.AddWithValue("@product_id", newProductId)
                cmd.Parameters.AddWithValue("@product_code", txtPCode.Text)
                cmd.Parameters.AddWithValue("@name", txtProductName.Text)
                cmd.Parameters.AddWithValue("@category", cbProductCategory.SelectedItem)
                cmd.Parameters.AddWithValue("@desc", txtProductDesc.Text)
                cmd.Parameters.AddWithValue("@image", If(String.IsNullOrEmpty(imagePath), DBNull.Value, Convert.ToBase64String(File.ReadAllBytes(imagePath))))
                cmd.Parameters.AddWithValue("@reg_price", Decimal.Parse(txtProductPrice.Text))
                cmd.Parameters.AddWithValue("@barcode", txtProductBarCode.Text)
                cmd.Parameters.AddWithValue("@qrcode", txtProductQR.Text)
                cmd.Parameters.AddWithValue("@addon_type", cbProductAddonType.SelectedItem)
                cmd.Parameters.AddWithValue("@partners", cbProductPartners.SelectedItem)
                cmd.Parameters.AddWithValue("@product_type", productTypeValue)
                cmd.Parameters.AddWithValue("@arrangement", "1")
                cmd.Parameters.AddWithValue("@unit_cost", Decimal.Parse(txtProductUnitCost.Text))
                cmd.Parameters.AddWithValue("@origin", "Server")
                cmd.Parameters.AddWithValue("@store_id", cbProductStoreID.SelectedItem)
                cmd.Parameters.AddWithValue("@kitchen_", Integer.Parse(cbKitchen.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@bar_", Integer.Parse(cbBar.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@station_1", Integer.Parse(cbStation1.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@station_2", Integer.Parse(cbStation2.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@tax_", cbTaxValue.SelectedItem)

                connection.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Product saved successfully!")
            Catch ex As Exception
                MessageBox.Show("Error saving product: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using

        LoadProducts()
        ClearFields()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnProductUpdate.Click
        If selectedProductId = 0 Then
            MessageBox.Show("Please select a product to update.")
            Return
        End If

        Dim productTypeValue As Integer = If(cbProdType.SelectedItem.ToString() = "Kitchen", 0, 1)

        Dim query As String = "UPDATE 02_pos_products SET " &
        "product_code = @product_code, " &
        "name_ = @name, " &
        "category_ = @category, " &
        "desc_ = @desc, " &
        "image_ = @image, " &
        "reg_price = @reg_price, " &
        "barcode_ = @barcode, " &
        "QRCode = @qrcode, " &
        "addon_type = @addon_type, " &
        "partners_ = @partners, " &
        "product_type = @product_type, " &
        "arrangement_ = @arrangement, " &
        "unit_cost = @unit_cost, " &
        "origin_ = @origin, " &
        "store_id = @store_id, " &
        "kitchen_ = @kitchen_, " &
        "bar_ = @bar_, " &
        "station_1 = @station_1, " &
        "station_2 = @station_2 " &
        "tax_ = @tax_" &
        "WHERE id = @id"

        Using cmd As New MySqlCommand(query, connection)
            Try
                cmd.Parameters.AddWithValue("@id", selectedProductId)
                cmd.Parameters.AddWithValue("@product_code", txtPCode.Text)
                cmd.Parameters.AddWithValue("@name", txtProductName.Text)
                cmd.Parameters.AddWithValue("@category", cbProductCategory.SelectedItem)
                cmd.Parameters.AddWithValue("@desc", txtProductDesc.Text)
                cmd.Parameters.AddWithValue("@image", If(String.IsNullOrEmpty(imagePath), DBNull.Value, Convert.ToBase64String(File.ReadAllBytes(imagePath))))
                cmd.Parameters.AddWithValue("@reg_price", Decimal.Parse(txtProductPrice.Text))
                cmd.Parameters.AddWithValue("@barcode", txtProductBarCode.Text)
                cmd.Parameters.AddWithValue("@qrcode", txtProductQR.Text)
                cmd.Parameters.AddWithValue("@addon_type", cbProductAddonType.SelectedItem)
                cmd.Parameters.AddWithValue("@partners", cbProductPartners.SelectedItem)
                cmd.Parameters.AddWithValue("@product_type", productTypeValue)
                cmd.Parameters.AddWithValue("@arrangement", "1")
                cmd.Parameters.AddWithValue("@unit_cost", Decimal.Parse(txtProductUnitCost.Text))
                cmd.Parameters.AddWithValue("@origin", "Server")
                cmd.Parameters.AddWithValue("@store_id", cbProductStoreID.SelectedItem)
                cmd.Parameters.AddWithValue("@kitchen_", Integer.Parse(cbKitchen.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@bar_", Integer.Parse(cbBar.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@station_1", Integer.Parse(cbStation1.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@station_2", Integer.Parse(cbStation2.SelectedItem.ToString()))
                cmd.Parameters.AddWithValue("@tax_", cbTaxValue.SelectedItem)

                connection.Open()
                cmd.ExecuteNonQuery()
                MessageBox.Show("Product updated successfully!")
            Catch ex As Exception
                MessageBox.Show("Error updating product: " & ex.Message)
            Finally
                connection.Close()
            End Try
        End Using

        LoadProducts()
        ClearFields()
        selectedProductId = 0
    End Sub

    Private Sub dgvProducts_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducts.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvProducts.Rows(e.RowIndex)
            selectedProductId = Convert.ToInt32(row.Cells("id").Value)
            txtPCode.Text = row.Cells("product_code").Value.ToString()
            txtProductName.Text = row.Cells("name_").Value.ToString()
            cbProductCategory.SelectedItem = row.Cells("category_").Value
            txtProductDesc.Text = row.Cells("desc_").Value.ToString()
            txtProductPrice.Text = row.Cells("reg_price").Value.ToString()
            txtProductBarCode.Text = row.Cells("barcode_").Value.ToString()
            txtProductQR.Text = row.Cells("QRCode").Value.ToString()
            cbProductAddonType.SelectedItem = row.Cells("addon_type").Value
            cbProductPartners.SelectedItem = row.Cells("Partners_").Value
            txtProductUnitCost.Text = row.Cells("unit_cost").Value.ToString()
            cbProductCategory.SelectedItem = row.Cells("store_id").Value

            ' Set values for new comboboxes
            cbKitchen.SelectedItem = row.Cells("kitchen_").Value.ToString()
            cbBar.SelectedItem = row.Cells("bar_").Value.ToString()
            cbStation1.SelectedItem = row.Cells("station_1").Value.ToString()
            cbStation2.SelectedItem = row.Cells("station_2").Value.ToString()
            cbTaxValue.SelectedItem = row.Cells("tax_").Value.ToString()

            Dim imageData As String = row.Cells("Image_").Value.ToString()
            If Not String.IsNullOrEmpty(imageData) Then
                Dim imageBytes As Byte() = Convert.FromBase64String(imageData)
                Using ms As New MemoryStream(imageBytes)
                    PictureBoxProduct.Image = Image.FromStream(ms)
                End Using
            Else
                PictureBoxProduct.Image = Nothing
            End If
        End If
    End Sub

    Private Sub ClearFields()
        txtPCode.Clear()
        txtProductName.Clear()
        cbProductCategory.SelectedIndex = -1
        txtProductDesc.Clear()
        txtProductPrice.Clear()
        txtProductBarCode.Clear()
        txtProductQR.Text = ""
        cbProductAddonType.SelectedIndex = -1
        cbProductPartners.SelectedIndex = -1
        cbProdType.SelectedIndex = -1
        txtProductUnitCost.Clear()
        PictureBoxProduct.Image = Nothing
        imagePath = ""
        cbProductStoreID.SelectedIndex = -1

        ' Clear new comboboxes
        cbKitchen.SelectedIndex = -1
        cbBar.SelectedIndex = -1
        cbStation1.SelectedIndex = -1
        cbStation2.SelectedIndex = -1
        cbTaxValue.SelectedIndex = -1
    End Sub


    Private Sub btnDeleteProduct_Click(sender As Object, e As EventArgs) Handles btnProductDelete.Click
        If dgvProducts.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a product to delete.")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvProducts.SelectedRows(0)
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("id").Value)

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM 02_pos_products WHERE id=@id"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", productId)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadProducts()
            ClearFields()
        End If
    End Sub

    Private Sub btnProductImage_Click(sender As Object, e As EventArgs) Handles btnProductImage.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                imagePath = openFileDialog.FileName
                PictureBoxProduct.Image = Image.FromFile(imagePath)
            End If
        End Using
    End Sub

    Private Sub btnNewProduct_Click(sender As Object, e As EventArgs) Handles btnNewProduct.Click
        ClearFields()
    End Sub


#Region "EXCEL IMPORT"
    Private Function GetLastProductId() As Integer
        Dim lastId As Integer = 0
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT MAX(id) FROM 02_pos_products"
                Using cmd As New MySqlCommand(query, connection)
                    Dim result = cmd.ExecuteScalar()
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

    Private Sub ImportExcelData()
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls"
            openFileDialog.Title = "Select an Excel File"

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    Dim excelFile As String = openFileDialog.FileName
                    Using workbook As New XLWorkbook(excelFile)
                        Dim worksheet = workbook.Worksheet(1)
                        Dim lastRow As Integer = worksheet.LastRowUsed().RowNumber()
                        Dim nextProductId As Integer = GetLastProductId() + 1

                        For row As Integer = 2 To lastRow
                            Try
                                ' Read values based on new column arrangement
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

                                Using connection As New MySqlConnection(connectionString)
                                    Using cmd As New MySqlCommand(insertQuery, connection)
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

                                        connection.Open()
                                        cmd.ExecuteNonQuery()
                                        nextProductId += 1
                                    End Using
                                End Using
                            Catch ex As Exception
                                MessageBox.Show($"Error processing row {row}: {ex.Message}", "Row Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Continue For
                            End Try
                        Next

                        MessageBox.Show("Data imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadProducts()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error importing data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnImportExcel_Click(sender As Object, e As EventArgs) Handles btnImportExcel.Click
        ImportExcelData()
    End Sub
#End Region

#End Region

#Region "PRODUCT CATEGORY"
    Private Sub LoadProductCategory()
        Dim query As String = "SELECT * FROM 02_pos_category"
        Using conn As New MySqlConnection(connectionString)
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

        If IsDuplicate("02_pos_category", "category_name", txtCategoryName.Text) Then
            MessageBox.Show("Category name already exists. Please enter a unique category name.")
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_category (category_name, description, store_id, status) VALUES (@category_name, @description, @store_id, @status)"

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text)
                cmd.Parameters.AddWithValue("@description", txtCatDesc.Text)
                cmd.Parameters.AddWithValue("@store_id", cbCatStoreID.SelectedItem.ToString)
                cmd.Parameters.AddWithValue("@status", 1)

                Try
                    connection.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving activation data: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using

            LoadProductCategory()
            ClearCategoryField()
        End Using
    End Sub
    Private Sub btnUpdateProdCat_Click(sender As Object, e As EventArgs) Handles btnUpdateProdCat.Click
        If IsDuplicate("02_pos_category", "category_name", txtCategoryName.Text) Then
            MessageBox.Show("Category name already exists. Please enter a unique category name.")
            Return
        End If

        If dgvProductCategory.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvProductCategory.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_category SET category_name=@category_name, description=@description, store_id=@store_id WHERE id=@id"

            Using cmd As New MySqlCommand(query, connection)
                connection.Open()
                cmd.Parameters.AddWithValue("@category_name", txtCategoryName.Text)
                cmd.Parameters.AddWithValue("@description", txtCatDesc.Text)
                cmd.Parameters.AddWithValue("@store_id", cbCatStoreID.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", selectedId)

                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadProductCategory()
            ClearCategoryField()
        End If
    End Sub


    Private Sub btnDeleteProdCat_Click(sender As Object, e As EventArgs) Handles btnDeleteProdCat.Click
        If dgvProductCategory.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvProductCategory.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_category WHERE id = @Id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadProductCategory()
                ClearCategoryField()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub dgvProductCategory_Click(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductCategory.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvProductCategory.Rows.Count Then
            Dim row As DataGridViewRow = dgvProductCategory.Rows(e.RowIndex)
            txtCategoryName.Text = row.Cells("category_name").Value.ToString()
            txtCatDesc.Text = row.Cells("description").Value.ToString()
            cbCatStoreID.SelectedItem = row.Cells("store_id").Value.ToString
        End If
    End Sub
    Private Sub btnClearProdCat_Click(sender As Object, e As EventArgs) Handles btnClearProdCat.Click
        ClearCategoryField()
    End Sub

    Private Sub ClearCategoryField()
        txtCategoryName.Clear()
        txtCatDesc.Clear()
        cbCatStoreID.SelectedIndex = -1
    End Sub

#End Region

#Region "ACTIVATION"
    Private Sub LoadActivation()
        Dim query As String = "SELECT * FROM 02_pos_activation"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvActivation.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveActivation_Click(sender As Object, e As EventArgs) Handles btnSaveActivation.Click
        If Not AreFieldsValid(txtEmail, txtTerminalCount, txtSubTerminalCount, txtClientName, txtClientContact) Then
            Return
        End If

        If IsDuplicate("02_pos_activation", "Email", txtEmail.Text) Then
            MessageBox.Show("The email address already exists. Please use a different email address.")
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_activation (client_id, client_name, Email, contact_, Date_Registered, Terminal_Count, SubTerminal_Count) " &
                             "VALUES (LAST_INSERT_ID(), @ClientName, @Email, @Contact, @DateRegistered, @TerminalCount, @SubTerminalCount); " &
                             "UPDATE 02_pos_activation SET client_id = LAST_INSERT_ID() WHERE id = LAST_INSERT_ID();"

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ClientName", txtClientName.Text)
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                cmd.Parameters.AddWithValue("@Contact", txtClientContact.Text)
                cmd.Parameters.AddWithValue("@DateRegistered", DateTime.Now)
                cmd.Parameters.AddWithValue("@TerminalCount", Convert.ToInt32(txtTerminalCount.Text))
                cmd.Parameters.AddWithValue("@SubTerminalCount", Convert.ToInt32(txtSubTerminalCount.Text))

                Try
                    connection.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving activation data: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using

        LoadActivation()
        ClearActivationFields()
    End Sub

    Private Sub btnUpdateActivation_Click(sender As Object, e As EventArgs) Handles btnUpdateActivation.Click
        If Not AreFieldsValid(txtEmail, txtTerminalCount, txtSubTerminalCount, txtClientName, txtClientContact) Then
            Return
        End If

        If dgvActivation.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvActivation.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_activation SET client_id = @Id, client_name = @ClientName, Email = @Email, contact_ = @Contact, " &
                                "Terminal_Count = @TerminalCount, SubTerminal_Count = @SubTerminalCount WHERE id = @Id"

            Using connection As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@ClientName", txtClientName.Text)
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text)
                    cmd.Parameters.AddWithValue("@Contact", txtClientContact.Text)
                    cmd.Parameters.AddWithValue("@TerminalCount", Convert.ToInt32(txtTerminalCount.Text))
                    cmd.Parameters.AddWithValue("@SubTerminalCount", Convert.ToInt32(txtSubTerminalCount.Text))
                    cmd.Parameters.AddWithValue("@Id", selectedId)

                    Try
                        connection.Open()
                        cmd.ExecuteNonQuery()
                    Catch ex As MySqlException
                        MessageBox.Show("An error occurred while updating activation data: " & ex.Message)
                    Finally
                        connection.Close()
                    End Try
                End Using
            End Using

            LoadActivation()
            ClearActivationFields()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub

    Private Sub dgvActivation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvActivation.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvActivation.Rows.Count Then
            Dim row As DataGridViewRow = dgvActivation.Rows(e.RowIndex)
            txtClientName.Text = row.Cells("client_name").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtClientContact.Text = row.Cells("contact_").Value.ToString()
            txtTerminalCount.Text = row.Cells("Terminal_Count").Value.ToString()
            txtSubTerminalCount.Text = row.Cells("SubTerminal_Count").Value.ToString()
        End If
    End Sub

    Private Sub ClearActivationFields()
        txtClientName.Clear()
        txtEmail.Clear()
        txtClientContact.Clear()
        txtTerminalCount.Clear()
        txtSubTerminalCount.Clear()
    End Sub

    Private Sub btnNewActivation_Click(sender As Object, e As EventArgs) Handles btnNewActivation.Click
        ClearActivationFields()
    End Sub
#End Region

#Region "COUPON"
    Private couponID As Integer = 0
    'Private Sub LoadProductsForCoupon()
    '    Dim query As String = "SELECT id, product_code, Name FROM 02_pos_products"
    '    Using adapter As New MySqlDataAdapter(query, connection)
    '        Dim table As New DataTable()
    '        adapter.Fill(table)

    '        ' Add checkbox column to DataGridView
    '        Dim chkColumn As New DataGridViewCheckBoxColumn()
    '        chkColumn.HeaderText = "Select"
    '        chkColumn.Name = "chkSelect"
    '        dgvProductsCoupon.Columns.Add(chkColumn)

    '        dgvProductsCoupon.DataSource = table
    '    End Using
    'End Sub
    'Private Sub dgvProductsCoupon_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
    '    If e.ColumnIndex = dgvProductsCoupon.Columns("chkSelect").Index Then
    '        Dim row As DataGridViewRow = dgvProductsCoupon.Rows(e.RowIndex)
    '        Dim productID As String = row.Cells("id").Value.ToString()
    '        Dim productName As String = row.Cells("Name").Value.ToString()

    '        Dim isChecked As Boolean = Convert.ToBoolean(row.Cells("chkSelect").EditedFormattedValue)

    '        If isChecked Then
    '            If String.IsNullOrEmpty(txtBundleBase.Text) Then
    '                txtBundleBase.Text = productID
    '            Else
    '                txtBundleBase.Text &= "," & productID
    '            End If
    '        Else
    '            Dim productList As List(Of String) = txtBundleBase.Text.Split(","c).ToList()
    '            productList.Remove(productID)
    '            txtBundleBase.Text = String.Join(",", productList)
    '        End If
    '    End If
    'End Sub
    Private Sub btnSaveCoupon_Click(sender As Object, e As EventArgs) Handles btnSaveCoupon.Click
        If Not AreFieldsValid(txtCouponName, txtCouponDesc, txtDiscValue, txtReferenceValue, cbCouponType, txtBundleBase, txtBundlePromo, cbCouponStoreID) Then
            Return
        End If

        If IsDuplicate("02_pos_coupon", "Coupon_Name", txtCouponName.Text) Then
            MessageBox.Show("The email address already exists. Please use a different email address.")
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_coupon (Coupon_Name, `Desc`, Disc_Value, Reference, Type, Bundlebase, BBValue, BundlePromo, BPValue, Effective, Expiry, Date_Registered, Status, store_id) " &
                           "VALUES (@Coupon_Name, @Desc, @Disc_Value, @Reference, @Type, @Bundlebase, @BBValue, @BundlePromo, @BPValue, @Effective, @Expiry, @Date_Registered, @Status, @store_id)"

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@Coupon_Name", txtCouponName.Text)
                cmd.Parameters.AddWithValue("@Desc", txtCouponDesc.Text)
                cmd.Parameters.AddWithValue("@Disc_Value", Decimal.Parse(txtDiscValue.Text))
                cmd.Parameters.AddWithValue("@Reference", txtReferenceValue.Text)
                cmd.Parameters.AddWithValue("@Type", cbCouponType.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@Bundlebase", txtBundleBase.Text)
                cmd.Parameters.AddWithValue("@BBValue", If(Decimal.TryParse(txtBBValue.Text, Nothing), Decimal.Parse(txtBBValue.Text), DBNull.Value))
                cmd.Parameters.AddWithValue("@BundlePromo", txtBundlePromo.Text)
                cmd.Parameters.AddWithValue("@BPValue", If(Decimal.TryParse(txtBPValue.Text, Nothing), Decimal.Parse(txtBPValue.Text), DBNull.Value))
                cmd.Parameters.AddWithValue("@Effective", dtpEffectiveDate.Value.Date)
                cmd.Parameters.AddWithValue("@Expiry", dtpExpiryDate.Value.Date)
                cmd.Parameters.AddWithValue("@Date_Registered", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("@Status", 1)
                cmd.Parameters.AddWithValue("@store_id", cbCouponStoreID.SelectedItem.ToString())

                Try
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Coupon created successfully!")
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving the coupon: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using
        End Using

        LoadCoupons()
        ClearCouponFields()
    End Sub

    Private Sub btnUpdateCoupon_Click(sender As Object, e As EventArgs) Handles btnUpdateCoupon.Click

        If IsDuplicate("02_pos_coupon", "Coupon_Name", txtCouponName.Text) Then
            MessageBox.Show("The email address already exists. Please use a different email address.")
            Return
        End If

        If couponID = 0 Then
            MessageBox.Show("Please select a coupon to update.")
            Return
        End If

        Dim query As String = "UPDATE 02_pos_coupon SET Coupon_Name=@Coupon_Name, `Desc`=@Desc, Disc_Value=@Disc_Value, Reference=@Reference, `Type`=@Type, Bundlebase=@Bundlebase, BBValue=@BBValue, BundlePromo=@BundlePromo, BPValue=@BPValue, Effective=@Effective, Expiry=@Expiry, store_id=@store_id WHERE id=@id"

        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@id", couponID)
            cmd.Parameters.AddWithValue("@Coupon_Name", txtCouponName.Text)
            cmd.Parameters.AddWithValue("@Desc", txtCouponDesc.Text)
            cmd.Parameters.AddWithValue("@Disc_Value", Decimal.Parse(txtDiscValue.Text))
            cmd.Parameters.AddWithValue("@Reference", txtReferenceValue.Text)
            cmd.Parameters.AddWithValue("@Type", cbCouponType.SelectedItem)
            cmd.Parameters.AddWithValue("@Bundlebase", txtBundleBase.Text)
            cmd.Parameters.AddWithValue("@BBValue", If(String.IsNullOrEmpty(txtBBValue.Text), DBNull.Value, CInt(txtBBValue.Text)))
            cmd.Parameters.AddWithValue("@BundlePromo", txtBundlePromo.Text)
            cmd.Parameters.AddWithValue("@BPValue", If(String.IsNullOrEmpty(txtBPValue.Text), DBNull.Value, CInt(txtBPValue.Text)))
            cmd.Parameters.AddWithValue("@Effective", dtpEffectiveDate.Value.Date)
            cmd.Parameters.AddWithValue("@Expiry", dtpExpiryDate.Value.Date)
            cmd.Parameters.AddWithValue("@store_id", cbCouponStoreID.SelectedItem)

            connection.Open()
            cmd.ExecuteNonQuery()
            connection.Close()
        End Using

        LoadCoupons()
        ClearCouponFields()
        couponID = 0
        MessageBox.Show("Update Success")
    End Sub

    Private Sub btnDeleteCoupon_Click(sender As Object, e As EventArgs) Handles btnDeleteCoupon.Click
        If couponID = 0 Then
            MessageBox.Show("Please select a coupon to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this coupon?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Dim query As String = "DELETE FROM 02_pos_coupon WHERE id=@id"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@id", couponID)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadCoupons()
            ClearCouponFields()
            couponID = 0
        End If
    End Sub

    Private Sub LoadCoupons()
        Dim query As String = "SELECT * FROM 02_pos_coupon"
        Using adapter As New MySqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvCoupons.DataSource = table
        End Using
    End Sub
    Private Sub ClearCouponFields()
        txtCouponName.Clear()
        txtCouponDesc.Clear()
        txtDiscValue.Clear()
        txtReferenceValue.Clear()
        cbCouponType.SelectedItem = -1
        txtBundleBase.Clear()
        txtBBValue.Clear()
        txtBundlePromo.Clear()
        txtBPValue.Clear()
        dtpEffectiveDate.Value = DateTime.Now
        dtpExpiryDate.Value = DateTime.Now
        cbCouponStoreID.SelectedIndex = -1
    End Sub
    Private Sub dgvCoupons_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvCoupons.Rows(e.RowIndex)

            couponID = Convert.ToInt32(selectedRow.Cells("id").Value)
            txtCouponName.Text = selectedRow.Cells("Coupon_Name").Value.ToString()
            txtCouponDesc.Text = selectedRow.Cells("Desc").Value.ToString()
            txtDiscValue.Text = selectedRow.Cells("Disc_Value").Value.ToString()
            txtReferenceValue.Text = If(selectedRow.Cells("Reference").Value Is DBNull.Value, "", selectedRow.Cells("Reference").Value.ToString())
            cbCouponType.SelectedItem = selectedRow.Cells("Type").Value.ToString()
            txtBundleBase.Text = selectedRow.Cells("Bundlebase").Value.ToString()
            txtBBValue.Text = selectedRow.Cells("BBValue").Value.ToString()
            txtBundlePromo.Text = selectedRow.Cells("BundlePromo").Value.ToString()
            txtBPValue.Text = selectedRow.Cells("BPValue").Value.ToString()
            dtpEffectiveDate.Value = Convert.ToDateTime(selectedRow.Cells("Effective").Value)
            dtpExpiryDate.Value = Convert.ToDateTime(selectedRow.Cells("Expiry").Value)
            cbCouponStoreID.SelectedItem = selectedRow.Cells("store_id").Value.ToString()
            txtCouponName.Focus()
        End If
    End Sub
    Private Sub cbCouponType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCouponType.SelectedIndexChanged
        If cbCouponType.SelectedItem Is Nothing Then Exit Sub

        Dim selectedType As String = cbCouponType.SelectedItem.ToString()
        Dim textboxesToDisable As Guna.UI2.WinForms.Guna2TextBox() = {
        txtBundleBase,
        txtBBValue,
        txtBundlePromo,
        txtBPValue
    }

        Select Case selectedType
            Case "Percentage(w/ vat)", "Percentage(w/o vat)", "Percentage(w/ vat-2)", "Fix-1", "Fix-2"
                For Each txtBox As Guna.UI2.WinForms.Guna2TextBox In textboxesToDisable
                    txtBox.Text = "N/A"
                    txtBox.Enabled = False
                Next
                If selectedType = "Fix-2" Then
                    txtReferenceValue.Text = ""
                    txtReferenceValue.Enabled = True
                Else
                    txtReferenceValue.Text = ""
                    txtReferenceValue.Enabled = False
                End If
            Case Else
                For Each txtBox As Guna.UI2.WinForms.Guna2TextBox In textboxesToDisable
                    txtBox.Text = ""
                    txtBox.Enabled = True
                Next
                txtReferenceValue.Text = ""
                txtReferenceValue.Enabled = True
                'UpdateBundleTextBoxes()
        End Select
    End Sub

    'Private Sub UpdateBundleTextBoxes()
    '    Dim selectedProductIds As New List(Of String)
    '    For Each row As DataGridViewRow In dgvProductsCoupon.Rows
    '        Dim isSelected As Boolean = Convert.ToBoolean(row.Cells("chkSelect").Value)
    '        If isSelected Then
    '            selectedProductIds.Add(row.Cells("id").Value.ToString())
    '        End If
    '    Next
    '    Dim productIdsString As String = String.Join(",", selectedProductIds)
    '    txtBundleBase.Text = productIdsString
    '    txtBundlePromo.Text = productIdsString
    'End Sub
    Private Sub dgvCoupons_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCoupons.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCoupons.Rows.Count Then
            Dim selectedRow As DataGridViewRow = dgvCoupons.Rows(e.RowIndex)

            ' Store the coupon ID for update/delete operations
            couponID = Convert.ToInt32(selectedRow.Cells("id").Value)

            ' Load basic coupon information
            txtCouponName.Text = selectedRow.Cells("Coupon_Name").Value.ToString()
            txtCouponDesc.Text = selectedRow.Cells("Desc").Value.ToString()
            txtDiscValue.Text = selectedRow.Cells("Disc_Value").Value.ToString()

            ' Handle potentially null reference values
            txtReferenceValue.Text = If(selectedRow.Cells("Reference").Value IsNot DBNull.Value,
                                  selectedRow.Cells("Reference").Value.ToString(),
                                  "")

            ' Set the coupon type and handle related field states
            cbCouponType.SelectedItem = selectedRow.Cells("Type").Value.ToString()

            ' Load bundle values, handling potential DBNull values
            txtBundleBase.Text = If(selectedRow.Cells("Bundlebase").Value IsNot DBNull.Value,
                              selectedRow.Cells("Bundlebase").Value.ToString(),
                              "")
            txtBBValue.Text = If(selectedRow.Cells("BBValue").Value IsNot DBNull.Value,
                           selectedRow.Cells("BBValue").Value.ToString(),
                           "")
            txtBundlePromo.Text = If(selectedRow.Cells("BundlePromo").Value IsNot DBNull.Value,
                               selectedRow.Cells("BundlePromo").Value.ToString(),
                               "")
            txtBPValue.Text = If(selectedRow.Cells("BPValue").Value IsNot DBNull.Value,
                           selectedRow.Cells("BPValue").Value.ToString(),
                           "")

            ' Set dates
            dtpEffectiveDate.Value = Convert.ToDateTime(selectedRow.Cells("Effective").Value)
            dtpExpiryDate.Value = Convert.ToDateTime(selectedRow.Cells("Expiry").Value)

            ' Set store ID
            If selectedRow.Cells("store_id").Value IsNot DBNull.Value Then
                cbCouponStoreID.SelectedItem = selectedRow.Cells("store_id").Value.ToString()
            Else
                cbCouponStoreID.SelectedIndex = -1
            End If

            ' Set focus to the coupon name textbox
            txtCouponName.Focus()
        End If
    End Sub
    Private Sub btnClearCoupon_Click(sender As Object, e As EventArgs) Handles btnClearCoupon.Click
        ClearCouponFields()
    End Sub
#End Region

#Region "INVENTORY"
    Private Sub LoadInventoryData()
        Dim query As String = "SELECT * FROM 02_pos_inventory_item"
        Using conn As New MySqlConnection(connectionString)
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

        Using conn As New MySqlConnection(connectionString)
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
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveItem_Click(sender As Object, e As EventArgs) Handles btnSaveItem.Click

        If Not AreFieldsValid(txtItemCode, txtItemName, cbPrimaryUOM, txtPrimaryValue, cbInvStoreID) Then
            Return
        End If

        If IsDuplicate("02_pos_inventory_item", "item_name", txtItemName.Text) Then
            MessageBox.Show("Item name already exist.")
            Return
        End If


        Dim query As String = "INSERT INTO 02_pos_inventory_item (item_code, item_name, primary_uom, primary_value, secondary_uom, secondary_value, critical_limit, unit_cost, origin, store_id) " &
                          "VALUES (@item_code, @item_name, @primary_uom, @primary_value, @secondary_uom, @secondary_value, @critical_limit, @unit_cost, @origin, @store_id)"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@item_code", txtItemCode.Text)
                cmd.Parameters.AddWithValue("@item_name", txtItemName.Text)
                cmd.Parameters.AddWithValue("@primary_uom", cbPrimaryUOM.SelectedItem)
                cmd.Parameters.AddWithValue("@primary_value", Convert.ToDecimal(txtPrimaryValue.Text))
                cmd.Parameters.AddWithValue("@secondary_uom", cbSecondaryUOM.SelectedItem)
                cmd.Parameters.AddWithValue("@secondary_value", If(String.IsNullOrEmpty(txtSecondaryValue.Text), DBNull.Value, Convert.ToDecimal(txtSecondaryValue.Text)))
                cmd.Parameters.AddWithValue("@critical_limit", Convert.ToDecimal(txtCriticalLimit.Text))
                cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtItemUnitCost.Text))
                cmd.Parameters.AddWithValue("@origin", "Local")
                cmd.Parameters.AddWithValue("@store_id", If(cbInvStoreID.SelectedItem IsNot Nothing, cbInvStoreID.SelectedItem.ToString(), DBNull.Value))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Item saved successfully!")
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving the item: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using

        LoadInventoryData()
        ClearInventory()
    End Sub

    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click
        If dgvInventory.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvInventory.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_inventory_item SET item_code = @item_code, item_name = @item_name, primary_uom = @primary_uom, primary_value = @primary_value, secondary_uom = @secondary_uom, secondary_value = @secondary_value, critical_limit = @critical_limit, unit_cost = @unit_cost, store_id=@store_id WHERE id = @id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@item_code", txtItemCode.Text)
                cmd.Parameters.AddWithValue("@item_name", txtItemName.Text)
                cmd.Parameters.AddWithValue("@primary_uom", cbPrimaryUOM.SelectedItem)
                cmd.Parameters.AddWithValue("@primary_value", Convert.ToDecimal(txtPrimaryValue.Text))
                cmd.Parameters.AddWithValue("@secondary_uom", cbSecondaryUOM.SelectedItem)
                cmd.Parameters.AddWithValue("@secondary_value", If(String.IsNullOrEmpty(txtSecondaryValue.Text), DBNull.Value, Convert.ToDecimal(txtSecondaryValue.Text)))
                cmd.Parameters.AddWithValue("@critical_limit", Convert.ToDecimal(txtCriticalLimit.Text))
                cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtItemUnitCost.Text))
                cmd.Parameters.AddWithValue("@store_id", cbInvStoreID.SelectedItem)
                cmd.Parameters.AddWithValue("@id", selectedId)

                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadInventoryData()
            ClearInventory()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub
    Private Sub btnDeleteItem_Click(sender As Object, e As EventArgs) Handles btnDeleteItem.Click
        If dgvInventory.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvInventory.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_inventory_item WHERE id = @id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadInventoryData()
                ClearInventory()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub
    Private Sub dgvInventory_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventory.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvInventory.Rows.Count Then
            Dim row As DataGridViewRow = dgvInventory.Rows(e.RowIndex)
            txtItemCode.Text = row.Cells("item_code").Value.ToString()
            txtItemName.Text = row.Cells("item_name").Value.ToString()
            cbPrimaryUOM.SelectedItem = row.Cells("primary_uom").Value.ToString()
            txtPrimaryValue.Text = row.Cells("primary_value").Value.ToString()
            cbSecondaryUOM.SelectedItem = If(IsDBNull(row.Cells("secondary_uom").Value), "", row.Cells("secondary_uom").Value.ToString())
            txtSecondaryValue.Text = If(IsDBNull(row.Cells("secondary_value").Value), "", row.Cells("secondary_value").Value.ToString())
            txtCriticalLimit.Text = row.Cells("critical_limit").Value.ToString()
            txtItemUnitCost.Text = row.Cells("unit_cost").Value.ToString()
            cbInvStoreID.SelectedItem = row.Cells("store_id").Value
        End If
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
    Private Sub btnClearInventory_Click(sender As Object, e As EventArgs) Handles btnClearInventory.Click
        ClearInventory()
    End Sub
#End Region

#Region "FORMULA"
    Private Sub LoadFormulaData()
        Dim query As String = "SELECT * FROM 02_pos_formula"
        Using conn As New MySqlConnection(connectionString)
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

        Using conn As New MySqlConnection(connectionString)
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
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadItemCodesForFormula()
        cbItemCodeFormula.Items.Clear()
        Dim query As String = "SELECT item_code FROM 02_pos_inventory_item ORDER BY item_code"

        Using conn As New MySqlConnection(connectionString)
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
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveFormula_Click(sender As Object, e As EventArgs) Handles btnSaveFormula.Click

        If Not AreFieldsValid(cbPCodeFormula, txtServingValue, txtToleranceValue, txtFormulaUnitCost, cbFormulaStoreID) Then
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_formula (product_id, item_code, serving_value, tolerance_value, unit_cost, store_id) " &
                          "VALUES (@product_id, @item_code, @serving_value, @tolerance_value, @unit_cost, @store_id)"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@product_id", cbPCodeFormula.SelectedItem)
                cmd.Parameters.AddWithValue("@item_code", cbItemCodeFormula.SelectedItem)
                cmd.Parameters.AddWithValue("@serving_value", Convert.ToDecimal(txtServingValue.Text))
                cmd.Parameters.AddWithValue("@tolerance_value", Convert.ToDecimal(txtToleranceValue.Text))
                cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtFormulaUnitCost.Text))
                cmd.Parameters.AddWithValue("@store_id", If(cbFormulaStoreID.SelectedItem IsNot Nothing, cbFormulaStoreID.SelectedItem.ToString(), DBNull.Value))

                Try
                    conn.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Formula saved successfully!")
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving the formula: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using

        LoadFormulaData()
        ClearFormula()
    End Sub

    Private Sub btnUpdateFormula_Click(sender As Object, e As EventArgs) Handles btnUpdateFormula.Click
        If dgvFormula.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvFormula.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_formula SET product_id = @product_id, item_code = @item_code, serving_value = @serving_value, tolerance_value = @tolerance_value, unit_cost = @unit_cost, store_id=@store_id WHERE id = @id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@product_id", cbPCodeFormula.SelectedItem)
                cmd.Parameters.AddWithValue("@item_code", cbItemCodeFormula.SelectedItem)
                cmd.Parameters.AddWithValue("@serving_value", Convert.ToDecimal(txtServingValue.Text))
                cmd.Parameters.AddWithValue("@tolerance_value", Convert.ToDecimal(txtToleranceValue.Text))
                cmd.Parameters.AddWithValue("@unit_cost", Convert.ToDecimal(txtFormulaUnitCost.Text))
                cmd.Parameters.AddWithValue("@store_id", cbFormulaStoreID.SelectedItem)
                cmd.Parameters.AddWithValue("@id", selectedId)

                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadFormulaData()
            ClearFormula()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDeleteFormula.Click
        If dgvFormula.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvFormula.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_formula WHERE id = @id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadFormulaData()
                ClearFormula()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub
    Private Sub dgvFormula_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFormula.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvFormula.Rows.Count Then
            Dim row As DataGridViewRow = dgvFormula.Rows(e.RowIndex)
            cbPCodeFormula.SelectedItem = row.Cells("product_id").Value.ToString()
            cbItemCodeFormula.SelectedItem = row.Cells("item_code").Value.ToString()
            txtServingValue.Text = row.Cells("serving_value").Value.ToString()
            txtToleranceValue.Text = row.Cells("tolerance_value").Value.ToString()
            txtFormulaUnitCost.Text = row.Cells("unit_cost").Value.ToString()
            cbFormulaStoreID.SelectedItem = row.Cells("store_id").Value.ToString
        End If
    End Sub
    Private Sub ClearFormula()
        cbPCodeFormula.SelectedIndex = -1
        cbItemCodeFormula.SelectedIndex = -1
        txtServingValue.Clear()
        txtToleranceValue.Clear()
        txtFormulaUnitCost.Clear()
        cbFormulaStoreID.SelectedIndex = -1
    End Sub

    Private Sub btnClearFormula_Click(sender As Object, e As EventArgs) Handles btnClearFormula.Click
        ClearFormula()
    End Sub
#End Region

#Region "SERVER PROFILES"
    Private Sub LoadServerProfiles()
        Dim query As String = "SELECT * FROM 02_pos_server_profiles"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvServerProfiles.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveServProfile_Click(sender As Object, e As EventArgs) Handles btnSaveServProfile.Click

        If Not AreFieldsValid(txtLocConnName, txtLocConnPass, txtLocConnPort, txtLocConnCert,
                          txtFTPHost, txtFTPUsername, txtFTPPass, txtFTPPort,
                          txtFTPCert, txtCloudConnName, txtCloudConnPass, txtCloudConnPort, txtCloudConnCert) Then
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_server_profiles (loc_conn_name, loc_conn_pass, loc_conn_port, loc_conn_cert, ftp_host, ftp_username, ftp_pass, ftp_port, ftp_cert, cloud_conn_name, cloud_conn_pass, cloud_conn_port, cloud_conn_cert) " &
                         "VALUES (@loc_conn_name, @loc_conn_pass, @loc_conn_port, @loc_conn_cert, @ftp_host, @ftp_username, @ftp_pass, @ftp_port, @ftp_cert, @cloud_conn_name, @cloud_conn_pass, @cloud_conn_port, @cloud_conn_cert)"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@loc_conn_name", txtLocConnName.Text)
                cmd.Parameters.AddWithValue("@loc_conn_pass", txtLocConnPass.Text)
                cmd.Parameters.AddWithValue("@loc_conn_port", Convert.ToInt32(txtLocConnPort.Text))
                cmd.Parameters.AddWithValue("@loc_conn_cert", txtLocConnCert.Text)
                cmd.Parameters.AddWithValue("@ftp_host", txtFTPHost.Text)
                cmd.Parameters.AddWithValue("@ftp_username", txtFTPUsername.Text)
                cmd.Parameters.AddWithValue("@ftp_pass", txtFTPPass.Text)
                cmd.Parameters.AddWithValue("@ftp_port", Convert.ToInt32(txtFTPPort.Text))
                cmd.Parameters.AddWithValue("@ftp_cert", txtFTPCert.Text)
                cmd.Parameters.AddWithValue("@cloud_conn_name", txtCloudConnName.Text)
                cmd.Parameters.AddWithValue("@cloud_conn_pass", txtCloudConnPass.Text)
                cmd.Parameters.AddWithValue("@cloud_conn_port", Convert.ToInt32(txtCloudConnPort.Text))
                cmd.Parameters.AddWithValue("@cloud_conn_cert", txtCloudConnCert.Text)

                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using
        End Using

        LoadServerProfiles()
        ClearServProfile()
    End Sub

    Private Sub btnUpdateServProfile_Click(sender As Object, e As EventArgs) Handles btnUpdateServProfile.Click
        If dgvServerProfiles.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvServerProfiles.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_server_profiles SET loc_conn_name = @loc_conn_name, loc_conn_pass = @loc_conn_pass, loc_conn_port = @loc_conn_port, loc_conn_cert = @loc_conn_cert, ftp_host = @ftp_host, ftp_username = @ftp_username, ftp_pass = @ftp_pass, ftp_port = @ftp_port, ftp_cert = @ftp_cert, cloud_conn_name = @cloud_conn_name, cloud_conn_pass = @cloud_conn_pass, cloud_conn_port = @cloud_conn_port, cloud_conn_cert = @cloud_conn_cert WHERE id = @id"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@loc_conn_name", txtLocConnName.Text)
                    cmd.Parameters.AddWithValue("@loc_conn_pass", txtLocConnPass.Text)
                    cmd.Parameters.AddWithValue("@loc_conn_port", Convert.ToInt32(txtLocConnPort.Text))
                    cmd.Parameters.AddWithValue("@loc_conn_cert", txtLocConnCert.Text)
                    cmd.Parameters.AddWithValue("@ftp_host", txtFTPHost.Text)
                    cmd.Parameters.AddWithValue("@ftp_username", txtFTPUsername.Text)
                    cmd.Parameters.AddWithValue("@ftp_pass", txtFTPPass.Text)
                    cmd.Parameters.AddWithValue("@ftp_port", Convert.ToInt32(txtFTPPort.Text))
                    cmd.Parameters.AddWithValue("@ftp_cert", txtFTPCert.Text)
                    cmd.Parameters.AddWithValue("@cloud_conn_name", txtCloudConnName.Text)
                    cmd.Parameters.AddWithValue("@cloud_conn_pass", txtCloudConnPass.Text)
                    cmd.Parameters.AddWithValue("@cloud_conn_port", Convert.ToInt32(txtCloudConnPort.Text))
                    cmd.Parameters.AddWithValue("@cloud_conn_cert", txtCloudConnCert.Text)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using
            End Using

            LoadServerProfiles()
            ClearServProfile()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub

    Private Sub btnDeleteServProfile_Click(sender As Object, e As EventArgs) Handles btnDeleteServProfile.Click
        If dgvServerProfiles.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvServerProfiles.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_server_profiles WHERE id = @id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadServerProfiles()
                ClearServProfile()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub btnClearServProfile_Click(sender As Object, e As EventArgs) Handles btnClearServProfile.Click
        ClearServProfile()
    End Sub

    Private Sub dgvServerProfiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServerProfiles.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvServerProfiles.Rows.Count Then
            Dim row As DataGridViewRow = dgvServerProfiles.Rows(e.RowIndex)
            txtLocConnName.Text = row.Cells("loc_conn_name").Value.ToString()
            txtLocConnPass.Text = row.Cells("loc_conn_pass").Value.ToString()
            txtLocConnPort.Text = row.Cells("loc_conn_port").Value.ToString()
            txtLocConnCert.Text = row.Cells("loc_conn_cert").Value.ToString()
            txtFTPHost.Text = row.Cells("ftp_host").Value.ToString()
            txtFTPUsername.Text = row.Cells("ftp_username").Value.ToString()
            txtFTPPass.Text = row.Cells("ftp_pass").Value.ToString()
            txtFTPPort.Text = row.Cells("ftp_port").Value.ToString()
            txtFTPCert.Text = row.Cells("ftp_cert").Value.ToString()
            txtCloudConnName.Text = row.Cells("cloud_conn_name").Value.ToString()
            txtCloudConnPass.Text = row.Cells("cloud_conn_pass").Value.ToString()
            txtCloudConnPort.Text = row.Cells("cloud_conn_port").Value.ToString()
            txtCloudConnCert.Text = row.Cells("cloud_conn_cert").Value.ToString()
        End If
    End Sub

    Private Sub ClearServProfile()
        txtLocConnName.Clear()
        txtLocConnPass.Clear()
        txtLocConnPort.Clear()
        txtLocConnCert.Clear()
        txtFTPHost.Clear()
        txtFTPUsername.Clear()
        txtFTPPass.Clear()
        txtFTPPort.Clear()
        txtFTPCert.Clear()
        txtCloudConnName.Clear()
        txtCloudConnPass.Clear()
        txtCloudConnPort.Clear()
        txtCloudConnCert.Clear()
    End Sub
#End Region

#Region "USERS"
    Private Sub LoadUsers()
        Dim query As String = "SELECT * FROM 02_pos_users"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvUsers.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveUser_Click(sender As Object, e As EventArgs) Handles btnSaveUser.Click
        If Not AreFieldsValid(txtUsername, txtPassword, txtPin, txtFullName, txtUserEmail, cbUserPosition) Then
            Return
        End If

        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If Not rbMale.Checked AndAlso Not rbFemale.Checked Then
            MessageBox.Show("Gender is required!", "Incomplete Fields", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If IsDuplicate("02_pos_users", "username", txtUsername.Text.Trim()) Then
            MessageBox.Show("The username already exists. Please choose a different username.")
            Return
        End If

        If IsDuplicate("02_pos_users", "email", txtUserEmail.Text.Trim()) Then
            MessageBox.Show("The email already exists. Please use a different email address.")
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_users (user_id, username, password, user_pin, fullname, email, position, gender, creator_id, created_date, status) " &
                           "VALUES (@user_id, @username, @password, @user_pin, @fullname, @email, @position, @gender, @creator_id, @created_date, @status)"

        Try
            Using connection As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, connection)
                    ' Add parameters with proper value assignment
                    cmd.Parameters.AddWithValue("@user_id", GenerateUserId())
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                    cmd.Parameters.AddWithValue("@user_pin", txtPin.Text.Trim())
                    cmd.Parameters.AddWithValue("@fullname", txtFullName.Text.Trim())
                    cmd.Parameters.AddWithValue("@email", txtUserEmail.Text.Trim())
                    cmd.Parameters.AddWithValue("@position", If(cbUserPosition.SelectedItem IsNot Nothing, cbUserPosition.SelectedItem.ToString().Trim(), String.Empty))
                    cmd.Parameters.AddWithValue("@gender", If(rbMale.Checked, "Male", "Female"))
                    cmd.Parameters.AddWithValue("@creator_id", cbUserCreatorID.SelectedItem)
                    cmd.Parameters.AddWithValue("@created_date", DateTime.Now.ToString("yyyy-MM-dd"))
                    cmd.Parameters.AddWithValue("@status", 1)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            LoadUsers()
            ClearUserForm()

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GenerateUserId() As String
        Dim rnd As New Random()
        Return rnd.Next(1000, 9999).ToString()
    End Function

    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click
        If txtPassword.Text <> txtConfirmPassword.Text Then
            MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvUsers.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_users SET username = @username, password = @password, user_pin = @user_pin, fullname = @fullname, email = @email, " &
                                  "position = @position, gender = @gender, creator_id=@creator_id WHERE id = @id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)
                cmd.Parameters.AddWithValue("@user_pin", txtPin.Text)
                cmd.Parameters.AddWithValue("@fullname", txtFullName.Text)
                cmd.Parameters.AddWithValue("@email", txtUserEmail.Text)
                cmd.Parameters.AddWithValue("@position", cbUserPosition.SelectedItem)
                cmd.Parameters.AddWithValue("@gender", If(rbMale.Checked, "Male", "Female"))
                cmd.Parameters.AddWithValue("@creator_id", cbUserCreatorID.SelectedItem)
                cmd.Parameters.AddWithValue("@id", selectedId)
                connection.Open()
                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadUsers()
            ClearUserForm()
        Else
            MessageBox.Show("Please select a row to update.")
        End If
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvUsers.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_users WHERE id = @id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadUsers()
                ClearUserForm()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub btnClearUser_Click(sender As Object, e As EventArgs) Handles btnClearUser.Click
        ClearUserForm()
    End Sub
    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvUsers.Rows.Count Then
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            txtUsername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            txtPin.Text = row.Cells("user_pin").Value.ToString()
            txtFullName.Text = row.Cells("fullname").Value.ToString()
            txtUserEmail.Text = row.Cells("email").Value.ToString()
            cbUserPosition.SelectedItem = row.Cells("position").Value.ToString()
            cbUserCreatorID.SelectedItem = row.Cells("creator_id").Value.ToString()
            Dim gender As String = row.Cells("gender").Value.ToString()

            If gender = "Male" Then
                rbMale.Checked = True
            Else
                rbFemale.Checked = True
            End If
        End If
    End Sub
    Private Sub ClearUserForm()
        txtUsername.Clear()
        txtPassword.Clear()
        txtPin.Clear()
        txtFullName.Clear()
        txtUserEmail.Clear()
        cbUserPosition.SelectedIndex = -1
        cbUserCreatorID.SelectedIndex = -1
        rbMale.Checked = False
        rbFemale.Checked = False
    End Sub
#End Region

#Region "SETTINGS"
    Private Sub LoadSettings()
        Dim query As String = "SELECT * FROM 02_pos_other_settings"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            If table.Rows.Count > 0 Then
                Dim row As DataRow = table.Rows(0)
                txtSalesInvoiceFormat.Text = row("Sales_Invoice_format").ToString()
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_Void")), rbMcodeVoidYes, rbMcodeVoidNo)
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_Refund")), rbMCodeRefundYes, rbMCodeRefundNo)
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_Settings")), rbMCodeSettingsYes, rbMCodeSettingsNo)
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_Zread")), rbMCodeZreadYes, rbMCodeZreadNo)
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_CouponPromos")), rbMCodeCouponPromosYes, rbMCodeCouponPromosNo)
                SetMCodeRadioButtons(Convert.ToInt32(row("MCode_Reprint")), rbmCodeReprintYes, rbmCodeReprintNo)
                txtMEMCValue.Text = row("MEMC_Value").ToString()
            End If
        End Using
    End Sub

    Private Sub SetMCodeRadioButtons(value As Integer, rbYes As RadioButton, rbNo As RadioButton)
        If value = 1 Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        Dim mCodeVoid As Integer = If(rbMcodeVoidYes.Checked, 1, 0)
        Dim mCodeRefund As Integer = If(rbMCodeRefundYes.Checked, 1, 0)
        Dim mCodeSettings As Integer = If(rbMCodeSettingsYes.Checked, 1, 0)
        Dim mCodeZread As Integer = If(rbMCodeZreadYes.Checked, 1, 0)
        Dim mCodeCouponPromos As Integer = If(rbMCodeCouponPromosYes.Checked, 1, 0)
        Dim mCodeReprint As Integer = If(rbmCodeReprintYes.Checked, 1, 0)

        Dim query As String = "INSERT INTO 02_pos_other_settings (Sales_Invoice_format, MCode_Void, MCode_Refund, MCode_Settings, MCode_Zread, MCode_CouponPromos, MCode_Reprint, MEMC_Value) " &
                          "VALUES (@Sales_Invoice_format, @MCode_Void, @MCode_Refund, @MCode_Settings, @MCode_Zread, @MCode_CouponPromos, @MCode_Reprint, @MEMC_Value) " &
                          "ON DUPLICATE KEY UPDATE Sales_Invoice_format = @Sales_Invoice_format, MCode_Void = @MCode_Void, MCode_Refund = @MCode_Refund, MCode_Settings = @MCode_Settings, MCode_Zread = @MCode_Zread, MCode_CouponPromos = @MCode_CouponPromos, MCode_Reprint = @MCode_Reprint, MEMC_Value = @MEMC_Value"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                cmd.Parameters.AddWithValue("@Sales_Invoice_format", txtSalesInvoiceFormat.Text)
                cmd.Parameters.AddWithValue("@MCode_Void", mCodeVoid)
                cmd.Parameters.AddWithValue("@MCode_Refund", mCodeRefund)
                cmd.Parameters.AddWithValue("@MCode_Settings", mCodeSettings)
                cmd.Parameters.AddWithValue("@MCode_Zread", mCodeZread)
                cmd.Parameters.AddWithValue("@MCode_CouponPromos", mCodeCouponPromos)
                cmd.Parameters.AddWithValue("@MCode_Reprint", mCodeReprint)
                cmd.Parameters.AddWithValue("@MEMC_Value", txtMEMCValue.Text)

                cmd.ExecuteNonQuery()
                conn.Close()
            End Using
        End Using

        LoadSettings()
        MessageBox.Show("Settings saved successfully.")
    End Sub


#End Region

#Region "OTHER SETTINGS"
    Private Sub LoadOtherSettings()
        Dim query As String = "SELECT * FROM 02_pos_other_settings LIMIT 1"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            If table.Rows.Count > 0 Then
                Dim row As DataRow = table.Rows(0)
                ' Set the radio buttons based on the loaded values
                SetRadioButtons(Convert.ToInt32(row("preview_all")), rbPreviewAllYes, rbPreviewAllNo)
                SetRadioButtons(Convert.ToInt32(row("print_receipt")), rbPrintReceiptYes, rbPrintReceiptNo)
                SetRadioButtons(Convert.ToInt32(row("print_x_reading")), rbPrintXreadingYes, rbPrintXreadingNo)
                SetRadioButtons(Convert.ToInt32(row("print_z_reading")), rbPrintZreadYes, rbPrintZreadNo)
                SetRadioButtons(Convert.ToInt32(row("print_sales_report")), rbPrintSalesYes, rbPrintSalesNo)
                SetRadioButtons(Convert.ToInt32(row("print_inventory")), rbPrintInventoryYes, rbPrintInventoryNo)
                SetRadioButtons(Convert.ToInt32(row("print_reprint")), rbPrintReprintYes, rbPrintReprintNo)
                SetRadioButtons(Convert.ToInt32(row("print_log_data")), rbPrintLogDataYes, rbPrintLogDataNo)
                SetRadioButtons(Convert.ToInt32(row("print_log_data")), rbTrainingModeYes, rbTrainingModeNo)
            End If
        End Using
    End Sub

    Private Sub SetRadioButtons(value As Integer, rbYes As RadioButton, rbNo As RadioButton)
        If value = 1 Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
    End Sub

    Private Sub btnSaveOtherSettings_Click(sender As Object, e As EventArgs) Handles btnSaveOtherSettings.Click
        Dim previewAll As Integer = If(rbPreviewAllYes.Checked, 1, 0)
        Dim printReceipt As Integer = If(rbPrintReceiptYes.Checked, 1, 0)
        Dim printXreading As Integer = If(rbPrintXreadingYes.Checked, 1, 0)
        Dim printZread As Integer = If(rbPrintZreadYes.Checked, 1, 0)
        Dim printSales As Integer = If(rbPrintSalesYes.Checked, 1, 0)
        Dim printInventory As Integer = If(rbPrintInventoryYes.Checked, 1, 0)
        Dim printReprint As Integer = If(rbPrintReprintYes.Checked, 1, 0)
        Dim printLogData As Integer = If(rbPrintLogDataYes.Checked, 1, 0)
        Dim trainingMode As Integer = If(rbTrainingModeYes.Checked, 1, 0)

        Dim query As String = "INSERT INTO 02_pos_other_settings (preview_all, print_receipt, print_x_reading, print_z_reading, print_sales_report, print_inventory, print_reprint, print_log_data,training_mode) " &
                              "VALUES (@preview_all, @print_receipt, @print_x_reading, @print_z_reading, @print_sales_report, @print_inventory, @print_reprint, @print_log_data, @training_mode) " &
                              "ON DUPLICATE KEY UPDATE preview_all = @preview_all, print_receipt = @print_receipt, print_x_reading = @print_x_reading, print_z_reading = @print_z_reading, print_sales_report = @print_sales_report, print_inventory = @print_inventory, print_reprint = @print_reprint, print_log_data = @print_log_data, training_mode = @training_mode"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@preview_all", previewAll)
                cmd.Parameters.AddWithValue("@print_receipt", printReceipt)
                cmd.Parameters.AddWithValue("@print_x_reading", printXreading)
                cmd.Parameters.AddWithValue("@print_z_reading", printZread)
                cmd.Parameters.AddWithValue("@print_sales_report", printSales)
                cmd.Parameters.AddWithValue("@print_inventory", printInventory)
                cmd.Parameters.AddWithValue("@print_reprint", printReprint)
                cmd.Parameters.AddWithValue("@print_log_data", printLogData)
                cmd.Parameters.AddWithValue("@training_mode", trainingMode)

                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using
        End Using

        LoadOtherSettings()
        MessageBox.Show("Settings saved successfully.")
    End Sub
#End Region

#Region "Payment Method"
    Private Sub LoadPaymentMethod()
        Dim query As String = "SELECT * FROM 02_pos_payment_method"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvPaymentMethod.DataSource = table
        End Using
    End Sub
    Private Sub btnSavePayment_Click(sender As Object, e As EventArgs) Handles btnSavePayment.Click
        If Not AreFieldsValid(txtPaymentType, cbPaymentStoreID) Then
            Return
        End If

        If IsDuplicate("02_pos_payment_method", "payment_type", txtPaymentType.Text) Then
            MessageBox.Show("Payment type already exists. Please enter different payment type.")
            Return
        End If

        Dim query As String = "INSERT INTO 02_pos_payment_method (payment_type, status, store_id, created_at) VALUES (@payment_type, @status, @store_id, NOW())"

        Using connection As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@payment_type", txtPaymentType.Text)
                cmd.Parameters.AddWithValue("@status", 1)
                cmd.Parameters.AddWithValue("@store_id", cbPaymentStoreID.SelectedItem.ToString)

                Try
                    connection.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As MySqlException
                    MessageBox.Show("An error occurred while saving activation data: " & ex.Message)
                Finally
                    connection.Close()
                End Try
            End Using

            LoadPaymentMethod()
            ClearPaymentFields()
        End Using
    End Sub

    Private Sub btnUpdatePayment_Click(sender As Object, e As EventArgs) Handles btnUpdatePayment.Click
        If dgvPaymentMethod.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvPaymentMethod.SelectedRows(0).Cells("id").Value)
            Dim query As String = "UPDATE 02_pos_payment_method SET payment_type=@payment_type, status=@status, store_id=@store_id WHERE id=@id"

            Using cmd As New MySqlCommand(query, connection)
                connection.Open()
                cmd.Parameters.AddWithValue("@payment_type", txtPaymentType.Text)
                cmd.Parameters.AddWithValue("@store_id", cbPaymentStoreID.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@id", selectedId)

                cmd.ExecuteNonQuery()
                connection.Close()
            End Using

            LoadPaymentMethod()
            ClearPaymentFields()
        End If
    End Sub

    Private Sub btnDeletePayment_Click(sender As Object, e As EventArgs) Handles btnDeletePayment.Click
        If dgvPaymentMethod.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvPaymentMethod.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_payment_method WHERE id = @Id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@Id", selectedId)

                    connection.Open()
                    cmd.ExecuteNonQuery()
                    connection.Close()
                End Using

                LoadPaymentMethod()
                ClearPaymentFields()
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub btnClearPayment_Click(sender As Object, e As EventArgs) Handles btnClearPayment.Click
        ClearPaymentFields()
    End Sub
    Private Sub ClearPaymentFields()
        txtPaymentType.Clear()
        cbPaymentStoreID.SelectedIndex = -1
    End Sub
#End Region

#Region "UOM"
    Private Sub LoadUOM()
        Dim query As String = "SELECT * FROM 02_pos_loc_uom"
        Using conn As New MySqlConnection(connectionString)
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

            Using conn As New MySqlConnection(connectionString)
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
        Using conn As New MySqlConnection(connectionString)
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

        Using conn As New MySqlConnection(connectionString)
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

                Using conn As New MySqlConnection(connectionString)
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

    Private Sub dgvuom_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUom.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvUom.Rows.Count Then
            Dim row As DataGridViewRow = dgvUom.Rows(e.RowIndex)
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

#Region "PROVIDER INFO"
    Private Sub LoadProviderInfo()
        Dim query As String = "SELECT * FROM 02_pos_provider_info ORDER BY arrangement"
        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim arrangement As Integer = Convert.ToInt32(reader("arrangement"))
                            Dim value As String = reader("value").ToString()

                            Select Case arrangement
                                Case 1
                                    txtProviderName.Text = value
                                Case 2
                                    txtProviderFullName.Text = value
                                Case 3
                                    txtProviderAddress1.Text = value
                                Case 4
                                    txtProviderAddress2.Text = value
                                Case 5
                                    txtProviderTIN.Text = value
                                Case 6
                                    txtProviderACCR.Text = value
                                Case 7
                                    txtProviderPTU.Text = value
                                Case 8
                                    txtProviderTel.Text = value
                            End Select
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading provider info: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveProvider_Click(sender As Object, e As EventArgs) Handles btnSaveProvider.Click
        If Not AreFieldsValid(txtProviderName, txtProviderFullName, txtProviderAddress1,
                         txtProviderAddress2, txtProviderTIN, txtProviderACCR,
                         txtProviderPTU, txtProviderTel) Then
            Return
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim values() As String = {
                        txtProviderName.Text,
                        txtProviderFullName.Text,
                        txtProviderAddress1.Text,
                        txtProviderAddress2.Text,
                        txtProviderTIN.Text,
                        txtProviderACCR.Text,
                        txtProviderPTU.Text,
                        txtProviderTel.Text
                    }

                        Dim arrangements() As Integer = {1, 2, 3, 4, 5, 6, 7, 8}

                        ' Save to 02_pos_provider_info
                        For i As Integer = 0 To values.Length - 1
                            Dim checkQuery As String = "SELECT COUNT(*) FROM 02_pos_provider_info WHERE arrangement = @arrangement"
                            Using checkCmd As New MySqlCommand(checkQuery, conn, transaction)
                                checkCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                                If exists > 0 Then
                                    Dim updateQuery As String = "UPDATE 02_pos_provider_info SET value = @value WHERE arrangement = @arrangement"
                                    Using updateCmd As New MySqlCommand(updateQuery, conn, transaction)
                                        updateCmd.Parameters.AddWithValue("@value", values(i))
                                        updateCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                        updateCmd.ExecuteNonQuery()
                                    End Using
                                Else
                                    Dim insertQuery As String = "INSERT INTO 02_pos_provider_info (value, arrangement) VALUES (@value, @arrangement)"
                                    Using insertCmd As New MySqlCommand(insertQuery, conn, transaction)
                                        insertCmd.Parameters.AddWithValue("@value", values(i))
                                        insertCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                        insertCmd.ExecuteNonQuery()
                                    End Using
                                End If
                            End Using

                            ' Save to 02_pos_receipt_info
                            Dim receiptCheckQuery As String = "SELECT COUNT(*) FROM 02_pos_receipt_info " &
                                                        "WHERE store_id = '0' AND type_ = 'Footer' AND arrangement = @arrangement"
                            Using checkCmd As New MySqlCommand(receiptCheckQuery, conn, transaction)
                                checkCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                                If exists > 0 Then
                                    Dim updateQuery As String = "UPDATE 02_pos_receipt_info SET " &
                                                          "value = @value, date_updated = @dateUpdated " &
                                                          "WHERE store_id = '0' AND type_ = 'Footer' AND arrangement = @arrangement"
                                    Using updateCmd As New MySqlCommand(updateQuery, conn, transaction)
                                        updateCmd.Parameters.AddWithValue("@value", values(i))
                                        updateCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                        updateCmd.Parameters.AddWithValue("@dateUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                        updateCmd.ExecuteNonQuery()
                                    End Using
                                Else
                                    Dim insertQuery As String = "INSERT INTO 02_pos_receipt_info " &
                                                          "(type_, value, arrangement, store_id, date_updated) " &
                                                          "VALUES ('Footer', @value, @arrangement, '0', @dateUpdated)"
                                    Using insertCmd As New MySqlCommand(insertQuery, conn, transaction)
                                        insertCmd.Parameters.AddWithValue("@value", values(i))
                                        insertCmd.Parameters.AddWithValue("@arrangement", arrangements(i))
                                        insertCmd.Parameters.AddWithValue("@dateUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                        insertCmd.ExecuteNonQuery()
                                    End Using
                                End If
                            End Using
                        Next

                        transaction.Commit()
                        MessageBox.Show("Provider information saved successfully!")
                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("Error saving provider info: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Database connection error: " & ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
    End Sub

    Private Sub ClearProviderFields()
        txtProviderName.Clear()
        txtProviderFullName.Clear()
        txtProviderAddress1.Clear()
        txtProviderAddress2.Clear()
        txtProviderTIN.Clear()
        txtProviderACCR.Clear()
        txtProviderPTU.Clear()
        txtProviderTel.Clear()
    End Sub

    Private Sub btnClearProvider_Click(sender As Object, e As EventArgs) Handles btnClearProvider.Click
        ClearProviderFields()
    End Sub
#End Region

#Region "OUTLET"
    Private Sub LoadClientIDs()
        cbClientID.Items.Clear()
        Dim query As String = "SELECT client_id FROM 02_pos_activation ORDER BY client_id"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbClientID.Items.Add(reader("client_id").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading client IDs: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadOutletInfo()
        Dim query As String = "SELECT * FROM 02_pos_outlets WHERE store_id = @store_id"
        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cbClientID.Text = reader("client_id").ToString()
                            txtOutletBrand.Text = reader("brand_").ToString()
                            txtOutletOperated.Text = reader("operated_by").ToString()
                            txtOutletBranch.Text = reader("location_name").ToString()
                            txtOutletAddress1.Text = reader("address_1").ToString()
                            txtOutletAddress2.Text = reader("address_2").ToString()
                            txtOutletTin.Text = reader("tin_").ToString()
                            txtOutletSerial.Text = reader("serial_no").ToString()
                            txtOutletTel.Text = reader("tel_no").ToString()
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading outlet info: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using

        ' Load receipt info
        query = "SELECT * FROM 02_pos_receipt_info WHERE store_id = @store_id ORDER BY arrangement"
        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Select Case reader("arrangement").ToString()
                                Case "1"
                                    txtOutletBrand.Text = reader("value").ToString()
                                Case "2"
                                    txtOutletOperated.Text = reader("value").ToString()
                                Case "3"
                                    txtOutletBranch.Text = reader("value").ToString()
                                Case "4"
                                    txtOutletAddress1.Text = reader("value").ToString()
                                Case "5"
                                    txtOutletAddress2.Text = reader("value").ToString()
                                Case "6"
                                    txtOutletTin.Text = reader("value").ToString()
                                Case "7"
                                    txtOutletSerial.Text = reader("value").ToString()
                                Case "8"
                                    txtOutletTel.Text = reader("value").ToString()
                            End Select
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading receipt info: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub
    Private Function IsClientIDUsed(clientID As String, currentStoreID As String) As Boolean
        Using conn As New MySqlConnection(connectionString)
            Dim query As String = "SELECT COUNT(*) FROM 02_pos_outlets WHERE client_id = @clientID AND store_id <> @storeID"
            Using cmd As New MySqlCommand(query, conn)
                Try
                    cmd.Parameters.AddWithValue("@clientID", clientID)
                    cmd.Parameters.AddWithValue("@storeID", currentStoreID)
                    conn.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0
                Catch ex As Exception
                    MessageBox.Show("Error checking client ID: " & ex.Message)
                    Return True ' Return true to prevent save on error
                End Try
            End Using
        End Using
    End Function

    Private Sub btnSaveOutlet_Click(sender As Object, e As EventArgs) Handles btnSaveOutlet.Click
        If Not AreFieldsValid(txtOutletBrand, txtOutletOperated, txtOutletBranch,
                        txtOutletAddress1, txtOutletAddress2, txtOutletTin,
                        txtOutletSerial, txtOutletTel, cbClientID, txtOutletStoreID) Then
            Return
        End If

        If IsClientIDUsed(cbClientID.Text, txtOutletStoreID.Text) Then
            MessageBox.Show("This Client ID is already assigned to another outlet. Please choose a different Client ID or Create new activation account.", "Duplicate Client ID", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim checkQuery As String = "SELECT COUNT(*) FROM 02_pos_outlets WHERE store_id = @store_id"
                        Dim exists As Integer = 0

                        Using checkCmd As New MySqlCommand(checkQuery, conn, transaction)
                            checkCmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                            exists = Convert.ToInt32(checkCmd.ExecuteScalar())
                        End Using

                        If exists > 0 Then
                            Dim updateOutletQuery As String = "UPDATE 02_pos_outlets SET " &
                            "client_id = @client_id, " &
                            "brand_ = @brand, " &
                            "operated_by = @operated_by, " &
                            "location_name = @location_name, " &
                            "address_1 = @address_1, " &
                            "address_2 = @address_2, " &
                            "tin_ = @tin, " &
                            "serial_no = @serial_no, " &
                            "tel_no = @tel_no, " &
                            "date_updated = @date_updated " &
                            "WHERE store_id = @store_id"

                            Using cmd As New MySqlCommand(updateOutletQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@client_id", cbClientID.Text)
                                cmd.Parameters.AddWithValue("@brand", txtOutletBrand.Text)
                                cmd.Parameters.AddWithValue("@operated_by", txtOutletOperated.Text)
                                cmd.Parameters.AddWithValue("@location_name", txtOutletBranch.Text)
                                cmd.Parameters.AddWithValue("@address_1", txtOutletAddress1.Text)
                                cmd.Parameters.AddWithValue("@address_2", txtOutletAddress2.Text)
                                cmd.Parameters.AddWithValue("@tin", txtOutletTin.Text)
                                cmd.Parameters.AddWithValue("@serial_no", txtOutletSerial.Text)
                                cmd.Parameters.AddWithValue("@tel_no", txtOutletTel.Text)
                                cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                                cmd.Parameters.AddWithValue("@date_updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                cmd.ExecuteNonQuery()
                            End Using
                        Else
                            ' Insert new outlet
                            Dim insertOutletQuery As String = "INSERT INTO 02_pos_outlets " &
                            "(client_id, brand_, operated_by, location_name, address_1, address_2, " &
                            "tin_, serial_no, tel_no, store_id, status_, date_updated) VALUES " &
                            "(@client_id, @brand, @operated_by, @location_name, @address_1, @address_2, " &
                            "@tin, @serial_no, @tel_no, @store_id, @status, @date_updated)"

                            Using cmd As New MySqlCommand(insertOutletQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@client_id", cbClientID.Text)
                                cmd.Parameters.AddWithValue("@brand", txtOutletBrand.Text)
                                cmd.Parameters.AddWithValue("@operated_by", txtOutletOperated.Text)
                                cmd.Parameters.AddWithValue("@location_name", txtOutletBranch.Text)
                                cmd.Parameters.AddWithValue("@address_1", txtOutletAddress1.Text)
                                cmd.Parameters.AddWithValue("@address_2", txtOutletAddress2.Text)
                                cmd.Parameters.AddWithValue("@tin", txtOutletTin.Text)
                                cmd.Parameters.AddWithValue("@serial_no", txtOutletSerial.Text)
                                cmd.Parameters.AddWithValue("@tel_no", txtOutletTel.Text)
                                cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                                cmd.Parameters.AddWithValue("@status", 1)
                                cmd.Parameters.AddWithValue("@date_updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                cmd.ExecuteNonQuery()
                            End Using
                        End If

                        ' Handle receipt info - same pattern
                        Dim values() As String = {
                        txtOutletBrand.Text,
                        txtOutletOperated.Text,
                        txtOutletBranch.Text,
                        txtOutletAddress1.Text,
                        txtOutletAddress2.Text,
                        txtOutletTin.Text,
                        txtOutletSerial.Text,
                        txtOutletTel.Text
                    }

                        For i As Integer = 0 To values.Length - 1
                            ' Check if receipt info exists
                            Dim receiptCheckQuery As String = "SELECT COUNT(*) FROM 02_pos_receipt_info " &
                                                        "WHERE store_id = @store_id AND arrangement = @arrangement"
                            Dim receiptExists As Integer = 0

                            Using checkCmd As New MySqlCommand(receiptCheckQuery, conn, transaction)
                                checkCmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                                checkCmd.Parameters.AddWithValue("@arrangement", (i + 1).ToString())
                                receiptExists = Convert.ToInt32(checkCmd.ExecuteScalar())
                            End Using

                            If receiptExists > 0 Then
                                ' Update receipt info
                                Dim updateReceiptQuery As String = "UPDATE 02_pos_receipt_info SET " &
                                "value = @value, date_updated = @date_updated " &
                                "WHERE store_id = @store_id AND arrangement = @arrangement"

                                Using cmd As New MySqlCommand(updateReceiptQuery, conn, transaction)
                                    cmd.Parameters.AddWithValue("@value", values(i))
                                    cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                                    cmd.Parameters.AddWithValue("@arrangement", (i + 1).ToString())
                                    cmd.Parameters.AddWithValue("@date_updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    cmd.ExecuteNonQuery()
                                End Using
                            Else
                                ' Insert receipt info
                                Dim insertReceiptQuery As String = "INSERT INTO 02_pos_receipt_info " &
                                "(type_, value, arrangement, store_id, date_updated) VALUES " &
                                "(@type, @value, @arrangement, @store_id, @date_updated)"

                                Using cmd As New MySqlCommand(insertReceiptQuery, conn, transaction)
                                    cmd.Parameters.AddWithValue("@type", "Header")
                                    cmd.Parameters.AddWithValue("@value", values(i))
                                    cmd.Parameters.AddWithValue("@arrangement", (i + 1).ToString())
                                    cmd.Parameters.AddWithValue("@store_id", txtOutletStoreID.Text)
                                    cmd.Parameters.AddWithValue("@date_updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    cmd.ExecuteNonQuery()
                                End Using
                            End If
                        Next

                        transaction.Commit()
                        MessageBox.Show("Outlet information saved successfully!")

                    Catch ex As Exception
                        Try
                            transaction.Rollback()
                        Catch rollbackEx As Exception
                            MessageBox.Show("Rollback error: " & rollbackEx.Message)
                        End Try
                        MessageBox.Show("Error saving outlet information: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Database connection error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ClearOutletFields()
        txtOutletBrand.Clear()
        txtOutletOperated.Clear()
        txtOutletBranch.Clear()
        txtOutletAddress1.Clear()
        txtOutletAddress2.Clear()
        txtOutletTin.Clear()
        txtOutletSerial.Clear()
        txtOutletTel.Clear()
        cbClientID.SelectedIndex = -1
        txtOutletStoreID.Clear()
    End Sub

    Private Sub btnClearOutlet_Click(sender As Object, e As EventArgs) Handles btnClearOutlet.Click
        ClearOutletFields()
    End Sub

    Private Function GenerateNewStoreID() As String
        Dim newStoreID As Integer = 1
        Dim query As String = "SELECT MAX(CAST(store_id AS UNSIGNED)) FROM 02_pos_outlets"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot DBNull.Value AndAlso result IsNot Nothing Then
                        newStoreID = Convert.ToInt32(result) + 1
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error generating store ID: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using

        Return newStoreID.ToString()
    End Function

    Private Sub btnGenerateStoreID_Click(sender As Object, e As EventArgs) Handles btnGenerateStoreID.Click
        Dim newStoreID As String = GenerateNewStoreID()
        txtOutletStoreID.Text = newStoreID
        MessageBox.Show($"New Store ID generated: {newStoreID}")
    End Sub
#End Region

#Region "SPECIAL FOOTER"
    Private Sub LoadStoreIDs()
        cbSPFooter.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbSPFooter.Items.Add(reader("store_id").ToString())
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

    Private Sub LoadFooterText()
        If cbSPFooter.SelectedItem Is Nothing Then Return

        Dim query As String = "SELECT value FROM 02_pos_receipt_info WHERE store_id = @store_id AND type_ = 'Footer' ORDER BY arrangement"
        txtSPFooter.Clear()

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", cbSPFooter.SelectedItem.ToString())
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim footerText As New StringBuilder()
                        While reader.Read()
                            footerText.AppendLine(reader("value").ToString())
                        End While
                        txtSPFooter.Text = footerText.ToString().TrimEnd()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading footer text: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub btnSaveFooter_Click(sender As Object, e As EventArgs) Handles btnSaveSPFooter.Click
        If cbSPFooter.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a store ID.")
            Return
        End If

        ' Split text into lines and validate
        Dim lines As String() = txtSPFooter.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        If lines.Length > 5 Then
            MessageBox.Show("Maximum 5 lines allowed.")
            Return
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' First, update existing records to blank or remove them
                        Dim updateBlankQuery As String = "UPDATE 02_pos_receipt_info SET value = '' " &
                                                   "WHERE store_id = @storeId AND type_ = 'Special Footer'"

                        Using cmdBlank As New MySqlCommand(updateBlankQuery, conn, transaction)
                            cmdBlank.Parameters.AddWithValue("@storeId", cbSPFooter.SelectedItem.ToString())
                            cmdBlank.ExecuteNonQuery()
                        End Using

                        ' Then insert/update with new values
                        For i As Integer = 0 To lines.Length - 1
                            Dim upsertQuery As String = "INSERT INTO 02_pos_receipt_info (type_, value, arrangement, store_id, date_updated) " &
                                                  "VALUES ('Special Footer', @footerValue, @arrangementNum, @storeId, @dateUpdated) " &
                                                  "ON DUPLICATE KEY UPDATE value = @footerValue, date_updated = @dateUpdated"

                            Using cmd As New MySqlCommand(upsertQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@footerValue", lines(i))
                                cmd.Parameters.AddWithValue("@arrangementNum", (i + 1).ToString())
                                cmd.Parameters.AddWithValue("@storeId", cbSPFooter.SelectedItem.ToString())
                                cmd.Parameters.AddWithValue("@dateUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                        MessageBox.Show("Footer text saved successfully!")
                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("Error saving footer text: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Database connection error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub txtSPFooter_TextChanged(sender As Object, e As EventArgs) Handles txtSPFooter.TextChanged
        Dim lines As String() = txtSPFooter.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
        Dim formattedLines As New List(Of String)

        ' Process each line and limit to 40 characters
        For i As Integer = 0 To Math.Min(lines.Length - 1, 4) ' Limit to 5 lines
            If lines(i).Length > 40 Then
                formattedLines.Add(lines(i).Substring(0, 40))
            Else
                formattedLines.Add(lines(i))
            End If
        Next

        ' Update text without triggering TextChanged event
        RemoveHandler txtSPFooter.TextChanged, AddressOf txtSPFooter_TextChanged
        txtSPFooter.Text = String.Join(Environment.NewLine, formattedLines)
        txtSPFooter.SelectionStart = txtSPFooter.Text.Length
        AddHandler txtSPFooter.TextChanged, AddressOf txtSPFooter_TextChanged
    End Sub

    Private Sub txtSPFooter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPFooter.KeyPress
        ' Count current lines
        Dim lines As String() = txtSPFooter.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        ' If enter is pressed and we already have 5 lines, prevent it
        If (e.KeyChar = ChrW(Keys.Enter) OrElse e.KeyChar = vbCr OrElse e.KeyChar = vbLf) AndAlso lines.Length >= 5 Then
            e.Handled = True
        End If
    End Sub
#End Region

#Region "TAG/HEADER"
    Private Sub btnSaveTags_Click(sender As Object, e As EventArgs) Handles btnSaveTags.Click
        ' Validate that at least one field has a value
        If String.IsNullOrWhiteSpace(txtTagSI.Text) AndAlso
       String.IsNullOrWhiteSpace(txtTagRefund.Text) AndAlso
       String.IsNullOrWhiteSpace(txtHeaderSI.Text) AndAlso
       String.IsNullOrWhiteSpace(txtHeaderRefund.Text) Then
            MessageBox.Show("Please enter at least one value.")
            Return
        End If

        ' Set store_id based on combobox selection
        Dim storeId As String = "0"
        If cbSPFooter.SelectedItem IsNot Nothing Then
            storeId = cbSPFooter.SelectedItem.ToString()
        End If

        Using conn As New MySqlConnection(connectionString)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        ' Handle special texts
                        Dim specialTexts As New Dictionary(Of String, String) From {
                        {"Sales Invoice Tag", txtTagSI.Text},
                        {"Refund tag", txtTagRefund.Text},
                        {"Invoice Header", txtHeaderSI.Text},
                        {"Refund Header", txtHeaderRefund.Text}
                    }

                        For Each item In specialTexts
                            Dim upsertSpecialQuery As String = "INSERT INTO 02_pos_receipt_info (type_, value, arrangement, store_id, date_updated) " &
                                                         "VALUES (@type, @textValue, '1', @storeId, @dateUpdated) " &
                                                         "ON DUPLICATE KEY UPDATE value = @textValue, date_updated = @dateUpdated"

                            Using cmd As New MySqlCommand(upsertSpecialQuery, conn, transaction)
                                cmd.Parameters.AddWithValue("@type", item.Key)
                                cmd.Parameters.AddWithValue("@textValue", item.Value)
                                cmd.Parameters.AddWithValue("@storeId", storeId)
                                cmd.Parameters.AddWithValue("@dateUpdated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        transaction.Commit()
                        MessageBox.Show("Tags and headers saved successfully!")
                        ClearTags()
                    Catch ex As Exception
                        transaction.Rollback()
                        MessageBox.Show("Error saving tags and headers: " & ex.Message)
                    End Try
                End Using
            Catch ex As Exception
                MessageBox.Show("Database connection error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadSpecialTags()
        ' Load special texts with store_id = 0 or selected store_id
        Dim storeId As String = "0"
        If cbSPFooter.SelectedItem IsNot Nothing Then
            storeId = cbSPFooter.SelectedItem.ToString()
        End If

        Dim query As String = "SELECT type_, value FROM 02_pos_receipt_info WHERE store_id = @store_id AND arrangement = '1' " &
                         "AND type_ IN ('Sales Invoice Tag', 'Refund tag', 'Invoice Header', 'Refund Header')"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", storeId)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Select Case reader("type_").ToString()
                                Case "Sales Invoice Tag"
                                    txtTagSI.Text = reader("value").ToString()
                                Case "Refund Tag"
                                    txtTagRefund.Text = reader("value").ToString()
                                Case "Invoice Header"
                                    txtHeaderSI.Text = reader("value").ToString()
                                Case "Refund Header"
                                    txtHeaderRefund.Text = reader("value").ToString()
                            End Select
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading special texts: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub ClearTags()
        txtTagSI.Clear()
        txtTagRefund.Clear()
        txtHeaderSI.Clear()
        txtHeaderRefund.Clear()
    End Sub
#End Region

#Region "RECEIPT INFO VIEWER"
    Private Sub LoadStoreIDsForReceipt()
        cbReceiptStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_receipt_info ORDER BY store_id"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbReceiptStoreID.Items.Add(reader("store_id").ToString())
                            cbProductStoreID.Items.Add(reader("store_id").ToString())
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

    Private Sub LoadReceiptInfo()
        If cbReceiptStoreID.SelectedItem Is Nothing Then Return

        ' Clear all textboxes first
        txtReceiptHeader.Clear()
        txtReceiptFooter.Clear()
        txtSpecialFooter.Clear()
        txtSITag.Clear()
        txtRefundtag.Clear()
        txtOHeader.Clear()
        txtORefund.Clear()

        Dim query As String = "SELECT type_, value, arrangement FROM 02_pos_receipt_info " &
                         "WHERE store_id IN ('0', @store_id) " &
                         "ORDER BY store_id DESC, type_, arrangement"

        Using conn As New MySqlConnection(connectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", cbReceiptStoreID.SelectedItem.ToString())
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim headerBuilder As New StringBuilder()
                        Dim footerBuilder As New StringBuilder()
                        Dim specialFooterBuilder As New StringBuilder()

                        Dim populatedFields As New HashSet(Of String)()

                        While reader.Read()
                            Dim type_ As String = reader("type_").ToString()
                            Dim value As String = reader("value").ToString()

                            Select Case type_
                                Case "Header"
                                    headerBuilder.AppendLine(value)
                                Case "Footer"
                                    footerBuilder.AppendLine(value)
                                Case "Special Footer"
                                    specialFooterBuilder.AppendLine(value)
                                Case "Sales Invoice Tag"
                                    If Not populatedFields.Contains("SITag") Then
                                        txtSITag.Text = value
                                        populatedFields.Add("SITag")
                                    End If
                                Case "Refund Tag"
                                    If Not populatedFields.Contains("RefundTag") Then
                                        txtRefundtag.Text = value
                                        populatedFields.Add("RefundTag")
                                    End If
                                Case "Invoice Header"
                                    If Not populatedFields.Contains("InvoiceHeader") Then
                                        txtOHeader.Text = value
                                        populatedFields.Add("InvoiceHeader")
                                    End If
                                Case "Refund Header"
                                    If Not populatedFields.Contains("RefundHeader") Then
                                        txtORefund.Text = value
                                        populatedFields.Add("RefundHeader")
                                    End If
                            End Select
                        End While

                        txtReceiptHeader.Text = headerBuilder.ToString().TrimEnd()
                        txtReceiptFooter.Text = footerBuilder.ToString().TrimEnd()
                        txtSpecialFooter.Text = specialFooterBuilder.ToString().TrimEnd()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading receipt info: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub

    Private Sub cbReceiptStoreID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbReceiptStoreID.SelectedIndexChanged
        LoadReceiptInfo()
    End Sub

    Private Sub ClearReceiptFields()
        txtReceiptHeader.Clear()
        txtReceiptFooter.Clear()
        txtSpecialFooter.Clear()
        txtSITag.Clear()
        txtRefundtag.Clear()
        txtOHeader.Clear()
        txtORefund.Clear()
        cbReceiptStoreID.SelectedIndex = -1
    End Sub

#End Region

#Region "MODIFIER GROUP"
    Private Sub LoadModifierGroups()
        Dim query As String = "SELECT * FROM 02_pos_modifiergroup"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvModifier.DataSource = table
        End Using
    End Sub

    Private selectedModId As Integer = 0

    Private Sub btnModSave_Click(sender As Object, e As EventArgs) Handles btnModSave.Click
        If Not AreFieldsValid(txtModGroup, txtModName, txtModPrice, cbModStoreID) Then
            Return
        End If

        If selectedModId = 0 Then
            Dim nextArrangement As Integer = 1
            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand("SELECT COALESCE(MAX(arrangement), 0) + 1 FROM 02_pos_modifiergroup", conn)
                    conn.Open()
                    nextArrangement = Convert.ToInt32(cmd.ExecuteScalar())
                End Using
            End Using

            Dim insertQuery As String = "INSERT INTO 02_pos_modifiergroup (arrangement, modifier_group, modifier_name, price_, store_id) " &
                                  "VALUES (@arrangement, @modifier_group, @modifier_name, @price, @store_id)"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(insertQuery, conn)
                    cmd.Parameters.AddWithValue("@arrangement", nextArrangement)
                    cmd.Parameters.AddWithValue("@modifier_group", txtModGroup.Text)
                    cmd.Parameters.AddWithValue("@modifier_name", txtModName.Text)
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtModPrice.Text))
                    cmd.Parameters.AddWithValue("@store_id", cbModStoreID.SelectedItem)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Modifier group saved successfully!")
                    Catch ex As Exception
                        MessageBox.Show("Error saving modifier group: " & ex.Message)
                    End Try
                End Using
            End Using
        Else
            Dim updateQuery As String = "UPDATE 02_pos_modifiergroup SET " &
                                  "modifier_group = @modifier_group, " &
                                  "modifier_name = @modifier_name, " &
                                  "price_ = @price, " &
                                  "store_id = @store_id " &
                                  "WHERE id = @id"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@modifier_group", txtModGroup.Text)
                    cmd.Parameters.AddWithValue("@modifier_name", txtModName.Text)
                    cmd.Parameters.AddWithValue("@price", Convert.ToDouble(txtModPrice.Text))
                    cmd.Parameters.AddWithValue("@store_id", cbModStoreID.SelectedItem)
                    cmd.Parameters.AddWithValue("@id", selectedModId)

                    Try
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Modifier group updated successfully!")
                    Catch ex As Exception
                        MessageBox.Show("Error updating modifier group: " & ex.Message)
                    End Try
                End Using
            End Using
        End If

        LoadModifierGroups()
        ClearModifierFields()
        selectedModId = 0
    End Sub

    Private Sub btnModDelete_Click(sender As Object, e As EventArgs) Handles btnModDelete.Click
        If dgvModifier.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvModifier.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this modifier group?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_modifiergroup WHERE id = @id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@id", selectedId)

                    Try
                        LocalConn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Modifier group deleted successfully!")
                    Catch ex As MySqlException
                        MessageBox.Show("An error occurred while deleting the modifier group: " & ex.Message)
                    Finally
                        LocalConn.Close()
                    End Try
                End Using

                LoadModifierGroups()
                ClearModifierFields()
            End If
        Else
            MessageBox.Show("Please select a modifier group to delete.")
        End If
    End Sub

    Private Sub dgvModifier_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvModifier.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvModifier.Rows.Count Then
            Dim row As DataGridViewRow = dgvModifier.Rows(e.RowIndex)
            selectedModId = Convert.ToInt32(row.Cells("id").Value)
            txtModGroup.Text = row.Cells("modifier_group").Value.ToString()
            txtModName.Text = row.Cells("modifier_name").Value.ToString()
            txtModPrice.Text = row.Cells("price_").Value.ToString()
            cbModStoreID.SelectedItem = row.Cells("store_id").Value.ToString()
        End If
    End Sub

    Private Sub ClearModifierFields()
        selectedModId = 0
        txtModGroup.Clear()
        txtModName.Clear()
        txtModPrice.Clear()
        cbModStoreID.SelectedIndex = -1
    End Sub

    Private Sub btnModClear_Click(sender As Object, e As EventArgs) Handles btnModClear.Click
        ClearModifierFields()
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

        Using conn As New MySqlConnection(connectionString)
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

        Using conn As New MySqlConnection(connectionString)
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
    Private Sub LoadProductModifier()
        Dim query As String = "SELECT * FROM 02_pos_productmodifier"
        Using conn As New MySqlConnection(connectionString)
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvProdMod.DataSource = table

        End Using
    End Sub

    Private Sub LoadProductIDsForModifier()
        cbProdModID.Items.Clear()
        Dim query As String = "SELECT product_id FROM 02_pos_products ORDER BY product_id"

        Using conn As New MySqlConnection(connectionString)
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

        Using conn As New MySqlConnection(connectionString)
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

    Private Sub btnSaveProductModifier_Click(sender As Object, e As EventArgs) Handles btnSaveProductModifier.Click
        If Not AreFieldsValid(cbProdModGroup, cbProdModID) Then
            Return
        End If

        If dgvProdMod.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvProdMod.SelectedRows(0).Cells("id").Value)

            Dim isDuplicate As Boolean = False
            Using conn As New MySqlConnection(connectionString)
                Dim checkQuery As String = "SELECT COUNT(*) FROM 02_pos_productmodifier WHERE product_id = @product_id AND modifier_group = @modifier_group AND id <> @id"
                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))
                    cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString())
                    cmd.Parameters.AddWithValue("@id", selectedId)
                    conn.Open()
                    isDuplicate = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using

            If isDuplicate Then
                MessageBox.Show("This product modifier combination already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim updateQuery As String = "UPDATE 02_pos_productmodifier SET product_id = @product_id, modifier_group = @modifier_group WHERE id = @id"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(updateQuery, conn)
                    Try
                        cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))
                        cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString())
                        cmd.Parameters.AddWithValue("@id", selectedId)

                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Product modifier updated successfully!")
                    Catch ex As Exception
                        MessageBox.Show("Error updating product modifier: " & ex.Message)
                    Finally
                        conn.Close()
                    End Try
                End Using
            End Using
        Else
            Dim isDuplicate As Boolean = False
            Using conn As New MySqlConnection(connectionString)
                Dim checkQuery As String = "SELECT COUNT(*) FROM 02_pos_productmodifier WHERE product_id = @product_id AND modifier_group = @modifier_group"
                Using cmd As New MySqlCommand(checkQuery, conn)
                    cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))  ' Fix: Use cbProdModID instead
                    cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString()) ' Fix: Use cbProdModGroup instead
                    conn.Open()
                    isDuplicate = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using
            End Using

            If isDuplicate Then
                MessageBox.Show("This product modifier combination already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim insertQuery As String = "INSERT INTO 02_pos_productmodifier (product_id, modifier_group) VALUES (@product_id, @modifier_group)"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(insertQuery, conn)
                    Try
                        cmd.Parameters.AddWithValue("@product_id", Convert.ToInt32(cbProdModID.SelectedItem))
                        cmd.Parameters.AddWithValue("@modifier_group", cbProdModGroup.SelectedItem.ToString())

                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Product modifier saved successfully!")
                    Catch ex As Exception
                        MessageBox.Show("Error saving product modifier: " & ex.Message)
                    Finally
                        conn.Close()
                    End Try
                End Using
            End Using
        End If

        LoadProductModifier()
        ClearProductModifierFields()
    End Sub

    Private Sub btnDeleteProductModifier_Click(sender As Object, e As EventArgs) Handles btnDeleteProductModifier.Click
        If dgvProdMod.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a record to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this product modifier?",
                                                    "Confirm Delete",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim selectedId As Integer = Convert.ToInt32(dgvProdMod.SelectedRows(0).Cells("id").Value)
            Dim query As String = "DELETE FROM 02_pos_productmodifier WHERE id = @id"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    Try
                        cmd.Parameters.AddWithValue("@id", selectedId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Product modifier deleted successfully!")
                    Catch ex As Exception
                        MessageBox.Show("Error deleting product modifier: " & ex.Message)
                    Finally
                        conn.Close()
                    End Try
                End Using
            End Using

            LoadProductModifier()
            ClearProductModifierFields()
        End If
    End Sub

    Private Sub ClearProductModifierFields()
        cbProdModGroup.SelectedIndex = -1
        cbProdModID.SelectedIndex = -1
    End Sub

    Private Sub btnClearProductModifier_Click(sender As Object, e As EventArgs) Handles btnClearProductModifier.Click
        ClearProductModifierFields()
    End Sub

    Private Sub dgvProdMod_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProdMod.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvProdMod.Rows.Count Then
            Dim row As DataGridViewRow = dgvProdMod.Rows(e.RowIndex)
            ' Fix: Swap these assignments to match the correct fields
            cbProdModID.SelectedItem = row.Cells("product_id").Value.ToString()
            cbProdModGroup.SelectedItem = row.Cells("modifier_group").Value.ToString()
        End If
    End Sub

#End Region
End Class