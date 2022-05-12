using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class LiveNode
    {
        //variables
        public Coordinate Location { get; set; }
        private Chunk chunk;
        private int xNeighbours;
        private bool isOnBorder;

        
        public override bool Equals(object obj)
        {
            LiveNode comparison = (LiveNode)obj;
            if (comparison.Location.X.Equals(this.Location.X) && comparison.Location.Y.Equals(this.Location.Y)) return true;
            else return false;
        }

        public LiveNode(int x, int y, Chunk chunk)
        {
            this.Location = new Coordinate(chunk, x, y);
            this.chunk = chunk;
        }

        public LiveNode(Coordinate location, Chunk chunk)
        {
            this.Location = location;
            this.chunk = chunk;
        }

        public int XNeighbours
        {
            get
            {
                xNeighbours = Location.GetNeighbours().Count;
                return xNeighbours;
            }
        }

    }
}

