namespace Tp2_A20
{
    partial class frmAccueil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvPublications = new System.Windows.Forms.TreeView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtContenu = new System.Windows.Forms.TextBox();
            this.gbAuthentifie = new System.Windows.Forms.GroupBox();
            this.btnCreerCompte = new System.Windows.Forms.Button();
            this.btnAuthentifie = new System.Windows.Forms.Button();
            this.txtMdp = new System.Windows.Forms.TextBox();
            this.txtNomUtilisateur = new System.Windows.Forms.TextBox();
            this.lblMdp = new System.Windows.Forms.Label();
            this.lblNomUtilisateur = new System.Windows.Forms.Label();
            this.btnAjoutCommentaire = new System.Windows.Forms.Button();
            this.btnDiscussion = new System.Windows.Forms.Button();
            this.gbDiscuss = new System.Windows.Forms.GroupBox();
            this.btnDeconnexion = new System.Windows.Forms.Button();
            this.lstItemsFiltre = new System.Windows.Forms.ListBox();
            this.btnFiltreCat = new System.Windows.Forms.Button();
            this.btnFiltreUser = new System.Windows.Forms.Button();
            this.lblFiltre = new System.Windows.Forms.Label();
            this.txtFiltre = new System.Windows.Forms.TextBox();
            this.btnDownvote = new System.Windows.Forms.Button();
            this.btnUpvote = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbAuthentifie.SuspendLayout();
            this.gbDiscuss.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvPublications
            // 
            this.tvPublications.Location = new System.Drawing.Point(317, 12);
            this.tvPublications.Name = "tvPublications";
            this.tvPublications.Size = new System.Drawing.Size(587, 666);
            this.tvPublications.TabIndex = 0;
            this.tvPublications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPublications_AfterSelect);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // txtContenu
            // 
            this.txtContenu.Location = new System.Drawing.Point(910, 12);
            this.txtContenu.Multiline = true;
            this.txtContenu.Name = "txtContenu";
            this.txtContenu.Size = new System.Drawing.Size(498, 666);
            this.txtContenu.TabIndex = 3;
            // 
            // gbAuthentifie
            // 
            this.gbAuthentifie.Controls.Add(this.btnCreerCompte);
            this.gbAuthentifie.Controls.Add(this.btnAuthentifie);
            this.gbAuthentifie.Controls.Add(this.txtMdp);
            this.gbAuthentifie.Controls.Add(this.txtNomUtilisateur);
            this.gbAuthentifie.Controls.Add(this.lblMdp);
            this.gbAuthentifie.Controls.Add(this.lblNomUtilisateur);
            this.gbAuthentifie.Location = new System.Drawing.Point(11, 12);
            this.gbAuthentifie.Name = "gbAuthentifie";
            this.gbAuthentifie.Size = new System.Drawing.Size(299, 666);
            this.gbAuthentifie.TabIndex = 2;
            this.gbAuthentifie.TabStop = false;
            this.gbAuthentifie.Text = "Authentification";
            // 
            // btnCreerCompte
            // 
            this.btnCreerCompte.Location = new System.Drawing.Point(6, 82);
            this.btnCreerCompte.Name = "btnCreerCompte";
            this.btnCreerCompte.Size = new System.Drawing.Size(131, 32);
            this.btnCreerCompte.TabIndex = 7;
            this.btnCreerCompte.Text = "Créer un compte";
            this.btnCreerCompte.UseVisualStyleBackColor = true;
            this.btnCreerCompte.Click += new System.EventHandler(this.btnCreerCompte_Click);
            // 
            // btnAuthentifie
            // 
            this.btnAuthentifie.Location = new System.Drawing.Point(149, 82);
            this.btnAuthentifie.Name = "btnAuthentifie";
            this.btnAuthentifie.Size = new System.Drawing.Size(129, 32);
            this.btnAuthentifie.TabIndex = 6;
            this.btnAuthentifie.Text = "S\'authentifier";
            this.btnAuthentifie.UseVisualStyleBackColor = true;
            this.btnAuthentifie.Click += new System.EventHandler(this.btnAuthentifie_Click);
            // 
            // txtMdp
            // 
            this.txtMdp.Location = new System.Drawing.Point(90, 45);
            this.txtMdp.Name = "txtMdp";
            this.txtMdp.PasswordChar = '*';
            this.txtMdp.Size = new System.Drawing.Size(183, 23);
            this.txtMdp.TabIndex = 5;
            // 
            // txtNomUtilisateur
            // 
            this.txtNomUtilisateur.Location = new System.Drawing.Point(92, 16);
            this.txtNomUtilisateur.Name = "txtNomUtilisateur";
            this.txtNomUtilisateur.Size = new System.Drawing.Size(183, 23);
            this.txtNomUtilisateur.TabIndex = 2;
            // 
            // lblMdp
            // 
            this.lblMdp.AutoSize = true;
            this.lblMdp.Location = new System.Drawing.Point(6, 48);
            this.lblMdp.Name = "lblMdp";
            this.lblMdp.Size = new System.Drawing.Size(80, 15);
            this.lblMdp.TabIndex = 1;
            this.lblMdp.Text = "Mot de passe:";
            // 
            // lblNomUtilisateur
            // 
            this.lblNomUtilisateur.AutoSize = true;
            this.lblNomUtilisateur.Location = new System.Drawing.Point(6, 19);
            this.lblNomUtilisateur.Name = "lblNomUtilisateur";
            this.lblNomUtilisateur.Size = new System.Drawing.Size(63, 15);
            this.lblNomUtilisateur.TabIndex = 0;
            this.lblNomUtilisateur.Text = "Utilisateur:";
            // 
            // btnAjoutCommentaire
            // 
            this.btnAjoutCommentaire.Location = new System.Drawing.Point(6, 136);
            this.btnAjoutCommentaire.Name = "btnAjoutCommentaire";
            this.btnAjoutCommentaire.Size = new System.Drawing.Size(269, 23);
            this.btnAjoutCommentaire.TabIndex = 2;
            this.btnAjoutCommentaire.Text = "Ajouter un commentaire";
            this.btnAjoutCommentaire.UseVisualStyleBackColor = true;
            this.btnAjoutCommentaire.Click += new System.EventHandler(this.btnAjoutCommentaire_Click);
            // 
            // btnDiscussion
            // 
            this.btnDiscussion.Location = new System.Drawing.Point(6, 165);
            this.btnDiscussion.Name = "btnDiscussion";
            this.btnDiscussion.Size = new System.Drawing.Size(269, 23);
            this.btnDiscussion.TabIndex = 1;
            this.btnDiscussion.Text = "Ajouter une discussion";
            this.btnDiscussion.UseVisualStyleBackColor = true;
            this.btnDiscussion.Click += new System.EventHandler(this.btnDiscussion_Click);
            // 
            // gbDiscuss
            // 
            this.gbDiscuss.Controls.Add(this.btnDeconnexion);
            this.gbDiscuss.Controls.Add(this.lstItemsFiltre);
            this.gbDiscuss.Controls.Add(this.btnFiltreCat);
            this.gbDiscuss.Controls.Add(this.btnFiltreUser);
            this.gbDiscuss.Controls.Add(this.lblFiltre);
            this.gbDiscuss.Controls.Add(this.txtFiltre);
            this.gbDiscuss.Controls.Add(this.btnDownvote);
            this.gbDiscuss.Controls.Add(this.btnUpvote);
            this.gbDiscuss.Controls.Add(this.btnDiscussion);
            this.gbDiscuss.Controls.Add(this.btnAjoutCommentaire);
            this.gbDiscuss.Location = new System.Drawing.Point(12, 12);
            this.gbDiscuss.Name = "gbDiscuss";
            this.gbDiscuss.Size = new System.Drawing.Size(299, 666);
            this.gbDiscuss.TabIndex = 3;
            this.gbDiscuss.TabStop = false;
            this.gbDiscuss.Text = "Bienvenue";
            this.gbDiscuss.Visible = false;
            // 
            // btnDeconnexion
            // 
            this.btnDeconnexion.Location = new System.Drawing.Point(178, 633);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(100, 23);
            this.btnDeconnexion.TabIndex = 10;
            this.btnDeconnexion.Text = "Se déconnecter";
            this.btnDeconnexion.UseVisualStyleBackColor = true;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            // 
            // lstItemsFiltre
            // 
            this.lstItemsFiltre.FormattingEnabled = true;
            this.lstItemsFiltre.ItemHeight = 15;
            this.lstItemsFiltre.Location = new System.Drawing.Point(9, 428);
            this.lstItemsFiltre.Name = "lstItemsFiltre";
            this.lstItemsFiltre.Size = new System.Drawing.Size(269, 199);
            this.lstItemsFiltre.TabIndex = 9;
            this.lstItemsFiltre.SelectedIndexChanged += new System.EventHandler(this.lstItemsFiltre_SelectedIndexChanged);
            // 
            // btnFiltreCat
            // 
            this.btnFiltreCat.Location = new System.Drawing.Point(9, 385);
            this.btnFiltreCat.Name = "btnFiltreCat";
            this.btnFiltreCat.Size = new System.Drawing.Size(269, 23);
            this.btnFiltreCat.TabIndex = 8;
            this.btnFiltreCat.Text = "Filtrer par catégorie";
            this.btnFiltreCat.UseVisualStyleBackColor = true;
            this.btnFiltreCat.Click += new System.EventHandler(this.btnFiltreCat_Click);
            // 
            // btnFiltreUser
            // 
            this.btnFiltreUser.Location = new System.Drawing.Point(9, 351);
            this.btnFiltreUser.Name = "btnFiltreUser";
            this.btnFiltreUser.Size = new System.Drawing.Size(269, 23);
            this.btnFiltreUser.TabIndex = 7;
            this.btnFiltreUser.Text = "Filtrer par utilisateur";
            this.btnFiltreUser.UseVisualStyleBackColor = true;
            this.btnFiltreUser.Click += new System.EventHandler(this.btnFiltreUser_Click);
            // 
            // lblFiltre
            // 
            this.lblFiltre.AutoSize = true;
            this.lblFiltre.Location = new System.Drawing.Point(6, 300);
            this.lblFiltre.Name = "lblFiltre";
            this.lblFiltre.Size = new System.Drawing.Size(36, 15);
            this.lblFiltre.TabIndex = 6;
            this.lblFiltre.Text = "Filtre:";
            // 
            // txtFiltre
            // 
            this.txtFiltre.Location = new System.Drawing.Point(57, 297);
            this.txtFiltre.Name = "txtFiltre";
            this.txtFiltre.Size = new System.Drawing.Size(218, 23);
            this.txtFiltre.TabIndex = 5;
            // 
            // btnDownvote
            // 
            this.btnDownvote.Location = new System.Drawing.Point(6, 82);
            this.btnDownvote.Name = "btnDownvote";
            this.btnDownvote.Size = new System.Drawing.Size(269, 23);
            this.btnDownvote.TabIndex = 4;
            this.btnDownvote.Text = "Pouce vers le bas";
            this.btnDownvote.UseVisualStyleBackColor = true;
            this.btnDownvote.Click += new System.EventHandler(this.btnDownvote_Click);
            // 
            // btnUpvote
            // 
            this.btnUpvote.Location = new System.Drawing.Point(6, 48);
            this.btnUpvote.Name = "btnUpvote";
            this.btnUpvote.Size = new System.Drawing.Size(269, 23);
            this.btnUpvote.TabIndex = 3;
            this.btnUpvote.Text = "Pouce vers le haut";
            this.btnUpvote.UseVisualStyleBackColor = true;
            this.btnUpvote.Click += new System.EventHandler(this.btnUpvote_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 713);
            this.Controls.Add(this.txtContenu);
            this.Controls.Add(this.tvPublications);
            this.Controls.Add(this.gbDiscuss);
            this.Controls.Add(this.gbAuthentifie);
            this.Name = "frmAccueil";
            this.Text = "Accueil";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAccueil_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbAuthentifie.ResumeLayout(false);
            this.gbAuthentifie.PerformLayout();
            this.gbDiscuss.ResumeLayout(false);
            this.gbDiscuss.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvPublications;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtContenu;
        private System.Windows.Forms.GroupBox gbAuthentifie;
        private System.Windows.Forms.Button btnAjoutCommentaire;
        private System.Windows.Forms.Button btnDiscussion;
        private System.Windows.Forms.GroupBox gbDiscuss;
        private System.Windows.Forms.Button btnCreerCompte;
        private System.Windows.Forms.Button btnAuthentifie;
        private System.Windows.Forms.TextBox txtMdp;
        private System.Windows.Forms.TextBox txtNomUtilisateur;
        private System.Windows.Forms.Label lblMdp;
        private System.Windows.Forms.Label lblNomUtilisateur;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnDownvote;
        private System.Windows.Forms.Button btnUpvote;
        private System.Windows.Forms.Button btnFiltreCat;
        private System.Windows.Forms.Button btnFiltreUser;
        private System.Windows.Forms.Label lblFiltre;
        private System.Windows.Forms.TextBox txtFiltre;
        private System.Windows.Forms.Button btnDeconnexion;
        private System.Windows.Forms.ListBox lstItemsFiltre;
    }
}

