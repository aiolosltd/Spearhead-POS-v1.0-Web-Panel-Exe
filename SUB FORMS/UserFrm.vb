Imports MySql.Data.MySqlClient

Public Class UserFrm
    Private IsEditMode As Boolean = False
    Private SelectedUserId As Integer = 0

    Private Sub UserFrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadUsers()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUsers()
        Dim query As String = "SELECT * FROM 02_pos_users"
        Using conn As New MySqlConnection(ConnectionString)
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

        If Not IsEditMode Then
            If IsDuplicate("02_pos_users", "username", txtUsername.Text.Trim()) Then
                MessageBox.Show("The username already exists. Please choose a different username.")
                Return
            End If

            If IsDuplicate("02_pos_users", "email", txtUserEmail.Text.Trim()) Then
                MessageBox.Show("The email already exists. Please use a different email address.")
                Return
            End If
        End If

        Try
            If IsEditMode Then
                UpdateUser()
            Else
                InsertUser()
            End If

            LoadUsers()
            ClearUserForm()
            IsEditMode = False
            SelectedUserId = 0
            btnSaveUser.Text = "Save User"

        Catch ex As MySqlException
            MessageBox.Show("MySQL Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InsertUser()
        Dim query As String = "INSERT INTO 02_pos_users (user_id, username, password, user_pin, fullname, email, position, gender, creator_id, created_date, status) " &
                           "VALUES (@user_id, @username, @password, @user_pin, @fullname, @email, @position, @gender, @creator_id, @created_date, @status)"

        Using connection As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, connection)
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
    End Sub

    Private Sub UpdateUser()
        Dim query As String = "UPDATE 02_pos_users SET username = @username, password = @password, user_pin = @user_pin, " &
                             "fullname = @fullname, email = @email, position = @position, gender = @gender, " &
                             "creator_id = @creator_id WHERE id = @id"

        Using connection As New MySqlConnection(ConnectionString)
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                cmd.Parameters.AddWithValue("@user_pin", txtPin.Text.Trim())
                cmd.Parameters.AddWithValue("@fullname", txtFullName.Text.Trim())
                cmd.Parameters.AddWithValue("@email", txtUserEmail.Text.Trim())
                cmd.Parameters.AddWithValue("@position", If(cbUserPosition.SelectedItem IsNot Nothing, cbUserPosition.SelectedItem.ToString().Trim(), String.Empty))
                cmd.Parameters.AddWithValue("@gender", If(rbMale.Checked, "Male", "Female"))
                cmd.Parameters.AddWithValue("@creator_id", cbUserCreatorID.SelectedItem)
                cmd.Parameters.AddWithValue("@id", SelectedUserId)

                connection.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Function GenerateUserId() As String
        Dim rnd As New Random()
        Return rnd.Next(1000, 9999).ToString()
    End Function

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If dgvUsers.SelectedRows.Count > 0 Then
            Dim selectedId As Integer = Convert.ToInt32(dgvUsers.SelectedRows(0).Cells("id").Value)
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo)

            If result = DialogResult.Yes Then
                Dim query As String = "DELETE FROM 02_pos_users WHERE id = @id"

                Using connection As New MySqlConnection(ConnectionString)
                    Using cmd As New MySqlCommand(query, connection)
                        cmd.Parameters.AddWithValue("@id", selectedId)
                        connection.Open()
                        cmd.ExecuteNonQuery()
                    End Using
                End Using

                LoadUsers()
                ClearUserForm()
                IsEditMode = False
                SelectedUserId = 0
                btnSaveUser.Text = "Save User"
            End If
        Else
            MessageBox.Show("Please select a row to delete.")
        End If
    End Sub

    Private Sub btnClearUser_Click(sender As Object, e As EventArgs) Handles btnClearUser.Click
        ClearUserForm()
        IsEditMode = False
        SelectedUserId = 0
        btnSaveUser.Text = "Save User"
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvUsers.Rows.Count Then
            Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
            SelectedUserId = Convert.ToInt32(row.Cells("id").Value)
            txtUsername.Text = row.Cells("username").Value.ToString()
            txtPassword.Text = row.Cells("password").Value.ToString()
            txtConfirmPassword.Text = row.Cells("password").Value.ToString()
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

            IsEditMode = True
            btnSaveUser.Text = "Update User"
        End If
    End Sub

    Private Sub ClearUserForm()
        txtUsername.Clear()
        txtPassword.Clear()
        txtConfirmPassword.Clear()
        txtPin.Clear()
        txtFullName.Clear()
        txtUserEmail.Clear()
        cbUserPosition.SelectedIndex = -1
        cbUserCreatorID.SelectedIndex = -1
        rbMale.Checked = False
        rbFemale.Checked = False
    End Sub
End Class