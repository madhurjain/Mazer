Public Class Mazer_Form
    Dim xLoc, yLoc As Short
    Dim mTile(256) As MazeTile.MazeTile
    Dim mazeGroupBox As GroupBox
    Dim backPanel, gridPanel As Panel
    Dim ClickedOn, XClickLoc, YClickLoc, MyTolerance, MyWidth, MyHeight As Short
    Dim NextWall, PreviousWall, UpWall, DownWall As Short
    Dim gridShown As Boolean


    Private Sub Mazer_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        gridShown = 1
        mazeGroupBox = New GroupBox
        mazeGroupBox.Location = New Point(300, 0)
        mazeGroupBox.Size = New Size(700, 700)
        mazeGroupBox.Text = "Maze"
        Me.Controls.Add(mazeGroupBox)

        backPanel = New Panel
        backPanel.Location = New Point(25, 25)
        backPanel.Size = New Size(645, 645)
        backPanel.BackColor = Color.Red
        mazeGroupBox.Controls.Add(backPanel)

        xLoc = 2
        yLoc = 2

        For i As Short = 1 To 256

            mTile(i) = New MazeTile.MazeTile
            mTile(i).Location = New Point(xLoc, yLoc)
            mTile(i).WallThickness = 20
            mTile(i).Name = "mTile_" & i
            mTile(i).TileIndex = i
            backPanel.Controls.Add(mTile(i))
            AddHandler mTile(i).Click, AddressOf TileClicked

            If i Mod 16 = 0 Then
                xLoc = 2
                yLoc += mTile(i).Height
            Else
                xLoc += mTile(i).Width
            End If
        Next

        For i As Short = 0 To 15
            mTile(i + 1).NorthSet = 1
            mTile((i * 16) + 16).EastSet = 1
            mTile((i * 16) + 1).WestSet = 1
            mTile(i + 241).SouthSet = 1
        Next

        MyTolerance = mTile(1).ClickTolerance
        MyWidth = mTile(1).Width
        MyHeight = mTile(1).Height

        'gridPanel.SendToBack()
    End Sub
    Private Sub TileClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ClickedOn = sender.TileIndex
        XClickLoc = e.X
        YClickLoc = e.Y

        NextWall = ClickedOn + 1
        PreviousWall = ClickedOn - 1
        UpWall = ClickedOn - 16
        DownWall = ClickedOn + 16

        If XClickLoc < MyTolerance Then
            'MsgBox("Add wall to East of previous")
            If (ClickedOn - 1) Mod 16 = 0 Then
                mTile(ClickedOn).WestSet = 1
            Else
                If mTile(PreviousWall).EastSet() Then
                    mTile(PreviousWall).EastSet = 0
                Else
                    mTile(PreviousWall).EastSet = 1
                End If
            End If
        End If

        If XClickLoc > (MyWidth - MyTolerance) Then
            'MsgBox("Add wall to West of next")
            If ClickedOn Mod 16 = 0 Then
                mTile(ClickedOn).EastSet = 1
            Else
                If mTile(NextWall).WestSet() Then
                    mTile(NextWall).WestSet = 0
                Else
                    mTile(NextWall).WestSet = 1
                End If
            End If
        End If

        If YClickLoc < MyTolerance Then
            'MsgBox("Add wall to South of above")
            If ClickedOn >= 1 And ClickedOn <= 16 Then
                mTile(ClickedOn).NorthSet = 1
            Else
                If mTile(UpWall).SouthSet Then
                    mTile(UpWall).SouthSet = 0
                Else
                    mTile(UpWall).SouthSet = 1
                End If
            End If


        End If

        If YClickLoc > (MyHeight - MyTolerance) Then
            'MsgBox("Add wall to North of below")
            If ClickedOn >= 241 And ClickedOn <= 256 Then
                mTile(ClickedOn).SouthSet = 1
            Else
                If mTile(DownWall).NorthSet Then
                    mTile(DownWall).NorthSet = 0
                Else
                    mTile(DownWall).NorthSet = 1
                End If
            End If
        End If
    End Sub

   
    Private Sub btnGridToggle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGridToggle.Click
        gridShown = Not gridShown
        For i As Short = 1 To 256
            mTile(i).ShowGrid = gridShown
            mTile(i).Refresh()
        Next
    End Sub
End Class

