﻿using System;
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
            this.Location = new Coordinate(x, y);
            this.chunk = chunk;

        }

        public int XNeighbours
        {
            get
            {
                if (!isOnBorder)
                {

                }
                else
                {

                }
                return xNeighbours;
            }
            set { xNeighbours = value; }
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



        public bool IsOnBorder
        {
            get {
                if (Location.X == 0 || Location.X == Chunk.SIZE - 1 || Location.Y == 0 || Location.Y == Chunk.SIZE - 1)
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

        public int UpdateNeighbours()
        {
            if (!isOnBorder)
            {
                int _xNeighbours = 0;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X - 1, Location.Y, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X + 1, Location.Y, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X, Location.Y - 1, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X, Location.Y + 1, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X - 1, Location.Y - 1, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X + 1, Location.Y - 1, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X - 1, Location.Y + 1, chunk))) _xNeighbours++;
                if (chunk.GetActiveCells().Contains(new LiveNode(Location.X + 1, Location.Y + 1, chunk))) _xNeighbours++;
                return _xNeighbours;
            }
            else
            {
                switch (Location.X)
                {
                    case 0:
                        switch (Location.Y)
                        {
                            case 0:
                                //bottom left corner
                                break;
                            case Chunk.SIZE - 1:
                                //top left corner
                                break;
                            default:
                                //left side
                                break;
                        }
                        break;

                    case Chunk.SIZE - 1:
                        switch (Location.Y)
                        {
                            case 0:
                                //bottom right corner
                                break;
                            case Chunk.SIZE - 1:
                                //top right corner
                                break;
                            default:
                                //right side
                                break;
                        }
                        break;
                }
            }
            return 0;
        }      
    }
}

