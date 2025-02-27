Imports MySql.Data.MySqlClient
Imports System.Text
Public Class CouponFrm
    Private Sub CouponFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreID()
        LoadCoupons()
    End Sub
    Private Sub LoadStoreID()
        cbCouponStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbCouponStoreID.Items.Add(reader("store_id").ToString())
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

    Private IsEditMode As Boolean = False
    Private SelectedCouponId As Integer = 0

    Private Sub LoadCoupons()
        Dim query As String = "SELECT * FROM 02_pos_coupon"
        Using conn = ConnectionModule.GetConnection()
            Dim adapter As New MySqlDataAdapter(query, conn)
            Dim table As New DataTable()
            adapter.Fill(table)
            dgvCoupons.DataSource = table
        End Using
    End Sub

    Private Sub btnSaveCoupon_Click(sender As Object, e As EventArgs) Handles btnSaveCoupon.Click
        'If Not AreFieldsValid(txtCouponName, txtCouponDesc, txtDiscValue, txtReferenceValue, cbCouponType, txtBundleBase, txtBundlePromo, cbCouponStoreID) Then
        '    Return
        'End If

        If Not IsEditMode Then
            If IsDuplicate("02_pos_coupon", "Coupon_Name", txtCouponName.Text) Then
                MessageBox.Show("The coupon name already exists. Please use a different name.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdateCoupon()
            Else
                InsertCoupon()
            End If

            LoadCoupons()
            ClearCouponFields()
            IsEditMode = False
            SelectedCouponId = 0
            btnSaveCoupon.Text = "Save Coupon"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertCoupon()
        Dim query As String = "INSERT INTO 02_pos_coupon (Coupon_Name, `Desc`, Disc_Value, Reference, Type, " &
                         "Bundlebase, BBValue, BundlePromo, BPValue, Effective, Expiry, " &
                         "Date_Registered, Status, store_id, display_type) " &
                         "VALUES (@Coupon_Name, @Desc, @Disc_Value, @Reference, @Type, " &
                         "@Bundlebase, @BBValue, @BundlePromo, @BPValue, @Effective, @Expiry, " &
                         "@Date_Registered, @Status, @store_id, @display_type)"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                SetCouponParameters(cmd)
                cmd.Parameters.AddWithValue("@Date_Registered", DateTime.Now.Date)
                cmd.Parameters.AddWithValue("@Status", 1)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateCoupon()
        Dim query As String = "UPDATE 02_pos_coupon SET " &
                         "Coupon_Name=@Coupon_Name, " &
                         "`Desc`=@Desc, " &
                         "Disc_Value=@Disc_Value, " &
                         "Reference=@Reference, " &
                         "`Type`=@Type, " &
                         "Bundlebase=@Bundlebase, " &
                         "BBValue=@BBValue, " &
                         "BundlePromo=@BundlePromo, " &
                         "BPValue=@BPValue, " &
                         "Effective=@Effective, " &
                         "Expiry=@Expiry, " &
                         "store_id=@store_id, " &
                         "display_type=@display_type " &
                         "WHERE id=@id"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                SetCouponParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedCouponId)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetCouponParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@Coupon_Name", txtCouponName.Text.Trim())
        cmd.Parameters.AddWithValue("@Desc", txtCouponDesc.Text.Trim())
        cmd.Parameters.AddWithValue("@Disc_Value", Decimal.Parse(txtDiscValue.Text))
        cmd.Parameters.AddWithValue("@Reference", txtReferenceValue.Text.Trim())
        cmd.Parameters.AddWithValue("@Type", cbCouponType.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@Bundlebase", txtBundleBase.Text.Trim())
        cmd.Parameters.AddWithValue("@BBValue", If(Decimal.TryParse(txtBBValue.Text, Nothing), Decimal.Parse(txtBBValue.Text), DBNull.Value))
        cmd.Parameters.AddWithValue("@BundlePromo", txtBundlePromo.Text.Trim())
        cmd.Parameters.AddWithValue("@BPValue", If(Decimal.TryParse(txtBPValue.Text, Nothing), Decimal.Parse(txtBPValue.Text), DBNull.Value))
        cmd.Parameters.AddWithValue("@Effective", dtpEffectiveDate.Value.Date)
        cmd.Parameters.AddWithValue("@Expiry", dtpExpiryDate.Value.Date)
        cmd.Parameters.AddWithValue("@store_id", cbCouponStoreID.SelectedItem.ToString())
        cmd.Parameters.AddWithValue("@display_type", cbDisplayType.SelectedItem.ToString())
    End Sub
    Private Sub btnDeleteCoupon_Click(sender As Object, e As EventArgs) Handles btnDeleteCoupon.Click
        If SelectedCouponId = 0 Then
            MessageBox.Show("Please select a coupon to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this coupon?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_coupon WHERE id=@id"
                Using connection = ConnectionModule.GetConnection()
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@id", SelectedCouponId)
                        connection.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadCoupons()
                ClearCouponFields()
                IsEditMode = False
                SelectedCouponId = 0
                btnSaveCoupon.Text = "Save Coupon"

            Catch ex As Exception
                MessageBox.Show("Error deleting coupon: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvCoupons_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCoupons.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvCoupons.Rows.Count Then
            Dim selectedRow As DataGridViewRow = dgvCoupons.Rows(e.RowIndex)
            SelectedCouponId = Convert.ToInt32(selectedRow.Cells("id").Value)

            txtCouponName.Text = selectedRow.Cells("Coupon_Name").Value.ToString()
            txtCouponDesc.Text = selectedRow.Cells("Desc").Value.ToString()
            txtDiscValue.Text = selectedRow.Cells("Disc_Value").Value.ToString()
            txtReferenceValue.Text = If(selectedRow.Cells("Reference").Value IsNot DBNull.Value,
                                      selectedRow.Cells("Reference").Value.ToString(),
                                      "")
            cbCouponType.SelectedItem = selectedRow.Cells("Type").Value.ToString()
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

            dtpEffectiveDate.Value = Convert.ToDateTime(selectedRow.Cells("Effective").Value)
            dtpExpiryDate.Value = Convert.ToDateTime(selectedRow.Cells("Expiry").Value)

            cbCouponStoreID.SelectedItem = If(selectedRow.Cells("store_id").Value IsNot DBNull.Value,
                                            selectedRow.Cells("store_id").Value.ToString(),
                                            Nothing)

            IsEditMode = True
            btnSaveCoupon.Text = "Update Coupon"
            txtCouponName.Focus()
        End If
    End Sub

    Private Sub btnClearCoupon_Click(sender As Object, e As EventArgs) Handles btnClearCoupon.Click
        ClearCouponFields()
        IsEditMode = False
        SelectedCouponId = 0
        btnSaveCoupon.Text = "Save Coupon"
    End Sub
    Private Sub ClearCouponFields()
        txtCouponName.Clear()
        txtCouponDesc.Clear()
        txtDiscValue.Clear()
        txtReferenceValue.Clear()
        cbCouponType.SelectedIndex = -1
        txtBundleBase.Clear()
        txtBBValue.Clear()
        txtBundlePromo.Clear()
        txtBPValue.Clear()
        dtpEffectiveDate.Value = DateTime.Now
        dtpExpiryDate.Value = DateTime.Now
        cbCouponStoreID.SelectedIndex = -1
        cbDisplayType.SelectedIndex = -1  ' Add this line
    End Sub
End Class