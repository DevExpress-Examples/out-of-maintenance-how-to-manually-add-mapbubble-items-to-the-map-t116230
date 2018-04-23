using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraMap;

namespace MapBubbleItem {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a layer to show vector items.
            VectorItemsLayer itemsLayer = new VectorItemsLayer();
            mapControl1.Layers.Add(itemsLayer);

            // Create a storage to provide data for the vector layer.
            MapItemStorage storage = new MapItemStorage();
            itemsLayer.Data = storage;

            // Create an array of Bubble items with different values, sizes and locations.
            MapBubble bubble1 = new MapBubble() { Argument = "A", Value = 200, Location = new GeoPoint(-45, -60), Size = 20 };
            MapBubble bubble2 = new MapBubble() { Argument = "B", Value = 400, Location = new GeoPoint(-45, 0), Size = 40 };
            MapBubble bubble3 = new MapBubble() { Argument = "C", Value = 800, Location = new GeoPoint(-45, 60), Size = 80 };
            storage.Items.AddRange(new MapItem[] { bubble1, bubble2, bubble3 });

            // Provide color indexes to bubbles as attributes.
            int i = 0;
            foreach (MapItem bubble in storage.Items) {
                bubble.Attributes.Add(new MapItemAttribute() { Name = "Color", Value = i });
                i++;
            }

            // Create a colorizer to provide colors for bubble items.
            ColorIndexColorizer colorizer = new ColorIndexColorizer();
            itemsLayer.Colorizer = colorizer;

            // Add colors to the colorizer.
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.Coral, Text = "Category A" });
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.Orange, Text = "Category B" });
            colorizer.ColorItems.Add(new ColorizerColorTextItem() { Color = Color.LightBlue, Text = "Category C" });

            // Load color indexes from bubbles via the 'Color' attribute
            colorizer.ColorIndexProvider = new ShapeAttributeColorIndexProvider() { AttributeName = "Color" };

            
            // Show a color legend.
            mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });
        }

    }

}
