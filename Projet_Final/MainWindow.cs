using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_Final
{
    public partial class MainWindow : Form
    {

        private List<Etudiant> etudiants = new List<Etudiant>();
        private List<Cours> listCrs = new List<Cours>();
        private List<Note> listNote = new List<Note>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        //Ajoute un etudiant
        private void BT_Add_Etudiant_Click(object sender, EventArgs e)
        {
            Etudiant etudiant = new Etudiant
                (
                    this.TB_NomEtudiant.Text,
                    this.TB_PrenomEtudiant.Text,
                    this.TB_NumeroEtudiant.Text
                );

            etudiants.Add(etudiant);
            EtudiantSerialisation.Save_2(etudiants);

            this.TB_NomEtudiant.Text = "";
            this.TB_PrenomEtudiant.Text = "";
            this.TB_NumeroEtudiant.Text = "";
        }

        //Ajoute un cours
        private void BT_Add_Cours_Click(object sender, EventArgs e)
        {
            Cours cours = new Cours
                (
                    
                    this.TB_NumeroCours.Text,
                    this.TB_CodeCours.Text,
                    this.TB_TitreCours.Text
                );

            listCrs.Add(cours);
            CoursSerialisation.Save_2(listCrs);
            this.TB_NumeroCours.Text = "";
            this.TB_CodeCours.Text = "";
            this.TB_TitreCours.Text = "";
        }

        //Affiche la liste des etudiants
        private void TB_AfficheEtudiant_Click(object sender, EventArgs e)
        {
            this.TB_Information.Text = "";

            string ch = "";
            List<Etudiant> listEtudiant = EtudiantSerialisation.Open();

            foreach (Etudiant x in listEtudiant)
            {
                ch += x.ToString();
            }

            this.TB_Information.Text = "Liste des étudiants";
            this.LB_affiche.Text = ch;
        }

        //Affiche la liste des cours
        private void BT_Cours_Click(object sender, EventArgs e)
        {
            this.TB_Information.Text = "";

            string ch = "";
            List<Cours> listCours = CoursSerialisation.Open();

            foreach (Cours x in listCours)
            {
                ch += x.ToString();
            }

            this.TB_Information.Text = "Liste des cours";
            this.LB_affiche.Text = ch;
        }

        //Ajoute une note
        private void button1_Click(object sender, EventArgs e)
        {
           
            List<Etudiant> listTempEtuidiant = EtudiantSerialisation.Open();
            int p = 0;
            string ch = this.TB_Note_NumeroEtudiant.Text;            
            foreach (Etudiant x in listTempEtuidiant)
            {
                if ((x.NumeroEtudiant).Equals(ch, StringComparison.OrdinalIgnoreCase))
                {                                                  
                                      
                        Note note = new Note
                            (

                                this.TB_Note_NumeroEtudiant.Text,
                                this.TB_Note_NumeroCours.Text,
                                this.TB_Note.Text
                            );

                                    listNote.Add(note);
                                    NoteSerialisation.Save_2(listNote);
                                    this.TB_Note_NumeroEtudiant.Text = "";
                                    this.TB_Note_NumeroCours.Text = "";
                                    this.TB_Note.Text = "";
                    
                }else
                {
                    MessageBox.Show("Aucune correspondance avec un numero etudiant ou un numero de cours existant dans les listes!");
                }

            }            
            
        }

        //Affiche la liste de note
        private void BT_AfficheNote_Click(object sender, EventArgs e)
        {
            this.TB_Information.Text = "";

            string ch = "";
            List<Note> listNote = NoteSerialisation.Open();
            List<Etudiant> listTempEtuidiant = EtudiantSerialisation.Open();

            foreach (Note x in listNote)
            {
                foreach(Etudiant etudiant in listTempEtuidiant)
                    if(x.NumeroEtudiantNote.Equals(etudiant.NumeroEtudiant))
                    {
                        ch += "Etudiant : " + etudiant.Nom + ", " + etudiant.Prenom + " " +  x.ToString() + "\n";
                    }                
            }

            this.TB_Information.Text = "Liste des notes";
            this.LB_affiche.Text = ch;
        }

        private void BT_Supprime_Click(object sender, EventArgs e)
        {
           
            EtudiantSerialisation.Save(etudiants);
            CoursSerialisation.Save(listCrs);
            NoteSerialisation.Save(listNote);
            this.LB_affiche.Text = "";
        }
    }//Fin classe

}//fin Namespace
