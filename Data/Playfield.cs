using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Playfield
    {
        public Chunk[,] chunkGrid = new Chunk[3, 3];
        private const int EXPANDMODIFIER = 2;

        public Playfield()
        {
            this.chunkGrid = new Chunk[3, 3];
        }

        public void AddChunk(int x, int y)
        {
            this.chunkGrid[x, y] = new Chunk(this);
        }
        public Chunk GetChunk(int x, int y)
        {
            return this.chunkGrid[x, y];
        }

        public void RemoveChunk(int x, int y)
        {
            this.chunkGrid[x, y] = null;
        }

        public void ExpandGrid(string direction)
        {
            Chunk[,] newGrid = new Chunk[1, 1];
            switch (direction)
            {
                case "up":
                    newGrid = new Chunk[this.chunkGrid.GetLength(0), this.chunkGrid.GetLength(1) + EXPANDMODIFIER];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x, y] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 50");
                            }
                        }
                    }
                    break;

                case "down":
                    newGrid = new Chunk[this.chunkGrid.GetLength(0), this.chunkGrid.GetLength(1) + EXPANDMODIFIER];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x, y + EXPANDMODIFIER] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 69");
                            }
                        }
                    }
                    break;
                case "left":
                    newGrid = new Chunk[this.chunkGrid.GetLength(0) + EXPANDMODIFIER, this.chunkGrid.GetLength(1)];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x + EXPANDMODIFIER, y] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 87");
                            }
                        }
                    }
                    break;
                case "right":
                    newGrid = new Chunk[this.chunkGrid.GetLength(0) + EXPANDMODIFIER, this.chunkGrid.GetLength(1)];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x, y] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 87");
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            chunkGrid = newGrid;
        }

        public void Update()
        {
            Chunk[,] newGrid;
            List<Coordinate> coordsToUpdate = new List<Coordinate>();
            List<Chunk> activeChunks = new List<Chunk>();


            for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
            {
                for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                {
                    Chunk loadedChunk = this.chunkGrid[x, y];
                    if (loadedChunk != null)
                    {
                        Gamerules.CheckPlayfieldBorder(this, chunkGrid, loadedChunk);
                        activeChunks.Add(loadedChunk);

                        foreach (Chunk chunk in loadedChunk.GetNeighbours())
                        {
                            if (!activeChunks.Contains(chunk))
                                activeChunks.Add(chunk);
                        }

                        foreach (LiveNode cell in loadedChunk.GetActiveCells())
                        {
                            Coordinate coord = cell.Location;
                            if (!coordsToUpdate.Contains(coord)) coordsToUpdate.Add(coord);
                            foreach (Coordinate neighbor in coord.GetNeighbours())
                            {
                                if (!coordsToUpdate.Contains(neighbor))
                                    coordsToUpdate.Add(neighbor);
                            }
                        }
                    }
                }
            }

            newGrid = new Chunk[this.chunkGrid.GetLength(0), this.chunkGrid.GetLength(1)];

            foreach (Chunk chunk in activeChunks)
            {
                Chunk newChunk = new Chunk(this);
                newGrid[chunk.RootCoord.X, chunk.RootCoord.Y] = newChunk;
            }
            foreach (Coordinate coord in coordsToUpdate)
            {
                if (Gamerules.IsAlive(coord))
                    newGrid[coord.chunk.RootCoord.X, coord.chunk.RootCoord.Y].GetActiveCells().Add(new LiveNode(coord, newGrid[coord.chunk.RootCoord.X, coord.chunk.RootCoord.Y]));
            }
        }
    }
}
