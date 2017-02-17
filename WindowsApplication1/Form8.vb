Imports MySql.Data.MySqlClient
Public Class Form8
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck
        If e.Node.Parent Is Nothing Then
            For Each MyChildNode As TreeNode In e.Node.Nodes
                MyChildNode.Checked = e.Node.Checked
            Next
        End If
        'clear the textboxes as we need to reset them each time
        TextBox1.Text = ""
        TextBox2.Text = ""
        'add them to the textboxes
        For Each MyTreeNode As TreeNode In TreeView1.Nodes
            ' If MyTreeNode.Checked = True Then
            TextBox1.Text = TextBox1.Text & ", " & MyTreeNode.Text
            For Each MyChildNode As TreeNode In MyTreeNode.Nodes

                If MyChildNode.Checked = True Then
                    'TextBox2.Show()
                    TextBox2.Text = TextBox2.Text & ", " & "'" & MyChildNode.Text & "'"
                End If
            Next
            'End If
        Next
        'remove the first coma and space on the textboxes as they were
        'addes first
        TextBox1.Text = Mid(TextBox1.Text, 3)
        TextBox2.Text = Mid(TextBox2.Text, 3)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
        Dim reader As MySqlDataReader

        Try
            Mysqlcon.Open()
            'Dim no As Integer
            Dim Query1, Query2 As String

            If RadioButton1.Checked = Enabled Then
                Query1 = "select date,sum(uploaded)as uploaded,sum(feedback)as feedback from data.cli_data where date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by date;"
                command = New MySqlCommand(Query1, Mysqlcon)
            ElseIf RadioButton2.Checked = Enabled Then
                Query2 = "select customer,sum(uploaded) as uploaded,sum(feedback)as feedback from data.cli_data where customer in ( " & TextBox2.Text & ") and date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by customer;"
                command = New MySqlCommand(Query2, Mysqlcon)
            End If

            Dim count As Integer
            count = 0

            Chart1.Series(0).Points.Clear()
            Chart1.Series(1).Points.Clear()
            reader = command.ExecuteReader
            While reader.Read
                Chart1.Series(0).IsVisibleInLegend = True
                Chart1.Series(1).IsVisibleInLegend = True

                If RadioButton1.Checked = Enabled Then


                    Chart1.Series("Uploaded").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("uploaded"))
                    Chart1.Series("Feedback").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("feedback"))

                ElseIf RadioButton2.Checked = Enabled Then

                    Chart1.Series("Uploaded").Points.AddXY(reader.GetString("customer"), reader.GetInt32("uploaded"))
                    Chart1.Series("Feedback").Points.AddXY(reader.GetString("customer"), reader.GetInt32("feedback"))
                End If
            End While
            Mysqlcon.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            Mysqlcon.Dispose()
        End Try

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TreeView1.Hide()
        Label5.Hide()
        Chart1.Series(1).IsVisibleInLegend = True
        Chart1.Series(0).IsVisibleInLegend = True
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TreeView1.Show()
        Label5.Show()
        Chart1.Series(1).IsVisibleInLegend = True
        Chart1.Series(0).IsVisibleInLegend = True
    End Sub


End Class