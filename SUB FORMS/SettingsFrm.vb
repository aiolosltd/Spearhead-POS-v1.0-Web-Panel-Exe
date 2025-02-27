Imports MySql.Data.MySqlClient
Public Class SettingsFrm
    Private Sub SettingsFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreID()
    End Sub

    Private Sub LoadStoreID()
        cbStoreID.Items.Clear()
        Dim query As String = "SELECT DISTINCT store_id FROM 02_pos_outlets ORDER BY store_id"

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            cbStoreID.Items.Add(reader("store_id").ToString())
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

#Region "SETTINGS"
    Private Sub LoadSettings()
        If cbStoreID.SelectedItem Is Nothing Then
            Return
        End If

        Dim query As String = "SELECT * FROM 02_pos_other_settings WHERE store_id = @store_id"
        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@store_id", cbStoreID.SelectedItem)

                Try
                    Dim adapter As New MySqlDataAdapter(cmd)
                    Dim table As New DataTable()
                    adapter.Fill(table)

                    If table.Rows.Count > 0 Then
                        Dim row As DataRow = table.Rows(0)
                        ' Load MCode settings
                        txtSalesInvoiceFormat.Text = row("Sales_Invoice_format").ToString()
                        SetRadioButtons(Convert.ToInt32(row("MCode_Void")), rbMcodeVoidYes, rbMcodeVoidNo)
                        SetRadioButtons(Convert.ToInt32(row("MCode_Refund")), rbMCodeRefundYes, rbMCodeRefundNo)
                        SetRadioButtons(Convert.ToInt32(row("MCode_Settings")), rbMCodeSettingsYes, rbMCodeSettingsNo)
                        SetRadioButtons(Convert.ToInt32(row("MCode_Zread")), rbMCodeZreadYes, rbMCodeZreadNo)
                        SetRadioButtons(Convert.ToInt32(row("MCode_CouponPromos")), rbMCodeCouponPromosYes, rbMCodeCouponPromosNo)
                        SetRadioButtons(Convert.ToInt32(row("MCode_Reprint")), rbmCodeReprintYes, rbmCodeReprintNo)
                        txtMEMCValue.Text = row("MEMC_Value").ToString()
                        SetRadioButtons(Convert.ToInt32(row("MEMC_Mode")), rbMEMCYes, rbMEMCno)

                        SetRadioButtons(Convert.ToInt32(row("preview_all")), rbPreviewAllYes, rbPreviewAllNo)
                        SetRadioButtons(Convert.ToInt32(row("print_receipt")), rbPrintReceiptYes, rbPrintReceiptNo)
                        SetRadioButtons(Convert.ToInt32(row("print_x_reading")), rbPrintXreadingYes, rbPrintXreadingNo)
                        SetRadioButtons(Convert.ToInt32(row("print_z_reading")), rbPrintZreadYes, rbPrintZreadNo)
                        SetRadioButtons(Convert.ToInt32(row("print_sales_report")), rbPrintSalesYes, rbPrintSalesNo)
                        SetRadioButtons(Convert.ToInt32(row("print_inventory")), rbPrintInventoryYes, rbPrintInventoryNo)
                        SetRadioButtons(Convert.ToInt32(row("print_reprint")), rbPrintReprintYes, rbPrintReprintNo)
                        SetRadioButtons(Convert.ToInt32(row("print_log_data")), rbPrintLogDataYes, rbPrintLogDataNo)
                        SetRadioButtons(Convert.ToInt32(row("training_mode")), rbTrainingModeYes, rbTrainingModeNo)
                    Else
                        ClearSettings()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error loading settings: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub SetRadioButtons(value As Integer, rbYes As RadioButton, rbNo As RadioButton)
        If value = 1 Then
            rbYes.Checked = True
        Else
            rbNo.Checked = True
        End If
    End Sub

    Private Sub ClearSettings()
        txtSalesInvoiceFormat.Clear()
        txtMEMCValue.Clear()

        ' Reset all radio buttons to default values (No)
        rbMcodeVoidNo.Checked = True
        rbMCodeRefundNo.Checked = True
        rbMCodeSettingsNo.Checked = True
        rbMCodeZreadNo.Checked = True
        rbMCodeCouponPromosNo.Checked = True
        rbmCodeReprintNo.Checked = True
        rbMEMCno.Checked = True
        rbPreviewAllNo.Checked = True
        rbPrintReceiptNo.Checked = True
        rbPrintXreadingNo.Checked = True
        rbPrintZreadNo.Checked = True
        rbPrintSalesNo.Checked = True
        rbPrintInventoryNo.Checked = True
        rbPrintReprintNo.Checked = True
        rbPrintLogDataNo.Checked = True
        rbTrainingModeNo.Checked = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbStoreID.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a store ID.")
            Return
        End If

        ' Get MCode settings values
        Dim mCodeVoid As Integer = If(rbMcodeVoidYes.Checked, 1, 0)
        Dim mCodeRefund As Integer = If(rbMCodeRefundYes.Checked, 1, 0)
        Dim mCodeSettings As Integer = If(rbMCodeSettingsYes.Checked, 1, 0)
        Dim mCodeZread As Integer = If(rbMCodeZreadYes.Checked, 1, 0)
        Dim mCodeCouponPromos As Integer = If(rbMCodeCouponPromosYes.Checked, 1, 0)
        Dim mCodeReprint As Integer = If(rbmCodeReprintYes.Checked, 1, 0)
        Dim memcMode As Integer = If(rbMEMCYes.Checked, 1, 0)

        ' Get Print settings values
        Dim previewAll As Integer = If(rbPreviewAllYes.Checked, 1, 0)
        Dim printReceipt As Integer = If(rbPrintReceiptYes.Checked, 1, 0)
        Dim printXreading As Integer = If(rbPrintXreadingYes.Checked, 1, 0)
        Dim printZread As Integer = If(rbPrintZreadYes.Checked, 1, 0)
        Dim printSales As Integer = If(rbPrintSalesYes.Checked, 1, 0)
        Dim printInventory As Integer = If(rbPrintInventoryYes.Checked, 1, 0)
        Dim printReprint As Integer = If(rbPrintReprintYes.Checked, 1, 0)
        Dim printLogData As Integer = If(rbPrintLogDataYes.Checked, 1, 0)
        Dim trainingMode As Integer = If(rbTrainingModeYes.Checked, 1, 0)

        ' Check if settings exist for this store_id
        Dim exists As Boolean = False
        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand("SELECT COUNT(*) FROM 02_pos_other_settings WHERE store_id = @store_id", conn)
                cmd.Parameters.AddWithValue("@store_id", cbStoreID.SelectedItem)
                conn.Open()
                exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
            End Using
        End Using

        ' Prepare query based on existence
        Dim query As String
        If exists Then
            query = "UPDATE 02_pos_other_settings SET " &
                   "Sales_Invoice_format = @Sales_Invoice_format, " &
                   "MCode_Void = @MCode_Void, " &
                   "MCode_Refund = @MCode_Refund, " &
                   "MCode_Settings = @MCode_Settings, " &
                   "MCode_Zread = @MCode_Zread, " &
                   "MCode_CouponPromos = @MCode_CouponPromos, " &
                   "MCode_Reprint = @MCode_Reprint, " &
                   "MEMC_Value = @MEMC_Value, " &
                   "MEMC_Mode = @MEMC_Mode, " &
                   "preview_all = @preview_all, " &
                   "print_receipt = @print_receipt, " &
                   "print_x_reading = @print_x_reading, " &
                   "print_z_reading = @print_z_reading, " &
                   "print_sales_report = @print_sales_report, " &
                   "print_inventory = @print_inventory, " &
                   "print_reprint = @print_reprint, " &
                   "print_log_data = @print_log_data, " &
                   "training_mode = @training_mode " &
                   "WHERE store_id = @store_id"
        Else
            query = "INSERT INTO 02_pos_other_settings (" &
                   "store_id, Sales_Invoice_format, MCode_Void, MCode_Refund, MCode_Settings, " &
                   "MCode_Zread, MCode_CouponPromos, MCode_Reprint, MEMC_Value, MEMC_Mode, " &
                   "preview_all, print_receipt, print_x_reading, print_z_reading, " &
                   "print_sales_report, print_inventory, print_reprint, print_log_data, training_mode) " &
                   "VALUES (" &
                   "@store_id, @Sales_Invoice_format, @MCode_Void, @MCode_Refund, @MCode_Settings, " &
                   "@MCode_Zread, @MCode_CouponPromos, @MCode_Reprint, @MEMC_Value, @MEMC_Mode, " &
                   "@preview_all, @print_receipt, @print_x_reading, @print_z_reading, " &
                   "@print_sales_report, @print_inventory, @print_reprint, @print_log_data, @training_mode)"
        End If

        Using conn As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, conn)
                Try
                    cmd.Parameters.AddWithValue("@store_id", cbStoreID.SelectedItem)
                    cmd.Parameters.AddWithValue("@Sales_Invoice_format", txtSalesInvoiceFormat.Text)
                    cmd.Parameters.AddWithValue("@MCode_Void", mCodeVoid)
                    cmd.Parameters.AddWithValue("@MCode_Refund", mCodeRefund)
                    cmd.Parameters.AddWithValue("@MCode_Settings", mCodeSettings)
                    cmd.Parameters.AddWithValue("@MCode_Zread", mCodeZread)
                    cmd.Parameters.AddWithValue("@MCode_CouponPromos", mCodeCouponPromos)
                    cmd.Parameters.AddWithValue("@MCode_Reprint", mCodeReprint)
                    cmd.Parameters.AddWithValue("@MEMC_Value", txtMEMCValue.Text)
                    cmd.Parameters.AddWithValue("@MEMC_Mode", memcMode)
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
                    MessageBox.Show("Settings saved successfully.")
                    LoadSettings()
                Catch ex As Exception
                    MessageBox.Show("Error saving settings: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub cbStoreID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbStoreID.SelectedIndexChanged
        LoadSettings()
    End Sub

#End Region


End Class