using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace com.vidhucraft.cs.AStar
{
    public class GridFactory
    {
        public static Tile makeTile(TileType type)
        {
            Tile pic_gird = new Tile();
            pic_gird.Size = new Size(25, 25);
            pic_gird.BackColor = Color.FromArgb((int)type);
            pic_gird.type = type;
            pic_gird.BorderStyle = BorderStyle.FixedSingle;
            return pic_gird;
            
        }

        public static void setTileType(ref Tile tile, TileType type){
            tile.type = type;
            tile.BackColor = Color.FromArgb((int)type);
        }

        
    }

    public class Tile : PictureBox
    {
        public int x;
        public int y;
        public TileType type;

        public Tile()
        {

        }

        public Tile(int x, int y) : base()
        {
            this.x = x;
            this.y = y;
        }
    }
}
