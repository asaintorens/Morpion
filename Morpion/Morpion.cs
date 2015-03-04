using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morpion
{
    public class Morpion
    {
        bool finDuJeu;
        public Plateau Plateau { get; set; }
        public List<Joueur> Listejoueurs { get; set; }

        public Morpion()
        {
            this.finDuJeu = false;
            this.Plateau = new Plateau(3, 3);
        }

        private void InitJoueurs()
        {
            Joueur joueur1 = new Joueur();
            joueur1.SaisirPseudo(1);
            joueur1.SaisirTypePion();
            Joueur joueur2 = new Joueur();
            joueur2.SaisirPseudo(2);
            joueur2.AllouerPion(joueur1);
            this.Listejoueurs = new List<Joueur>();
            Listejoueurs.Add(joueur1);
            Listejoueurs.Add(joueur2);
           
        }

        public void Play()
        {
            InitJoueurs();

            FaireJouerJoueur();

        }

        private void FaireJouerJoueur()
        {
            while (!finDuJeu)
            {
                FaireJouerJoueur(this.Listejoueurs[0]);
                this.EtatParti();
                if (!finDuJeu)
                {
                    FaireJouerJoueur(this.Listejoueurs[1]);
                    this.EtatParti();
                }
                this.ToString();
            }
        }

        private void EtatParti()
        {
            if(this.Plateau.EstPlein())
                 this.finDuJeu = true;
            if (this.EstGagnant())
                this.finDuJeu = true;
        }

        public override string ToString()
        {
            Console.WriteLine(string.Format("{0}|{1}|{2}", this.Plateau.GetCase(new Position(0, 0)).ToString(),this.Plateau.GetCase( new Position(1, 0)).ToString(),this.Plateau.GetCase(new Position(2,0))).ToString());
            Console.WriteLine(string.Format("{0}|{1}|{2}", this.Plateau.GetCase(new Position(0, 1)).ToString(), this.Plateau.GetCase(new Position(1, 1)).ToString(), this.Plateau.GetCase(new Position(2, 1))).ToString());
            Console.WriteLine(string.Format("{0}|{1}|{2}", this.Plateau.GetCase(new Position(0,2)).ToString(), this.Plateau.GetCase(new Position(1, 2)).ToString(),this.Plateau.GetCase( new Position(2, 2))).ToString());
            return "trololo";
        }
        private bool EstGagnant()
        {
            bool res = false;

            res = this.Plateau.TroisCaseAligne();
            if (res)
                this.attribuerGagnant();
            return res;
        }

        private void attribuerGagnant()
        {
            TypePion typePionGagnant = this.Plateau.DerniereCasePose().Pion.TypePion;
            if(this.Listejoueurs.ElementAt(0).Pion.TypePion == typePionGagnant)
            {
                this.Listejoueurs.ElementAt(0).Gagnant = true;
            }
            else
                this.Listejoueurs.ElementAt(0).Gagnant = false;
        }

        private void FaireJouerJoueur(Joueur joueur)
        {
            bool joueurAjouer = false;
            while (!joueurAjouer)
            {
                try
                {
                    joueur.deplacerPion(this.Plateau);
                    joueurAjouer = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }

        public void AfficherFinDePartie()
        {
            Console.WriteLine("Fin de partie.");
            bool res = false;
            foreach (Joueur unJoueur in this.Listejoueurs)
            {
                if (unJoueur.Gagnant)
                {
                    Console.WriteLine(unJoueur.Pseudo + " à gagné la partie.");
                    res = true;
                }
            }
            if (!res)
            {
                Console.WriteLine("Aucun gagnant, égalité.");
            }
            Console.ReadLine();
        }
    }
}
