Imports Microsoft.Kinect
Imports Microsoft.Kinect.VisualGestureBuilder
Imports FRRobot
Imports System.Console
Imports System.Math


Public Class StartScreen

    ' New line character shorthand
    Dim NL As String = vbNewLine

    Public RightHandPosition = New Double
    ' Shared Kinect Sensor Object
    Friend Shared kSensor As KinectSensor
    Private Initialized As Boolean
    Private RHXPos As Double
    Private RHYPos As Double
    Private RHZPos As Double
    Private Kinect0X As Double
    Private Kinect0Y As Double
    Private Kinect0Z As Double
    Private Kinect0W As Double
    Private Kinect0P As Double
    Private Kinect0R As Double
    Public AbsLocMem As Double
    Public NewLocMem As Double
    Private PosToCheck As FRCSysGroupPosition
    Private PosToCheckXYZ As FRCXyzWpr
    Private HomeSysPos As FRCSysGroupPosition
    Private TempPos As FRCXyzWpr
    Private TempSysPos As FRCSysGroupPosition
    Public program As FRCTPProgram
    Public missedupdate As Double
    Public outofboundarycounter As Double
    Public Shared task As FRCTask
    Public robotuframe As FRCVar
    Public robottoolframe As FRCVar
    Public RobotVars As FRCVars
    Public rufnumber As FRCRegNumeric
    Public rtfnumber As FRCRegNumeric
    '  Friend Shared CognexTest As 
    ' Response timer (shared) for recording gestures
    ' Kinect bodies (all 6 and only the active ones)
    Private allBods(5) As Body
    Private activeBods As List(Of Body)
    Private firstActiveBod As Body
    Private alpha As Double
    ' Shared Reader for body frames
    Friend Shared bodyFrameReader As BodyFrameReader

    ' Shared SkeletalTracker object which tracks detected Kinect bodies as skeletons with to XYZ co-ordinates
    Friend Shared skelTracker As SkeletalTracker

    ' Gesture detector for the tracked body (a custom-made class in this project)
    Friend Shared gestureDetector As GestureDetector

    ' Track skeletal data (or not) flag
    Private trackBodies As Boolean = False

    ' Screens for a two screen set-up
    Private primaryScreen As Screen
    Private secondScreen As Screen

    ' Fanuc stuff
    Public Robot As FRCRobot
    Public CurPos As FRCCurGroupPosition
    Public Fanuc0 As FRCXyzWpr
    Public RobotMoving As FRCUOPIOSignal
    Public RobotIO As FRCIOTypes
    Public RobotSignals As FRCIOSignal
    Public RobotConfig As FRCConfig
