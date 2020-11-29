using System;
using System.Collections.Generic;
using System.Text;

namespace Tp2_A20
{
    [Serializable]
    public class Session
    {
        private Utilisateur _user;
        private bool _actif;

        public Utilisateur User
        {
            get { return _user; }
            set { _user = value; }
        }

        public bool Actif
        {
            get { return _actif; }
            set { _actif = value; }
        }

        public Session()
        {
            User = null;
            Actif = false;
        }
        public Session(Utilisateur pUser, bool pActif)
        {
            User = pUser;
            Actif = pActif;
        }
    }
}
