using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projet_Final
{


    public static class EtudiantSerialisation
    {
        private static string filePath = "Etudiants.txt";

        public static void Save(List<Etudiant> etudiant)
        {

            //Création et ouverture du fichier
            FileStream fs = File.Create(filePath);
            //Permet de sérialiser un objet
            BinaryFormatter bf = new BinaryFormatter();
            //Sérialisation de l'objet clientList dans le fichier créé
            bf.Serialize(fs, etudiant);
            //Fermeture du fichier
            fs.Close();

        }        
    

        public static List<Etudiant> Open()
        {
            //Instanciation d'une nouvelle liste de clients, vide pour le moment.
            List<Etudiant> Etudiants = new List<Etudiant>();

            //Si le fichier existe alors...
            if (File.Exists(filePath))
            {
                //Déclaration d'une variable FileStream
                FileStream fs = null;

                //Le bloc Try...Catch permet de gérer les erreurs si l'ouverture se passe mal
                try
                {
                    //Ouverture du fichier
                    fs = File.OpenRead(filePath);
                    //Permet de déserialiser un fichier
                    BinaryFormatter bf = new BinaryFormatter();
                    //Déserialisation : On récupère notre objet
                    Etudiants = (List<Etudiant>)bf.Deserialize(fs);
                }
                catch (Exception e)
                {
                    //Affichage d'un message en cas d'erreur
                    throw e;
                }
                finally
                {
                    //Qu'il y est une erreur ou non, on ferme le fichier
                    //s'il a été ouvert
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
            }

            //On retourne notre liste
            return Etudiants;
        }


    }


}
