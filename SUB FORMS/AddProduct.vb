Imports MySql.Data.MySqlClient
Imports System.IO

Public Class AddProduct
    Private ReadOnly IsEditMode As Boolean = False
    Private ReadOnly ProductId As Integer = 0
    Private imagePath As String = ""

    Public Sub New()
        InitializeComponent()
        IsEditMode = False
        btnSave.Text = "Save Product"
    End Sub

    Public Sub New(productId As Integer)
        InitializeComponent()
        IsEditMode = True
        Me.ProductId = productId
        btnSave.Text = "Update Product"
    End Sub

    Private Sub AddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadProductCategory()
            LoadStoreID()

            If IsEditMode Then
                LoadProductDetails()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStoreID()
        cbProductStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbProductStoreID.Items.Add(reader("store_id").ToString())
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
        cbProductCategory.Items.Clear()
        Dim query As String = "SELECT category_name FROM 02_pos_category"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbProductCategory.Items.Add(reader("category_name").ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading categories: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadProductDetails()
        Try
            Dim query As String = "SELECT * FROM 02_pos_products WHERE id = @id"
            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@id", ProductId)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtPCode.Text = reader("product_code").ToString()
                            txtProductName.Text = reader("name_").ToString()
                            cbProductCategory.SelectedItem = reader("category_").ToString()
                            txtProductDesc.Text = reader("desc_").ToString()
                            txtProductPrice.Text = reader("reg_price").ToString()
                            txtProductBarCode.Text = reader("barcode_").ToString()
                            txtProductQR.Text = reader("QRCode").ToString()
                            cbProductAddonType.SelectedItem = reader("addon_type").ToString()
                            cbProductPartners.SelectedItem = reader("Partners_").ToString()
                            txtProductUnitCost.Text = reader("unit_cost").ToString()
                            cbProductStoreID.SelectedItem = reader("store_id").ToString()

                            ' Load tax value
                            Dim taxValue = If(IsDBNull(reader("tax_")), "", reader("tax_").ToString())
                            cbTaxValue.SelectedItem = taxValue

                            Dim productType As Integer = Convert.ToInt32(reader("product_type"))
                            cbProdType.SelectedItem = If(productType = 1, "Selling", "Kitchen")

                            ' Load other values
                            cbKitchen.SelectedItem = reader("kitchen_").ToString()
                            cbBar.SelectedItem = reader("bar_").ToString()
                            cbStation1.SelectedItem = reader("station_1").ToString()
                            cbStation2.SelectedItem = reader("station_2").ToString()

                            If Not IsDBNull(reader("Image_")) Then
                                Dim imageData As String = reader("Image_").ToString()
                                If Not String.IsNullOrEmpty(imageData) Then
                                    Dim imageBytes As Byte() = Convert.FromBase64String(imageData)
                                    Using ms As New MemoryStream(imageBytes)
                                        PictureBoxProduct.Image = Image.FromStream(ms)
                                    End Using
                                End If
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product details: " & ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not ValidateInputs() Then Return

        Try
            If IsEditMode Then
                UpdateProduct()
            Else
                InsertProduct()
            End If

            DialogResult = DialogResult.OK
            Close()
        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message)
        End Try
    End Sub

    Private Sub InsertProduct()
        Dim lastProductId As Integer = GetLastProductId()
        Dim newProductId As Integer = lastProductId + 1

        Dim query As String = "INSERT INTO 02_pos_products (" &
        "product_id, product_code, name_, category_, desc_, image_, reg_price, " &
        "barcode_, QRCode, addon_type, partners_, product_type, arrangement_, " &
        "unit_cost, origin_, store_id, kitchen_, bar_, station_1, station_2, tax_, status_) " &
        "VALUES (" &
        "@product_id, @product_code, @name, @category, @desc, @image, @reg_price, " &
        "@barcode, @qrcode, @addon_type, @partners, @product_type, @arrangement, " &
        "@unit_cost, @origin, @store_id, @kitchen_, @bar_, @station_1, @station_2, @tax_, 1)"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetProductParameters(cmd, newProductId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateProduct()
        Dim query As String = "UPDATE 02_pos_products SET " &
            "product_code = @product_code, name_ = @name, category_ = @category, " &
            "desc_ = @desc, image_ = @image, reg_price = @reg_price, " &
            "barcode_ = @barcode, QRCode = @qrcode, addon_type = @addon_type, " &
            "partners_ = @partners, product_type = @product_type, " &
            "unit_cost = @unit_cost, store_id = @store_id, " &
            "kitchen_ = @kitchen_, bar_ = @bar_, " &
            "station_1 = @station_1, station_2 = @station_2, " &
            "tax_ = @tax_ " &
            "WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetProductParameters(cmd, Nothing)
                cmd.Parameters.AddWithValue("@id", ProductId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetProductParameters(cmd As MySqlCommand, Optional newProductId As Integer? = Nothing)
        If newProductId.HasValue Then
            cmd.Parameters.AddWithValue("@product_id", newProductId.Value)
        End If

        Dim productTypeValue As Integer = If(cbProdType.SelectedItem.ToString() = "Selling", 1, 0)

        cmd.Parameters.AddWithValue("@product_code", If(String.IsNullOrEmpty(txtPCode.Text), DBNull.Value, txtPCode.Text.Trim()))
        cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim())
        cmd.Parameters.AddWithValue("@category", If(cbProductCategory.SelectedItem Is Nothing, DBNull.Value, cbProductCategory.SelectedItem))
        cmd.Parameters.AddWithValue("@desc", If(String.IsNullOrEmpty(txtProductDesc.Text), DBNull.Value, txtProductDesc.Text.Trim()))
        cmd.Parameters.AddWithValue("@image", If(String.IsNullOrEmpty(imagePath), DBNull.Value, Convert.ToBase64String(File.ReadAllBytes(imagePath))))
        cmd.Parameters.AddWithValue("@reg_price", If(String.IsNullOrEmpty(txtProductPrice.Text), DBNull.Value, Decimal.Parse(txtProductPrice.Text)))
        cmd.Parameters.AddWithValue("@barcode", If(String.IsNullOrEmpty(txtProductBarCode.Text), DBNull.Value, txtProductBarCode.Text.Trim()))
        cmd.Parameters.AddWithValue("@qrcode", If(String.IsNullOrEmpty(txtProductQR.Text), DBNull.Value, txtProductQR.Text.Trim()))
        cmd.Parameters.AddWithValue("@addon_type", If(cbProductAddonType.SelectedItem Is Nothing, "Regular", cbProductAddonType.SelectedItem))
        cmd.Parameters.AddWithValue("@partners", If(cbProductPartners.SelectedItem Is Nothing, "Standard", cbProductPartners.SelectedItem))
        cmd.Parameters.AddWithValue("@product_type", productTypeValue)
        cmd.Parameters.AddWithValue("@arrangement", "1")
        cmd.Parameters.AddWithValue("@unit_cost", If(String.IsNullOrEmpty(txtProductUnitCost.Text), DBNull.Value, Decimal.Parse(txtProductUnitCost.Text)))
        cmd.Parameters.AddWithValue("@origin", "Server")
        cmd.Parameters.AddWithValue("@store_id", If(cbProductStoreID.SelectedItem Is Nothing, DBNull.Value, cbProductStoreID.SelectedItem))
        cmd.Parameters.AddWithValue("@kitchen_", If(cbKitchen.SelectedItem Is Nothing, 0, Convert.ToInt32(cbKitchen.SelectedItem)))
        cmd.Parameters.AddWithValue("@bar_", If(cbBar.SelectedItem Is Nothing, 0, Convert.ToInt32(cbBar.SelectedItem)))
        cmd.Parameters.AddWithValue("@station_1", If(cbStation1.SelectedItem Is Nothing, 0, Convert.ToInt32(cbStation1.SelectedItem)))
        cmd.Parameters.AddWithValue("@station_2", If(cbStation2.SelectedItem Is Nothing, 0, Convert.ToInt32(cbStation2.SelectedItem)))
        cmd.Parameters.AddWithValue("@tax_", If(cbTaxValue.SelectedItem Is Nothing, DBNull.Value,
                                          If(Decimal.TryParse(cbTaxValue.SelectedItem.ToString(), Nothing),
                                             Decimal.Parse(cbTaxValue.SelectedItem.ToString()),
                                             DBNull.Value)))
    End Sub

    Private Function GetLastProductId() As Integer
        Dim lastId As Integer = 0
        Using conn As New MySqlConnection(ConnectionString)
            Dim query As String = "SELECT COALESCE(MAX(product_id), 0) FROM 02_pos_products"
            Using cmd As New MySqlCommand(query, conn)
                conn.Open()
                lastId = Convert.ToInt32(cmd.ExecuteScalar())
            End Using
        End Using
        Return lastId
    End Function

    Private Function ValidateInputs() As Boolean
        If Not AreFieldsValid(txtPCode, txtProductName, txtProductDesc, txtProductPrice,
                            txtProductBarCode, txtProductUnitCost, cbProductCategory,
                            cbProductAddonType, cbProductPartners, cbProdType,
                            cbProductStoreID, cbKitchen, cbBar, cbStation1, cbStation2,
                            cbTaxValue) Then
            Return False
        End If

        If Not IsEditMode Then
            If IsDuplicate("02_pos_products", "product_code", txtPCode.Text.Trim()) Then
                MessageBox.Show("The product code already exists. Please choose a different product code.")
                Return False
            End If

            If IsDuplicate("02_pos_products", "name_", txtProductName.Text.Trim()) Then
                MessageBox.Show("The product name already exists. Please use a different product name.")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnProductImage_Click(sender As Object, e As EventArgs) Handles btnProductImage.Click
        Using openFileDialog As New OpenFileDialog()
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"
            If openFileDialog.ShowDialog() = DialogResult.OK Then
                imagePath = openFileDialog.FileName
                PictureBoxProduct.Image = Image.FromFile(imagePath)
            End If
        End Using
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class