Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraMap

Namespace MapBubbleItem
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a layer to show vector items.
			Dim itemsLayer As New VectorItemsLayer()
			mapControl1.Layers.Add(itemsLayer)

			' Create a storage to provide data for the vector layer.
			Dim storage As New MapItemStorage()
			itemsLayer.Data = storage

			' Create an array of Bubble items with different values, sizes and locations.
			Dim bubble1 As New MapBubble() With {.Argument = "A", .Value = 200, .Location = New GeoPoint(-45, -60), .Size = 20}
			Dim bubble2 As New MapBubble() With {.Argument = "B", .Value = 400, .Location = New GeoPoint(-45, 0), .Size = 40}
			Dim bubble3 As New MapBubble() With {.Argument = "C", .Value = 800, .Location = New GeoPoint(-45, 60), .Size = 80}
			storage.Items.AddRange(New MapItem() { bubble1, bubble2, bubble3 })

			' Provide color indexes to bubbles as attributes.
			Dim i As Integer = 0
			For Each bubble As MapItem In storage.Items
				bubble.Attributes.Add(New MapItemAttribute() With {.Name = "Color", .Value = i})
				i += 1
			Next bubble

			' Create a colorizer to provide colors for bubble items.
			Dim colorizer As New ColorIndexColorizer()
			itemsLayer.Colorizer = colorizer

			' Add colors to the colorizer.
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.Coral, .Text = "Category A"})
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.Orange, .Text = "Category B"})
			colorizer.ColorItems.Add(New ColorizerColorTextItem() With {.Color = Color.LightBlue, .Text = "Category C"})

			' Load color indexes from bubbles via the 'Color' attribute
			colorizer.ColorIndexProvider = New ShapeAttributeColorIndexProvider() With {.AttributeName = "Color"}


			' Show a color legend.
			mapControl1.Legends.Add(New ColorListLegend() With {.Layer = itemsLayer})
		End Sub

	End Class

End Namespace
