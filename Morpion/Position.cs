using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Position
    {
       public int X, Y;
       

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(string position)
        {
            string[] xy = position.Split(',');
            this.X = int.Parse(xy[0].ToString());
            this.Y = int.Parse(xy[1].ToString());
        }

        /// <summary>
        /// return true if same value
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns></returns>
        public  bool Compare(Position position)
        {
            bool res = false;

            if (this.X == position.X && this.Y == position.Y)
                res = true;

            return res;
        }
    }

    
}
