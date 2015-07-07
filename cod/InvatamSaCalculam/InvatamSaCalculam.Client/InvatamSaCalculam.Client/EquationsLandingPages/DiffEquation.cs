using System;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.EquationsLandingPages
{
    public partial class DiffEquation : UserControl
    {
        public DiffEquation()
        {
            InitializeComponent();
        }

        private void btnResultTop_Click(object sender, System.EventArgs e)
        {
            if ((txtSubtrahend.Text == "") || (txtDifferenceTop.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int sum = Convert.ToInt16(txtSubtrahend.Text) + Convert.ToInt16(txtDifferenceTop.Text);
                lblResultTop.Text = "X = " + sum;
            }
        }

        private void btnResultBottom_Click(object sender, System.EventArgs e)
        {
            if ((txtMinuend.Text == "") || (txtDifferenceBottom.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int diff = Convert.ToInt16(txtMinuend.Text) - Convert.ToInt16(txtDifferenceBottom.Text);
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
