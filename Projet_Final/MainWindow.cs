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

            this.TB_Information.Text = ch;
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

            this.TB_Information.Text = ch;
        }

        //Ajoute une note
        private void button1_Click(object sender, EventArgs e)
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
        }

        //Affiche la liste de note
        private void BT_AfficheNote_Click(object sender, EventArgs e)
        {
            this.TB_Information.Text = "";

            string ch = "";
            List<Note> listNote = NoteSerialisation.Open();

            foreach (Note x in listNote)
            {
                ch += x.ToString();
            }

            this.TB_Information.Text = ch;
        }

        private void MainWindow_Load_1(object sender, EventArgs e)
        {

        }

        private void BT_Supprime_Click(object sender, EventArgs e)
        {
            EtudiantSerialisation.Save(etudiants);
            CoursSerialisation.Save(listCrs);
            NoteSerialisation.Save(listNote);
        }
    }//Fin classe

}//fin Namespace
