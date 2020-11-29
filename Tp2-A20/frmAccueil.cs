using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;

namespace Tp2_A20
{
    public partial class frmAccueil : Form
    {

        private Dictionary<string, Utilisateur> _dicoUsers;
        private Dictionary<string, byte[]> _dicoSalts;
        private Session _session;

        public Dictionary<string, Utilisateur> DicoUsers
        {
            get { return _dicoUsers; }
            set { _dicoUsers = value; }
        }

        public Dictionary<string, byte[]> DicoSalts
        {
            get { return _dicoSalts; }
            set { _dicoSalts = value; }
        }

        public Session Session
        {
            get { return _session; }
            set { _session = value; }
        }

        public frmAccueil()
        {
            InitializeComponent();
            if (File.Exists("user.dat") && File.Exists("user.slt"))
            {
                try
                {
                    chargerFichiers();
                }
                catch (Exception e)
                {
                    _dicoSalts = new Dictionary<string, byte[]>();
                    _dicoUsers = new Dictionary<string, Utilisateur>();
                    _session = new Session();
                }
            }
            else
            {
                _dicoSalts = new Dictionary<string, byte[]>();
                _dicoUsers = new Dictionary<string, Utilisateur>();
                _session = new Session();
            }

            if (_session.User != null)
                FlipUI();

            if (File.Exists("TreeView.xml"))
            {
                tvPublications = Utilitaires.ImporterXML("TreeView.xml", tvPublications);
                RafraichirTreeView();
            }
        }


        private void frmAccueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("user.dat"))
                sw.Write(JsonSerializer.Serialize(_dicoUsers, typeof(Dictionary<string, Utilisateur>)));
            using (StreamWriter sw = new StreamWriter("user.slt"))
                sw.Write(JsonSerializer.Serialize(_dicoSalts, typeof(Dictionary<string, byte[]>)));
            using (StreamWriter sw = new StreamWriter("session.dat"))
                sw.Write(JsonSerializer.Serialize(_session, typeof(Session)));

