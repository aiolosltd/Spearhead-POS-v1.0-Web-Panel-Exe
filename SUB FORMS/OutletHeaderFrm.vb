Imports MySql.Data.MySqlClient
Public Class OutletHeaderFrm
    Private Sub OutletHeaderFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadClientIDs()
    End Sub
    Private Sub LoadClientIDs()
        cbClientID.Items.Clear()
        Dim query As String = "SELECT client_id FROM 02_pos_activation ORDER BY client_id"

        Using conn As New MySqlConnection(ConnectionString)
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

    Private Function IsClientIDUsed(clientID As String, currentStoreID As String) As Boolean
        Using conn As New MySqlConnection(ConnectionString)
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

        Using conn As New MySqlConnection(ConnectionString)
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

    Private Sub btnClearOutlet_Click(sender As Object, e As EventArgs) Handles btnClearoutlet.Click
        ClearOutletFields()
    End Sub

    Private Function GenerateNewStoreID() As String
        Dim newStoreID As Integer = 1
        Dim query As String = "SELECT MAX(CAST(store_id AS UNSIGNED)) FROM 02_pos_outlets"

        Using conn As New MySqlConnection(ConnectionString)
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


End Class