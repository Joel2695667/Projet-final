using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projet_Final
{

    public static class NoteSerialisation
    {

        private static string filePath = "Note.txt";
        public static void Save(List<Note> notes)
        {
            //Création et ouverture du fichier
            FileStream fs = File.Create(filePath);
            //Permet de sérialiser un objet
            BinaryFormatter bf = new BinaryFormatter();
            //Sérialisation de l'objet clientList dans le fichier créé
            bf.Serialize(fs, notes);
            //Fermeture du fichier
            fs.Close();
        }


        public static List<Note> Open()
        {
            //Instanciation d'une nouvelle liste de clients, vide pour le moment.
            List<Note> notes = new List<Note>();

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
                    notes = (List<Note>)bf.Deserialize(fs);
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
            return notes;
        }


    }

}