            Utilitaires.ExporterXML(tvPublications, "TreeView.xml");

        }


        private void btnDiscussion_Click(object sender, EventArgs e)
        {
            frmAjoutDiscussion formulaireAjout = new frmAjoutDiscussion(_session);
            if (formulaireAjout.ShowDialog() == DialogResult.OK)
            {
                Discussion discussion = formulaireAjout.Discussion;
                tvPublications.Nodes.Add(discussion);
                RafraichirTreeView();
            }
        }

        private void btnAjoutCommentaire_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (tvPublications.SelectedNode != null)
            {
                frmAjoutDiscussion formulaireAjout =
                    new frmAjoutDiscussion(((Commentaire) tvPublications.SelectedNode).Contenu, _session);
                if (formulaireAjout.ShowDialog() == DialogResult.OK)
                {
                    Commentaire commentaire = formulaireAjout.Commentaire;
                    tvPublications.SelectedNode.Nodes.Add(commentaire);
                    RafraichirTreeView();
                }
            }
            else
            {
                errorProvider1.SetError(btnAjoutCommentaire, "Veuillez sélectionner un commentaire ou une discussion");
            }
        }


        private void tvPublications_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtContenu.Text = ((Commentaire) tvPublications.SelectedNode).Contenu;
        }

        private void btnAuthentifie_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (_dicoUsers.ContainsKey(txtNomUtilisateur.Text))
            {
                if (Utilitaires.VerifierMdp(txtMdp.Text,_dicoSalts[txtNomUtilisateur.Text],_dicoUsers[txtNomUtilisateur.Text].Mdp))
                {
                    _session.User = new Utilisateur(txtNomUtilisateur.Text, Utilitaires.HashMotDePasse(txtMdp.Text, _dicoSalts[txtNomUtilisateur.Text]));
                    _session.Actif = true;

                    FlipUI();
                }
            }
            else 
            {
                errorProvider1.SetError(txtNomUtilisateur, "Erreur d'authentification");
                errorProvider1.SetError(txtMdp, "Erreur d'authentification");
            }


        }

        private void btnCreerCompte_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (_dicoUsers.ContainsKey(txtNomUtilisateur.Text))
                errorProvider1.SetError(txtNomUtilisateur, String.Format("Ce nom d'utilisateur est déja pris \n Suggestions : xX{0}420Xx", txtNomUtilisateur.Text));
            else if(txtNomUtilisateur.Text.Length < 3)
                errorProvider1.SetError(txtNomUtilisateur, "votre nom d'utilisateur doit avoir au minimum 3 charactère");
            else if (txtMdp.Text.Length < 3)
                errorProvider1.SetError(txtMdp, "votre mot de passe doit avoir au minimum 3 charactère");
            else if (!(Regex.IsMatch(txtNomUtilisateur.Text, @"^[a-zA-Z0-9_]+$")))
                errorProvider1.SetError(txtNomUtilisateur, "Votre nom d'utilisateur doit contenir que des lettres, chiffre ou barre de soulignement");
            else if (!(Regex.IsMatch(txtMdp.Text, @"^[a-zA-Z0-9_]+$")))
                errorProvider1.SetError(txtMdp, "Votre mot de passe doit contenir que des lettres, chiffre ou barre de soulignement");
            else
            {
                _dicoSalts.Add(txtNomUtilisateur.Text,Utilitaires.SaltMotDePasse());
                byte[] mdp = Utilitaires.HashMotDePasse(txtMdp.Text, _dicoSalts[txtNomUtilisateur.Text]);
                Utilisateur user = new Utilisateur(txtNomUtilisateur.Text, mdp);

                _dicoUsers.Add(txtNomUtilisateur.Text, user);

                _session.User = user;
                _session.Actif = true;

                FlipUI();
            }
        }

        private void chargerFichiers()
        {
            using (StreamReader sr = new StreamReader("user.dat"))
                _dicoUsers = (Dictionary<string, Utilisateur>)JsonSerializer.Deserialize(sr.ReadToEnd(),
                    typeof(Dictionary<string, Utilisateur>));

            using (StreamReader sr = new StreamReader("user.slt"))
                _dicoSalts =
                    (Dictionary<string, byte[]>)JsonSerializer.Deserialize(sr.ReadToEnd(),
                        typeof(Dictionary<string, byte[]>));

            if (File.Exists("session.dat"))
            {
                using (StreamReader sr = new StreamReader("session.dat"))
                    _session = (Session)JsonSerializer.Deserialize(sr.ReadToEnd(), typeof(Session));
            }
            else
                _session = new Session();

        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            _session = new Session();
            FlipUI();
        }

        private void btnUpvote_Click(object sender, EventArgs e)
        {
            Vote(true);
        }

        private void btnDownvote_Click(object sender, EventArgs e)
        {
            Vote(false);
        }

        private void Vote(bool pUpvote)
        {
            errorProvider1.Clear();
            if (tvPublications.SelectedNode != null)
            {
                if (_session.Actif)
                {
                    Commentaire noeud = (Commentaire)tvPublications.SelectedNode;
                    if (pUpvote)
                        noeud.AjouterPouceEnHaut();
                    else
                        noeud.AjouterPouceEnBas();
                    RafraichirTreeView();
                }
            }
            else
            {
                if (pUpvote)
                    errorProvider1.SetError(btnUpvote, "Aucune discussion ou commentaire sélectionner");
                else
                    errorProvider1.SetError(btnDownvote, "Aucune discussion ou commentaire sélectionner");
            }

        }

        private void RafraichirTreeView()
        {
            foreach (Discussion noeuDiscussion in tvPublications.Nodes)
            {
                noeuDiscussion.RafraichirAffichage();
            }
            tvPublications.TreeViewNodeSorter = new NodeSorter();
            tvPublications.Sort();
            tvPublications.Refresh();
            tvPublications.Focus();
            errorProvider1.Clear();
        }

        private void FlipUI()
        {
            errorProvider1.Clear();
            if (gbDiscuss.Visible)
            {
                gbDiscuss.Visible = false;
                gbAuthentifie.Visible = true;
            }
            else
            {
                gbDiscuss.Visible = true;
                gbAuthentifie.Visible = false;
            }

        }

        private void btnFiltreUser_Click(object sender, EventArgs e)
        {
            lstItemsFiltre.Items.Clear();
            string utilisateur = txtFiltre.Text;
            foreach (Commentaire publication in tvPublications.Nodes)
            {
                lstItemsFiltre = publication.FiltrerSelonAuteur(utilisateur, lstItemsFiltre);
            }
        }

        private void btnFiltreCat_Click(object sender, EventArgs e)
        {
            lstItemsFiltre.Items.Clear();
            string cat = txtFiltre.Text.Trim();
            foreach (Discussion discussion in tvPublications.Nodes)
            {
                if (discussion.Categorie == cat)
                    lstItemsFiltre.Items.Add(discussion);
            }
        }

        private void lstItemsFiltre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstItemsFiltre.SelectedIndex != -1)
            {
                Commentaire selectedNode = (Commentaire) lstItemsFiltre.Items[lstItemsFiltre.SelectedIndex];
                tvPublications.SelectedNode = selectedNode;
                tvPublications.Focus();
            }
        }
    }
}