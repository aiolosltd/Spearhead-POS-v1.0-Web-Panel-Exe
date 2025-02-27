Imports MySql.Data.MySqlClient
Imports System.ComponentModel

Public Class ScriptRunnerFrm
    Private Const ACTIVE_STATUS_SUCCESS As String = "1"
    Private Const CLOUD_SCRIPT_TABLE As String = "02_pos_script_runner"

    Private Sub ScriptRunnerFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadStoreIDs()
        LoadScripts()
    End Sub

    Private Sub LoadStoreIDs()
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

    Private Sub LoadScripts()
        Try
            Dim query As String = "SELECT id, command_, store_id, created_at, active_ FROM " & CLOUD_SCRIPT_TABLE &
                                 " ORDER BY created_at DESC"

            Using conn As New MySqlConnection(ConnectionString)
                Using cmd As New MySqlCommand(query, conn)
                    Dim dt As New DataTable()
                    conn.Open()
                    dt.Load(cmd.ExecuteReader())

                    With dgvScripts
                        .DataSource = dt
                        .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                        If .Columns.Count > 0 Then
                            .Columns("id").HeaderText = "ID"
                            .Columns("id").Width = 70
                            .Columns("id").Visible = False
                            .Columns("command_").HeaderText = "Command"
                            .Columns("store_id").HeaderText = "Store ID"
                            .Columns("store_id").Width = 30
                            .Columns("created_at").HeaderText = "Created At"
                            .Columns("created_at").Width = 50
                            .Columns("active_").HeaderText = "Active"
                            .Columns("active_").Width = 50

                            .Columns("command_").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("store_id").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("created_at").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("active_").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("store_id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("created_at").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                            .Columns("active_").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        End If
                    End With
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading scripts: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Async Sub btnRunScript_Click(sender As Object, e As EventArgs) Handles btnRunScript.Click
        Try
            If cbStoreID.SelectedItem Is Nothing Then
                MessageBox.Show("Please select a Store ID", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            If String.IsNullOrWhiteSpace(txtScript.Text) Then
                MessageBox.Show("Please enter a SQL script", "Validation Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            btnRunScript.Enabled = False

            Await LogScriptAsync(txtScript.Text.Trim(), Convert.ToInt32(cbStoreID.SelectedItem))

            MessageBox.Show("Script logged successfully!", "Success",
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtScript.Clear()

            LoadScripts()

        Catch ex As MySqlException
            HandleError(ex, $"MySQL Error ({ex.Number}): {ex.Message}")
        Catch ex As Exception
            HandleError(ex, "Error logging script")
        Finally
            btnRunScript.Enabled = True
        End Try
    End Sub

    Private Async Function LogScriptAsync(scriptCommand As String, storeId As Integer) As Task
        Using conn As MySqlConnection = GetConnection()
            Await conn.OpenAsync()

            Dim scriptId As Integer = Await GetNextScriptIdAsync(conn)

            Dim query As String = "INSERT INTO " & CLOUD_SCRIPT_TABLE &
                                " (id, command_, store_id, created_at, active_) " &
                                "VALUES (@id, @command_, @store_id, @created_at, @active_)"

            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@id", scriptId)
                cmd.Parameters.AddWithValue("@command_", scriptCommand)
                cmd.Parameters.AddWithValue("@store_id", storeId)
                cmd.Parameters.AddWithValue("@created_at", DateTime.Now)
                cmd.Parameters.AddWithValue("@active_", ACTIVE_STATUS_SUCCESS)

                Await cmd.ExecuteNonQueryAsync()
            End Using
        End Using
    End Function

    Private Async Function GetNextScriptIdAsync(conn As MySqlConnection) As Task(Of Integer)
        Dim query As String = "SELECT COALESCE(MAX(id), 0) + 1 FROM " & CLOUD_SCRIPT_TABLE
        Using cmd As New MySqlCommand(query, conn)
            Return Convert.ToInt32(Await cmd.ExecuteScalarAsync())
        End Using
    End Function

    Private Sub HandleError(ex As Exception, message As String)
        MessageBox.Show($"{message}{Environment.NewLine}{ex.Message}", "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
        Debug.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}")
        Debug.WriteLine($"Exception: {ex.Message}")
        Debug.WriteLine($"Stack Trace: {ex.StackTrace}")
    End Sub
End Class