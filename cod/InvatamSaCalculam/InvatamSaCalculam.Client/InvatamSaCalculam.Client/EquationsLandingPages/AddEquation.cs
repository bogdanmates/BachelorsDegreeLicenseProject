using System;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.EquationsLandingPages
{
    public partial class AddEquation : UserControl
    {
        public AddEquation()
        {
            InitializeComponent();
        }

        private void btnResultTop_Click(object sender, System.EventArgs e)
        {
            if ((txtSecondAddend.Text == "") || (txtSumTop.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int diff = Convert.ToInt16(txtSumTop.Text) - Convert.ToInt16(txtSecondAddend.Text);
                lblResultTop.Text = "X = " + diff;
            }
        }

        private void btnResultBottom_Click(object sender, EventArgs e)
        {
            if ((txtFirstAddend.Text == "") || (txtSumBottom.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int diff = Convert.ToInt16(txtSumBottom.Text) - Convert.ToInt16(txtFirstAddend.Text);
                lblResultBottom.Text = "X = " + diff;
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
