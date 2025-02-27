Imports MySql.Data.MySqlClient
Imports System.Text
Public Class ReceiptDetailsFrm
    Private Sub ReceiptDetailsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreIDsForReceipt()
    End Sub

    Private Sub LoadStoreIDsForReceipt()
        cbReceiptStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbReceiptStoreID.Items.Add(reader("store_id").ToString())
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

        Using conn As New MySqlConnection(ConnectionString)
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
                            Dim value As String = reader("value").ToString().Trim() ' Trim spaces from DB values

                            Select Case type_
                                Case "Header"
                                    headerBuilder.Append(value).AppendLine()
                                Case "Footer"
                                    footerBuilder.Append(value).AppendLine()
                                Case "Special Footer"
                                    specialFooterBuilder.Append(value).AppendLine()
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

                        ' Remove trailing newline and set the text
                        txtReceiptHeader.Text = headerBuilder.ToString().Trim()
                        txtReceiptFooter.Text = footerBuilder.ToString().Trim()
                        txtSpecialFooter.Text = specialFooterBuilder.ToString().Trim()
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error loading receipt info: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End Using
        End Using
    End Sub


    'Private Sub LoadReceiptInfo()
    '    If cbReceiptStoreID.SelectedItem Is Nothing Then Return

    '    ' Clear all textboxes first
    '    txtReceiptHeader.Clear()
    '    txtReceiptFooter.Clear()
    '    txtSpecialFooter.Clear()
    '    txtSITag.Clear()
    '    txtRefundtag.Clear()
    '    txtOHeader.Clear()
    '    txtORefund.Clear()

    '    Dim query As String = "SELECT type_, value, arrangement FROM 02_pos_receipt_info " &
    '                     "WHERE store_id IN ('0', @store_id) " &
    '                     "ORDER BY store_id DESC, type_, arrangement"

    '    Using conn As New MySqlConnection(ConnectionString)
    '        Using cmd As New MySqlCommand(query, conn)
    '            cmd.Parameters.AddWithValue("@store_id", cbReceiptStoreID.SelectedItem.ToString())
    '            Try
    '                conn.Open()
    '                Using reader As MySqlDataReader = cmd.ExecuteReader()
    '                    Dim headerBuilder As New StringBuilder()
    '                    Dim footerBuilder As New StringBuilder()
    '                    Dim specialFooterBuilder As New StringBuilder()

    '                    Dim populatedFields As New HashSet(Of String)()

    '                    While reader.Read()
    '                        Dim type_ As String = reader("type_").ToString()
    '                        Dim value As String = reader("value").ToString()

    '                        Select Case type_
    '                            Case "Header"
    '                                headerBuilder.AppendLine(value)
    '                            Case "Footer"
    '                                footerBuilder.AppendLine(value)
    '                            Case "Special Footer"
    '                                specialFooterBuilder.AppendLine(value)
    '                            Case "Sales Invoice Tag"
    '                                If Not populatedFields.Contains("SITag") Then
    '                                    txtSITag.Text = value
    '                                    populatedFields.Add("SITag")
    '                                End If
    '                            Case "Refund Tag"
    '                                If Not populatedFields.Contains("RefundTag") Then
    '                                    txtRefundtag.Text = value
    '                                    populatedFields.Add("RefundTag")
    '                                End If
    '                            Case "Invoice Header"
    '                                If Not populatedFields.Contains("InvoiceHeader") Then
    '                                    txtOHeader.Text = value
    '                                    populatedFields.Add("InvoiceHeader")
    '                                End If
    '                            Case "Refund Header"
    '                                If Not populatedFields.Contains("RefundHeader") Then
    '                                    txtORefund.Text = value
    '                                    populatedFields.Add("RefundHeader")
    '                                End If
    '                        End Select
    '                    End While

    '                    txtReceiptHeader.Text = headerBuilder.ToString().TrimEnd()
    '                    txtReceiptFooter.Text = footerBuilder.ToString().TrimEnd()
    '                    txtSpecialFooter.Text = specialFooterBuilder.ToString().TrimEnd()
    '                End Using
    '            Catch ex As Exception
    '                MessageBox.Show("Error loading receipt info: " & ex.Message)
    '            Finally
    '                conn.Close()
    '            End Try
    '        End Using
    '    End Using
    'End Sub

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

End Class
