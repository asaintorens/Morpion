using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Joueur
    {
        public bool Gagnant { get; set; }
        public Pion Pion { get; set; }
        public string Pseudo { get; set; }


        public Joueur()
        {
            this.Pion = new Pion();
            this.Gagnant = false;
        }
    

          



        public void deplacerPion(Plateau lePlateau)
        {
            string inputJoueur = this.SaisirPosition();
            Position position = new Position(inputJoueur);
            lePlateau.placerPion(position,this.Pion);
        }

        private string SaisirPosition()
        {
            Console.WriteLine(this.Pseudo + " Saisir X,Y");
            string res =  Console.ReadLine();
            return res;
        }

        public void SaisirPseudo(int numeroJoueur)
        {
            Console.WriteLine("Joueur numero " + numeroJoueur + ", saisir ton pseudo");
            string inputPseudo = Console.ReadLine();
            this.Pseudo = inputPseudo;
        }

        public void SaisirTypePion()
        {
            Console.WriteLine("Saisir votre pion X ou O");
            string typePion = Console.ReadLine();
            if(typePion == "X")
            {
                this.Pion.TypePion = TypePion.croix;
            }
            else
            {
                this.Pion.TypePion = TypePion.rond;
            }
        }

        public void AllouerPion(Joueur joueur1)
        {
            if (joueur1.Pion.TypePion == TypePion.croix)
            {
                this.Pion.TypePion = TypePion.rond;
            }
            else
                this.Pion.TypePion = TypePion.croix;
        }


    }
}
