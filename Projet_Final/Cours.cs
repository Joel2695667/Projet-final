using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{


    [Serializable]
    public class Cours
    {

        //variables membres
        private string numeroCours,
                        codeCours,
                        titreCours;

        //Methodes
        public string NumeroCours
        {
            get { return numeroCours; }
            set { numeroCours = value; }
        }

        public string CodeCours
        {
            get { return codeCours; }
            set { codeCours = value; }
        }

        public string TitreCours
        {
            get { return titreCours; }
            set { titreCours = value; }
        }

        //definition du construteur
        public Cours(string numeroCours, string codeCours, string titreCours)
        {
            this.NumeroCours = numeroCours;
            this.CodeCours = codeCours;
            this.TitreCours = titreCours;
        }

        public Cours()
        {

        }


        public override string ToString()
        {
            return "Titre : " + this.TitreCours + ", Code : " + this.CodeCours + ", Numero" + this.NumeroCours;
        }

    }

}
