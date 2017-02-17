Imports MySql.Data.MySqlClient
Public Class Form5
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString =
"server=localhost;userid=root;password=pava@123;database=data"
        Try
            Mysqlcon.Open()
            Dim Query As String
            Query = "select * from data.my_data where name='" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'"
            command = New MySqlCommand(Query, Mysqlcon)
            Dim READER As MySqlDataReader
            READER = command.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
            End While
            If count = 1 Then
                MessageBox.Show("Username and Password are correct", "login successful!")
                Me.Hide()
                Form1.Show()
            ElseIf count > 1 Then
                MsgBox("Username and Password are Duplicate!", MsgBoxStyle.Critical, "Error")
            ElseIf TextBox1.Text = Nothing And TextBox2.Text = Nothing Then
                MessageBox.Show("Please Enter the Username and Password", "Uaername and Password?")
            ElseIf TextBox1.Text = Nothing Then
                MessageBox.Show("Please Enter the username", "Username?")
            ElseIf TextBox2.Text = Nothing Then
                MessageBox.Show("Please Enter the Password", "Password?")
            Else
                MsgBox("Incorrect Username or Password !", MsgBoxStyle.Critical, "Error")
            End If

            Mysqlcon.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            Mysqlcon.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
    End Sub
End Class





