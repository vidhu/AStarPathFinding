using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.vidhucraft.cs.AStar
{
    class StartNodeMissingException : Exception
    {
        public StartNodeMissingException()
            : base("Start node is missing")
        { }
    }

    class FinishNodeMissingException : Exception
    {
        public FinishNodeMissingException()
            : base("Finish node is missing")
        { }
    }
}
