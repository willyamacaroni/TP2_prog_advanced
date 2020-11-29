using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tp2_A20
{
    [Serializable]
    public class Utilisateur
    {
        private string _nom;
        private byte[] _mdp;

        public string NomUtilisateur
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public byte[] Mdp
        {
            get { return _mdp; }
            set { _mdp = value; }
        }

        public Utilisateur()
        {
        }

        public Utilisateur(string pNomUtilisateur, byte[] pMdp)
        {
            NomUtilisateur = pNomUtilisateur;
            Mdp = pMdp;
        }

    }
}