#Region "Fanuc"
    Private Sub ConnectToRobot()
        Robot = New FRCRobot
        AppendDebug("Now Connecting")
        Try
            Robot.Connect("10.35.188.118")
        Catch ex As Exception
            AppendDebug("Could not connect")
            AppendDebug(ex.Message)
        End Try
        If Robot.RemoteMotionMaster <> FRERemoteMotionMasterConstants.frHostMaster Then
            Try
                Robot.RemoteMotionMaster = FRERemoteMotionMasterConstants.frHostMaster
            Catch ex As Exception
                AppendDebug("Couldnt lock motion group")
                AppendDebug(ex.Message)
            End Try
        End If
    End Sub
    Private Sub StartProgram()
        program = Robot.Programs.Item("KINECT2")
        program.IgnoreAbort(FRETaskIgnoreConstants.frIgnoreCommand) = False
        program.Run(FREStepTypeConstants.frStepNone, 1, FREExecuteConstants.frExecuteFwd)
        task = Robot.Tasks.Item(Name:="KINECT2")
        task.IgnoreAbort(FRETaskIgnoreConstants.frIgnoreCommand) = False
        ' program.IgnoreAbort(FRETaskIgnoreConstants.frIgnoreCommand) = False
        AppendDebug("Program Started")
    End Sub
   
    Private Sub ObtainInitValues()
        CurPos = Robot.CurPosition.Group(1, FRECurPositionConstants.frUserDisplayType)
        Fanuc0 = CurPos.Formats(FRETypeCodeConstants.frXyzWpr)
        Kinect0X = RHXPos
        Kinect0Y = RHYPos
        Kinect0Z = RHZPos
        Kinect0W = Fanuc0.W
        Kinect0P = Fanuc0.P
        Kinect0R = Fanuc0.R
        RobotIO = Robot.IOTypes
        RobotMoving = RobotIO.Item(FREIOTypeConstants.frUOPOutType).Signals.Item(3)
        AbsLocMem = Pow(Pow(RHXPos, 2) + Pow(RHYPos, 2) + Pow(RHZPos, 2), 0.5)
        AppendDebug("initialized")
        TempSysPos = Robot.RegPositions.Item(3).Group(1)
        TempPos = TempSysPos.Formats(FRETypeCodeConstants.frXyzWpr)
        TempPos.X = Fanuc0.X
        TempPos.Y = Fanuc0.Y
        TempPos.Z = Fanuc0.Z
        TempPos.P = Fanuc0.P
        TempPos.W = Fanuc0.W
        TempPos.R = Fanuc0.R
        TempSysPos.Update()
        IsPosReachable.Text = "Waiting for new Posn"
        IsPosReachable.ForeColor = Color.Black
        IsPosReachable.BackColor = Color.Gray
        missedupdate = 0
        outofboundarycounter = 0
    End Sub
    Private Sub InitializeRobot()
        ' This routine initializes the proper user and tool frame
        robotuframe = Robot.RegNumerics(20)
        robottoolframe = Robot.RegNumerics(21)
        robotuframe.NoUpdate = True
        robottoolframe.NoUpdate = True
        rufnumber = robotuframe.Value
        rtfnumber = robottoolframe.Value
        rufnumber.RegLong = 4
        rtfnumber.RegLong = 1
        robotuframe.Update()
        robottoolframe.Update()
    End Sub
    Private Sub WriteRegister()
        alpha = 1.0
        TempSysPos = Robot.RegPositions.Item(3).Group(1)
        PosToCheck = Robot.RegPositions.Item(10).Group(1)
        PosToCheckXYZ = PosToCheck.Formats(FRETypeCodeConstants.frXyzWpr)
        TempPos = TempSysPos.Formats(FRETypeCodeConstants.frXyzWpr)
        TempPos.X = alpha * 1000 * (RHXPos - Kinect0X) + Fanuc0.X
        TempPos.Y = alpha * 1000 * (RHYPos - Kinect0Y) + Fanuc0.Y
        TempPos.Z = alpha * 1000 * (RHZPos - Kinect0Z) + Fanuc0.Z
        TempPos.P = Kinect0P
        TempPos.W = Kinect0W
        TempPos.R = Kinect0R
        PosToCheckXYZ.X = TempPos.X
        PosToCheckXYZ.Y = TempPos.Y
        PosToCheckXYZ.Z = TempPos.Z
        PosToCheckXYZ.P = TempPos.P
        PosToCheckXYZ.W = TempPos.W
        PosToCheckXYZ.R = TempPos.R
        If PosToCheckXYZ.Y > 180 Then
            Try
                PosToCheck.CheckReach()
                Try
                    TempSysPos.Update()
                    IsPosReachable.Text = "Posn OK"
                    IsPosReachable.ForeColor = Color.LightGreen
                    IsPosReachable.BackColor = Color.Green
                Catch ex As Exception
                    missedupdate = missedupdate + 1
                    AppendDebug("Couldnt Copy PR")
                    AppendDebug(ex.Message)
                End Try
            Catch ex As Exception
                IsPosReachable.Text = "Out of Bounds"
                IsPosReachable.ForeColor = Color.LightPink
                IsPosReachable.BackColor = Color.Red
                AppendDebug("Not Reachable")
                AppendDebug(ex.Message)
                outofboundarycounter = outofboundarycounter + 1
            End Try
        Else
            IsPosReachable.Text = "Out of Bounds"
            IsPosReachable.ForeColor = Color.LightPink
            IsPosReachable.BackColor = Color.Red
            AppendDebug("Not Reachable, lowwer bound")
            outofboundarycounter = outofboundarycounter + 1

        End If
    End Sub
