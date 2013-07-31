<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSaveKey
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
	Public WithEvents _cmdSave_1 As System.Windows.Forms.Button
	Public WithEvents _cmdSave_2 As System.Windows.Forms.Button
	Public WithEvents _cmdSave_0 As System.Windows.Forms.Button
	Public WithEvents txtKEY As System.Windows.Forms.TextBox
	Public WithEvents _optKEY_0 As System.Windows.Forms.RadioButton
	Public WithEvents _optKEY_1 As System.Windows.Forms.RadioButton
	Public WithEvents cmbSector As System.Windows.Forms.ComboBox
	Public WithEvents labStatus As System.Windows.Forms.Label
	Public WithEvents Image1 As System.Windows.Forms.PictureBox
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents cmdSave As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents optKEY As Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray
	'注意: 以下為 Windows Form 設計工具所需的程序
	'可以使用 Windows Form 設計工具進行修改。
	'請不要使用程式碼編輯器進行修改。
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSaveKey))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me._cmdSave_1 = New System.Windows.Forms.Button
		Me._cmdSave_2 = New System.Windows.Forms.Button
		Me._cmdSave_0 = New System.Windows.Forms.Button
		Me.txtKEY = New System.Windows.Forms.TextBox
		Me._optKEY_0 = New System.Windows.Forms.RadioButton
		Me._optKEY_1 = New System.Windows.Forms.RadioButton
		Me.cmbSector = New System.Windows.Forms.ComboBox
		Me.labStatus = New System.Windows.Forms.Label
		Me.Image1 = New System.Windows.Forms.PictureBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.cmdSave = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(components)
		Me.optKEY = New Microsoft.VisualBasic.Compatibility.VB6.RadioButtonArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.optKEY, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
		Me.Text = "Save Key To Reader EEPROM"
		Me.ClientSize = New System.Drawing.Size(387, 105)
		Me.Location = New System.Drawing.Point(3, 21)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "frmSaveKey"
		Me._cmdSave_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdSave_1.Text = "Save All"
		Me._cmdSave_1.Size = New System.Drawing.Size(89, 25)
		Me._cmdSave_1.Location = New System.Drawing.Point(288, 40)
		Me._cmdSave_1.TabIndex = 5
		Me._cmdSave_1.BackColor = System.Drawing.SystemColors.Control
		Me._cmdSave_1.CausesValidation = True
		Me._cmdSave_1.Enabled = True
		Me._cmdSave_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdSave_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdSave_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdSave_1.TabStop = True
		Me._cmdSave_1.Name = "_cmdSave_1"
		Me._cmdSave_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdSave_2.Text = "Exit"
		Me._cmdSave_2.Size = New System.Drawing.Size(89, 25)
		Me._cmdSave_2.Location = New System.Drawing.Point(288, 72)
		Me._cmdSave_2.TabIndex = 6
		Me._cmdSave_2.BackColor = System.Drawing.SystemColors.Control
		Me._cmdSave_2.CausesValidation = True
		Me._cmdSave_2.Enabled = True
		Me._cmdSave_2.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdSave_2.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdSave_2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdSave_2.TabStop = True
		Me._cmdSave_2.Name = "_cmdSave_2"
		Me._cmdSave_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me._cmdSave_0.Text = "Save"
		Me._cmdSave_0.Size = New System.Drawing.Size(89, 25)
		Me._cmdSave_0.Location = New System.Drawing.Point(288, 8)
		Me._cmdSave_0.TabIndex = 4
		Me._cmdSave_0.BackColor = System.Drawing.SystemColors.Control
		Me._cmdSave_0.CausesValidation = True
		Me._cmdSave_0.Enabled = True
		Me._cmdSave_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._cmdSave_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._cmdSave_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._cmdSave_0.TabStop = True
		Me._cmdSave_0.Name = "_cmdSave_0"
		Me.txtKEY.AutoSize = False
		Me.txtKEY.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.txtKEY.Size = New System.Drawing.Size(125, 21)
		Me.txtKEY.Location = New System.Drawing.Point(150, 42)
		Me.txtKEY.Maxlength = 12
		Me.txtKEY.TabIndex = 3
		Me.txtKEY.Text = "FFFFFFFFFFFF"
		Me.txtKEY.AcceptsReturn = True
		Me.txtKEY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.txtKEY.BackColor = System.Drawing.SystemColors.Window
		Me.txtKEY.CausesValidation = True
		Me.txtKEY.Enabled = True
		Me.txtKEY.ForeColor = System.Drawing.SystemColors.WindowText
		Me.txtKEY.HideSelection = True
		Me.txtKEY.ReadOnly = False
		Me.txtKEY.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.txtKEY.MultiLine = False
		Me.txtKEY.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.txtKEY.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.txtKEY.TabStop = True
		Me.txtKEY.Visible = True
		Me.txtKEY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.txtKEY.Name = "txtKEY"
		Me._optKEY_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optKEY_0.Text = "KEY_A"
		Me._optKEY_0.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._optKEY_0.Size = New System.Drawing.Size(59, 19)
		Me._optKEY_0.Location = New System.Drawing.Point(152, 12)
		Me._optKEY_0.TabIndex = 1
		Me._optKEY_0.Checked = True
		Me._optKEY_0.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optKEY_0.BackColor = System.Drawing.SystemColors.Control
		Me._optKEY_0.CausesValidation = True
		Me._optKEY_0.Enabled = True
		Me._optKEY_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optKEY_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._optKEY_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optKEY_0.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optKEY_0.TabStop = True
		Me._optKEY_0.Visible = True
		Me._optKEY_0.Name = "_optKEY_0"
		Me._optKEY_1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optKEY_1.Text = "KEY_B"
		Me._optKEY_1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._optKEY_1.Size = New System.Drawing.Size(59, 19)
		Me._optKEY_1.Location = New System.Drawing.Point(216, 12)
		Me._optKEY_1.TabIndex = 2
		Me._optKEY_1.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me._optKEY_1.BackColor = System.Drawing.SystemColors.Control
		Me._optKEY_1.CausesValidation = True
		Me._optKEY_1.Enabled = True
		Me._optKEY_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._optKEY_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._optKEY_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._optKEY_1.Appearance = System.Windows.Forms.Appearance.Normal
		Me._optKEY_1.TabStop = True
		Me._optKEY_1.Checked = False
		Me._optKEY_1.Visible = True
		Me._optKEY_1.Name = "_optKEY_1"
		Me.cmbSector.Size = New System.Drawing.Size(91, 21)
		Me.cmbSector.Location = New System.Drawing.Point(52, 11)
		Me.cmbSector.Items.AddRange(New Object(){"Sector 0", "Sector 1", "Sector 2", "Sector 3", "Sector 4", "Sector 5", "Sector 6", "Sector 7", "Sector 8", "Sector 9", "Sector 10", "Sector 11", "Sector 12", "Sector 13", "Sector 14", "Sector 15"})
		Me.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbSector.TabIndex = 0
		Me.cmbSector.BackColor = System.Drawing.SystemColors.Window
		Me.cmbSector.CausesValidation = True
		Me.cmbSector.Enabled = True
		Me.cmbSector.ForeColor = System.Drawing.SystemColors.WindowText
		Me.cmbSector.IntegralHeight = True
		Me.cmbSector.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmbSector.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmbSector.Sorted = False
		Me.cmbSector.TabStop = True
		Me.cmbSector.Visible = True
		Me.cmbSector.Name = "cmbSector"
		Me.labStatus.BackColor = System.Drawing.Color.FromARGB(128, 128, 128)
		Me.labStatus.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.labStatus.ForeColor = System.Drawing.Color.White
		Me.labStatus.Size = New System.Drawing.Size(273, 17)
		Me.labStatus.Location = New System.Drawing.Point(8, 80)
		Me.labStatus.TabIndex = 8
		Me.labStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.labStatus.Enabled = True
		Me.labStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.labStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.labStatus.UseMnemonic = True
		Me.labStatus.Visible = True
		Me.labStatus.AutoSize = False
		Me.labStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.labStatus.Name = "labStatus"
		Me.Image1.Size = New System.Drawing.Size(32, 32)
		Me.Image1.Location = New System.Drawing.Point(4, 14)
		Me.Image1.Image = CType(resources.GetObject("Image1.Image"), System.Drawing.Image)
		Me.Image1.Enabled = True
		Me.Image1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
		Me.Image1.Visible = True
		Me.Image1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Image1.Name = "Image1"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "KEY (HEX) : "
		Me.Label1.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Size = New System.Drawing.Size(89, 15)
		Me.Label1.Location = New System.Drawing.Point(52, 45)
		Me.Label1.TabIndex = 7
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(_cmdSave_1)
		Me.Controls.Add(_cmdSave_2)
		Me.Controls.Add(_cmdSave_0)
		Me.Controls.Add(txtKEY)
		Me.Controls.Add(_optKEY_0)
		Me.Controls.Add(_optKEY_1)
		Me.Controls.Add(cmbSector)
		Me.Controls.Add(labStatus)
		Me.Controls.Add(Image1)
		Me.Controls.Add(Label1)
		Me.cmdSave.SetIndex(_cmdSave_1, CType(1, Short))
		Me.cmdSave.SetIndex(_cmdSave_2, CType(2, Short))
		Me.cmdSave.SetIndex(_cmdSave_0, CType(0, Short))
		Me.optKEY.SetIndex(_optKEY_0, CType(0, Short))
		Me.optKEY.SetIndex(_optKEY_1, CType(1, Short))
		CType(Me.optKEY, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.cmdSave, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class