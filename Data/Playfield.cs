using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Playfield
    {
        public static Chunk[,] chunkGrid = new Chunk[3, 3];
        public int width= 3;
        public int height = 3;
        private  const int EXPANDMODIFIER = 2;

        public static int Width { get; internal set; }
        public static int Height { get; internal set; }

        public Playfield()
        {
            Playfield.chunkGrid = new Chunk[3, 3];
        }

        public void AddChunk(int x, int y)
        {
            Playfield.chunkGrid[x,y] = new Chunk(this);
        }
        public Chunk GetChunk(int x, int y)
        {
            return Playfield.chunkGrid[x, y];
        }

        public void RemoveChunk(int x, int y)
        {
            Playfield.chunkGrid[x, y] = null;
        }

        public void ExpandGrid(string direction)
        {
            Chunk[,] newGrid;
            switch (direction) {
                case "up":
                    newGrid = new Chunk[Playfield.chunkGrid.GetLength(0), Playfield.chunkGrid.GetLength(1) + EXPANDMODIFIER];
                    height += EXPANDMODIFIER;
                    for (int x = 0; x < Playfield.chunkGrid.GetLength(0); x++)
                    {
                        for(int y = 0; y < Playfield.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = Playfield.chunkGrid[x, y];
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
                    newGrid = new Chunk[Playfield.chunkGrid.GetLength(0), Playfield.chunkGrid.GetLength(1) + EXPANDMODIFIER];
                    height += EXPANDMODIFIER;
                    for (int x = 0; x < Playfield.chunkGrid.GetLength(0); x++)
                    {
                        for(int y = 0; y < Playfield.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = Playfield.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x, y+EXPANDMODIFIER] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 69");
                            }
                        }
                    }
                    break;
                case "left":
                    newGrid = new Chunk[Playfield.chunkGrid.GetLength(0)+EXPANDMODIFIER, Playfield.chunkGrid.GetLength(1)];
                    width += EXPANDMODIFIER;
                    for (int x = 0; x < Playfield.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < Playfield.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = Playfield.chunkGrid[x, y];
                            if (loadedChunk != null)
                            {
                                newGrid[x+EXPANDMODIFIER, y] = loadedChunk;
                            }
                            else
                            {
                                Console.WriteLine("Chunk had geen waarde... playfield.cs, ln 87");
                            }
                        }
                    }
                    break;
                case "right":
                    newGrid = new Chunk[Playfield.chunkGrid.GetLength(0) + EXPANDMODIFIER, Playfield.chunkGrid.GetLength(1)];
                    width += EXPANDMODIFIER;
                    for (int x = 0; x < Playfield.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < Playfield.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = Playfield.chunkGrid[x, y];
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
        }
    } 
}
