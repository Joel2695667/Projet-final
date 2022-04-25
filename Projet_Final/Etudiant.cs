using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{
    [Serializable]
    public class Etudiant
    {

        //variables membres
        private string nom,
                        prenom,
                        numeroEtudiant;

        //Méthodes
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string NumeroEtudiant
        {
            get { return numeroEtudiant; }
            set { numeroEtudiant = value; }
        }

        //definition du construteur
        public Etudiant()
        {

        }

        //definition du construteur
        public Etudiant(string nom, string prenom, string numeroEtudiant)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.NumeroEtudiant = numeroEtudiant;
        }

        public override string ToString()
        {
            return "Nom : " + this.Nom + "\t" + ", Prenom : " + this.Prenom + "\t" + ", numeroEtudiant : " + this.NumeroEtudiant + "\t\n";
        }

    }
}
