using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.vidhucraft.cs.AStar
{
    public enum TileType : uint
    {
        Walkable = 0xFF4188D2,
        UnWalkable = 0xFF43066F,
        Walked = 0xFF0D58A6,
        Start = 0xFF00FF00,
        Destination = 0xFFFF0000
    }
}
