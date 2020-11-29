using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Tp2_A20
{
    public partial class frmAjoutDiscussion : Form
    {
        private Discussion _discussion;
        private Commentaire _commentaire;
        private bool _bAjoutCommentaire;
        private Session _session;

        public Commentaire Commentaire
        {
            get { return _commentaire; }
        }

        public Discussion Discussion
        {
            get { return _discussion; }
        }

        public frmAjoutDiscussion(Session session)
        {
            InitializeComponent();
            _bAjoutCommentaire = false;
            _session = session;
        }

        public frmAjoutDiscussion(string pContenu, Session session)
        {
            InitializeComponent();
            txtTitre.Text = pContenu.Substring(0, Math.Min(50, pContenu.Length));
            txtTitre.Enabled = false;
            txtCatégorie.Enabled = false;
            _bAjoutCommentaire = true;
            _session = session;
        }

        private void btnSauvegarder_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            bool bValide = true;

            if (txtTitre.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtTitre, "Votre titre doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (!_bAjoutCommentaire && txtCatégorie.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtCatégorie, "Votre catégorie doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (txtContenu.Text.Trim().Length < 3)
            {
                errorProvider1.SetError(txtContenu, "Votre contenu doit comporter au moins 3 caractères");
                bValide = false;
            }

            if (bValide)
            {
                if (_bAjoutCommentaire)
                {
                    _commentaire = new Commentaire( txtContenu.Text, _session.User.NomUtilisateur, 0 ,0);
                }
                else
                {
                    _discussion = new Discussion( txtContenu.Text, _session.User.NomUtilisateur,0 ,0, txtTitre.Text, txtCatégorie.Text);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}