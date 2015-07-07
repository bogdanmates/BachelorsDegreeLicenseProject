using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class PuzzleMenu : UserControl
    {
        private MainPage callback;
        private int puzzleSize;
        private Operations puzzleOperation;

        public PuzzleMenu(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void btnPuzzle_Click(object sender, System.EventArgs e)
        {
            string buttonName = ((Button) sender).Name;
            int puzzleIndex = Convert.ToInt32(buttonName.Substring(9, buttonName.Length-9)) - 1;
            callback.ShowPuzzle(puzzleIndex, puzzleSize, puzzleOperation);
        }

        private void btnSmallPuzze_Click(object sender, EventArgs e)
        {
            pnlPuzzles.Visible = true;
            puzzleSize = 1;
        }

        private void btnBigPuzzle_Click(object sender, EventArgs e)
        {
            pnlPuzzles.Visible = true;
            puzzleSize = 2;
        }

        private void PuzzleMenu_ParentChanged(object sender, EventArgs e)
        {
            pnlPuzzles.Visible = false;
        }

        public void SetOpretaion(Operations operation)
        {
            puzzleOperation = operation;
        }
    }
}
