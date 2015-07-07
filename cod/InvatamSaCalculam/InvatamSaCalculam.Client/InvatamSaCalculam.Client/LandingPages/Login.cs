using System;
using System.Diagnostics;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Login : UserControl
    {
        private MainPage callback;

        public Login(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
            CheckServerConnection();
        }

        private void CheckServerConnection()
        {
            try
            {
                BusinessStructure.Instance.BDService.CheckConnection();
            }
            catch
            {
                btnLogin.Enabled = false;
                btnRegister.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrWhiteSpace(txtUserName.Text)) || (string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                MessageBox.Show("Completaţi toate căsuţele!");
            }
            else
            {
                int? userId = BusinessStructure.Instance.BDService.Login(txtUserName.Text, PasswordHandler.Instance.EncryptString(txtPassword.Text));
                if (userId == null)
                {
                    MessageBox.Show("User inexistent!");
                    ClearFields();
                }
                else
                {
                    if (userId == 0)
                    {
                        MessageBox.Show("Parolă incorectă!");
                        txtPassword.Text = "";
                    }
                    else
                    {
                        BusinessStructure.Instance.UserId = (int)userId;
                        BusinessStructure.Instance.Username = txtUserName.Text;
                        BusinessStructure.Instance.IsTeacher = BusinessStructure.Instance.BDService.IsTeacher((int)userId);
                        BusinessStructure.Instance.IsGuest = false;
                        ClearFields();
                        callback.ShowMainMenuLandingPage();
                    }
                }
            }
        }

        private void ClearFields()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            BusinessStructure.Instance.IsGuest = true;
            BusinessStructure.Instance.IsTeacher = false;
            callback.ShowMainMenuLandingPage();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            callback.ShowRegisterLandingPage();
        }

        private void event_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
