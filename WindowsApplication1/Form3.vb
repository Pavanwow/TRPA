Imports MySql.Data.MySqlClient
Public Class Form3
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand

    Private ReadOnly fileUpload As Object
    Public Property ConfigurationManager As Object
    Public Property FileUpload1 As Object
    Public Property Server As Object
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Try
            If TextBox1.Text = Nothing Then
                MsgBox("Path doesn't exist!", MsgBoxStyle.Critical, "Error")

            Else

                Mysqlcon = New MySqlConnection
                Dim Query As String
                Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
                Mysqlcon.Open()
                Query = "LOAD DATA LOCAL INFILE '" & TextBox1.Text & " ' INTO TABLE data_1 FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES"
                command = New MySqlCommand(Query, Mysqlcon)
                command.ExecuteNonQuery()
                Mysqlcon.Close()
                MessageBox.Show("Successfully Updated")
            End If
        Catch
            'TextBox1.Text = ""
            MsgBox("Error while submiting the file! Please check the file format!", MsgBoxStyle.Critical, "Error")
        End Try
        TextBox1.Clear()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        OpenFileDialog1.ShowDialog()


        Select Case True
            Case OpenFileDialog1.FileName.Contains("\")
                OpenFileDialog1.FileName = OpenFileDialog1.FileName.Replace("\", "\\")
        End Select
        TextBox1.Text = OpenFileDialog1.FileName
        'OpenFileDialog1.FileName = ""
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Form4.TreeView1.Nodes(ComboBox1.SelectedIndex).Nodes.Add(TextBox2.Text)
            Form2.TreeView1.Nodes(ComboBox1.SelectedIndex).Nodes.Add(TextBox2.Text)
            MessageBox.Show("Sucessfully Added")

        Catch
            TextBox2.Text = Nothing
            MessageBox.Show("Customer Name!!")
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click


        Try
            If TextBox3.Text = Nothing Then
                MsgBox("Path doesn't exist!", MsgBoxStyle.Critical, "Error")
            Else
                Mysqlcon = New MySqlConnection
                Dim Query As String
                Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
                Mysqlcon.Open()
                Query = "LOAD DATA LOCAL INFILE '" & TextBox3.Text & " ' INTO TABLE diversion_reported FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES"
                command = New MySqlCommand(Query, Mysqlcon)
                command.ExecuteNonQuery()
                Mysqlcon.Close()
                MessageBox.Show("Successfully Updated")
            End If
        Catch
            ' TextBox3.Text = ""
            MsgBox("Error while submiting the file! Please check the file format!", MsgBoxStyle.Critical, "Error")
        End Try
        TextBox3.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        OpenFileDialog1.ShowDialog()
        'OpenFileDialog1 = "Chose a file".
        Select Case True
            Case OpenFileDialog1.FileName.Contains("\")
                OpenFileDialog1.FileName = OpenFileDialog1.FileName.Replace("\", "\\")
        End Select
        TextBox3.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        OpenFileDialog1.ShowDialog()
        'OpenFileDialog1 = "Chose a file".
        Select Case True
            Case OpenFileDialog1.FileName.Contains("\")
                OpenFileDialog1.FileName = OpenFileDialog1.FileName.Replace("\", "\\")
        End Select
        TextBox4.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If TextBox4.Text = Nothing Then
                MsgBox("Path doesn't exist!", MsgBoxStyle.Critical, "Error")
            Else


                Mysqlcon = New MySqlConnection
                Dim Query As String
                Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
                Mysqlcon.Open()
                Query = "LOAD DATA LOCAL INFILE '" & TextBox4.Text & " ' INTO TABLE diversion_unreported FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES;"
                command = New MySqlCommand(Query, Mysqlcon)
                command.ExecuteNonQuery()
                Mysqlcon.Close()
                MessageBox.Show("Successfully Updated")

            End If
        Catch
            'TextBox4.Text = ""
            MsgBox("Error while submiting the file! Please check the file format!", MsgBoxStyle.Critical, "Error")
        End Try
        TextBox4.Clear()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        OpenFileDialog1.ShowDialog()
        'OpenFileDialog1 = "Chose a file".
        Select Case True
            Case OpenFileDialog1.FileName.Contains("\")
                OpenFileDialog1.FileName = OpenFileDialog1.FileName.Replace("\", "\\")
        End Select
        TextBox5.Text = OpenFileDialog1.FileName
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click


        Try
            If TextBox5.Text = Nothing Then
                MsgBox("Path doesn't exist!", MsgBoxStyle.Critical, "Error")

            Else
                Mysqlcon = New MySqlConnection
                Dim Query As String
                Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
                Mysqlcon.Open()
                Query = "LOAD DATA LOCAL INFILE '" & TextBox5.Text & " ' INTO TABLE cli_data FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n' IGNORE 1 LINES;"
                command = New MySqlCommand(Query, Mysqlcon)
                command.ExecuteNonQuery()
                Mysqlcon.Close()
                MessageBox.Show("Successfully Updated")
            End If
        Catch
            'TextBox5.Text = ""
            MsgBox("Error while submiting the file! Please check the file format!", MsgBoxStyle.Critical, "Error")
        End Try
        TextBox5.Clear()
    End Sub


End Class
