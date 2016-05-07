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
        public void tile_MouseDown(object sender, MouseEventArgs e)
        {
            Tile tile = (Tile)sender;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tile_Click(tile);
                    break;
                case MouseButtons.Right:
                    tile_RightClick(tile);
                    break;
            }
        }

        public void tile_Click(Tile sender)
        {
            Tile tile = (Tile)sender;
            if (tile.type == TileType.Walkable)
            {
                GridFactory.setTileType(ref tile, TileType.UnWalkable);
            }
            else
            {
                GridFactory.setTileType(ref tile, TileType.Walkable);
            }
        }

        public void tile_RightClick(Tile sender)
        {
            Tile tile = (Tile)sender;
            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add(new MenuItem("Start Position", setStart));
            cm.MenuItems.Add(new MenuItem("End Position", setEnd));
            cm.Show(tile, new Point(10, 10));
        }

        public void setStart(object sender, EventArgs e){
            Tile tile = (Tile)((ContextMenu)((MenuItem)sender).Parent).SourceControl;
            GridFactory.setTileType(ref tile, TileType.Start);
        }

        public void setEnd(object sender, EventArgs e)
        {
            Tile tile = (Tile)((ContextMenu)((MenuItem)sender).Parent).SourceControl;
            GridFactory.setTileType(ref tile, TileType.Destination);
        }
    }
}
