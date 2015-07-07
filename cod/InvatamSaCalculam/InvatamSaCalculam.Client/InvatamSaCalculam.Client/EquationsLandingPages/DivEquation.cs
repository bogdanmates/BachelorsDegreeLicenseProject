using System;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.EquationsLandingPages
{
    public partial class DivEquation : UserControl
    {
        public DivEquation()
        {
            InitializeComponent();
        }

        private void btnResultTop_Click(object sender, System.EventArgs e)
        {
            if ((txtDivisorTop.Text == "") || (txtQuotientTop.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int remainder = txtRemainderTop.Text.Equals("") ? 0 : Convert.ToInt32(txtRemainderTop.Text);
                int divisor = Convert.ToInt32(txtDivisorTop.Text);
                int dividend = divisor * Convert.ToInt32(txtQuotientTop.Text) + remainder;

                if (remainder < divisor)
                {
                    lblResultTop.Text = "X = " + dividend;
                }
                else
                {
                    lblResultTop.Text = "imposibil";
                }
            }
        }

        private void btnResultMiddle_Click(object sender, System.EventArgs e)
        {
            if ((txtDividendMiddle.Text == "") || (txtQuotientMiddle.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int remainder = txtRemainderMiddle.Text.Equals("") ? 0 : Convert.ToInt32(txtRemainderMiddle.Text);
                int divisor = (Convert.ToInt32(txtDividendMiddle.Text) - remainder) /
                              Convert.ToInt32(txtQuotientMiddle.Text);

                if (remainder < divisor)
                {
                    lblResultMiddle.Text = "X = " + divisor;
                }
                else
                {
                    lblResultMiddle.Text = "imposibil";
                }
            }
        }

        private void btnResultBottom_Click(object sender, System.EventArgs e)
        {
            if ((txtDividendBottom.Text == "") || (txtDivisorBottom.Text == "") || (txtQuotientBottom.Text == ""))
            {
                MessageBox.Show("Completati casutele colorate");
            }
            else
            {
                int divisor = Convert.ToInt16(txtDivisorBottom.Text);
                int remainder = Convert.ToInt16(txtDividendBottom.Text) - (divisor * Convert.ToInt16(txtQuotientBottom.Text));

                if (remainder < 0)
                {
                    lblResultBottom.Text = "imposibil";
                }
                else
                {
                    if (remainder < divisor)
                    {
                        lblResultBottom.Text = "X = " + remainder;
                    }
                    else
                    {
                        lblResultBottom.Text = "imposibil";
                    }
                }
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
