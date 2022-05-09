using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Chunk
    {
        //constructor
        public Chunk(Playfield playfield)
        {
            this.playField = playfield;
        }
        
        //variables
        private List<LiveNode> activeCells = new List<LiveNode>();
        private Playfield playField;
        public const int SIZE = 50;

        //properties
        public Coordinate RootCoord { get; internal set; }
        public Playfield PlayField { get; set; }
        
        //returns active cells
        public List<LiveNode> GetActiveCells() {
            return activeCells;
        }
        //adds a live node to the active cells
        public void AddActiveCell(LiveNode cell)
        {
            activeCells.Add(cell);
        }

        //removes a live node from the active cells
        public void RemoveActiveCell(LiveNode cell)
        {
            activeCells.Remove(cell);
        }
        public void RemoveActiveCell(int x, int y)
        {
            activeCells.Remove(new LiveNode(x, y, this));
        }

        //returns cell at x,y
        public LiveNode GetCell(int x, int y)
        {
            foreach(LiveNode cell in activeCells)
                if (cell.Location.X == x && cell.Location.Y == y) return cell;
            return null;
        }
        //checks wether or not a cell is active
        public bool HasActiveCell(int x, int y)
        {
            if (GetActiveCells().Contains(new LiveNode(x, y, this))) return true;
            else return false;

        }

        //checks wether or not a chunk is active
        public bool IsActiveChunk()
        {
            if (this.activeCells.Count > 0)
            {
                return true;
            }
            else return false;
        }

        //returns al neighbouring chunks in a list
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