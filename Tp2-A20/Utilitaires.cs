using System;
using System.Collections.Generic;
using System.Text;
using Konscious.Security.Cryptography;
using System.Security.Cryptography;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text.Json;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace Tp2_A20
{
    public static class Utilitaires
    {
        #region Salt et Hash

        public static byte[] SaltMotDePasse()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        public static byte[] HashMotDePasse(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8,
                Iterations = 4,
                MemorySize = 1024 * 1024
            };
            return argon2.GetBytes(16);
        }

        public static bool VerifierMdp(string password, byte[] salt, byte[] hash)
        {
            return hash.SequenceEqual(HashMotDePasse(password, salt));
        }

        #endregion
        #region Export/Import XML
        public static void ExporterXML(TreeView pTv, string pPath)
        {
            using StreamWriter sw = new StreamWriter(pPath, false, Encoding.UTF8);
            sw.WriteLine("<TreeView>");
            foreach (Commentaire publication in pTv.Nodes)
            {
                publication.ExporterXML(sw, 0);
            }
            sw.WriteLine("</TreeView>");

        }

        public static TreeView ImporterXML(string pPath, TreeView tv)
        {
            Queue<string> maQueue = new Queue<string>();
            using StreamReader sr = new StreamReader(pPath);
            {
                foreach (string balise in sr.ReadToEnd().Split("<"))
                {
                    maQueue.Enqueue(balise.Trim());
                }
            }
            if (maQueue.Count > 1)
            {
                for (int i = 0; i < 2; i++)
                {
                    maQueue.Dequeue();
                }

                while (maQueue.Count > 1)
                {
                    TreeNode node = ImportationDiscussion(maQueue);
                    if (node != null)
                        tv.Nodes.Add(node);
                }
                return tv;
            }
            return tv;

        }

        private static Discussion ImportationDiscussion(Queue<string> pQueue)
        {
            try
            {
                Discussion discussion;
                pQueue.Dequeue();
                string titre = pQueue.Dequeue().Substring(6);
                pQueue.Dequeue();
                string cat = pQueue.Dequeue().Substring(10);
                pQueue.Dequeue();
                string contenu = pQueue.Dequeue().Substring(8);
                pQueue.Dequeue();
                int pouceEnHaut = 0;
                if (Char.IsDigit(pQueue.Peek().Substring(12), 0))
                    pouceEnHaut = Convert.ToInt32(pQueue.Dequeue().Substring(12, 1));
                else
                    pQueue.Dequeue();
                pQueue.Dequeue();
                int pouceEnBas = 0;
                if (Char.IsDigit(pQueue.Peek().Substring(11), 0))
                    pouceEnBas = Convert.ToInt32(pQueue.Dequeue().Substring(11, 1));
                else
                    pQueue.Dequeue();
                pQueue.Dequeue();
                string nomAuteur = pQueue.Dequeue().Substring(7);
                pQueue.Dequeue();
                discussion = new Discussion(contenu, nomAuteur, pouceEnHaut, pouceEnBas, titre, cat);

                while (pQueue.Peek() != "/Discussion>")
                {
                    TreeNode node = ImportationCommentaire(pQueue);
                    if (node != null)
                        discussion.Nodes.Add(node);
                }

                pQueue.Dequeue();
                return discussion;

            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to import discussion", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private static Commentaire ImportationCommentaire(Queue<string> pQueue)
        {
            try
            {
                pQueue.Dequeue();
                string contenu = pQueue.Dequeue().Substring(8);
                pQueue.Dequeue();
                int pouceEnHaut = 0;
                if (Char.IsDigit(pQueue.Peek().Substring(12), 0))
                    pouceEnHaut = Convert.ToInt32(pQueue.Dequeue().Substring(12, 1));
                else
                    pQueue.Dequeue();
                pQueue.Dequeue();
                int pouceEnBas = 0;
                if (Char.IsDigit(pQueue.Peek().Substring(11), 0))
                    pouceEnBas = Convert.ToInt32(pQueue.Dequeue().Substring(11, 1));
                else
                    pQueue.Dequeue();
                pQueue.Dequeue();

                string nomAuteur = pQueue.Dequeue().Substring(7);
                pQueue.Dequeue();
                Commentaire commentaire = new Commentaire(contenu, nomAuteur, pouceEnHaut, pouceEnBas);
                while (pQueue.Peek() != "/Commentaire>")
                {
                    TreeNode node = ImportationCommentaire(pQueue);
                    if (node != null)
                        commentaire.Nodes.Add(node);
                }

                pQueue.Dequeue();
                return commentaire;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to import comment", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        #endregion

    }
}