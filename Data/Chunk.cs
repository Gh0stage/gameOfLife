using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Chunk
    {
        public Chunk(Playfield playfield)
        {
            this.playField = playfield;
        }
        
        private List<LiveNode> activeCells = new List<LiveNode>();
        private Playield playField;
        public const int SIZE = 50;
        public Coordinate RootCoord { get; internal set; }
        public Playfield PlayField { get; set; }
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
