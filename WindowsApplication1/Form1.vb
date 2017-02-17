Imports MySql.Data.MySqlClient
Public Class Form1
    Dim Mysqlcon As MySqlConnection
    Dim command As MySqlCommand
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'Label1.Left -= 8
        'If Label1.Right = Me.Left Then
        'Label1.Left = Me.Width
        'End If
        'If Label1.Left >= Me.Width Then
        ' Label1.Left = -100
        'Else
        ' Label1.Left = Label1.Left + 10
        ' End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Timer1.Start()
        ' Label1.Left = Me.Width

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub
 Private Sub CheckConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckConnectionToolStripMenuItem.Click
        Mysqlcon = New MySqlConnection
        Mysqlcon.ConnectionString =
        "server=localhost;userid=root;password=pava@123;database=data"
        Try
                   Mysqlcon.Open()
                    MessageBox.Show("Connection sucessful")
                   Mysqlcon.Close()
               Catch ex As MySqlException
            MessageBox.Show(ex.Message)
           Finally
            Mysqlcon.Dispose()
            End Try
    End Sub

    Private Sub UploaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploaderToolStripMenuItem.Click
        Form3.Show()
    End Sub

    Private Sub SummaryGraphToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SummaryGraphToolStripMenuItem2.Click
        Form8.Show()
    End Sub

    Private Sub SummaryGraphToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SummaryGraphToolStripMenuItem1.Click
        Form6.Show()
    End Sub

    Private Sub SummaryGraphToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SummaryGraphToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Private Sub OtherExceptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherExceptionsToolStripMenuItem.Click

        Form4.Show()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        MessageBox.Show("Trax Process analyzer")
    End Sub
End Class

