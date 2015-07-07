namespace InvatamSaCalculam.Client.LandingPages
{
    partial class Register
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.chkIsTeacher = new System.Windows.Forms.CheckBox();
            this.ddlTeacher = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(209, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 154;
            this.label3.Text = "PAROLĂ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 25);
            this.label1.TabIndex = 153;
            this.label1.Text = "USER:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(325, 236);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(207, 44);
            this.txtPassword.TabIndex = 151;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.event_KeyUp);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(325, 155);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(207, 44);
            this.txtUserName.TabIndex = 150;
            this.txtUserName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.event_KeyUp);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(325, 406);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(246, 46);
            this.btnRegister.TabIndex = 152;
            this.btnRegister.Text = "INREGISTRARE";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // chkIsTeacher
            // 
            this.chkIsTeacher.AutoSize = true;
            this.chkIsTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.chkIsTeacher.Location = new System.Drawing.Point(325, 82);
            this.chkIsTeacher.Name = "chkIsTeacher";
            this.chkIsTeacher.Size = new System.Drawing.Size(157, 41);
            this.chkIsTeacher.TabIndex = 155;
            this.chkIsTeacher.Text = "Profesor";
            this.chkIsTeacher.UseVisualStyleBackColor = true;
            this.chkIsTeacher.CheckedChanged += new System.EventHandler(this.chkIsTeacher_CheckedChanged);
            // 
            // ddlTeacher
            // 
            this.ddlTeacher.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ddlTeacher.FormattingEnabled = true;
            this.ddlTeacher.Location = new System.Drawing.Point(325, 312);
            this.ddlTeacher.Name = "ddlTeacher";
            this.ddlTeacher.Size = new System.Drawing.Size(207, 45);
            this.ddlTeacher.TabIndex = 156;
            this.ddlTeacher.KeyUp += new System.Windows.Forms.KeyEventHandler(this.event_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(177, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 25);
            this.label2.TabIndex = 157;
            this.label2.Text = "PROFESOR:";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(137, 406);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 46);
            this.btnBack.TabIndex = 158;
            this.btnBack.Text = "INAPOI";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlTeacher);
            this.Controls.Add(this.chkIsTeacher);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnRegister);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(740, 530);
            this.ParentChanged += new System.EventHandler(this.Register_ParentChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.CheckBox chkIsTeacher;
        private System.Windows.Forms.ComboBox ddlTeacher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBack;
    }
}
