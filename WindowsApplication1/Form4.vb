Imports MySql.Data.MySqlClient

Public Class Form4
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString =
"server=localhost;userid=root;password=pava@123;database=data"
        Dim reader As MySqlDataReader

        If RadioButton6.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "Select * From data.data_1 WHERE `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' And account in ('Total');"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(4).Points.Clear()
                While reader.Read

                    If RadioButton1.Checked = Enabled Then
                        Chart1.Series("Potential Diversions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("potential_diversions"))

                    ElseIf RadioButton2.Checked = Enabled Then
                        Chart1.Series("Cars which need advice").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("cars_which_need_advice"))

                    ElseIf RadioButton3.Checked = Enabled Then
                        Chart1.Series("Special instructions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("special_instructions"))

                    ElseIf RadioButton4.Checked = Enabled Then
                        Chart1.Series("System Error").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("system_error"))

                    Else RadioButton5.Checked = Enabled
                        Chart1.Series("Kept for futher Updates").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("kept_for_futher_updates"))

                    End If
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        ElseIf RadioButton7.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                If RadioButton1.Checked = Enabled Then
                    Query = "Select date,sum(potential_diversions) AS Total from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    While reader.Read

                        Chart1.Series("Potential Diversions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                    End While

                ElseIf RadioButton2.Checked = Enabled Then
                    Query = "Select date,sum(cars_which_need_advice) AS Total from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    While reader.Read
                        Chart1.Series("Cars which need advice").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                    End While

                ElseIf RadioButton3.Checked = Enabled Then
                    Query = "Select date,sum(special_instructions) AS Total from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    While reader.Read
                        Chart1.Series("Special instructions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                    End While
                ElseIf RadioButton4.Checked = Enabled Then
                    Query = "Select date,sum(system_error) AS Total from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    While reader.Read
                        Chart1.Series("System Error").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                    End While



                ElseIf RadioButton5.Checked = Enabled Then
                    Query = "Select date,sum(kept_for_futher_updates) AS Total from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    While reader.Read
                        Chart1.Series("Kept for futher Updates").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                    End While
                End If
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        Else
            RadioButton8.Checked = Enabled
            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "select*From data.data_1 WHERE date='" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' And account in (" & TextBox2.Text & ");"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(4).Points.Clear()
                While reader.Read

                    If RadioButton1.Checked = Enabled Then
                        Chart1.Series("Potential Diversions").Points.AddXY(reader.GetString("account"), reader.GetInt32("potential_diversions"))

                    ElseIf RadioButton2.Checked = Enabled Then
                        Chart1.Series("Cars which need advice").Points.AddXY(reader.GetString("account"), reader.GetInt32("cars_which_need_advice"))

                    ElseIf RadioButton3.Checked = Enabled Then
                        Chart1.Series("Special instructions").Points.AddXY(reader.GetString("account"), reader.GetInt32("special_instructions"))

                    ElseIf RadioButton4.Checked = Enabled Then
                        Chart1.Series("System Error").Points.AddXY(reader.GetString("account"), reader.GetInt32("system_error"))

                    Else RadioButton5.Checked = Enabled
                        Chart1.Series("Kept for futher Updates").Points.AddXY(reader.GetString("account"), reader.GetInt32("kept_for_futher_updates"))

                    End If
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try
        End If

    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        Button2.Enabled = RadioButton1.Checked
        Chart1.Series(0).IsVisibleInLegend = True
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = False
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button2.Enabled = RadioButton2.Checked
        Chart1.Series(1).IsVisibleInLegend = True
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = False
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
    End Sub
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Button2.Enabled = RadioButton3.Checked
        Chart1.Series(2).IsVisibleInLegend = True
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = False
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Button2.Enabled = RadioButton4.Checked
        Chart1.Series(3).IsVisibleInLegend = True
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = False
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Button2.Enabled = RadioButton5.Checked
        Chart1.Series(4).IsVisibleInLegend = True
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
    End Sub
    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Label3.Hide()
        TreeView1.Hide()
        TextBox3.Hide()
        Label4.Hide()
        DateTimePicker2.Show()
        Label2.Show()
        Label1.Text = "From:-"
    End Sub
    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Label3.Show()
        TreeView1.Show()
        TextBox3.Hide()
        Label4.Hide()
        DateTimePicker2.Show()
        Label2.Show()
        Label1.Text = "From:-"
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
            'If MyTreeNode.Checked = True Then
            TextBox1.Text = TextBox1.Text & ", " & MyTreeNode.Text
            For Each MyChildNode As TreeNode In MyTreeNode.Nodes

                If MyChildNode.Checked = True Then
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox3.Text = Format(DateTimePicker1.Value, "MM/dd/yyyy")
    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton8.CheckedChanged
        Chart1.Series(0).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Label3.Show()
        TreeView1.Show()
        TextBox3.Show()
        Label4.Show()
        DateTimePicker2.Hide()
        Label2.Hide()
        Label1.Text = "Date:-"
        RadioButton6.Checked = False
        RadioButton7.Checked = False
    End Sub
End Class