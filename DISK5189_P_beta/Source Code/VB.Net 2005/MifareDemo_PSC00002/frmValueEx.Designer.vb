<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmValueEx
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
	Public WithEvents txtTransferValue As System.Windows.Forms.TextBox
	Public WithEvents cboTransferBlock As System.Windows.Forms.ComboBox
	Public WithEvents _cmdValueOpt_5 As System.Windows.Forms.Button
	Public WithEvents txtDataRegister As System.Windows.Forms.TextBox
	Public WithEvents txtOptValue As System.Windows.Forms.TextBox
	Public WithEvents _cmdValueOpt_4 As System.Windows.Forms.Button
	Public WithEvents _cmdValueOpt_3 As System.Windows.Forms.Button
	Public WithEvents _cmdValueOpt_2 As System.Windows.Forms.Button
	Public WithEvents txtBlockValue As System.Windows.Forms.TextBox
	Public WithEvents cboBlock As System.Windows.Forms.ComboBox
	Public WithEvents _cmdValueOpt_1 As System.Windows.Forms.Button
	Public WithEvents _cmdValueOpt_0 As System.Windows.Forms.Button
	Public WithEvents labStatus As System.Windows.Forms.Label
	Public WithEvents _labCaptionis_1 As System.Windows.Forms.Label
	Public WithEvents _labCaptionis_0 As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Image2 As System.Windows.Forms.PictureBox
	Public WithEvents cmdValueOpt As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents labCaptionis As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'注意: 以下為 Windows Form 設計工具所需的程序
	'可以使用 Windows Form 設計工具進行修改。
	'請不要使用程式碼編輯器進行修改。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValueEx))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtTransferValue = New System.Windows.Forms.TextBox
        Me.cboTransferBlock = New System.Windows.Forms.ComboBox
        Me._cmdValueOpt_5 = New System.Windows.Forms.Button
        Me.txtDataRegister = New System.Windows.Forms.TextBox
        Me.txtOptValue = New System.Windows.Forms.TextBox
        Me._cmdValueOpt_4 = New System.Windows.Forms.Button
        Me._cmdValueOpt_3 = New System.Windows.Forms.Button
        Me._cmdValueOpt_2 = New System.Windows.Forms.Button
        Me.txtBlockValue = New System.Windows.Forms.TextBox
        Me.cboBlock = New System.Windows.Forms.ComboBox
        Me._cmdValueOpt_1 = New System.Windows.Forms.Button
        Me._cmdValueOpt_0 = New System.Windows.Forms.Button
        Me.labStatus = New System.Windows.Forms.Label
        Me._labCaptionis_1 = New System.Windows.Forms.Label
        Me._labCaptionis_0 = New System.Windows.Forms.Label
        Me.Image1 = New System.Windows.Forms.PictureBox
        Me.Image2 = New System.Windows.Forms.PictureBox
        Me.cmdValueOpt = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.labCaptionis = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmdValueOpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.labCaptionis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTransferValue
        '
        Me.txtTransferValue.AcceptsReturn = True
        Me.txtTransferValue.BackColor = System.Drawing.SystemColors.Control
        Me.txtTransferValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTransferValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtTransferValue.Location = New System.Drawing.Point(99, 358)
        Me.txtTransferValue.MaxLength = 0
        Me.txtTransferValue.Name = "txtTransferValue"
        Me.txtTransferValue.ReadOnly = True
        Me.txtTransferValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTransferValue.Size = New System.Drawing.Size(159, 22)
        Me.txtTransferValue.TabIndex = 11
        '
        'cboTransferBlock
        '
        Me.cboTransferBlock.BackColor = System.Drawing.SystemColors.Window
        Me.cboTransferBlock.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboTransferBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransferBlock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboTransferBlock.Location = New System.Drawing.Point(99, 334)
        Me.cboTransferBlock.Name = "cboTransferBlock"
        Me.cboTransferBlock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboTransferBlock.Size = New System.Drawing.Size(160, 24)
        Me.cboTransferBlock.TabIndex = 10
        '
        '_cmdValueOpt_5
        '
        Me._cmdValueOpt_5.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_5.Enabled = False
        Me._cmdValueOpt_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_5, CType(5, Short))
        Me._cmdValueOpt_5.Location = New System.Drawing.Point(55, 286)
        Me._cmdValueOpt_5.Name = "_cmdValueOpt_5"
        Me._cmdValueOpt_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_5.Size = New System.Drawing.Size(248, 27)
        Me._cmdValueOpt_5.TabIndex = 9
        Me._cmdValueOpt_5.Text = "Transfer"
        Me._cmdValueOpt_5.UseVisualStyleBackColor = False
        '
        'txtDataRegister
        '
        Me.txtDataRegister.AcceptsReturn = True
        Me.txtDataRegister.BackColor = System.Drawing.SystemColors.Control
        Me.txtDataRegister.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDataRegister.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDataRegister.Location = New System.Drawing.Point(55, 241)
        Me.txtDataRegister.MaxLength = 0
        Me.txtDataRegister.Name = "txtDataRegister"
        Me.txtDataRegister.ReadOnly = True
        Me.txtDataRegister.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDataRegister.Size = New System.Drawing.Size(246, 22)
        Me.txtDataRegister.TabIndex = 8
        '
        'txtOptValue
        '
        Me.txtOptValue.AcceptsReturn = True
        Me.txtOptValue.BackColor = System.Drawing.SystemColors.Window
        Me.txtOptValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtOptValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtOptValue.Location = New System.Drawing.Point(99, 130)
        Me.txtOptValue.MaxLength = 0
        Me.txtOptValue.Name = "txtOptValue"
        Me.txtOptValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtOptValue.Size = New System.Drawing.Size(158, 22)
        Me.txtOptValue.TabIndex = 7
        '
        '_cmdValueOpt_4
        '
        Me._cmdValueOpt_4.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_4, CType(4, Short))
        Me._cmdValueOpt_4.Location = New System.Drawing.Point(226, 181)
        Me._cmdValueOpt_4.Name = "_cmdValueOpt_4"
        Me._cmdValueOpt_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_4.Size = New System.Drawing.Size(77, 25)
        Me._cmdValueOpt_4.TabIndex = 6
        Me._cmdValueOpt_4.Text = "Restore"
        Me._cmdValueOpt_4.UseVisualStyleBackColor = False
        '
        '_cmdValueOpt_3
        '
        Me._cmdValueOpt_3.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_3, CType(3, Short))
        Me._cmdValueOpt_3.Location = New System.Drawing.Point(140, 181)
        Me._cmdValueOpt_3.Name = "_cmdValueOpt_3"
        Me._cmdValueOpt_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_3.Size = New System.Drawing.Size(77, 25)
        Me._cmdValueOpt_3.TabIndex = 5
        Me._cmdValueOpt_3.Text = "Decrement"
        Me._cmdValueOpt_3.UseVisualStyleBackColor = False
        '
        '_cmdValueOpt_2
        '
        Me._cmdValueOpt_2.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_2, CType(2, Short))
        Me._cmdValueOpt_2.Location = New System.Drawing.Point(54, 182)
        Me._cmdValueOpt_2.Name = "_cmdValueOpt_2"
        Me._cmdValueOpt_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_2.Size = New System.Drawing.Size(77, 25)
        Me._cmdValueOpt_2.TabIndex = 4
        Me._cmdValueOpt_2.Text = "Increment"
        Me._cmdValueOpt_2.UseVisualStyleBackColor = False
        '
        'txtBlockValue
        '
        Me.txtBlockValue.AcceptsReturn = True
        Me.txtBlockValue.BackColor = System.Drawing.SystemColors.Control
        Me.txtBlockValue.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtBlockValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBlockValue.Location = New System.Drawing.Point(99, 87)
        Me.txtBlockValue.MaxLength = 0
        Me.txtBlockValue.Name = "txtBlockValue"
        Me.txtBlockValue.ReadOnly = True
        Me.txtBlockValue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtBlockValue.Size = New System.Drawing.Size(159, 22)
        Me.txtBlockValue.TabIndex = 3
        '
        'cboBlock
        '
        Me.cboBlock.BackColor = System.Drawing.SystemColors.Window
        Me.cboBlock.Cursor = System.Windows.Forms.Cursors.Default
        Me.cboBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBlock.Enabled = False
        Me.cboBlock.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBlock.Location = New System.Drawing.Point(100, 64)
        Me.cboBlock.Name = "cboBlock"
        Me.cboBlock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cboBlock.Size = New System.Drawing.Size(159, 24)
        Me.cboBlock.TabIndex = 2
        '
        '_cmdValueOpt_1
        '
        Me._cmdValueOpt_1.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_1, CType(1, Short))
        Me._cmdValueOpt_1.Location = New System.Drawing.Point(184, 5)
        Me._cmdValueOpt_1.Name = "_cmdValueOpt_1"
        Me._cmdValueOpt_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_1.Size = New System.Drawing.Size(104, 24)
        Me._cmdValueOpt_1.TabIndex = 1
        Me._cmdValueOpt_1.Text = "Read Value"
        Me._cmdValueOpt_1.UseVisualStyleBackColor = False
        '
        '_cmdValueOpt_0
        '
        Me._cmdValueOpt_0.BackColor = System.Drawing.SystemColors.Control
        Me._cmdValueOpt_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._cmdValueOpt_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdValueOpt.SetIndex(Me._cmdValueOpt_0, CType(0, Short))
        Me._cmdValueOpt_0.Location = New System.Drawing.Point(71, 6)
        Me._cmdValueOpt_0.Name = "_cmdValueOpt_0"
        Me._cmdValueOpt_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._cmdValueOpt_0.Size = New System.Drawing.Size(103, 23)
        Me._cmdValueOpt_0.TabIndex = 0
        Me._cmdValueOpt_0.Text = "Format"
        Me._cmdValueOpt_0.UseVisualStyleBackColor = False
        '
        'labStatus
        '
        Me.labStatus.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.labStatus.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labStatus.Location = New System.Drawing.Point(-1, 390)
        Me.labStatus.Name = "labStatus"
        Me.labStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.labStatus.Size = New System.Drawing.Size(355, 24)
        Me.labStatus.TabIndex = 14
        Me.labStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        '_labCaptionis_1
        '
        Me._labCaptionis_1.AutoSize = True
        Me._labCaptionis_1.BackColor = System.Drawing.SystemColors.Control
        Me._labCaptionis_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._labCaptionis_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labCaptionis_1.ForeColor = System.Drawing.Color.Blue
        Me.labCaptionis.SetIndex(Me._labCaptionis_1, CType(1, Short))
        Me._labCaptionis_1.Location = New System.Drawing.Point(102, 114)
        Me._labCaptionis_1.Name = "_labCaptionis_1"
        Me._labCaptionis_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labCaptionis_1.Size = New System.Drawing.Size(45, 16)
        Me._labCaptionis_1.TabIndex = 13
        Me._labCaptionis_1.Text = "Value"
        Me._labCaptionis_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_labCaptionis_0
        '
        Me._labCaptionis_0.AutoSize = True
        Me._labCaptionis_0.BackColor = System.Drawing.SystemColors.Control
        Me._labCaptionis_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._labCaptionis_0.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._labCaptionis_0.ForeColor = System.Drawing.Color.Blue
        Me.labCaptionis.SetIndex(Me._labCaptionis_0, CType(0, Short))
        Me._labCaptionis_0.Location = New System.Drawing.Point(57, 215)
        Me._labCaptionis_0.Name = "_labCaptionis_0"
        Me._labCaptionis_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._labCaptionis_0.Size = New System.Drawing.Size(93, 16)
        Me._labCaptionis_0.TabIndex = 12
        Me._labCaptionis_0.Text = "Data Register"
        Me._labCaptionis_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Image1
        '
        Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
        Me.Image1.Location = New System.Drawing.Point(6, 8)
        Me.Image1.Name = "Image1"
        Me.Image1.Size = New System.Drawing.Size(32, 32)
        Me.Image1.TabIndex = 15
        Me.Image1.TabStop = False
        '
        'Image2
        '
        Me.Image2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Image2.Image = CType(resources.GetObject("Image2.Image"), System.Drawing.Image)
        Me.Image2.Location = New System.Drawing.Point(52, 4)
        Me.Image2.Name = "Image2"
        Me.Image2.Size = New System.Drawing.Size(254, 381)
        Me.Image2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Image2.TabIndex = 16
        Me.Image2.TabStop = False
        '
        'cmdValueOpt
        '
        '
        'frmValueEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(353, 414)
        Me.Controls.Add(Me.txtTransferValue)
        Me.Controls.Add(Me.cboTransferBlock)
        Me.Controls.Add(Me._cmdValueOpt_5)
        Me.Controls.Add(Me.txtDataRegister)
        Me.Controls.Add(Me.txtOptValue)
        Me.Controls.Add(Me._cmdValueOpt_4)
        Me.Controls.Add(Me._cmdValueOpt_3)
        Me.Controls.Add(Me._cmdValueOpt_2)
        Me.Controls.Add(Me.txtBlockValue)
        Me.Controls.Add(Me.cboBlock)
        Me.Controls.Add(Me._cmdValueOpt_1)
        Me.Controls.Add(Me._cmdValueOpt_0)
        Me.Controls.Add(Me.labStatus)
        Me.Controls.Add(Me._labCaptionis_1)
        Me.Controls.Add(Me._labCaptionis_0)
        Me.Controls.Add(Me.Image1)
        Me.Controls.Add(Me.Image2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New System.Drawing.Point(3, 21)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValueEx"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Card Value"
        CType(Me.Image1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Image2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmdValueOpt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.labCaptionis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class