using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Chunk
    {
        private List<LiveNode> activeCells = new List<LiveNode>();
        public const int SIZE = 50;
        
        public Coordinate RootCoord { get; internal set; }

        public List<LiveNode> GetActiveCells() {
            return activeCells;
        }
        public void AddActiveCell(LiveNode cell)
        {
            activeCells.Add(cell);
        }
        public void RemoveActiveCell(LiveNode cell)
        {
            activeCells.Remove(cell);
        }

        public void RemoveActiveCell(int x, int y)
        {
            activeCells.Remove(new LiveNode(x, y, this));
        }
    }
}
