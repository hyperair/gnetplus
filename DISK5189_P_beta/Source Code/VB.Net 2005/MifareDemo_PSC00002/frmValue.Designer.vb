<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmValue
#Region "Windows Form 設計工具產生的程式碼 "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'此為 Windows Form 設計工具所需的呼叫。
		InitializeComponent()
	End Sub
	'Form 覆寫 Dispose 以清除元件清單。
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'為 Windows Form 設計工具的必要項
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public WithEvents _txtValue_1 As System.Windows.Forms.TextBox
	Public WithEvents _txtValue_0 As System.Windows.Forms.TextBox
	Public WithEvents _cmdValue_3 As System.Windows.Forms.Button
	Public WithEvents _cmdValue_2 As System.Windows.Forms.Button
	Public WithEvents _cmdValue_1 As System.Windows.Forms.Button
	Public WithEvents _cmdValue_0 As System.Windows.Forms.Button
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents labValue As System.Windows.Forms.Label
	Public WithEvents cmdValue As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents txtValue As Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray
	'注意: 以下為 Windows Form 設計工具所需的程序
	'可以使用 Windows Form 設計工具進行修改。
	'請不要使用程式碼編輯器進行修改。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValue))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._txtValue_1 = New System.Windows.Forms.TextBox
        Me._txtValue_0 = New System.Windows.Forms.TextBox
        Me._cmdValue_3 = New System.Windows.Forms.Button
        Me._cmdValue_2 = New System.Windows.Forms.Button
        Me._cmdValue_1 = New System.Windows.Forms.Button
        Me._cmdValue_0 = New System.Windows.Forms.Button
        Me.Image1 = New System.Windows.Forms.PictureBox
        Me.labValue = New System.Windows.Forms.Label
        Me.cmdValue = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.txtValue = New Microsoft.VisualBasic.Compatibility.VB6.TextBoxArray(Me.components)
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        '_txtValue_1
        '
        Me._txtValue_1.AcceptsReturn = True
        Me._txtValue_1.BackColor = System.Drawing.SystemColors.Window
        Me._txtValue_1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtValue_1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValue.SetIndex(Me._txtValue_1, CType(1, Short))
        Me._txtValue_1.Location = New System.Drawing.Point(120, 100)
        Me._txtValue_1.MaxLength = 9
        Me._txtValue_1.Name = "_txtValue_1"
        Me._txtValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtValue_1.Size = New System.Drawing.Size(87, 21)
        Me._txtValue_1.TabIndex = 5
        Me._txtValue_1.Text = "0"
        Me._txtValue_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_txtValue_0
        '
        Me._txtValue_0.AcceptsReturn = True
        Me._txtValue_0.BackColor = System.Drawing.SystemColors.Window
        Me._txtValue_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._txtValue_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtValue.SetIndex(Me._txtValue_0, CType(0, Short))
        Me._txtValue_0.Location = New System.Drawing.Point(120, 70)
        Me._txtValue_0.MaxLength = 9
        Me._txtValue_0.Name = "_txtValue_0"
        Me._txtValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._txtValue_0.Size = New System.Drawing.Size(87, 21)
        Me._txtValue_0.TabIndex = 3
        Me._txtValue_0.Text = "0"
        Me._txtValue_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        '_cmdValue_3
        '
        Me._cmdValue_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValue_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValue_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValue.SetIndex(Me._cmdValue_3, CType(3, Short))
        Me._cmdValue_3.Location = New System.Drawing.Point(48, 98)
        Me._cmdValue_3.Name = "_cmdValue_3"
        Me._cmdValue_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValue_3.Size = New System.Drawing.Size(73, 25)
        Me._cmdValue_3.TabIndex = 4
        Me._cmdValue_3.Text = "Decrement"
        Me._cmdValue_3.UseVisualStyleBackColor = False
        '
        '_cmdValue_2
        '
        Me._cmdValue_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValue_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValue_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValue.SetIndex(Me._cmdValue_2, CType(2, Short))
        Me._cmdValue_2.Location = New System.Drawing.Point(48, 68)
        Me._cmdValue_2.Name = "_cmdValue_2"
        Me._cmdValue_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValue_2.Size = New System.Drawing.Size(73, 25)
        Me._cmdValue_2.TabIndex = 2
        Me._cmdValue_2.Text = "Increment"
        Me._cmdValue_2.UseVisualStyleBackColor = False
        '
        '_cmdValue_1
        '
        Me._cmdValue_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValue_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValue_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValue.SetIndex(Me._cmdValue_1, CType(1, Short))
        Me._cmdValue_1.Location = New System.Drawing.Point(48, 38)
        Me._cmdValue_1.Name = "_cmdValue_1"
        Me._cmdValue_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValue_1.Size = New System.Drawing.Size(73, 25)
        Me._cmdValue_1.TabIndex = 1
        Me._cmdValue_1.Text = "Read Value"
        Me._cmdValue_1.UseVisualStyleBackColor = False
        '
        '_cmdValue_0
        '
        Me._cmdValue_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValue_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValue_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValue.SetIndex(Me._cmdValue_0, CType(0, Short))
        Me._cmdValue_0.Location = New System.Drawing.Point(48, 8)
        Me._cmdValue_0.Name = "_cmdValue_0"
        Me._cmdValue_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValue_0.Size = New System.Drawing.Size(73, 25)
        Me._cmdValue_0.TabIndex = 0
        Me._cmdValue_0.Text = "Format"
        Me._cmdValue_0.UseVisualStyleBackColor = False
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(6, 8)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(32, 32)
        Me.Image1.TabIndex = 6
        Me.Image1.TabStop = False
        '
        'labValue
        '
        Me.labValue.BackColor = System.Drawing.SystemColors.Control
        Me.labValue.Cursor = System.Windows.Forms.Cursors.Default
        Me.labValue.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labValue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labValue.Location = New System.Drawing.Point(120, 40)
        Me.labValue.Name = "labValue"
        Me.labValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labValue.Size = New System.Drawing.Size(87, 21)
        Me.labValue.TabIndex = 6
        Me.labValue.Text = "0"
        Me.labValue.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdValue
        '
        '
        'txtValue
        '
        '
        'frmValue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(223, 131)
        Me.Controls.Add(Me._txtValue_1)
        Me.Controls.Add(Me._txtValue_0)
        Me.Controls.Add(Me._cmdValue_3)
        Me.Controls.Add(Me._cmdValue_2)
        Me.Controls.Add(Me._cmdValue_1)
        Me.Controls.Add(Me._cmdValue_0)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.labValue)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValue"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Card Value"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class