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
            int x = cell.X;
            return true;
        }

        internal static void UpdatePlayfield()
        {
           
        }
    }
}
