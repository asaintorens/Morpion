using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Case
    {
        
        public Case(int compteurX, int compteurY)
        {
            this.Position = new Position(compteurX,compteurY);
            this.Pion = null;
        }
        public Position Position { get; set; }

        public Pion Pion { get; set; }

        public override string ToString()
        {
            string res = "";
            if(this.Pion == null)
            {
                res = "#";
            }else
            {
                if (this.Pion.TypePion == TypePion.croix)
                    res = "X";
                else
                    res = "O";
            }
            return res;
        }



        internal bool TroisCaseAligne()
        {
            throw new NotImplementedException();
        }
    }
}
