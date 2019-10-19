<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartScreen
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.picConn = New System.Windows.Forms.PictureBox()
        Me.chkShowSkel = New System.Windows.Forms.CheckBox()
        Me.lblSensorStatus = New System.Windows.Forms.Label()
        Me.lblBodiesStatus = New System.Windows.Forms.Label()
        Me.picSkeleton = New System.Windows.Forms.PictureBox()
        Me.txtDebugger = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.FanucEnable = New System.Windows.Forms.CheckBox()
        Me.FanucDescription = New System.Windows.Forms.Label()
        Me.RobotMovingDisplay = New System.Windows.Forms.Label()
        Me.IsPosReachable = New System.Windows.Forms.Label()
        Me.KinectFeedback = New System.Windows.Forms.GroupBox()
        Me.KinectFeedbacktext = New System.Windows.Forms.TextBox()
        Me.RobotManualControl = New System.Windows.Forms.CheckBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picConn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSkeleton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.KinectFeedback.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KinectVBtest.My.Resources.Resources.Capture
        Me.PictureBox1.Location = New System.Drawing.Point(33, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(3)
        Me.PictureBox1.Size = New System.Drawing.Size(136, 73)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'picConn
        '
        Me.picConn.BackColor = System.Drawing.Color.MistyRose
        Me.picConn.ErrorImage = Nothing
        Me.picConn.Image = Global.KinectVBtest.My.Resources.Resources.disconnected
        Me.picConn.InitialImage = Nothing
        Me.picConn.Location = New System.Drawing.Point(9, 90)
        Me.picConn.Margin = New System.Windows.Forms.Padding(0)
        Me.picConn.Name = "picConn"
        Me.picConn.Size = New System.Drawing.Size(83, 83)
        Me.picConn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConn.TabIndex = 6
        Me.picConn.TabStop = False
        '
        'chkShowSkel
        '
        Me.chkShowSkel.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkShowSkel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowSkel.Image = Global.KinectVBtest.My.Resources.Resources.no_stickman
        Me.chkShowSkel.Location = New System.Drawing.Point(9, 178)
        Me.chkShowSkel.Margin = New System.Windows.Forms.Padding(0)
        Me.chkShowSkel.Name = "chkShowSkel"
        Me.chkShowSkel.Size = New System.Drawing.Size(83, 139)
        Me.chkShowSkel.TabIndex = 1
        Me.chkShowSkel.Text = "OFF"
        Me.chkShowSkel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkShowSkel.UseVisualStyleBackColor = True
        '
        'lblSensorStatus
        '
        Me.lblSensorStatus.BackColor = System.Drawing.Color.MistyRose
        Me.lblSensorStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSensorStatus.ForeColor = System.Drawing.Color.Red
        Me.lblSensorStatus.Location = New System.Drawing.Point(104, 90)
        Me.lblSensorStatus.Name = "lblSensorStatus"
        Me.lblSensorStatus.Size = New System.Drawing.Size(89, 83)
        Me.lblSensorStatus.TabIndex = 0
        Me.lblSensorStatus.Text = "Kinect not Found"
        Me.lblSensorStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblBodiesStatus
        '
        Me.lblBodiesStatus.BackColor = System.Drawing.Color.MistyRose
        Me.lblBodiesStatus.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBodiesStatus.ForeColor = System.Drawing.Color.Red
        Me.lblBodiesStatus.Location = New System.Drawing.Point(104, 178)
        Me.lblBodiesStatus.Name = "lblBodiesStatus"
        Me.lblBodiesStatus.Size = New System.Drawing.Size(89, 139)
        Me.lblBodiesStatus.TabIndex = 2
        Me.lblBodiesStatus.Text = "Body" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tracking" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disabled"
        Me.lblBodiesStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picSkeleton
        '
        Me.picSkeleton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picSkeleton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSkeleton.Location = New System.Drawing.Point(199, 14)
        Me.picSkeleton.Name = "picSkeleton"
        Me.picSkeleton.Size = New System.Drawing.Size(623, 525)
        Me.picSkeleton.TabIndex = 11
        Me.picSkeleton.TabStop = False
        '
        'txtDebugger
        '
        Me.txtDebugger.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDebugger.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDebugger.Location = New System.Drawing.Point(3, 18)
        Me.txtDebugger.Multiline = True
        Me.txtDebugger.Name = "txtDebugger"
        Me.txtDebugger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDebugger.Size = New System.Drawing.Size(400, 137)
        Me.txtDebugger.TabIndex = 0
        Me.txtDebugger.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtDebugger)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 545)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(406, 158)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Debugger"
        '
        'FanucEnable
        '
        Me.FanucEnable.Appearance = System.Windows.Forms.Appearance.Button
        Me.FanucEnable.BackgroundImage = Global.KinectVBtest.My.Resources.Resources.R2008007_M20iA
        Me.FanucEnable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.FanucEnable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FanucEnable.Location = New System.Drawing.Point(9, 322)
        Me.FanucEnable.Margin = New System.Windows.Forms.Padding(0)
        Me.FanucEnable.Name = "FanucEnable"
        Me.FanucEnable.Size = New System.Drawing.Size(78, 103)
        Me.FanucEnable.TabIndex = 12
        Me.FanucEnable.Text = "OFF"
        Me.FanucEnable.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FanucEnable.UseVisualStyleBackColor = True
        '
        'FanucDescription
        '
        Me.FanucDescription.BackColor = System.Drawing.Color.MistyRose
        Me.FanucDescription.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FanucDescription.ForeColor = System.Drawing.Color.Red
        Me.FanucDescription.Location = New System.Drawing.Point(108, 322)
        Me.FanucDescription.Name = "FanucDescription"
        Me.FanucDescription.Size = New System.Drawing.Size(85, 103)
        Me.FanucDescription.TabIndex = 13
        Me.FanucDescription.Text = "Fanuc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tracking" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disabled"
        Me.FanucDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RobotMovingDisplay
        '
        Me.RobotMovingDisplay.BackColor = System.Drawing.Color.MistyRose
        Me.RobotMovingDisplay.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RobotMovingDisplay.ForeColor = System.Drawing.Color.Red
        Me.RobotMovingDisplay.Location = New System.Drawing.Point(9, 431)
        Me.RobotMovingDisplay.Name = "RobotMovingDisplay"
        Me.RobotMovingDisplay.Size = New System.Drawing.Size(81, 62)
        Me.RobotMovingDisplay.TabIndex = 14
        Me.RobotMovingDisplay.Text = "Fanuc" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tracking" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Disabled"
        Me.RobotMovingDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IsPosReachable
        '
        Me.IsPosReachable.BackColor = System.Drawing.Color.MistyRose
        Me.IsPosReachable.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IsPosReachable.ForeColor = System.Drawing.Color.Red
        Me.IsPosReachable.Location = New System.Drawing.Point(108, 431)
        Me.IsPosReachable.Name = "IsPosReachable"
        Me.IsPosReachable.Size = New System.Drawing.Size(81, 62)
        Me.IsPosReachable.TabIndex = 15
        Me.IsPosReachable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'KinectFeedback
        '
        Me.KinectFeedback.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KinectFeedback.Controls.Add(Me.KinectFeedbacktext)
        Me.KinectFeedback.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KinectFeedback.Location = New System.Drawing.Point(418, 545)
        Me.KinectFeedback.Name = "KinectFeedback"
        Me.KinectFeedback.Size = New System.Drawing.Size(413, 158)
        Me.KinectFeedback.TabIndex = 16
        Me.KinectFeedback.TabStop = False
        Me.KinectFeedback.Text = "Kinect Feedback"
        '
        'KinectFeedbacktext
        '
        Me.KinectFeedbacktext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.KinectFeedbacktext.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KinectFeedbacktext.Location = New System.Drawing.Point(3, 18)
        Me.KinectFeedbacktext.Multiline = True
        Me.KinectFeedbacktext.Name = "KinectFeedbacktext"
        Me.KinectFeedbacktext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.KinectFeedbacktext.Size = New System.Drawing.Size(407, 137)
        Me.KinectFeedbacktext.TabIndex = 0
        Me.KinectFeedbacktext.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'RobotManualControl
        '
        Me.RobotManualControl.Appearance = System.Windows.Forms.Appearance.Button
        Me.RobotManualControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RobotManualControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RobotManualControl.Location = New System.Drawing.Point(9, 493)
        Me.RobotManualControl.Margin = New System.Windows.Forms.Padding(0)
        Me.RobotManualControl.Name = "RobotManualControl"
        Me.RobotManualControl.Size = New System.Drawing.Size(180, 49)
        Me.RobotManualControl.TabIndex = 17
        Me.RobotManualControl.Text = "SHOW ROBOT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CONTROLS"
        Me.RobotManualControl.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.RobotManualControl.UseVisualStyleBackColor = True
        '
        'StartScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(834, 715)
        Me.Controls.Add(Me.RobotManualControl)
        Me.Controls.Add(Me.KinectFeedback)
        Me.Controls.Add(Me.IsPosReachable)
        Me.Controls.Add(Me.RobotMovingDisplay)
        Me.Controls.Add(Me.FanucDescription)
        Me.Controls.Add(Me.FanucEnable)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picSkeleton)
        Me.Controls.Add(Me.lblBodiesStatus)
        Me.Controls.Add(Me.picConn)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblSensorStatus)
        Me.Controls.Add(Me.chkShowSkel)
        Me.MinimumSize = New System.Drawing.Size(800, 680)
        Me.Name = "StartScreen"
        Me.Text = "Fanuc Kinect Interace (TESLA)"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picConn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSkeleton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.KinectFeedback.ResumeLayout(False)
        Me.KinectFeedback.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents picConn As System.Windows.Forms.PictureBox
    Friend WithEvents chkShowSkel As System.Windows.Forms.CheckBox
    Friend WithEvents lblSensorStatus As System.Windows.Forms.Label
    Friend WithEvents lblBodiesStatus As System.Windows.Forms.Label
    Friend WithEvents picSkeleton As System.Windows.Forms.PictureBox
    Friend WithEvents txtDebugger As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents FanucEnable As System.Windows.Forms.CheckBox
    Friend WithEvents FanucDescription As System.Windows.Forms.Label
    Friend WithEvents RobotMovingDisplay As System.Windows.Forms.Label
    Friend WithEvents IsPosReachable As System.Windows.Forms.Label
    Friend WithEvents KinectFeedback As System.Windows.Forms.GroupBox
    Friend WithEvents KinectFeedbacktext As System.Windows.Forms.TextBox
    Friend WithEvents RobotManualControl As System.Windows.Forms.CheckBox

End Class
