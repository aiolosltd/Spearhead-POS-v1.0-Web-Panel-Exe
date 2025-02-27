Imports MySql.Data.MySqlClient
Imports System.Text
Public Class ReceiptSettings
    Private Sub ProviderFooterFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreIDs()
    End Sub


    Private Sub btnClearProvider_Click(sender As Object, e As EventArgs) Handles btnClearProvider.Click
        ClearProviderFields()
        ClearTags()
        txtSPFooter.Clear()
    End Sub

#Region "Provider "
    Private Sub LoadProviderInfo()
        Dim query As String = "SELECT * FROM 02_pos_provider_info ORDER BY arrangement"
        Using conn As New MySqlConnection(ConnectionString)
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

        Using conn As New MySqlConnection(ConnectionString)
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
#End Region

#Region "Special Footer"
    Private Sub LoadStoreIDs()
        cbSPFooter.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
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

        Using conn As New MySqlConnection(ConnectionString)
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

        Dim lines As String() = txtSPFooter.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)

        If lines.Length > 5 Then
            MessageBox.Show("Maximum 5 lines allowed.")
            Return
        End If

        Using conn As New MySqlConnection(ConnectionString)
            Try
                conn.Open()
                Using transaction As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim updateBlankQuery As String = "UPDATE 02_pos_receipt_info SET value = '' " &
                                                   "WHERE store_id = @storeId AND type_ = 'Special Footer'"

                        Using cmdBlank As New MySqlCommand(updateBlankQuery, conn, transaction)
                            cmdBlank.Parameters.AddWithValue("@storeId", cbSPFooter.SelectedItem.ToString())
                            cmdBlank.ExecuteNonQuery()
                        End Using

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

        For i As Integer = 0 To Math.Min(lines.Length - 1, 4)
            If lines(i).Length > 40 Then
                formattedLines.Add(lines(i).Substring(0, 40))
            Else
                formattedLines.Add(lines(i))
            End If
        Next

        RemoveHandler txtSPFooter.TextChanged, AddressOf txtSPFooter_TextChanged
        txtSPFooter.Text = String.Join(Environment.NewLine, formattedLines)
        txtSPFooter.SelectionStart = txtSPFooter.Text.Length
        AddHandler txtSPFooter.TextChanged, AddressOf txtSPFooter_TextChanged
    End Sub

    Private Sub txtSPFooter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPFooter.KeyPress
        Dim lines As String() = txtSPFooter.Text.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        If (e.KeyChar = ChrW(Keys.Enter) OrElse e.KeyChar = vbCr OrElse e.KeyChar = vbLf) AndAlso lines.Length >= 5 Then
            e.Handled = True
        End If
    End Sub


#End Region

#Region "Tags"
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

        Using conn As New MySqlConnection(ConnectionString)
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

        Using conn As New MySqlConnection(ConnectionString)
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
End Class