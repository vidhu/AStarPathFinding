using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.vidhucraft.cs.AStar;

namespace AStartPathFinding
{
    public partial class Form1 : Form
    {
        Dictionary<string, Tile> tiles;

        public Form1()
        {
            InitializeComponent();
            tiles = generateMap(7, 5);
        }

        /// <summary>
        /// Generates a map of given size and returs a list of these tiles
        /// </summary>
        /// <param name="width">Numbers of tile x</param>
        /// <param name="height">Numbers of tile y</param>
        /// <returns></returns>
        public Dictionary<string, Tile> generateMap(int width, int height)
        {
            //Set windows size
            this.Size = new System.Drawing.Size(width*25 + 27, height*25 + 98);

            //Add grid tiles
            Dictionary<string, Tile> tiles = new Dictionary<string, Tile>(width * height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Tile pic_node = GridFactory.makeTile(TileType.Walkable);
                    pic_node.Name = "tile_" + i + "_" + j;
                    pic_node.x = i;
                    pic_node.y = j;
                    pic_node.MouseDown += tile_MouseDown;
                    pic_node.Location = new Point((i*25)+5, (j*25)+5);
                    this.Controls.Add(pic_node);        //Add to GUI
                    tiles.Add(i + "," + j, pic_node);   //Add to container
                }
            }
            
            //Return tiles container
            return tiles;
        }


        public void Run(Dictionary<string, Tile> tiles, Size size)
        {
            //Generate Nodes Based on Map
            Node[,] node = new Node[size.Width, size.Height];
            foreach(KeyValuePair<string, Tile> tilepair in tiles){
                Tile tile = tilepair.Value;
                node[tile.x, tile.y] = new Node(tile.x, tile.y, tile.type);
            }

            Map map = new Map(node);
            AStar astar = new AStar(map);
            astar.execute();

            foreach(Node n in map.path)
            {
                if (n.type == TileType.Start)
                    continue;
                this.tiles[n.X.ToString() + "," + n.Y.ToString()].BackColor = Color.FromArgb(13, 88, 166);
            }
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            this.Run(tiles, new Size(7, 5));
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            tiles = generateMap(7, 5);
        }
    }
}
