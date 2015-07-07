namespace InvatamSaCalculam.Client.LandingPages
{
    partial class Blocks
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.pnlBlocks = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.txtBestScore = new System.Windows.Forms.TextBox();
            this.lblBestScore = new System.Windows.Forms.Label();
            this.txtCurrentScore = new System.Windows.Forms.TextBox();
            this.lblCurrentScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 2000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pnlBlocks
            // 
            this.pnlBlocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBlocks.Location = new System.Drawing.Point(3, 58);
            this.pnlBlocks.Name = "pnlBlocks";
            this.pnlBlocks.Size = new System.Drawing.Size(834, 500);
            this.pnlBlocks.TabIndex = 0;
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(726, 20);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "JOC NOU";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // txtBestScore
            // 
            this.txtBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBestScore.Location = new System.Drawing.Point(199, 15);
            this.txtBestScore.Name = "txtBestScore";
            this.txtBestScore.ReadOnly = true;
            this.txtBestScore.Size = new System.Drawing.Size(100, 31);
            this.txtBestScore.TabIndex = 252;
            this.txtBestScore.Text = "0";
            this.txtBestScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBestScore
            // 
            this.lblBestScore.AutoSize = true;
            this.lblBestScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblBestScore.Location = new System.Drawing.Point(8, 18);
            this.lblBestScore.Name = "lblBestScore";
            this.lblBestScore.Size = new System.Drawing.Size(185, 25);
            this.lblBestScore.TabIndex = 251;
            this.lblBestScore.Text = "Cel Mai Bun Scor:";
            // 
            // txtCurrentScore
            // 
            this.txtCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentScore.Location = new System.Drawing.Point(532, 15);
            this.txtCurrentScore.Name = "txtCurrentScore";
            this.txtCurrentScore.ReadOnly = true;
            this.txtCurrentScore.Size = new System.Drawing.Size(100, 31);
            this.txtCurrentScore.TabIndex = 254;
            this.txtCurrentScore.Text = "0";
            this.txtCurrentScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCurrentScore
            // 
            this.lblCurrentScore.AutoSize = true;
            this.lblCurrentScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblCurrentScore.Location = new System.Drawing.Point(398, 18);
            this.lblCurrentScore.Name = "lblCurrentScore";
            this.lblCurrentScore.Size = new System.Drawing.Size(128, 25);
            this.lblCurrentScore.TabIndex = 253;
            this.lblCurrentScore.Text = "Scor curent:";
            // 
            // Blocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCurrentScore);
            this.Controls.Add(this.lblCurrentScore);
            this.Controls.Add(this.txtBestScore);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.lblBestScore);
            this.Controls.Add(this.pnlBlocks);
            this.Name = "Blocks";
            this.Size = new System.Drawing.Size(840, 560);
            this.ParentChanged += new System.EventHandler(this.Blocks_ParentChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Panel pnlBlocks;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.TextBox txtBestScore;
        private System.Windows.Forms.Label lblBestScore;
        private System.Windows.Forms.TextBox txtCurrentScore;
        private System.Windows.Forms.Label lblCurrentScore;
    }
}
