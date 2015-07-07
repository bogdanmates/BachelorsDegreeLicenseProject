using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.OperationsLandingPages
{
    public partial class Mul : UserControl
    {
        private MainPage callback;

        public Mul(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            if ((txtFirstFactor.Text == "") || (txtSecondFactor.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int firstFactor = Convert.ToInt16(txtFirstFactor.Text);
                int secondFactor = Convert.ToInt16(txtSecondFactor.Text);
                int product = firstFactor * secondFactor;
                txtProduct.Text = product.ToString();
                txtFirstVerification.Text = secondFactor + " x " + firstFactor + " = " + product;
                txtSecondVerification.Text = product + " : " + firstFactor + " = " + secondFactor;
                txtThirdVerification.Text = product + " : " + secondFactor + " = " + firstFactor;
            }
        }

        private void btnEquations_Click(object sender, EventArgs e)
        {
            callback.ShowEquation(Operations.Mul);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            callback.ShowTest(Operations.Mul);
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Mul, true);
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
