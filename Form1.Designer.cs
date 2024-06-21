namespace DKOTournamentApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtPlayerName = new System.Windows.Forms.TextBox();
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.btnCreateTournament = new System.Windows.Forms.Button();
            this.lstMatches = new System.Windows.Forms.ListBox();
            this.lblMatchDetails = new System.Windows.Forms.Label();
            this.btnPlayer1Win = new System.Windows.Forms.Button();
            this.btnPlayer2Win = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.Location = new System.Drawing.Point(12, 12);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(160, 20);
            this.txtPlayerName.TabIndex = 0;
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(178, 10);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 1;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(12, 39);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(241, 95);
            this.lstPlayers.TabIndex = 2;
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.Location = new System.Drawing.Point(12, 140);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.Size = new System.Drawing.Size(241, 23);
            this.btnCreateTournament.TabIndex = 3;
            this.btnCreateTournament.Text = "Create Tournament";
            this.btnCreateTournament.UseVisualStyleBackColor = true;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // lstMatches
            // 
            this.lstMatches.FormattingEnabled = true;
            this.lstMatches.Location = new System.Drawing.Point(12, 168);
            this.lstMatches.Name = "lstMatches";
            this.lstMatches.Size = new System.Drawing.Size(241, 95);
            this.lstMatches.TabIndex = 4;
            this.lstMatches.SelectedIndexChanged += new System.EventHandler(this.lstMatches_SelectedIndexChanged);
            // 
            // lblMatchDetails
            // 
            this.lblMatchDetails.AutoSize = true;
            this.lblMatchDetails.Location = new System.Drawing.Point(12, 266);
            this.lblMatchDetails.Name = "lblMatchDetails";
            this.lblMatchDetails.Size = new System.Drawing.Size(0, 13);
            this.lblMatchDetails.TabIndex = 5;
            // 
            // btnPlayer1Win
            // 
            this.btnPlayer1Win.Enabled = false;
            this.btnPlayer1Win.Location = new System.Drawing.Point(12, 282);
            this.btnPlayer1Win.Name = "btnPlayer1Win";
            this.btnPlayer1Win.Size = new System.Drawing.Size(75, 23);
            this.btnPlayer1Win.TabIndex = 6;
            this.btnPlayer1Win.Text = "Player 1 Wins";
            this.btnPlayer1Win.UseVisualStyleBackColor = true;
            this.btnPlayer1Win.Click += new System.EventHandler(this.btnPlayer1Win_Click);
            // 
            // btnPlayer2Win
            // 
            this.btnPlayer2Win.Enabled = false;
            this.btnPlayer2Win.Location = new System.Drawing.Point(93, 282);
            this.btnPlayer2Win.Name = "btnPlayer2Win";
            this.btnPlayer2Win.Size = new System.Drawing.Size(75, 23);
            this.btnPlayer2Win.TabIndex = 7;
            this.btnPlayer2Win.Text = "Player 2 Wins";
            this.btnPlayer2Win.UseVisualStyleBackColor = true;
            this.btnPlayer2Win.Click += new System.EventHandler(this.btnPlayer2Win_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 317);
            this.Controls.Add(this.btnPlayer2Win);
            this.Controls.Add(this.btnPlayer1Win);
            this.Controls.Add(this.lblMatchDetails);
            this.Controls.Add(this.lstMatches);
            this.Controls.Add(this.btnCreateTournament);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.btnAddPlayer);
            this.Controls.Add(this.txtPlayerName);
            this.Name = "Form1";
            this.Text = "DKO Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtPlayerName;
        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Button btnCreateTournament;
        private System.Windows.Forms.ListBox lstMatches;
        private System.Windows.Forms.Label lblMatchDetails;
        private System.Windows.Forms.Button btnPlayer1Win;
        private System.Windows.Forms.Button btnPlayer2Win;
    }
}
