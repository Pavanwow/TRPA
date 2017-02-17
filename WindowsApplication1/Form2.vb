Imports MySql.Data.MySqlClient
Public Class Form2
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString =
"server=localhost;userid=root;password=pava@123;database=data"
        Dim reader As MySqlDataReader

        If RadioButton5.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "Select * From data.data_1 WHERE `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' And account in ('Total');"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(5).Points.Clear()
                Chart1.Series(6).Points.Clear()
                While reader.Read
                    If RadioButton1.Checked = Enabled Then
                        Chart1.Series("L\E Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("l_e_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("no_resolved0"))
                    ElseIf RadioButton2.Checked = Enabled Then
                        Chart1.Series("Destination Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("destination_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("no_resolved1"))
                    ElseIf RadioButton3.Checked = Enabled Then
                        Chart1.Series("Event after PLA exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("event_after_pla_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("no_resolved2"))
                    Else RadioButton4.Checked = Enabled
                        Chart1.Series("PLA Destination Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("pla_destination_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("no_resolved3"))
                    End If
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try


            'Customer|Industry wise------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ElseIf RadioButton6.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                If RadioButton1.Checked = Enabled Then
                    Query = "Select date,sum(l_e_exceptions) AS Total,sum(no_resolved0) as Solved from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  ' " & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(5).Points.Clear()
                    Chart1.Series(6).Points.Clear()
                    While reader.Read

                        Chart1.Series("L\E Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Solved"))
                    End While

                ElseIf RadioButton2.Checked = Enabled Then
                    Query = "Select date,sum(destination_exceptions) AS Total,sum(no_resolved1) as Solved from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(5).Points.Clear()
                    Chart1.Series(6).Points.Clear()
                    While reader.Read
                        Chart1.Series("Destination Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Solved"))
                    End While

                ElseIf RadioButton3.Checked = Enabled Then
                    Query = "Select date,sum(event_after_pla_exceptions) AS Total,sum(no_resolved2) as Solved from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(5).Points.Clear()
                    Chart1.Series(6).Points.Clear()
                    While reader.Read
                        Chart1.Series("Event after PLA exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Solved"))
                    End While
                Else RadioButton4.Checked = Enabled
                    Query = "Select date,sum(pla_destination_exceptions) AS Total,sum(no_resolved3) as Solved from data.data_1 where account in (" & TextBox2.Text & ") and `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by(date);"
                    command = New MySqlCommand(Query, Mysqlcon)
                    reader = command.ExecuteReader
                    Dim count As Integer
                    count = 0
                    Chart1.Series(0).Points.Clear()
                    Chart1.Series(2).Points.Clear()
                    Chart1.Series(3).Points.Clear()
                    Chart1.Series(4).Points.Clear()
                    Chart1.Series(1).Points.Clear()
                    Chart1.Series(5).Points.Clear()
                    Chart1.Series(6).Points.Clear()
                    While reader.Read
                        Chart1.Series("PLA Destination Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Solved"))
                    End While
                End If
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

            'Total Exceptions---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ElseIf RadioButton7.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "SELECT date,(l_e_exceptions +destination_exceptions + event_after_pla_exceptions+pla_destination_exceptions) as 'Total_Exceptions', (no_resolved0 + no_resolved1+no_resolved2+no_resolved3) as 'Total_Solved' FROM data_1 where account in ('Total') and `date` BETWEEN  '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' AND '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "'"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(5).Points.Clear()
                Chart1.Series(6).Points.Clear()
                While reader.Read
                    Chart1.Series("Total Exceptions").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total_Exceptions"))
                    Chart1.Series("Total Solved").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("Total_Solved"))
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

            'Multi selections-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        Else
            RadioButton9.Checked = Enabled

            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "select*From data.data_1 WHERE date='" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' And account in (" & TextBox2.Text & ");"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(5).Points.Clear()
                Chart1.Series(6).Points.Clear()
                While reader.Read
                    If RadioButton1.Checked = Enabled Then
                        Chart1.Series("L\E Exceptions").Points.AddXY(reader.GetString("account"), reader.GetInt32("l_e_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetString("account"), reader.GetInt32("no_resolved0"))
                    ElseIf RadioButton2.Checked = Enabled Then
                        Chart1.Series("Destination Exceptions").Points.AddXY(reader.GetString("account"), reader.GetInt32("destination_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetString("account"), reader.GetInt32("no_resolved1"))
                    ElseIf RadioButton3.Checked = Enabled Then
                        Chart1.Series("Event after PLA exceptions").Points.AddXY(reader.GetString("account"), reader.GetInt32("event_after_pla_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetString("account"), reader.GetInt32("no_resolved2"))
                    Else RadioButton4.Checked = Enabled
                        Chart1.Series("PLA Destination Exceptions").Points.AddXY(reader.GetString("account"), reader.GetInt32("pla_destination_exceptions"))
                        Chart1.Series("Solved").Points.AddXY(reader.GetString("account"), reader.GetInt32("no_resolved3"))
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
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Chart1.Series(0).IsVisibleInLegend = True
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = True
        Chart1.Series(5).IsVisibleInLegend = False
        Chart1.Series(6).IsVisibleInLegend = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        Button2.Enabled = RadioButton2.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = True
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = True
        Chart1.Series(5).IsVisibleInLegend = False
        Chart1.Series(6).IsVisibleInLegend = False
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        Button2.Enabled = RadioButton3.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = True
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = True
        Chart1.Series(5).IsVisibleInLegend = False
        Chart1.Series(6).IsVisibleInLegend = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        Button2.Enabled = RadioButton4.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = True
        Chart1.Series(4).IsVisibleInLegend = True
        Chart1.Series(5).IsVisibleInLegend = False
        Chart1.Series(6).IsVisibleInLegend = False

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        Button2.Enabled = RadioButton5.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        TreeView1.Hide()
        GroupBox1.Show()
        Label3.Hide()
        DateTimePicker2.Show()
        Label2.Show()
        Label1.Text = "From:-"
        TextBox3.Hide()
        Label5.Hide()
        RadioButton9.Checked = False
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        Button2.Enabled = RadioButton6.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Label3.Show()
        GroupBox1.Show()
        TreeView1.Show()
        DateTimePicker2.Show()
        Label2.Show()
        Label1.Text = "From:-"
        TextBox3.Hide()
        Label5.Hide()
        RadioButton9.Checked = False
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        Button2.Enabled = RadioButton7.Checked

        Chart1.Series(0).IsVisibleInLegend = False
        Chart1.Series(1).IsVisibleInLegend = False
        Chart1.Series(2).IsVisibleInLegend = False
        Chart1.Series(3).IsVisibleInLegend = False
        Chart1.Series(4).IsVisibleInLegend = False
        Chart1.Series(5).IsVisibleInLegend = True
        Chart1.Series(6).IsVisibleInLegend = True
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        TreeView1.Hide()
        GroupBox1.Hide()
        Label3.Hide()
        DateTimePicker2.Show()
        Label2.Show()
        Label1.Text = "From:-"
        TextBox3.Hide()
        Label5.Hide()
        RadioButton9.Checked = False
    End Sub
    'Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
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

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox3.Text = Format(DateTimePicker1.Value, "MM/dd/yyyy")
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton9.CheckedChanged
        Button2.Enabled = RadioButton9.Checked
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(5).Points.Clear()
        Chart1.Series(6).Points.Clear()
        Label3.Show()
        GroupBox1.Show()
        TreeView1.Show()
        Label2.Hide()
        DateTimePicker2.Hide()
        Label1.Text = "Date:-"
        TextBox3.Show()
        Label5.Show()
        RadioButton5.Checked = False
        RadioButton6.Checked = False
        RadioButton7.Checked = False

    End Sub
End Class