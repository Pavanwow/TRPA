Imports MySql.Data.MySqlClient
Public Class Form6
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString = "server=localhost;userid=root;password=pava@123;database=data"
        Dim reader As MySqlDataReader

        '' Reported Diversion
        If RadioButton1.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "select date,sum(railcar)as railcar,sum(feedback_received_rr) as feedback_received_rr ,sum(rel_co) as rel_co,sum(rel_can) as rel_can,sum(rrr) as rrr  from data.diversion_reported where date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by date  ;"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0


                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()
                While reader.Read

                    If ComboBox1.SelectedItem = "FeedBack Received" Then
                        Chart1.Series(0).IsVisibleInLegend = True
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("FeedBack Received").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("feedback_received_rr"))
                    ElseIf ComboBox1.SelectedItem = "RR Rejected" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = True
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("RR Rejected").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("rrr"))
                    ElseIf ComboBox1.SelectedItem = "REL COR" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = True
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("REL COR").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("rel_co"))
                    ElseIf ComboBox1.SelectedItem = "REL Cancel" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = True
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("Rel Cancel").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("rel_can"))
                    Else ComboBox1.SelectedItem = "Total"
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = True
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("Total").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("railcar"))

                    End If
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        ElseIf RadioButton2.Checked = Enabled Then
            Try
                Mysqlcon.Open()
                Dim Query As String

                Query = "select date,sum(railcar) as total from data.diversion_unreported where date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by date ;"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0

                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()
                While reader.Read
                    Chart1.Series(0).IsVisibleInLegend = False
                    Chart1.Series(1).IsVisibleInLegend = False
                    Chart1.Series(2).IsVisibleInLegend = False
                    Chart1.Series(3).IsVisibleInLegend = False
                    Chart1.Series(4).IsVisibleInLegend = True
                    Chart1.Series(5).IsVisibleInLegend = False
                    Chart1.Series("Total").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("total"))
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        ElseIf RadioButton4.Checked = Enabled Then

            Try
                Mysqlcon.Open()
                Dim Query As String
                Query = "select customer,sum(railcar)as railcar,sum(feedback_received_rr) as feedback_received_rr ,sum(rel_co) as rel_co,sum(rel_can) as rel_can,sum(rrr) as rrr  from data.diversion_reported where customer in (" & TextBox2.Text & ") and date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by customer;"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()

                While reader.Read

                    If ComboBox1.SelectedItem = "FeedBack Received" Then
                        Chart1.Series(0).IsVisibleInLegend = True
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("FeedBack Received").Points.AddXY(reader.GetString("customer"), reader.GetInt32("feedback_received_rr"))
                    ElseIf ComboBox1.SelectedItem = "RR Rejected" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = True
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("RR Rejected").Points.AddXY(reader.GetString("customer"), reader.GetInt32("rrr"))
                    ElseIf ComboBox1.SelectedItem = "REL COR" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = True
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("REL COR").Points.AddXY(reader.GetString("customer"), reader.GetInt32("rel_co"))
                    ElseIf ComboBox1.SelectedItem = "REL Cancel" Then
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = True
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = False
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("Rel Cancel").Points.AddXY(reader.GetString("customer"), reader.GetInt32("rel_can"))
                    Else ComboBox1.SelectedItem = "Total"
                        Chart1.Series(0).IsVisibleInLegend = False
                        Chart1.Series(1).IsVisibleInLegend = False
                        Chart1.Series(2).IsVisibleInLegend = False
                        Chart1.Series(3).IsVisibleInLegend = False
                        Chart1.Series(4).IsVisibleInLegend = True
                        Chart1.Series(5).IsVisibleInLegend = False
                        Chart1.Series("Total").Points.AddXY(reader.GetString("customer"), reader.GetInt32("railcar"))
                    End If
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        ElseIf RadioButton5.Checked = Enabled Then

            Try
                Mysqlcon.Open()
                Dim Query As String

                Query = "select date,customer,sum(railcar) as total from data.diversion_unreported where customer in(" & TextBox2.Text & ") and date between '" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by customer ;"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()

                While reader.Read
                    Chart1.Series(0).IsVisibleInLegend = False
                    Chart1.Series(1).IsVisibleInLegend = False
                    Chart1.Series(2).IsVisibleInLegend = False
                    Chart1.Series(3).IsVisibleInLegend = False
                    Chart1.Series(4).IsVisibleInLegend = True
                    Chart1.Series(5).IsVisibleInLegend = False
                    Chart1.Series("Total").Points.AddXY(reader.GetString("customer"), reader.GetInt32("total"))
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        ElseIf RadioButton3.Checked = Enabled Then

            Try
                Mysqlcon.Open()
                Dim Query As String


                Query = "select date,sum(railcar) total from (select date,railcar from diversion_reported union all  select date,railcar from diversion_unreported) t where date between'" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by date;"

                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()

                While reader.Read
                    Chart1.Series(0).IsVisibleInLegend = False
                    Chart1.Series(1).IsVisibleInLegend = False
                    Chart1.Series(2).IsVisibleInLegend = False
                    Chart1.Series(3).IsVisibleInLegend = False
                    Chart1.Series(4).IsVisibleInLegend = False
                    Chart1.Series(5).IsVisibleInLegend = True
                    Chart1.Series("Total Diversion").Points.AddXY(reader.GetDateTime("date").ToShortDateString, reader.GetInt32("total"))
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        Else RadioButton6.Checked = Enabled

            Try
                Mysqlcon.Open()
                Dim Query As String

                Query = "Select date,customer,sum(railcar) as total from (select date,railcar,customer from diversion_reported union all  select date,railcar,customer from diversion_unreported) t where customer in(" & TextBox2.Text & ") and date between'" & Format(DateTimePicker1.Value, "yyy-MM-dd") & "' and '" & Format(DateTimePicker2.Value, "yyy-MM-dd") & "' group by customer;"
                command = New MySqlCommand(Query, Mysqlcon)
                reader = command.ExecuteReader
                Dim count As Integer
                count = 0
                Chart1.Series(0).Points.Clear()
                Chart1.Series(2).Points.Clear()
                Chart1.Series(3).Points.Clear()
                Chart1.Series(1).Points.Clear()
                Chart1.Series(4).Points.Clear()
                Chart1.Series(5).Points.Clear()

                While reader.Read
                    Chart1.Series(0).IsVisibleInLegend = False
                    Chart1.Series(1).IsVisibleInLegend = False
                    Chart1.Series(2).IsVisibleInLegend = False
                    Chart1.Series(3).IsVisibleInLegend = False
                    Chart1.Series(4).IsVisibleInLegend = True
                    Chart1.Series(5).IsVisibleInLegend = False
                    Chart1.Series("Total").Points.AddXY(reader.GetString("customer"), reader.GetInt32("total"))
                End While
                Mysqlcon.Close()
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                Mysqlcon.Dispose()
            End Try

        End If
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

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        RadioButton1.Checked = False
        RadioButton4.Checked = False
        RadioButton3.Checked = False
        RadioButton6.Checked = False
        DateTimePicker2.Show()
        ComboBox1.Hide()
        Label3.Hide()
        Label5.Hide()
        TreeView1.Hide()
        Label2.Show()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        RadioButton2.Checked = False
        RadioButton5.Checked = False
        RadioButton3.Checked = False
        RadioButton6.Checked = False
        DateTimePicker2.Show()
        ComboBox1.Show()
        Label3.Show()
        Label5.Hide()
        TreeView1.Hide()
        Label2.Show()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        RadioButton2.Checked = False
        RadioButton5.Checked = False
        RadioButton3.Checked = False
        RadioButton6.Checked = False
        ComboBox1.Show()
        Label3.Show()
        Label5.Show()
        TreeView1.Show()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        RadioButton1.Checked = False
        RadioButton4.Checked = False
        RadioButton3.Checked = False
        RadioButton6.Checked = False
        ComboBox1.Hide()
        TreeView1.Show()
        Label5.Show()
        Label3.Hide()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        Label3.Hide()
        Label5.Hide()
        TreeView1.Hide()
        ComboBox1.Hide()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton4.Checked = False
        RadioButton5.Checked = False
        Label3.Hide()
        Label5.Show()
        TreeView1.Show()
        ComboBox1.Hide()
        Chart1.Series(0).Points.Clear()
        Chart1.Series(2).Points.Clear()
        Chart1.Series(3).Points.Clear()
        Chart1.Series(1).Points.Clear()
        Chart1.Series(4).Points.Clear()
        Chart1.Series(5).Points.Clear()
    End Sub



    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class