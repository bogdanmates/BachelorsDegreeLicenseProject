using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class HallOfFame : UserControl
    {
        public HallOfFame()
        {
            InitializeComponent();
        }

        private void HallOfFameLandingPage_ParentChanged(object sender, System.EventArgs e)
        {
            if (Parent != null)
            {
                FillCups();
                FillMedals();
                FillPoints();
            }
        }

        private void FillCups()
        {
            int addCups = BusinessStructure.Instance.BDService.GetCup(Operations.Add.ToString(), BusinessStructure.Instance.UserId);
            int diffCups = BusinessStructure.Instance.BDService.GetCup(Operations.Diff.ToString(), BusinessStructure.Instance.UserId);
            int divCups = BusinessStructure.Instance.BDService.GetCup(Operations.Div.ToString(), BusinessStructure.Instance.UserId);
            int mulCups = BusinessStructure.Instance.BDService.GetCup(Operations.Mul.ToString(), BusinessStructure.Instance.UserId);
            txtAddCups.Text = addCups.ToString();
            txtDiffCups.Text = diffCups.ToString();
            txtDivCups.Text = divCups.ToString();
            txtMulCups.Text = mulCups.ToString();
            txtTotalCups.Text = (addCups + diffCups + divCups + mulCups).ToString();
        }

        private void FillMedals()
        {
            int smallGoldMedals = BusinessStructure.Instance.BDService.GetMedal(1, 1, BusinessStructure.Instance.UserId);
            int smallSilverMedals = BusinessStructure.Instance.BDService.GetMedal(1, 2, BusinessStructure.Instance.UserId);
            int smallBronzeMedals = BusinessStructure.Instance.BDService.GetMedal(1, 3, BusinessStructure.Instance.UserId);
            int bigGoldMedals = BusinessStructure.Instance.BDService.GetMedal(2, 1, BusinessStructure.Instance.UserId);
            int bigSilverMedals = BusinessStructure.Instance.BDService.GetMedal(2, 2, BusinessStructure.Instance.UserId);
            int bigBronzeMedals = BusinessStructure.Instance.BDService.GetMedal(2, 3, BusinessStructure.Instance.UserId);
            txtSmallGoldMedals.Text = smallGoldMedals.ToString();
            txtSmallSilverMedals.Text = smallSilverMedals.ToString();
            txtSmallBronzeMedals.Text = smallBronzeMedals.ToString();
            txtBigGoldMedals.Text = bigGoldMedals.ToString();
            txtBigSilverMedals.Text = bigSilverMedals.ToString();
            txtBigBronzeMedals.Text = bigBronzeMedals.ToString();
            txtTotalMedals.Text = (smallGoldMedals + smallSilverMedals + smallBronzeMedals + bigGoldMedals + bigSilverMedals + bigBronzeMedals).ToString();
        }

        private void FillPoints()
        {
            txtScore.Text = BusinessStructure.Instance.BDService.GetScore(BusinessStructure.Instance.UserId).ToString();
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            BusinessStructure.Instance.BDService.Reset(BusinessStructure.Instance.UserId);
            ClearFields();
        }

        private void ClearFields()
        {
            txtAddCups.Text = "0";
            txtDiffCups.Text = "0";
            txtDivCups.Text = "0";
            txtMulCups.Text = "0";
            txtTotalCups.Text = "0";
            txtSmallGoldMedals.Text = "0";
            txtSmallSilverMedals.Text = "0";
            txtSmallBronzeMedals.Text = "0";
            txtBigGoldMedals.Text = "0";
            txtBigSilverMedals.Text = "0";
            txtBigBronzeMedals.Text = "0";
            txtTotalMedals.Text = "0";
            txtScore.Text = "0";
        }
    }
}
