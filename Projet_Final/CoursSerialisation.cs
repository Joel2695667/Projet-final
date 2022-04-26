using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace Projet_Final
{

    public static class CoursSerialisation
    {

        private static string filePath = "Cours.txt";
        public static void Save(List<Cours> crs)
        {
            //Création et ouverture du fichier
            FileStream fs = File.Create(filePath);
            //Permet de sérialiser un objet
            BinaryFormatter bf = new BinaryFormatter();
            //Sérialisation de l'objet clientList dans le fichier créé
            bf.Serialize(fs, crs);
            //Fermeture du fichier
            fs.Close();
        }


        public static List<Cours> Open()
        {
            //Instanciation d'une nouvelle liste de clients, vide pour le moment.
            List<Cours> crs = new List<Cours>();

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
                    crs = (List<Cours>)bf.Deserialize(fs);
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
            return crs;
        }



        public static void Save_2(List<Cours> crs)
        {
            List<Cours> lisTemp = new List<Cours>();

            if (File.Exists(filePath))
            {
                lisTemp = Open();
                lisTemp.Add(crs[crs.Count - 1]);
                Save(lisTemp);
            }
            else
            {
                //Création et ouverture du fichier
                FileStream fs = File.Create(filePath);
                //Permet de sérialiser un objet
                BinaryFormatter bf = new BinaryFormatter();
                //Sérialisation de l'objet clientList dans le fichier créé
                bf.Serialize(fs, crs);
                //Fermeture du fichier
                fs.Close();
            }

        }

    }

}
