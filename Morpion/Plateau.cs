using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Plateau
    {
        private int NombreCaseX;
        private int NombreCaseY;
        private Case derniereCase;
        public List<Case> ListeCase { get; set; }

        public Plateau(int nombreCaseX, int nombreCaseY)
        {
            this.NombreCaseX = nombreCaseX;
            this.NombreCaseY = nombreCaseY;
            this.ListeCase = new List<Case>();

            for (int compteurX = 0; compteurX < nombreCaseX; compteurX++)
            {
                for (int compteurY = 0; compteurY < nombreCaseY; compteurY++)
                {
                    Case uneCase = new Case(compteurX, compteurY);
                    ListeCase.Add(uneCase);
                }
            }
        }

        public void placerPion(Position position, Pion pion)
        {
            Case uneCase = this.GetCase(position);
            if (uneCase != null)
            {
                if (uneCase.Pion == null)
                {
                    uneCase.Pion = pion;
                    this.derniereCase = uneCase;
                }
                else
                    throw new Exception("Cette case est déjà utilisé.");
            }
            else
                throw new Exception("Cette case n'existe pas.");
        }

        public Case GetCase(Position position)
        {
            Case caseRes = null;
            foreach (Case uneCase in this.ListeCase)
            {
                if (uneCase.Position.Compare(position))
                {
                    caseRes = uneCase;
                }

            }
            return caseRes;
        }

        public bool EstPlein()
        {
            int nombreCaseRemplies = 0;
            foreach (Case uneCase in this.ListeCase)
            {
                if (uneCase.Pion != null)
                {
                    nombreCaseRemplies++;
                }
            }
            return nombreCaseRemplies == this.NombreCaseX * this.NombreCaseY;
        }

        internal Case DerniereCase()
        {
            throw new NotImplementedException();
        }

        public bool MemeCaseAlentour(Case maDerniere)
        {
            bool res = false;

            List<Case> caseAlentours = new List<Case>();
            foreach (Case uneCase in this.ListeCase)
            {
                if (uneCase.Position.Compare(maDerniere.Position))
                {
                    //do nothing is the case
                }else
                {
                    if(uneCase.Position.X == maDerniere.Position.X && (uneCase.Position.Y == maDerniere.Position.Y))
                    {

                    }
                }
            }

            return res;
        }

        public bool TroisCaseAligne()
        {
            bool res = false;
            res = this.TroisCaseAligneY();
            
            if (res == false)
                res = this.TroisCaseAligneX();
         
            if (res == false)
                res = this.TroisCaseAligneDiagonale();
 
            return res;
        }

        private bool TroisCaseAligneDiagonale()
        {
            bool res =false ;
            bool resHaut = false;
            bool resBas = false;

            try
            {
                resHaut = estdiagonaleBasHaut();

            }
            catch (Exception)
            {
                resHaut = false;
              
            }

            try
            {
                resBas = EstDiagonaleHautBas();

            }
            catch (Exception)
            {
                resBas = false;

            }

            res = (resHaut || resBas);

            return res;
        }

        private bool estdiagonaleBasHaut()
        {
            return this.GetCase(new Position(2, 0)).Pion.TypePion == this.GetCase(new Position(1, 1)).Pion.TypePion && this.GetCase(new Position(1, 1)).Pion.TypePion == this.GetCase(new Position(0, 2)).Pion.TypePion;
        }

        private bool EstDiagonaleHautBas()
        {
            return this.GetCase(new Position(0, 0)).Pion.TypePion == this.GetCase(new Position(1, 1)).Pion.TypePion && this.GetCase(new Position(1, 1)).Pion.TypePion == this.GetCase(new Position(2, 2)).Pion.TypePion;
        }

        private bool TroisCaseAligneX()
        {
            bool res = false;
            for (int compteurY = 0; compteurY < NombreCaseY; compteurY++)
            {
                List<Case> listeCaseX = new List<Case>();
                bool croix = true;
                bool rond = true;
                for (int compteurX = 0; compteurX < this.NombreCaseX; compteurX++)
                {
                    listeCaseX.Add(this.GetCase(new Position(compteurX, compteurY)));
                }

                foreach (Case uneCase in listeCaseX)
                {
                    if (uneCase.Pion != null)
                    {
                        if (uneCase.Pion.TypePion != TypePion.rond)
                            rond = false;
                        else
                            croix = false;
                    }
                    else
                    {
                        rond = false;
                        croix = false;
                    }
                }

                if (croix || rond)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        private bool TroisCaseAligneY()
        {
            bool res = false;
            for (int compteurX = 0; compteurX < this.NombreCaseX; compteurX++)
            {
                List<Case> listeCaseX = new List<Case>();
                bool croix = true;
                bool rond = true;
                for (int compteurY = 0; compteurY < NombreCaseY; compteurY++)
                {
                    listeCaseX.Add(this.GetCase(new Position(compteurX, compteurY)));
                }

                foreach (Case uneCase in listeCaseX)
                {
                    if(uneCase.Pion != null)
                    {
                        if (uneCase.Pion.TypePion != TypePion.rond)
                            rond = false;
                        else
                            croix = false;
                    }
                    else
                    {
                        rond = false;
                        croix = false;
                    }
                }

                if (croix || rond)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public Case DerniereCasePose()
        {
            return this.derniereCase;
        }
    }
}
