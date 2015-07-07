using System;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.EquationsLandingPages
{
    public partial class MulEquation : UserControl
    {
        public MulEquation()
        {
            InitializeComponent();
        }

        private void btnResultTop_Click(object sender, System.EventArgs e)
        {
            if ((txtSecondFactor.Text == "") || (txtProductTop.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int div = Convert.ToInt32(txtProductTop.Text)/Convert.ToInt32(txtSecondFactor.Text);
                lblResultTop.Text = "X = " + div;
            }
        }

        private void btnResultBottom_Click(object sender, System.EventArgs e)
        {
            if ((txtFirstFactor.Text == "") || (txtProductBottom.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int div = Convert.ToInt32(txtProductTop.Text) / Convert.ToInt32(txtFirstFactor.Text);
                lblResultBottom.Text = "X = " + div;
            }
        }

        private void textBox_Validated(object sender, EventArgs e)
        {
            try
            {
                if (((TextBox)sender).Text != "")
                {
                    int number = Convert.ToInt16(((TextBox)sender).Text);
                }
            }
            catch
            {
                MessageBox.Show("Completaţi casuţele cu numere!");
                ((TextBox)sender).Text = "";
                ((TextBox)sender).Focus();
            }
        }
    }
}
