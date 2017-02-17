<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExceptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryGraphToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtherExceptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiversionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryGraphToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CLIToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SummaryGraphToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploaderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Image = Global.WindowsApplication1.My.Resources.Resources.general_electric_3d_logo_animation_by_syndikata_np_d61ktu6
        Me.PictureBox1.Location = New System.Drawing.Point(175, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(392, 390)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.HelpToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(727, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExceptionsToolStripMenuItem, Me.DiversionsToolStripMenuItem, Me.CLIToolStripMenuItem, Me.UploaderToolStripMenuItem, Me.CheckConnectionToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'ExceptionsToolStripMenuItem
        '
        Me.ExceptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryGraphToolStripMenuItem, Me.OtherExceptionsToolStripMenuItem})
        Me.ExceptionsToolStripMenuItem.Name = "ExceptionsToolStripMenuItem"
        Me.ExceptionsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ExceptionsToolStripMenuItem.Text = "Exceptions"
        '
        'SummaryGraphToolStripMenuItem
        '
        Me.SummaryGraphToolStripMenuItem.Name = "SummaryGraphToolStripMenuItem"
        Me.SummaryGraphToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.SummaryGraphToolStripMenuItem.Text = "Summary Graph"
        '
        'OtherExceptionsToolStripMenuItem
        '
        Me.OtherExceptionsToolStripMenuItem.Name = "OtherExceptionsToolStripMenuItem"
        Me.OtherExceptionsToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.OtherExceptionsToolStripMenuItem.Text = "Other Exceptions"
        '
        'DiversionsToolStripMenuItem
        '
        Me.DiversionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryGraphToolStripMenuItem1})
        Me.DiversionsToolStripMenuItem.Name = "DiversionsToolStripMenuItem"
        Me.DiversionsToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.DiversionsToolStripMenuItem.Text = "Diversions"
        '
        'SummaryGraphToolStripMenuItem1
        '
        Me.SummaryGraphToolStripMenuItem1.Name = "SummaryGraphToolStripMenuItem1"
        Me.SummaryGraphToolStripMenuItem1.Size = New System.Drawing.Size(160, 22)
        Me.SummaryGraphToolStripMenuItem1.Text = "Summary Graph"
        '
        'CLIToolStripMenuItem
        '
        Me.CLIToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SummaryGraphToolStripMenuItem2})
        Me.CLIToolStripMenuItem.Name = "CLIToolStripMenuItem"
        Me.CLIToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.CLIToolStripMenuItem.Text = "CLI"
        '
        'SummaryGraphToolStripMenuItem2
        '
        Me.SummaryGraphToolStripMenuItem2.Name = "SummaryGraphToolStripMenuItem2"
        Me.SummaryGraphToolStripMenuItem2.Size = New System.Drawing.Size(160, 22)
        Me.SummaryGraphToolStripMenuItem2.Text = "Summary Graph"
        '
        'UploaderToolStripMenuItem
        '
        Me.UploaderToolStripMenuItem.Name = "UploaderToolStripMenuItem"
        Me.UploaderToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.UploaderToolStripMenuItem.Text = "Uploader"
        '
        'CheckConnectionToolStripMenuItem
        '
        Me.CheckConnectionToolStripMenuItem.Name = "CheckConnectionToolStripMenuItem"
        Me.CheckConnectionToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.CheckConnectionToolStripMenuItem.Text = "CheckConnection"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.BackColor = System.Drawing.SystemColors.HotTrack
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.BackColor = System.Drawing.SystemColors.Highlight
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.Label1)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(727, 16)
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 403)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(727, 41)
        Me.ToolStripContainer1.TabIndex = 9
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.HotTrack
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(286, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Copyright © 2017 Shipxpress "
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(625, 387)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Version 1.0.0-alpha"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources.hero_ge_logo_full
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(727, 443)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "ShipxTrax"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.ContentPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExceptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SummaryGraphToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OtherExceptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiversionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SummaryGraphToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CLIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SummaryGraphToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents UploaderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripContainer1 As ToolStripContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
