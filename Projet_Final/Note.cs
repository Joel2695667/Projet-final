using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Final
{

    public class Note
    {
        //Variables membres
        private string numeroEtudiantNote;
        private string codeCours;
        private string noteDuCours;

        //methode
        public string NumeroEtudiantNote
        {
            get { return numeroEtudiantNote; }
            set { numeroEtudiantNote = value; }
        }

        public string CodeCours
        {
            get { return codeCours;}
            set { codeCours = value; }
        }


        public string NoteDuCours
        {
            get { return noteDuCours; }
            set { noteDuCours = value; }
        }

        //Definition d'un Construteur
        public Note() { }
        public Note(string numeroEtudiantNote, string codeCours, string noteDuCours)
        {
            this.NumeroEtudiantNote = numeroEtudiantNote;
            this.CodeCours = codeCours;
            this.NoteDuCours = noteDuCours;
        }

        public override string ToString()
        {
            return "numeroEtudiant : " + this.NumeroEtudiantNote + 
                    ", Code cours : " + this.CodeCours + ", Numero" + 
                    this.NoteDuCours;
        }

    }

}
