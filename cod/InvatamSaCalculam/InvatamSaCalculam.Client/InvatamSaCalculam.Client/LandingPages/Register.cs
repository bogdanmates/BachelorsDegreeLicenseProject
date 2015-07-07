using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;
using InvatamSaCalculam.Client.ServiceReference;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Register : UserControl
    {
        private MainPage callback;

        public Register(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void Register_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                FillTeachers();
            }
        }

        private void FillTeachers()
        {
            List<User> teachersList = BusinessStructure.Instance.BDService.GetTeachers();
            ddlTeacher.Items.Clear();
            foreach (User teacher in teachersList)
            {
                ddlTeacher.Items.Add(teacher.Username);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Trebuie completate toate casutele.");
                return;
            }
            if (!chkIsTeacher.Checked && string.IsNullOrWhiteSpace(ddlTeacher.Text))
            {
                MessageBox.Show("Trebuie sa alegeti un profesor.");
                return;
            }
            if (BusinessStructure.Instance.BDService.Register(txtUserName.Text, PasswordHandler.Instance.EncryptString(txtPassword.Text), chkIsTeacher.Checked, chkIsTeacher.Checked ? null : ddlTeacher.Text) == false)
            {
                MessageBox.Show("Utilizatorul există deja!");
                ClearFields();
                txtUserName.Focus();
            }
            else
            {
                MessageBox.Show("Utilizatorul a fost inregistrat cu succes.");
                ClearFields();
                callback.ShowLoginLandingPage();
            }
        }

        private void ClearFields()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            ddlTeacher.Text = "";
            chkIsTeacher.Checked = false;
        }

        private void chkIsTeacher_CheckedChanged(object sender, EventArgs e)
        {
            ddlTeacher.Enabled = !chkIsTeacher.Checked;
        }

        private void event_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnRegister_Click(null, null);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            callback.ShowLoginLandingPage();
        }
    }
}
