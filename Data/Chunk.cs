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
        private Playfield playField;
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

        public LiveNode GetCell(int x, int y)
        {
            foreach(LiveNode cell in activeCells)
                if (cell.Location.X == x && cell.Location.Y == y) return cell;
            return null;
        }

        public bool HasActiveCell(int x, int y)
        {
            if (GetActiveCells().Contains(new LiveNode(x, y, this))) return true;
            else return false;

        }

        public bool IsActiveChunk()
        {
            if (this.activeCells.Count > 0)
            {
                return true;
            }
            else return false;
        }

        public List<Chunk> GetNeighbours()
        {
            List<Chunk> neighbours = new List<Chunk>();
            Chunk[,] grid = this.playField.chunkGrid;
            if (grid[RootCoord.X + 1, RootCoord.Y] != null)
                neighbours.Add(grid[RootCoord.X + 1, RootCoord.Y]);
            if (grid[RootCoord.X + 1, RootCoord.Y + 1] != null)
                neighbours.Add(grid[RootCoord.X + 1, RootCoord.Y + 1]);
            if (grid[RootCoord.X + 1, RootCoord.Y - 1] != null)
                neighbours.Add(grid[RootCoord.X + 1, RootCoord.Y - 1]);
            if (grid[RootCoord.X, RootCoord.Y + 1] != null)
                neighbours.Add(grid[RootCoord.X, RootCoord.Y + 1]);
            if (grid[RootCoord.X, RootCoord.Y - 1] != null)
                neighbours.Add(grid[RootCoord.X, RootCoord.Y - 1]);
            if (grid[RootCoord.X - 1, RootCoord.Y + 1] != null)
                neighbours.Add(grid[RootCoord.X - 1, RootCoord.Y + 1]);
            if (grid[RootCoord.X - 1, RootCoord.Y] != null)
                neighbours.Add(grid[RootCoord.X - 1, RootCoord.Y]);
            if (grid[RootCoord.X - 1, RootCoord.Y - 1] != null)
                neighbours.Add(grid[RootCoord.X, RootCoord.Y]);

            return neighbours;
        }
    }
}
