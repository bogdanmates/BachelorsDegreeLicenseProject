using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.OperationsLandingPages
{
    public partial class Diff : UserControl
    {
        private MainPage callback;

        public Diff(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            if ((txtMinuend.Text == "") || (txtSubtrahend.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int minuend = Convert.ToInt16(txtMinuend.Text);
                int subtrahend = Convert.ToInt16(txtSubtrahend.Text);
                int difference = minuend - subtrahend;
                txtDifference.Text = difference.ToString();
                txtFirstVerification.Text = difference + " + " + subtrahend + " = " + minuend;
                txtSecondVerification.Text = minuend + " - " + difference + " = " + subtrahend;
            }
        }

        private void btnEquations_Click(object sender, EventArgs e)
        {
            callback.ShowEquation(Operations.Diff);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            callback.ShowTest(Operations.Diff);
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Diff, true);
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
