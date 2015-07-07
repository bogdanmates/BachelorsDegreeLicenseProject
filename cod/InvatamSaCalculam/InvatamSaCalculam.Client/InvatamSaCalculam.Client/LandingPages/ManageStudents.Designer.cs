namespace InvatamSaCalculam.Client.LandingPages
{
    partial class ManageStudents
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
            this.gvStudents = new System.Windows.Forms.DataGridView();
            this.dsStudentsLocal = new MathAssistant.Client.LandingPages.Helpers.dsStudents();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smallGoldMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smallSilverMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smallBronzeMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bigGoldMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bigSilverMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bigBronzeMedalsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addCupsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diffCupsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divCupsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mulCupsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scoreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hangmanDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blocksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reset = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsStudentsLocal)).BeginInit();
            this.SuspendLayout();
            // 
            // gvStudents
            // 
            this.gvStudents.AllowUserToAddRows = false;
            this.gvStudents.AutoGenerateColumns = false;
            this.gvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.smallGoldMedalsDataGridViewTextBoxColumn,
            this.smallSilverMedalsDataGridViewTextBoxColumn,
            this.smallBronzeMedalsDataGridViewTextBoxColumn,
            this.bigGoldMedalsDataGridViewTextBoxColumn,
            this.bigSilverMedalsDataGridViewTextBoxColumn,
            this.bigBronzeMedalsDataGridViewTextBoxColumn,
            this.addCupsDataGridViewTextBoxColumn,
            this.diffCupsDataGridViewTextBoxColumn,
            this.divCupsDataGridViewTextBoxColumn,
            this.mulCupsDataGridViewTextBoxColumn,
            this.scoreDataGridViewTextBoxColumn,
            this.hangmanDataGridViewTextBoxColumn,
            this.blocksDataGridViewTextBoxColumn,
            this.Reset,
            this.Delete});
            this.gvStudents.DataMember = "Students";
            this.gvStudents.DataSource = this.dsStudentsLocal;
            this.gvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvStudents.Location = new System.Drawing.Point(0, 0);
            this.gvStudents.Name = "gvStudents";
            this.gvStudents.Size = new System.Drawing.Size(1000, 464);
            this.gvStudents.TabIndex = 0;
            this.gvStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvStudents_CellContentClick);
            this.gvStudents.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gvStudents_ColumnHeaderMouseClick);
            // 
            // dsStudentsLocal
            // 
            this.dsStudentsLocal.DataSetName = "dsStudents";
            this.dsStudentsLocal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 50;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 50;
            // 
            // smallGoldMedalsDataGridViewTextBoxColumn
            // 
            this.smallGoldMedalsDataGridViewTextBoxColumn.DataPropertyName = "SmallGoldMedals";
            this.smallGoldMedalsDataGridViewTextBoxColumn.HeaderText = "SmallGoldMedals";
            this.smallGoldMedalsDataGridViewTextBoxColumn.Name = "smallGoldMedalsDataGridViewTextBoxColumn";
            this.smallGoldMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // smallSilverMedalsDataGridViewTextBoxColumn
            // 
            this.smallSilverMedalsDataGridViewTextBoxColumn.DataPropertyName = "SmallSilverMedals";
            this.smallSilverMedalsDataGridViewTextBoxColumn.HeaderText = "SmallSilverMedals";
            this.smallSilverMedalsDataGridViewTextBoxColumn.Name = "smallSilverMedalsDataGridViewTextBoxColumn";
            this.smallSilverMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // smallBronzeMedalsDataGridViewTextBoxColumn
            // 
            this.smallBronzeMedalsDataGridViewTextBoxColumn.DataPropertyName = "SmallBronzeMedals";
            this.smallBronzeMedalsDataGridViewTextBoxColumn.HeaderText = "SmallBronzeMedals";
            this.smallBronzeMedalsDataGridViewTextBoxColumn.Name = "smallBronzeMedalsDataGridViewTextBoxColumn";
            this.smallBronzeMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // bigGoldMedalsDataGridViewTextBoxColumn
            // 
            this.bigGoldMedalsDataGridViewTextBoxColumn.DataPropertyName = "BigGoldMedals";
            this.bigGoldMedalsDataGridViewTextBoxColumn.HeaderText = "BigGoldMedals";
            this.bigGoldMedalsDataGridViewTextBoxColumn.Name = "bigGoldMedalsDataGridViewTextBoxColumn";
            this.bigGoldMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // bigSilverMedalsDataGridViewTextBoxColumn
            // 
            this.bigSilverMedalsDataGridViewTextBoxColumn.DataPropertyName = "BigSilverMedals";
            this.bigSilverMedalsDataGridViewTextBoxColumn.HeaderText = "BigSilverMedals";
            this.bigSilverMedalsDataGridViewTextBoxColumn.Name = "bigSilverMedalsDataGridViewTextBoxColumn";
            this.bigSilverMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // bigBronzeMedalsDataGridViewTextBoxColumn
            // 
            this.bigBronzeMedalsDataGridViewTextBoxColumn.DataPropertyName = "BigBronzeMedals";
            this.bigBronzeMedalsDataGridViewTextBoxColumn.HeaderText = "BigBronzeMedals";
            this.bigBronzeMedalsDataGridViewTextBoxColumn.Name = "bigBronzeMedalsDataGridViewTextBoxColumn";
            this.bigBronzeMedalsDataGridViewTextBoxColumn.Width = 75;
            // 
            // addCupsDataGridViewTextBoxColumn
            // 
            this.addCupsDataGridViewTextBoxColumn.DataPropertyName = "AddCups";
            this.addCupsDataGridViewTextBoxColumn.HeaderText = "AddCups";
            this.addCupsDataGridViewTextBoxColumn.Name = "addCupsDataGridViewTextBoxColumn";
            this.addCupsDataGridViewTextBoxColumn.Width = 60;
            // 
            // diffCupsDataGridViewTextBoxColumn
            // 
            this.diffCupsDataGridViewTextBoxColumn.DataPropertyName = "DiffCups";
            this.diffCupsDataGridViewTextBoxColumn.HeaderText = "DiffCups";
            this.diffCupsDataGridViewTextBoxColumn.Name = "diffCupsDataGridViewTextBoxColumn";
            this.diffCupsDataGridViewTextBoxColumn.Width = 60;
            // 
            // divCupsDataGridViewTextBoxColumn
            // 
            this.divCupsDataGridViewTextBoxColumn.DataPropertyName = "DivCups";
            this.divCupsDataGridViewTextBoxColumn.HeaderText = "DivCups";
            this.divCupsDataGridViewTextBoxColumn.Name = "divCupsDataGridViewTextBoxColumn";
            this.divCupsDataGridViewTextBoxColumn.Width = 60;
            // 
            // mulCupsDataGridViewTextBoxColumn
            // 
            this.mulCupsDataGridViewTextBoxColumn.DataPropertyName = "MulCups";
            this.mulCupsDataGridViewTextBoxColumn.HeaderText = "MulCups";
            this.mulCupsDataGridViewTextBoxColumn.Name = "mulCupsDataGridViewTextBoxColumn";
            this.mulCupsDataGridViewTextBoxColumn.Width = 60;
            // 
            // scoreDataGridViewTextBoxColumn
            // 
            this.scoreDataGridViewTextBoxColumn.DataPropertyName = "Score";
            this.scoreDataGridViewTextBoxColumn.HeaderText = "Score";
            this.scoreDataGridViewTextBoxColumn.Name = "scoreDataGridViewTextBoxColumn";
            this.scoreDataGridViewTextBoxColumn.Width = 50;
            // 
            // hangmanDataGridViewTextBoxColumn
            // 
            this.hangmanDataGridViewTextBoxColumn.DataPropertyName = "Hangman";
            this.hangmanDataGridViewTextBoxColumn.HeaderText = "Hangman";
            this.hangmanDataGridViewTextBoxColumn.Name = "hangmanDataGridViewTextBoxColumn";
            this.hangmanDataGridViewTextBoxColumn.Width = 60;
            // 
            // blocksDataGridViewTextBoxColumn
            // 
            this.blocksDataGridViewTextBoxColumn.DataPropertyName = "Blocks";
            this.blocksDataGridViewTextBoxColumn.HeaderText = "Blocks";
            this.blocksDataGridViewTextBoxColumn.Name = "blocksDataGridViewTextBoxColumn";
            this.blocksDataGridViewTextBoxColumn.Width = 50;
            // 
            // Reset
            // 
            this.Reset.DataPropertyName = "Reset";
            this.Reset.HeaderText = "Reset";
            this.Reset.Name = "Reset";
            this.Reset.Width = 50;
            // 
            // Delete
            // 
            this.Delete.DataPropertyName = "Delete";
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Text = "";
            this.Delete.Width = 50;
            // 
            // ManageStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvStudents);
            this.Name = "ManageStudents";
            this.Size = new System.Drawing.Size(1000, 464);
            this.ParentChanged += new System.EventHandler(this.ManageStudents_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.gvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsStudentsLocal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MathAssistant.Client.LandingPages.Helpers.dsStudents dsStudentsLocal;
        private System.Windows.Forms.DataGridView gvStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smallGoldMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smallSilverMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn smallBronzeMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bigGoldMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bigSilverMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bigBronzeMedalsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addCupsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn diffCupsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn divCupsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mulCupsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hangmanDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn blocksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Reset;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;

    }
}
