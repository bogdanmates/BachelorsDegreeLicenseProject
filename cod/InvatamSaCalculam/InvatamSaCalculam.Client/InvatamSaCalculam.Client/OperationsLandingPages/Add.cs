using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.OperationsLandingPages
{
    public partial class Add : UserControl
    {
        private MainPage callback;

        public Add(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void btnSolution_Click(object sender, EventArgs e)
        {
            if ((txtFirstAddend.Text == "") || (txtSecondAddend.Text == ""))
            {
                MessageBox.Show("Completaţi casuţele colorate!");
            }
            else
            {
                int firstAddend = Convert.ToInt16(txtFirstAddend.Text);
                int secondAddend = Convert.ToInt16(txtSecondAddend.Text);
                int sum = firstAddend + secondAddend;
                txtSum.Text = sum.ToString();
                txtFirstVerification.Text = secondAddend + " + " + firstAddend + " = " + sum;
                txtSecondVerification.Text = sum + " - " + firstAddend + " = " + secondAddend;
                txtThirdVerification.Text = sum + " - " + secondAddend + " = " + firstAddend;
            }
        }

        private void btnEquations_Click(object sender, EventArgs e)
        {
            callback.ShowEquation(Operations.Add);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            callback.ShowTest(Operations.Add);
        }

        private void btnGame_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Add, true);
        }
        /// <summary>
        /// Validarea campurilor 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
