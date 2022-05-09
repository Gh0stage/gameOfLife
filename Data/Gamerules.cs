using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Gamerules
    {

        public static bool IsAlive(Coordinate coord)
        {
            switch (coord.chunk.GetCell(coord.X, coord.Y))
            {
                case null:
                    {
                        LiveNode tempcell = new LiveNode(coord.X, coord.Y, coord.chunk);
                        int xNeighbours = tempcell.XNeighbours;
                        if (xNeighbours == 3)
                            return true;
                        else return false;
                    }
                default:
                    {
                        int aliveNeighbors = coord.chunk.GetCell(coord.X, coord.Y).XNeighbours;
                        if (aliveNeighbors < 2)
                            return false;
                        else if (aliveNeighbors == 2 || aliveNeighbors == 3)
                            return true;
                        else if (aliveNeighbors > 3)
                            return false;
                        else return false;
                    }
            }
        }
        public static void CheckPlayfieldBorder(Playfield playField, Chunk[,] chunkGrid, Chunk loadedChunk)
        {
            if (loadedChunk.RootCoord.X + 2 >= chunkGrid.GetLength(0))
            {
                playField.ExpandGrid("right");
            }
            if (loadedChunk.RootCoord.Y + 2 >= chunkGrid.GetLength(1))
            {
                playField.ExpandGrid("down");
            }
            if (loadedChunk.RootCoord.X - 2 < 0)
            {
                playField.ExpandGrid("left");
            }
            if (loadedChunk.RootCoord.Y - 2 < 0)
            {
                playField.ExpandGrid("up");
            }
        }

        static void UpdateChunk(Playfield playfield, Chunk[,] chunkGrid, Chunk loadedChunk)
        {
            Chunk newChunk = new Chunk(playfield);
            newChunk.RootCoord = loadedChunk.RootCoord;
            List<Coordinate> coordsToUpdate = new List<Coordinate>();

            foreach (LiveNode cell in loadedChunk.GetActiveCells())
            {
                Coordinate coord = cell.Location;
                if (!coordsToUpdate.Contains(coord)) coordsToUpdate.Add(coord);
                foreach (Coordinate neighbor in coord.GetNeighbours())
                {
                    if (!coordsToUpdate.Contains(neighbor)) coordsToUpdate.Add(neighbor);
                }
            }

            for (int x = 0; x < loadedChunk.GetActiveCells().Count(); x++)
            {
                LiveNode cell = loadedChunk.GetActiveCells()[x];

                if (IsAlive(cell.Location))
                {
                    newChunk.GetActiveCells().Add(cell);
                }
            }
        }
    }
}