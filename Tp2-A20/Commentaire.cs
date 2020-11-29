using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tp2_A20
{
    public class Commentaire : TreeNode
    {
        private string _contenu;
        private int _pouceEnHaut;
        private int _pouceEnBas;
        private string auteur;

        public string Auteur
        {
            get { return auteur; }
            set { auteur = value; }
        }

        public string Contenu
        {
            get { return _contenu; }
            set { _contenu = value; }
        }

        public int PouceEnHaut
        {
            get { return _pouceEnHaut; }
            set { _pouceEnHaut = value; }
        }

        public int PouceEnBas
        {
            get { return _pouceEnBas; }
            set { _pouceEnBas = value; }
        }

        public Commentaire()
        {
        }

        public Commentaire(string pContenu, string pAuteur, int pUpvote, int pDownvote)
        {
            Contenu = pContenu;
            Auteur = pAuteur;
            PouceEnHaut = pUpvote;
            PouceEnBas = pDownvote;
            Text = ToString();
        }

        public void AjouterPouceEnHaut()
        {
            _pouceEnHaut++;
        }

        public void AjouterPouceEnBas()
        {
            _pouceEnBas++;
        }


        public override string ToString()
        {
            string score = (PouceEnHaut - PouceEnBas).ToString();
            return Contenu.Substring(0, Math.Min(25, Contenu.Length))+" - "+ Auteur + " - " +score;
        }

        public void RafraichirAffichage()
        {
            Text = ToString();
            foreach (Commentaire commnentaire  in Nodes)
            {
                commnentaire.RafraichirAffichage();
            }
        }

        public virtual void ExporterXML(StreamWriter pSw, int pDepth)
        {
            string tab = String.Concat(Enumerable.Repeat("\t", pDepth));
            pSw.WriteLine(tab+"<Commentaire>");
            pSw.WriteLine(tab +"\t<Contenu>" + Contenu + "</Contenu>");
            pSw.WriteLine(tab + "\t<PouceEnHaut>" + PouceEnHaut + "</PouceEnHaut>");
            pSw.WriteLine(tab + "\t<PouceEnBas>" + PouceEnBas + "</PouceEnBas>");
            pSw.WriteLine(tab + "\t<Auteur>" + Auteur + "</Auteur>");
            foreach (Commentaire comment in this.Nodes)
            {
                comment.ExporterXML(pSw, pDepth+1);
            }
            pSw.WriteLine(tab+"</Commentaire>");

        }

        public ListBox FiltrerSelonAuteur(string pAuteur, ListBox pLstBox)
        {
            if (Auteur == pAuteur)
                pLstBox.Items.Add(this);
            foreach (Commentaire publication in this.Nodes)
            {
                pLstBox = publication.FiltrerSelonAuteur(pAuteur, pLstBox);
            }

            return pLstBox;
        }
    }
}