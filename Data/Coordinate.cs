using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Chunk chunk;
        private bool isOnBorder;
        public int xNeighbours = 0;

        public Coordinate(Chunk chunk, int x, int y)
        {
            this.chunk = chunk;
            MoveCoord(x,y);
        }
        public void MoveCoord(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public bool IsOnBorder
        {
            get
            {
                if (this.X == 0 || this.X == Chunk.SIZE - 1 || this.Y == 0 || this.Y == Chunk.SIZE - 1)
                {
                    isOnBorder = true;
                    return true;
                }
                else
                {
                    isOnBorder = false;
                    return false;
                }
            }
        }
            

        public List<Coordinate> GetNeighbours()
        {
            List<Coordinate> neighbours = new List<Coordinate>();
            if (!isOnBorder)
            {
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y, chunk))) {
                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y, chunk)))
                {
                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y - 1, chunk)))
                {
                    neighbours.Add(new Coordinate(chunk, this.X, this.Y - 1));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y + 1, chunk)))
                {
                    neighbours.Add(new Coordinate(chunk, this.X, this.Y + 1));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y - 1, chunk))) {
                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y - 1));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y - 1, chunk))) {
                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y - 1));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y + 1, chunk))) {
                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y + 1));
                    xNeighbours++;
                }
                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y + 1, chunk))) {
                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y + 1));
                    xNeighbours++;
                }
                return neighbours;
            }
            else
            {
                switch (this.X)
                {
                    case 0:
                        switch (this.Y)
                        {
                            case 0:
                                //bottom left corner
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y, chunk))){
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y + 1, chunk)))
                                {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y + 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y + 1, chunk)))
                                {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y + 1));
                                    xNeighbours++;
                                }                                    
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X-1,chunk.RootCoord.Y],Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1].GetActiveCells().Contains(new LiveNode(0, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1], 0, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1].GetActiveCells().Contains(new LiveNode(0, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1], 0, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(0, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y], 0, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y + 1].GetActiveCells().Contains(new LiveNode(0, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y + 1])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y + 1], 0, 0));
                                    xNeighbours++;
                                }
                                    return neighbours;

                            case Chunk.SIZE - 1:
                                //top left corner
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y - 1));
                                    xNeighbours++;
                                }
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y], Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1].GetActiveCells().Contains(new LiveNode(0, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1], 0, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                return neighbours;

                            default:
                                //left side
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y + 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X + 1, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X + 1, this.Y + 1));
                                    xNeighbours++;
                                }
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X - 1, chunk.RootCoord.Y], Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1].GetActiveCells().Contains(new LiveNode(0, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1], 0, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y])))
                                {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                    return neighbours;
                        }


                    case Chunk.SIZE - 1:
                        switch (this.Y)
                        {
                            case 0:
                                //bottom right corner
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y + 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y + 1));
                                    xNeighbours++;
                                }
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(0, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y], 0, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1], Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                return neighbours;

                            case Chunk.SIZE - 1:
                                //top right corner
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y - 1));
                                    xNeighbours++;
                                }
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(0, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y], 0, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1], Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                return neighbours;

                            default:
                                //right side
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X, this.Y + 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y - 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y - 1));
                                    xNeighbours++;
                                }
                                if (chunk.GetActiveCells().Contains(new LiveNode(this.X - 1, this.Y + 1, chunk))) {
                                    neighbours.Add(new Coordinate(chunk, this.X - 1, this.Y + 1));
                                    xNeighbours++;
                                }
                                //parts from other chunks
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(0, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X + 1, chunk.RootCoord.Y], 0, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, 0, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y - 1], Chunk.SIZE - 1, 0));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y]))){
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                if (chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1].GetActiveCells().Contains(new LiveNode(Chunk.SIZE - 1, Chunk.SIZE - 1, chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1]))) {
                                    neighbours.Add(new Coordinate(chunk.PlayField.chunkGrid[chunk.RootCoord.X, chunk.RootCoord.Y + 1], Chunk.SIZE - 1, Chunk.SIZE - 1));
                                    xNeighbours++;
                                }
                                return neighbours;
                        }

                    default:
                        throw new Exception("isOnBorder is true, but not on a border");

                }
            }
        }

    }
}
