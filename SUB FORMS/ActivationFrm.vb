Imports MySql.Data.MySqlClient
Public Class ActivationFrm
    Private IsEditMode As Boolean = False
    Private SelectedActivationId As Integer = 0

    Private Sub ActivationFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadActivation()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadActivation()
        Dim query As String = "SELECT * FROM 02_pos_activation"
        Using conn = ConnectionModule.GetConnection()
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

        If Not IsEditMode Then
            If IsDuplicate("02_pos_activation", "Email", txtEmail.Text) Then
                MessageBox.Show("The email address already exists. Please use a different email address.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdateActivation()
            Else
                InsertActivation()
            End If

            LoadActivation()
            ClearActivationFields()
            IsEditMode = False
            SelectedActivationId = 0
            btnSaveActivation.Text = "Save Activation"

        Catch ex As MySqlException
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertActivation()
        Dim query As String = "INSERT INTO 02_pos_activation (client_id, client_name, Email, contact_, Date_Registered, Terminal_Count, SubTerminal_Count) " &
                             "VALUES (LAST_INSERT_ID(), @ClientName, @Email, @Contact, @DateRegistered, @TerminalCount, @SubTerminalCount); " &
                             "UPDATE 02_pos_activation SET client_id = LAST_INSERT_ID() WHERE id = LAST_INSERT_ID();"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ClientName", txtClientName.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Contact", txtClientContact.Text.Trim())
                cmd.Parameters.AddWithValue("@DateRegistered", DateTime.Now)
                cmd.Parameters.AddWithValue("@TerminalCount", Convert.ToInt32(txtTerminalCount.Text))
                cmd.Parameters.AddWithValue("@SubTerminalCount", Convert.ToInt32(txtSubTerminalCount.Text))

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub UpdateActivation()
        Dim query As String = "UPDATE 02_pos_activation SET " &
                            "client_name = @ClientName, " &
                            "Email = @Email, " &
                            "contact_ = @Contact, " &
                            "Terminal_Count = @TerminalCount, " &
                            "SubTerminal_Count = @SubTerminalCount " &
                            "WHERE id = @Id"

        Using connection = ConnectionModule.GetConnection()
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@ClientName", txtClientName.Text.Trim())
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@Contact", txtClientContact.Text.Trim())
                cmd.Parameters.AddWithValue("@TerminalCount", Convert.ToInt32(txtTerminalCount.Text))
                cmd.Parameters.AddWithValue("@SubTerminalCount", Convert.ToInt32(txtSubTerminalCount.Text))
                cmd.Parameters.AddWithValue("@Id", SelectedActivationId)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub dgvActivation_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvActivation.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvActivation.Rows.Count Then
            Dim row As DataGridViewRow = dgvActivation.Rows(e.RowIndex)
            SelectedActivationId = Convert.ToInt32(row.Cells("id").Value)
            txtClientName.Text = row.Cells("client_name").Value.ToString()
            txtEmail.Text = row.Cells("Email").Value.ToString()
            txtClientContact.Text = row.Cells("contact_").Value.ToString()
            txtTerminalCount.Text = row.Cells("Terminal_Count").Value.ToString()
            txtSubTerminalCount.Text = row.Cells("SubTerminal_Count").Value.ToString()

            IsEditMode = True
            btnSaveActivation.Text = "Update Activation"
        End If
    End Sub

    Private Sub btnNewActivation_Click(sender As Object, e As EventArgs) Handles btnNewActivation.Click
        ClearActivationFields()
        IsEditMode = False
        SelectedActivationId = 0
        btnSaveActivation.Text = "Save Activation"
    End Sub

    Private Sub ClearActivationFields()
        txtClientName.Clear()
        txtEmail.Clear()
        txtClientContact.Clear()
        txtTerminalCount.Clear()
        txtSubTerminalCount.Clear()
    End Sub
End Class