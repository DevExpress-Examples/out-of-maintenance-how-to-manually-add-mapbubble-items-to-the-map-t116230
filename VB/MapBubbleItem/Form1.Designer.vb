Imports Microsoft.VisualBasic
Imports System
Namespace MapBubbleItem
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim imageTilesLayer1 As New DevExpress.XtraMap.ImageTilesLayer()
			Dim openStreetMapDataProvider1 As New DevExpress.XtraMap.OpenStreetMapDataProvider()
			Me.mapControl1 = New DevExpress.XtraMap.MapControl()
			CType(Me.mapControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' mapControl1
			' 
			Me.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill
			imageTilesLayer1.DataProvider = openStreetMapDataProvider1
			Me.mapControl1.Layers.Add(imageTilesLayer1)
			Me.mapControl1.Location = New System.Drawing.Point(0, 0)
			Me.mapControl1.Name = "mapControl1"
			Me.mapControl1.Size = New System.Drawing.Size(1100, 543)
			Me.mapControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1100, 543)
			Me.Controls.Add(Me.mapControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.mapControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Public mapControl1 As DevExpress.XtraMap.MapControl

	End Class
End Namespace

