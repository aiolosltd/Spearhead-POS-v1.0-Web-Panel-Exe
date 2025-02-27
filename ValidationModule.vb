Imports Guna.UI2.WinForms
Imports MySql.Data.MySqlClient

Module ValidationModule
    Public Function AreFieldsValid(ParamArray controls() As Object) As Boolean
        If controls Is Nothing OrElse controls.Length = 0 Then
            Return False
        End If

        For Each ctrl As Object In controls
            If Not ValidateControl(ctrl) Then
                ShowValidationMessage()
                Return False
            End If
        Next

        Return True
    End Function

    Private Function ValidateControl(ctrl As Object) As Boolean
        Select Case True
            Case TypeOf ctrl Is TextBox
                Return ValidateTextBox(DirectCast(ctrl, TextBox))

            Case TypeOf ctrl Is Guna2TextBox
                Return ValidateGunaTextBox(DirectCast(ctrl, Guna2TextBox))

            Case TypeOf ctrl Is ComboBox
                Return ValidateComboBox(DirectCast(ctrl, ComboBox))

            Case TypeOf ctrl Is Guna2ComboBox
                Return ValidateGunaComboBox(DirectCast(ctrl, Guna2ComboBox))

            Case TypeOf ctrl Is RadioButton
                Return ValidateRadioButton(DirectCast(ctrl, RadioButton))

            Case TypeOf ctrl Is Guna2RadioButton
                Return ValidateGunaRadioButton(DirectCast(ctrl, Guna2RadioButton))

            Case TypeOf ctrl Is CheckBox
                Return ValidateCheckBox(DirectCast(ctrl, CheckBox))

            Case TypeOf ctrl Is Guna2CheckBox
                Return ValidateGunaCheckBox(DirectCast(ctrl, Guna2CheckBox))

            Case Else
                Return True ' Return true for unsupported control types
        End Select
    End Function

    Private Function ValidateTextBox(textBox As TextBox) As Boolean
        Return Not String.IsNullOrWhiteSpace(textBox.Text)
    End Function


    Private Function ValidateGunaTextBox(textBox As Guna2TextBox) As Boolean
        Return Not String.IsNullOrWhiteSpace(textBox.Text)
    End Function

    Private Function ValidateComboBox(comboBox As ComboBox) As Boolean
        Return comboBox.SelectedItem IsNot Nothing
    End Function

    Private Function ValidateGunaComboBox(comboBox As Guna2ComboBox) As Boolean
        Return comboBox.SelectedItem IsNot Nothing
    End Function


    Private Function ValidateRadioButton(radioButton As RadioButton) As Boolean
        Return radioButton.Checked
    End Function

    Private Function ValidateGunaRadioButton(radioButton As Guna2RadioButton) As Boolean
        Return radioButton.Checked
    End Function


    Private Function ValidateCheckBox(checkBox As CheckBox) As Boolean
        Return True ' Default to true as checkbox state might be valid either way
    End Function


    Private Function ValidateGunaCheckBox(checkBox As Guna2CheckBox) As Boolean
        Return True ' Default to true as checkbox state might be valid either way
    End Function

    Private Sub ShowValidationMessage()
        MessageBox.Show("All fields are required. Please fill in all the information.",
                       "Incomplete Fields",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning)
    End Sub


    Public Function IsDuplicate(tableName As String,
                              columnName As String,
                              value As String,
                              Optional excludeId As Integer = 0) As Boolean

        Dim query As String
        If excludeId > 0 Then
            query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value AND id <> @excludeId"
        Else
            query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value"
        End If

        Using connection As New MySqlConnection(ConnectionModule.ConnectionString)
            Using cmd As New MySqlCommand(query, connection)
                Try
                    cmd.Parameters.AddWithValue("@value", value)
                    If excludeId > 0 Then
                        cmd.Parameters.AddWithValue("@excludeId", excludeId)
                    End If

                    connection.Open()
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    Return count > 0

                Catch ex As Exception
                    MessageBox.Show($"Error checking for duplicates: {ex.Message}",
                                  "Database Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error)
                    Return True ' Return true on error to prevent potentially invalid data
                Finally
                    If connection.State = ConnectionState.Open Then
                        connection.Close()
                    End If
                End Try
            End Using
        End Using
    End Function

    Public Sub ShowDuplicateMessage(fieldName As String)
        MessageBox.Show($"The {fieldName} already exists. Please enter a different value.",
                       "Duplicate Value",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Warning)
    End Sub
End Module
