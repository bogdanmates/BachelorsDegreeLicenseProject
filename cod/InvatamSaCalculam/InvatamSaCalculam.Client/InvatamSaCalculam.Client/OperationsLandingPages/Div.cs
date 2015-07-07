using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.OperationsLandingPages
{
    public partial class Div : UserControl
    {
        private MainPage callback;

        public Div(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            if ((txtDividend.Text == "") || (txtDivisor.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int dividend = Convert.ToInt16(txtDividend.Text);
                int divisor = Convert.ToInt16(txtDivisor.Text);
                int quotient = dividend / divisor;
                int remainder = dividend % divisor;
                txtQuotient.Text = quotient.ToString();
                txtRemainder.Text = remainder.ToString();
                txtFirstVerification.Text = dividend + " = " + divisor + " x " + quotient + " + " + remainder;
                txtSecondVerification.Text = "(" + dividend + " - " + remainder + ")" + " : " + quotient + " = " + divisor;
            }
        }

        private void btnEquations_Click(object sender, EventArgs e)
        {
            callback.ShowEquation(Operations.Div);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            callback.ShowTest(Operations.Div);
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Div, true);
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
