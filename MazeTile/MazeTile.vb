<ToolboxBitmap("MazeTile.ico")> _
Public Class MazeTile
    Dim XClickLoc, YClickLoc, MyWidth, MyHeight, MyWallThickness, MyIndex As Short
    Dim MyTolerance As Short = 6
    Dim Wall As Boolean() = {0, 0, 0, 0, 0, 0}
    Dim MyWallColor As System.Drawing.Color = Color.Red
    Dim myText As String
    Dim MyShowGrid, textShown As Boolean

    'North =1, East = 2, West = 3, South = 4

    Private Sub MazeTile_Click(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.Click
        XClickLoc = e.Location.X
        YClickLoc = e.Location.Y

        'MsgBox("X = " & XClickLoc & " Y= " & YClickLoc & " Width = " & MyWidth & " Height =" & MyHeight)
        If XClickLoc < MyTolerance Then
            'MsgBox("Add wall to West")
            Wall(3) = Not Wall(3)
            If Wall(3) Then
                DrawWall(3)
            Else
                Me.Refresh()
            End If
        End If
        If XClickLoc > (MyWidth - MyTolerance) Then
            'MsgBox("Add wall to East")
            Wall(2) = Not Wall(2)
            If Wall(2) Then
                DrawWall(2)
            Else
                Me.Refresh()
            End If
        End If
        If YClickLoc < MyTolerance Then
            'MsgBox("Add wall to North")
            Wall(1) = Not Wall(1)
            If Wall(1) Then
                DrawWall(1)
            Else
                Me.Refresh()
            End If
        End If
        If YClickLoc > (MyHeight - MyTolerance) Then
            'MsgBox("Add wall to South")
            Wall(4) = Not Wall(4)
            If Wall(4) Then
                DrawWall(4)
            Else
                Me.Refresh()
            End If
        End If

    End Sub

    Private Sub MazeTile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MyWidth = Me.Size.Width
        MyHeight = Me.Size.Height
        MyWallThickness = 3
        MyShowGrid = 1
        textShown = 1
    End Sub

    Private Sub DrawWall(ByVal NEWS As Short)
        Select Case NEWS
            Case 1
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(MyWallColor, MyWallThickness)
                gfx.DrawLine(myPen, 0, 0, MyWidth, 0)
            Case 2
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(MyWallColor, MyWallThickness)
                gfx.DrawLine(myPen, MyWidth, 0, MyWidth, MyHeight)
            Case 3
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(MyWallColor, MyWallThickness)
                gfx.DrawLine(myPen, 0, 0, 0, MyHeight)
            Case 4
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(MyWallColor, MyWallThickness)
                gfx.DrawLine(myPen, 0, MyHeight, MyWidth, MyHeight)
            Case Else
                MsgBox("Error adding wall")
        End Select
    End Sub


    Private Sub DrawMouse(ByVal Orientation As Short)
        Dim Points(2) As Point
        Select Case Orientation
            Case 1
                Points(0) = New Point(20, 10)
                Points(1) = New Point(10, 30)
                Points(2) = New Point(30, 30)
                Dim gfx As Graphics = Me.CreateGraphics
                gfx.FillPolygon(Brushes.Violet, Points)
            Case 2
                Points(0) = New Point(30, 20)
                Points(1) = New Point(10, 10)
                Points(2) = New Point(10, 30)
                Dim gfx As Graphics = Me.CreateGraphics
                gfx.FillPolygon(Brushes.Violet, Points)
            Case 3
                Points(0) = New Point(10, 20)
                Points(1) = New Point(30, 10)
                Points(2) = New Point(30, 30)
                Dim gfx As Graphics = Me.CreateGraphics
                gfx.FillPolygon(Brushes.Violet, Points)
            Case 4
                Points(0) = New Point(20, 30)
                Points(1) = New Point(10, 10)
                Points(2) = New Point(30, 10)
                Dim gfx As Graphics = Me.CreateGraphics
                gfx.FillPolygon(Brushes.Violet, Points)
            Case Else
                MsgBox("Error drawing mice")
        End Select
    End Sub
    Private Sub DrawWhiteBorder(ByVal NEWS As Short)
        Select Case NEWS
            Case 1
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(Color.White, 1)
                gfx.DrawLine(myPen, 0, 0, MyWidth, 0)
            Case 2
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(Color.White, 1)
                gfx.DrawLine(myPen, MyWidth, 0, MyWidth, MyHeight)
            Case 3
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(Color.White, 1)
                gfx.DrawLine(myPen, 0, 0, 0, MyHeight)
            Case 4
                Dim gfx As Graphics = Me.CreateGraphics
                Dim myPen As Pen = New Pen(Color.White, 1)
                gfx.DrawLine(myPen, 0, MyHeight, MyWidth, MyHeight)
            Case Else
                MsgBox("Error adding wall")
        End Select
    End Sub


    Private Sub MazeTile_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        For i As Short = 1 To 4
            If Wall(i) Then
                DrawWall(i)
            ElseIf ShowGrid Then
                DrawWhiteBorder(i)
            End If
        Next
        If textShown Then
            DrawString(myText)
        End If

    End Sub

    Private Sub DrawString(ByVal s As String)
        Dim myBrush As New SolidBrush(Color.White)
        Dim f As Font = New Font(Font.Bold, 14)
        Me.CreateGraphics.DrawString(s, f, myBrush, 8, 8)
    End Sub


    Public Property WallThickness() As Short
        Get
            WallThickness = MyWallThickness
        End Get
        Set(ByVal value As Short)
            MyWallThickness = value
        End Set
    End Property
    Public Property TileIndex() As Short
        Get
            TileIndex = MyIndex
        End Get
        Set(ByVal value As Short)
            MyIndex = value
        End Set
    End Property
    Public Property WallColor() As System.Drawing.Color
        Get
            WallColor = MyWallColor
        End Get
        Set(ByVal value As System.Drawing.Color)
            MyWallColor = value
        End Set
    End Property

    Public Property ClickTolerance() As Short
        Get
            ClickTolerance = MyTolerance
        End Get
        Set(ByVal value As Short)
            MyTolerance = value
        End Set
    End Property

    Public Property NorthSet() As Boolean
        Get
            NorthSet = Wall(1)
        End Get
        Set(ByVal value As Boolean)
            Wall(1) = value
            Me.Refresh()
        End Set
    End Property

    Public Property EastSet() As Boolean
        Get
            EastSet = Wall(2)
        End Get
        Set(ByVal value As Boolean)
            Wall(2) = value
            Me.Refresh()
        End Set
    End Property

    Public Property WestSet() As Boolean
        Get
            WestSet = Wall(3)
        End Get
        Set(ByVal value As Boolean)
            Wall(3) = value
            Me.Refresh()
        End Set
    End Property

    Public Property SouthSet() As Boolean
        Get
            SouthSet = Wall(4)
        End Get
        Set(ByVal value As Boolean)
            Wall(4) = value
            Me.Refresh()
        End Set
    End Property

    Public Property ShowGrid() As Boolean
        Get
            ShowGrid = MyShowGrid
        End Get
        Set(ByVal value As Boolean)
            MyShowGrid = value
        End Set
    End Property

    Public Overrides Property Text() As String
        Get
            Return myText
        End Get
        Set(ByVal Value As String)
            myText = Value
            DrawString(myText)
        End Set
    End Property

    Public Property ShowText() As Boolean
        Get
            Return textShown
        End Get
        Set(ByVal value As Boolean)
            textShown = value
            Me.Refresh()
        End Set
    End Property


End Class
