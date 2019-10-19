<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RobotManualControl
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.HomeButton = New System.Windows.Forms.Button()
        Me.OpenGripButton = New System.Windows.Forms.Button()
        Me.CloseGripButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'HomeButton
        '
        Me.HomeButton.Location = New System.Drawing.Point(29, 34)
        Me.HomeButton.Name = "HomeButton"
        Me.HomeButton.Size = New System.Drawing.Size(153, 76)
        Me.HomeButton.TabIndex = 0
        Me.HomeButton.Text = "Send Robot Home"
        Me.HomeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.HomeButton.UseCompatibleTextRendering = True
        Me.HomeButton.UseVisualStyleBackColor = True
        '
        'OpenGripButton
        '
        Me.OpenGripButton.Location = New System.Drawing.Point(223, 34)
        Me.OpenGripButton.Name = "OpenGripButton"
        Me.OpenGripButton.Size = New System.Drawing.Size(153, 76)
        Me.OpenGripButton.TabIndex = 1
        Me.OpenGripButton.Text = "Open Gripper"
        Me.OpenGripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.OpenGripButton.UseCompatibleTextRendering = True
        Me.OpenGripButton.UseVisualStyleBackColor = True
        '
        'CloseGripButton
        '
        Me.CloseGripButton.Location = New System.Drawing.Point(223, 127)
        Me.CloseGripButton.Name = "CloseGripButton"
        Me.CloseGripButton.Size = New System.Drawing.Size(153, 76)
        Me.CloseGripButton.TabIndex = 2
        Me.CloseGripButton.Text = "Close Gripper"
        Me.CloseGripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.CloseGripButton.UseCompatibleTextRendering = True
        Me.CloseGripButton.UseVisualStyleBackColor = True
        '
        'RobotManualControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 220)
        Me.Controls.Add(Me.CloseGripButton)
        Me.Controls.Add(Me.OpenGripButton)
        Me.Controls.Add(Me.HomeButton)
        Me.Name = "RobotManualControl"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents HomeButton As System.Windows.Forms.Button
    Friend WithEvents OpenGripButton As System.Windows.Forms.Button
    Friend WithEvents CloseGripButton As System.Windows.Forms.Button
End Class