#End Region
#Region "Form"
    Private Sub AbortProgram(mode As Integer)
        Try
            If Robot.IsConnected() Then
                task = Robot.Tasks.Item(Name:="KINECT2")
                task.Abort(True, True)
                If Robot.RemoteMotionMaster <> FRERemoteMotionMasterConstants.frHostMaster Then
                    Try
                        Robot.RemoteMotionMaster = FRERemoteMotionMasterConstants.frHostMaster
                    Catch ex As Exception
                        AppendDebug("Couldnt lock motion group")
                        AppendDebug(ex.Message)
                    End Try
                End If
            End If

            If mode = 1 Then
                Try
                    Threading.Thread.Sleep(500)
                    HomeSysPos = Robot.RegPositions.Item(1).Group(1)
                    HomeSysPos.Moveto()
                Catch ex As Exception
                    AppendDebug("Couldnt move to home")
                    AppendDebug(ex.Message)
                End Try
            End If
            AppendDebug("Program Aborted")
        Catch ex As Exception
            AppendDebug("Not Connected")
            AppendDebug(ex.Message)
        End Try
    End Sub

    Private Sub StartScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim result As Integer = MessageBox.Show("Are you sure you want to shutdown?", "Program ShutDown Requested", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.No Then
            e.Cancel = True
        ElseIf result = DialogResult.Yes Then
            Dim result2 As Integer = MessageBox.Show("Do you want to move the robot home before shutting down?", "Program ShutDown Requested", MessageBoxButtons.YesNo)
                If result2 = DialogResult.Yes Then
                    AbortProgram(1)
                    MsgBox("Shutting Down, Moving Robot Home")
                End If
            ElseIf result = DialogResult.Cancel Then
                e.Cancel = True
            End If

    End Sub


    Private Sub StartScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Common.rTimer = New Stopwatch
        primaryScreen = Screen.PrimaryScreen
        If Screen.AllScreens.Where(Function(s) Not s.Primary).Count > 0 Then
            secondScreen = Screen.AllScreens.Where(Function(s) Not s.Primary).First
        Else
            secondScreen = Screen.PrimaryScreen
        End If
        ' Want smoothest re-draws
        Me.DoubleBuffered = True
        ' Get the default Kinect sensor (if attached)
        kSensor = KinectSensor.GetDefault
        ' Add an event handler to cover sensor availability changes (connected or not)
        AddHandler kSensor.IsAvailableChanged, AddressOf Sensor_IsAvailableChanged
        ' Try to open the sensor for reading data
        kSensor.Open()
        ' Initialize the skeletal tracker for this sensor
        skelTracker = New SkeletalTracker(kSensor)
        ' Gesture tracker
        gestureDetector = New GestureDetector(kSensor, KinectFeedbacktext)
        ' open the reader for the body frames
        bodyFrameReader = kSensor.BodyFrameSource.OpenReader()
        ' Add an event handler to the reader to fire when a Kinect frame arrives (every 1/30s)
        AddHandler bodyFrameReader.FrameArrived, AddressOf Reader_BodyFrameArrived
        ' Show this form on the primary display and the stimulus form to the secondary
        BindToScreen(Me, primaryScreen)
        RobotMovingDisplay.Text = "STILL"
        RobotMovingDisplay.BackColor = Color.LightGray
        RobotMovingDisplay.ForeColor = Color.Gray
        Initialized = False
        IsPosReachable.Text = "Not Started"
        IsPosReachable.ForeColor = Color.Black
        IsPosReachable.BackColor = Color.Gray
    End Sub
    ' Show or hide skeletal display
    Private Sub chkShowSkel_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowSkel.CheckedChanged
        If chkShowSkel.Checked Then
            trackBodies = True
            chkShowSkel.Image = My.Resources.stickman
            chkShowSkel.Text = "ON"
            ' txtGestures.Text = "Time (ms),Standing,Right Kick (X),Right Kick,Left Kick (X),Left Kick" & NL
            Common.rTimer.Restart()
        Else
            trackBodies = False
            chkShowSkel.Image = My.Resources.no_stickman
            chkShowSkel.Text = "OFF"
            Common.rTimer.Reset()
        End If
    End Sub
    ' Show or hide skeletal display
    Private Sub FanucEnable_CheckedChanged(sender As Object, e As EventArgs) Handles FanucEnable.CheckedChanged
        If FanucEnable.Checked Then
            ConnectToRobot()
            ObtainInitValues()
            InitializeRobot()
            StartProgram()
            Initialized = True
            FanucEnable.Text = "ON"
        ElseIf Not FanucEnable.Checked And Initialized = True Then
            Initialized = False
            AbortProgram(0)
            FanucEnable.Text = "OFF"
        Else
            FanucEnable.Text = "OFF"
        End If
    End Sub
    ' Show a screen on a certain display
    Private Sub BindToScreen(ByVal frm As Form, scr As Screen)
        Dim formPos As Point = frm.Location
        Dim formOffset = GetFormOffsetPosition(frm)
        Dim newPos = scr.Bounds.Location + formOffset
        frm.Location = newPos
    End Sub

#End Region

#Region "Kinect Sensor"
    ' Handles the event when a physical sensor becomes unavailable/available (e.g. paused, closed, unplugged)
    Private Sub Sensor_IsAvailableChanged(sender As Object, e As IsAvailableChangedEventArgs)
        If kSensor.IsAvailable Then
            lblSensorStatus.Text = "Kinect" & NL & "Found"
            lblSensorStatus.ForeColor = Color.Green
            lblSensorStatus.BackColor = Color.PaleGreen
            picConn.Image = My.Resources.connected
            picConn.BackColor = Color.PaleGreen
        Else
            lblSensorStatus.Text = "Kinect" & NL & "not" & NL & "Found"
            lblSensorStatus.ForeColor = Color.Red
            lblSensorStatus.BackColor = Color.MistyRose
            picConn.Image = My.Resources.disconnected
            picConn.BackColor = Color.MistyRose
        End If
    End Sub

    ' Handles the body frame data arriving from the sensor and updates the associated gesture detector object for each body
    Private Sub Reader_BodyFrameArrived(sender As Object, e As BodyFrameArrivedEventArgs)
        ' Get a temporary, disposable reference to the acquired Kinect body frame
        Using bodyFrame As BodyFrame = e.FrameReference.AcquireFrame
            If Not trackBodies OrElse IsNothing(bodyFrame) Then
                ' Not tracking bodies or no body frame available to track - pause the gesture detector and update status only
                gestureDetector.IsPaused = True
                UpdateTrackingStatus()
            Else
                ' The first time GetAndRefreshBodyData is called, Kinect will allocate each Body in the array.
                ' As long as those body objects are not disposed and not set to null the body objects will be re-used.
                bodyFrame.GetAndRefreshBodyData(allBods)
                ' Find the bodies that are being actively tracked
                activeBods = skelTracker.GetActiveBodies(allBods)
                If activeBods.Count = 0 Then
                    ' No active bodies, so no need to track
                    gestureDetector.IsPaused = True
                    UpdateTrackingStatus(0)
                Else
                    ' Enable gesture detection just for the first active body
                    gestureDetector.TrackingId = activeBods(0).TrackingId
                    gestureDetector.IsPaused = False
                    UpdateTrackingStatus(activeBods.Count)
                    ' Draw just the first active body skeleton using bitmap image generated via the SkeletalTracker
                    firstActiveBod = activeBods(0)
                    Dim image As Bitmap = skelTracker.DrawSkeleton(firstActiveBod, picSkeleton.Width, picSkeleton.Height)
                    picSkeleton.Image = image
                    RHXPos = firstActiveBod.Joints(JointType.HandRight).Position.X
                    RHYPos = firstActiveBod.Joints(JointType.HandRight).Position.Y
                    RHZPos = firstActiveBod.Joints(JointType.HandRight).Position.Z
                    NewLocMem = Pow(Pow(RHXPos, 2) + Pow(RHYPos, 2) + Pow(RHZPos, 2), 0.5)
                    If Abs(AbsLocMem - NewLocMem) > 0.005 And Abs(AbsLocMem - NewLocMem) < 1.5 Then
                        If Initialized Then
                            WriteRegister()
                        End If
                        AbsLocMem = NewLocMem
                    End If
                End If
            End If
        End Using
    End Sub

    Private Function GetKinectCapabilities() As String
        Dim capStr As String = "Kinect sensor detected with SensorID = " & kSensor.UniqueKinectId & NL
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Gamechat) Then
            capStr &= "Kinect has In-Game Chat Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Expressions) Then
            capStr &= "Kinect has Facial Expression Recognition Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Face) Then
            capStr &= "Kinect has Facial Recognition Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Audio) Then
            capStr &= "Kinect has Audio Capabilities" & NL
        End If
        If kSensor.KinectCapabilities.HasFlag(KinectCapabilities.Vision) Then
            capStr &= "Kinect has Vision Capabilities" & NL
        End If
        If kSensor.KinectCapabilities = KinectCapabilities.None Then
            capStr = "Kinect detected but is has no capabilities - is it broken?"
        End If
        Return capStr
    End Function

