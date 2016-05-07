using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.vidhucraft.cs.AStar
{
    class Map
    {
        public Node[,] node;
        public List<Node> path;
        Node start;
        Node finish;


        int width;
        int height;

        public Map(Node[,] node)
        {
            this.node = node;
            this.start = this.getStartNode();
            this.finish = this.getFinishNode();
            this.width = node.GetLength(0);
            this.height = node.GetLength(1);
        }

        public Node getStartNode()
        {
            if (this.start != null)
            {
                return this.start;
            }

            foreach (Node node in this.node)
            {
                if (node.type == TileType.Start)
                    return node;
            }

            throw new StartNodeMissingException();
        }

        public Node getFinishNode()
        {
            if (this.finish != null)
            {
                return this.finish;
            }

            foreach (Node node in this.node)
            {
                if (node.type == TileType.Destination)
                    return node;
            }

            return null;
        }

        public List<Node> getAdjacentNodes(Node target)
        {
            List<Node> adjList = new List<Node>();

            for(int i=target.Y-1; i<=target.Y+1; i++)
            {
                for(int j=target.X-1; j<=target.X+1; j++)
                {
                    if (i == target.Y && j == target.X)
                        continue;
                    if (i < 0 || j < 0 || i > this.height-1 || j > this.width-1)
                        continue;
                    adjList.Add(this.node[j, i]);
                    this.node[j, i].parent = target;
                }
            }

            return adjList;
        }

        public void TraceBackPath(Node node)
        {
            List<Node> path = new List<Node>();

            while(node.parent != null)
            {
                Node parent = node.parent;
                this.node[parent.X, parent.Y].type = TileType.Walked;
                node = parent;

                path.Add(parent);
            }

            this.path = path;
        }

    }
}
