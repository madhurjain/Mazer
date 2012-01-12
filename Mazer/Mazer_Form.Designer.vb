<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mazer_Form
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
        Me.btnGridToggle = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnGridToggle
        '
        Me.btnGridToggle.Location = New System.Drawing.Point(16, 58)
        Me.btnGridToggle.Name = "btnGridToggle"
        Me.btnGridToggle.Size = New System.Drawing.Size(112, 30)
        Me.btnGridToggle.TabIndex = 0
        Me.btnGridToggle.Text = "Toggle &Grid"
        Me.btnGridToggle.UseVisualStyleBackColor = True
        '
        'Mazer_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(465, 374)
        Me.Controls.Add(Me.btnGridToggle)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Name = "Mazer_Form"
        Me.Text = "Mazer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGridToggle As System.Windows.Forms.Button

End Class
