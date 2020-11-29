using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Tp2_A20
{
    public class Discussion : Commentaire
    {
        private string _titre;
        private string _categorie;

        public string Categorie
        {
            get { return _categorie; }
            set { _categorie = value.Trim(); }
        }

        public string Titre
        {
            get { return _titre; }
            set { _titre = value.Trim(); }
        }

        public Discussion()
        {
        }

        public Discussion(string pContenu, string pAuteur, int pUpvote, int pDownvote, string pTitre, string pCategorie) : base(pContenu, pAuteur, pUpvote, pDownvote)
        {
            Titre = pTitre;
            Categorie = pCategorie;
        }

        #region Overrides of Commentaire

        public override void ExporterXML(StreamWriter pSw, int pDepth)
        {
            pDepth = 2;
            pSw.WriteLine("\t<Discussion>");
            pSw.WriteLine("\t\t<Titre>" + Titre + "</Titre>");
            pSw.WriteLine("\t\t<Categorie>" + Categorie + "</Categorie>");
            pSw.WriteLine("\t\t<Contenu>" + Contenu + "</Contenu>");
            pSw.WriteLine("\t\t<PouceEnHaut>" + PouceEnHaut + "</PouceEnHaut>");
            pSw.WriteLine("\t\t<PouceEnBas>" + PouceEnBas + "</PouceEnBas>");
            pSw.WriteLine("\t\t<Auteur>" + Auteur + "</Auteur>");
            foreach (Commentaire comment in this.Nodes)
            {
                comment.ExporterXML(pSw, pDepth);
            }
            pSw.WriteLine("\t</Discussion>");

        }

        #endregion
    }
}