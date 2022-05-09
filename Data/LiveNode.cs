using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameOfLife.Data
{
    internal class LiveNode
    {
        public Coordinate Location { get; set; }
        private Chunk chunk;
        private int xNeighbours;
        private bool isOnBorder;

        public override bool Equals(object obj)
        {
            LiveNode comparison = (LiveNode)obj;
            if (comparison.Location.X.Equals(this.Location.X) && comparison.Location.Y.Equals(this.Location.Y)) return true;
            else return false;
        }

        public LiveNode(int x, int y, Chunk chunk)
        {
            this.Location = new Coordinate(chunk, x, y);
            this.chunk = chunk;
        }

        public LiveNode(Coordinate location, Chunk chunk)
        {
            this.Location = location;
            this.chunk = chunk;
        }

        public int XNeighbours
        {
            get
            {
                xNeighbours = Location.GetNeighbours().Count;
                return xNeighbours;
            }
        }

        /*public string IsOnBorder
        {
            get {

                bool upperborder;
                bool leftborder;
                bool rightborder;
                bool belowborder;
        
                
                // Ik heb toch een if statement gebruitk omdat we meerdere parameters moeten vergelijken. Ik zou niet weten hoe je dit met een case moet doen.
                // Misschien moeten we geen bool prop maken, maar een string prop zoda we letterlijk kunnen returne in tekst wat er precies moet gebeuren.
                // Hoe gaan we dat anders met enkele bools doen?
                // Da ziet er super scuft uit i know.. Veel dubbele code met altijd hier en daar een mini verschil. Heb jij een betere oplossing?

                if (this.Location.X == 0)
                {
                    leftborder = true;
                }
                else if (Location.X == Chunk.SIZE - 1)
                {
                    rightborder = true;
                }
                else if (this.Location.Y == Chunk.SIZE - 1)
                {
                    upperborder = true;
                }
                else if(Location.Y == 0)
                {
                    belowborder = true; ;
                }
                else if(Location.X == 0 && Location.Y == 0) // Drie chunks inladen links onder
                {
                    belowborder = true;
                    leftborder = true;
                }
                else if (Location.X == 0 && Location.Y == Chunk.SIZE - 1) // Drie chunks inladen links boven
                {
                    belowborder = true;
                    leftborder = true;
                }
                else if (Location.X == Chunk.SIZE - 1 && Location.Y == Chunk.SIZE - 1) // Drie chunks inladen rechts boven
                {
                    belowborder = true;
                    leftborder = true;
                }
                else if (Location.X == Chunk.SIZE - 1 && Location.Y == 0) // Drie chunks inladen rechts onder
                {
                    belowborder = true;
                    leftborder = true;
                }
                else
                {
                    throw new Exception(); //Idk wat hier te doen
                }
                
                return isOnBorder;
                }
        }*/

    }
}

