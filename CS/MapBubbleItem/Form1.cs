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
            VectorItemsLayer itemsLayer = new VectorItemsLayer() {
                Data = CreateData(),
                Colorizer = CreateColorizer()
            };
            mapControl1.Layers.Add(itemsLayer);

            // Show a color legend.
            mapControl1.Legends.Add(new ColorListLegend() { Layer = itemsLayer });
        }

        #region #CreateBubbles
        // Create a storage to provide data for the vector layer.
        private IMapDataAdapter CreateData() {
            MapItemStorage storage = new MapItemStorage();

            // Add Bubble charts with different values, sizes and 
            // locations to the storage's Items collection.
            storage.Items.Add( new MapBubble() {
                Argument = "A",
                Value = 200,
                Location = new GeoPoint(-45, -60),
                Size = 20,
                Group = 1,
                MarkerType = MarkerType.Diamond
            });
            storage.Items.Add( new MapBubble() {
                Argument = "B",
                Value = 400,
                Location = new GeoPoint(-45, 0),
                Size = 40,
                Group = 2,
                MarkerType = MarkerType.Plus
            });
            storage.Items.Add( new MapBubble() {
                Argument = "C",
                Value = 800,
                Location = new GeoPoint(-45, 60),
                Size = 80,
                Group = 1,
                MarkerType = MarkerType.Cross
            });

            return storage;
        }
        #endregion #CreateBubbles

        // Create a colorizer to provide colors for bubble items.    
        private MapColorizer CreateColorizer() {
            KeyColorColorizer colorizer = new KeyColorColorizer();

            // Add colors to the colorizer.
            colorizer.Colors.Add(Color.Coral);
            colorizer.Colors.Add(Color.Orange);
            colorizer.Colors.Add(Color.LightBlue);

            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "A", Name = "Category A" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "B", Name = "Category B" });
            colorizer.Keys.Add(new ColorizerKeyItem() { Key = "C", Name = "Category C" });

            // Load color indexes from bubbles via the 'Color' attribute
            colorizer.ItemKeyProvider = new ArgumentItemKeyProvider();

            return colorizer;
        }
    }

}
