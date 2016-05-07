using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C5;

namespace com.vidhucraft.cs.AStar
{
    class AStar
    {
        public Map map;

        IntervalHeap<Node> close = new IntervalHeap<Node>(new Node.NodeComparer());
        IntervalHeap<Node> open = new IntervalHeap<Node>(new Node.NodeComparer());


        public AStar(Map map)
        {
            this.map = map;

            open.Add(map.getStartNode().Clone());
        }

        public void execute()
        {
            while(open.Count > 0)
            {
                Node q = open.Min();
                open.DeleteMin();

                List<Node> successors = map.getAdjacentNodes(q);
                foreach(Node successor in successors)
                {
                    if (successor.type == TileType.Destination)
                    {
                        this.map.TraceBackPath(successor);
                        return;
                    }


                    if (successor.type == TileType.UnWalkable)
                        continue;

                    successor.G = q.G + Node.Dist(q, successor);
                    successor.H = Node.Dist(successor, map.getFinishNode());

                    if(open.Exists(n => n.X == successor.X && n.Y == successor.Y && n.F < successor.F))
                    {
                        continue;
                    }

                    if(close.Exists(n => n.X == successor.X && n.Y == successor.Y && n.F < successor.F))
                    {
                        continue;
                    }

                    open.Add(successor.Clone());
                }
                close.Add(q.Clone());
            }
        }

    }
}
