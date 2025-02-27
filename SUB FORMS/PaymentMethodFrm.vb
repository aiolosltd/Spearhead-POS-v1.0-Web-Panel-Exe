Imports MySql.Data.MySqlClient
Public Class PaymentMethodFrm
    Private Sub PaymentMethodFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreIDsForReceipt()
        LoadPaymentMethod()
    End Sub

    Private Sub LoadStoreIDsForReceipt()
        cbPaymentStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbPaymentStoreID.Items.Add(reader("store_id").ToString())
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

#Region "Payment Method"
    Private IsEditMode As Boolean = False
    Private SelectedPaymentId As Integer = 0

    Private Sub LoadPaymentMethod()
        Dim query As String = "SELECT * FROM 02_pos_payment_method"
        Using conn As New MySqlConnection(ConnectionString)
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

        If Not IsEditMode Then
            If IsDuplicate("02_pos_payment_method", "payment_type", txtPaymentType.Text) Then
                MessageBox.Show("Payment type already exists. Please enter different payment type.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdatePayment()
            Else
                InsertPayment()
            End If

            LoadPaymentMethod()
            ClearPaymentFields()
            IsEditMode = False
            SelectedPaymentId = 0
            btnSavePayment.Text = "Save Payment"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertPayment()
        Dim query As String = "INSERT INTO 02_pos_payment_method (payment_type, status, store_id, created_at) " &
                            "VALUES (@payment_type, @status, @store_id, NOW())"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetPaymentParameters(cmd)
                cmd.Parameters.AddWithValue("@status", 1)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdatePayment()
        Dim query As String = "UPDATE 02_pos_payment_method SET " &
                           "payment_type = @payment_type, " &
                           "store_id = @store_id " &
                           "WHERE id = @id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                SetPaymentParameters(cmd)
                cmd.Parameters.AddWithValue("@id", SelectedPaymentId)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub SetPaymentParameters(cmd As MySqlCommand)
        cmd.Parameters.AddWithValue("@payment_type", txtPaymentType.Text.Trim())
        cmd.Parameters.AddWithValue("@store_id", cbPaymentStoreID.SelectedItem.ToString())
    End Sub

    Private Sub btnDeletePayment_Click(sender As Object, e As EventArgs) Handles btnDeletePayment.Click
        If SelectedPaymentId = 0 Then
            MessageBox.Show("Please select a payment method to delete.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Try
                Dim query As String = "DELETE FROM 02_pos_payment_method WHERE id = @Id"
                Using conn As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@Id", SelectedPaymentId)
                        conn.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadPaymentMethod()
                ClearPaymentFields()
                IsEditMode = False
                SelectedPaymentId = 0
                btnSavePayment.Text = "Save Payment"

            Catch ex As Exception
                MessageBox.Show("Error deleting payment method: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub dgvPaymentMethod_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentMethod.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvPaymentMethod.Rows.Count Then
            Dim row As DataGridViewRow = dgvPaymentMethod.Rows(e.RowIndex)
            SelectedPaymentId = Convert.ToInt32(row.Cells("id").Value)
            txtPaymentType.Text = row.Cells("payment_type").Value.ToString()
            cbPaymentStoreID.SelectedItem = row.Cells("store_id").Value.ToString()

            IsEditMode = True
            btnSavePayment.Text = "Update Payment"
        End If
    End Sub

    Private Sub btnClearPayment_Click(sender As Object, e As EventArgs) Handles btnClearPayment.Click
        ClearPaymentFields()
        IsEditMode = False
        SelectedPaymentId = 0
        btnSavePayment.Text = "Save Payment"
    End Sub

    Private Sub ClearPaymentFields()
        txtPaymentType.Clear()
        cbPaymentStoreID.SelectedIndex = -1
    End Sub
#End Region
End Class