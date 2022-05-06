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
        private  const int EXPANDMODIFIER = 2;
        
        public Playfield()
        {
            this.chunkGrid = new Chunk[3, 3];
        }

        public void AddChunk(int x, int y)
        {
            this.chunkGrid[x,y] = new Chunk();
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
            Chunk[,] newGrid;
            switch (direction) {
                case "up":
                    newGrid = new Chunk[this.chunkGrid.GetLength(0), this.chunkGrid.GetLength(1) + EXPANDMODIFIER];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for(int y = 0; y < this.chunkGrid.GetLength(1); y++)
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
                        for(int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
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
                    newGrid = new Chunk[this.chunkGrid.GetLength(0)+EXPANDMODIFIER, this.chunkGrid.GetLength(1)];
                    for (int x = 0; x < this.chunkGrid.GetLength(0); x++)
                    {
                        for (int y = 0; y < this.chunkGrid.GetLength(1); y++)
                        {
                            Chunk loadedChunk = this.chunkGrid[x, y];
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
        }
    } 
}
