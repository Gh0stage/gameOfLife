using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Gamerules
    {

        public static bool IsAlive(LiveNode cell)
        {
            int aliveNeighbors = cell.XNeighbours;
            if (aliveNeighbors < 2)
            {
                return false;
            }
            else if (aliveNeighbors == 2 || aliveNeighbors == 3)
            {
                return true;
            }
            else if (aliveNeighbors > 3)
            {
                return false;
            }
            else return false;
        }

        internal bool isUnderpopulated(LiveNode cell)
        {
            int x = cell.Location.X;
            return true;
        }

        internal static void UpdatePlayfield()
        {
            for (int i = 0; i < Playfield.Width; i++)
            {
                for (int j = 0; j < Playfield.Height; j++)
                {
                    Chunk currentChunk = Playfield.chunkGrid[i, j];
                    if (currentChunk != null)
                    {
                        for (int k = 0; k < currentChunk.GetActiveCells().Count; k++)
                        {
                            LiveNode currentCell = currentChunk.GetActiveCells()[k];

                        }
                    }
                }
            }
        }
    }
}