#End Region

#Region "Helper Methods"

    ' Determine the given form's offset position on its screen
    Private Function GetFormOffsetPosition(ByVal frm As Form) As Point
        Dim formPos As Point = frm.Location
        Dim currScreen = If(primaryScreen.Bounds.Contains(formPos), primaryScreen, secondScreen)
        Dim offset As Point = formPos - currScreen.Bounds.Location
        Return offset
    End Function

    ' Method which updates the tracking status label
    Private Sub UpdateTrackingStatus(Optional ByVal bodyCount As Integer = 0)
        If Not trackBodies Then
            lblBodiesStatus.Text = "Body" & NL & "Tracking" & NL & "Disabled"
            lblBodiesStatus.BackColor = Color.MistyRose
            lblBodiesStatus.ForeColor = Color.Red
        Else
            If bodyCount = 0 Then
                gestureDetector.IsPaused = True
                lblBodiesStatus.Text = "No Bodies" & NL & "Found" & NL & "for" & NL & "Tracking"
                lblBodiesStatus.BackColor = Color.LightBlue
                lblBodiesStatus.ForeColor = Color.Navy
            Else
                ' Got at least one active body, so track the first body for gestures and update the status label
                lblBodiesStatus.Text = bodyCount & NL & "Bodies" & NL & "Found" & NL & "Tracking" & NL & "1st One"
                lblBodiesStatus.BackColor = Color.LightGreen
                lblBodiesStatus.ForeColor = Color.Green
            End If
        End If
        If FanucEnable.Checked Then
            FanucDescription.Text = "Fanuc" & NL & "Tracking" & NL & "Enabled"
            FanucDescription.BackColor = Color.LightGreen
            FanucDescription.ForeColor = Color.Green
            If RobotMoving.Value = False Then
                RobotMovingDisplay.Text = "STILL"
                RobotMovingDisplay.BackColor = Color.LightGray
                RobotMovingDisplay.ForeColor = Color.Gray
            Else
                RobotMovingDisplay.Text = "MOVING"
                RobotMovingDisplay.BackColor = Color.LightGreen
                RobotMovingDisplay.ForeColor = Color.Green
            End If

        Else
            FanucDescription.Text = "Fanuc" & NL & "Tracking" & NL & "Disabled"
            FanucDescription.BackColor = Color.MistyRose
            FanucDescription.ForeColor = Color.Red
        End If

    End Sub
    Private Sub AppendDebug(ByRef text As String)
        txtDebugger.AppendText(text)
    End Sub

#End Region

    Private Sub RobotManualControl_Click(sender As Object, e As EventArgs) Handles RobotManualControl.Click
        Dim RobotManualControl As New RobotManualControl
        RobotManualControl.Show()
        MessageBox.Show("TEST")
    End Sub

End Class
