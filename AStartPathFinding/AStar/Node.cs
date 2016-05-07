using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.vidhucraft.cs.AStar
{
    class Node : IComparable<Node>
    {
        public int X;
        public int Y;
        public int G = 0;
        public int H = 0;
        public int F
        {
            get
            {
                return G + H;
            }
        }

        public Node parent;
        public TileType type;

        public Node()
        {

        }

        public Node(int X, int Y, TileType type)
            :base()
        {
            this.X = X;
            this.Y = Y;
            this.type = type;
        }

        public Node Clone()
        {
            return (Node)this.MemberwiseClone();
        }

        public void SetType(TileType type)
        {
            this.type = type;
        }

        public override string ToString()
        {
            return "(" + this.Y + "," + this.X + ")    " + "F:" + this.F + " G:" + this.G + " H:" + this.H;
        }

        public static int Dist(Node a, Node b)
        {
            int l = Math.Abs(a.X - b.X);
            int h = Math.Abs(a.Y - b.Y);
            
            return (int) Math.Round(Math.Sqrt((l * l) + (h * h)), 0)*10;
        }

        public int CompareTo(Node other)
        {
            if (this.F > other.F)
                return 1;
            if (this.F < other.F)
                return -1;
            return 0;
        }

        public class NodeComparer : IComparer<Node>
        {
            public int Compare(Node x, Node y)
            {
                if (x.F > y.F)
                    return 1;
                if (x.F < y.F)
                    return -1;
                return 0;
            }
        }
    }
}
