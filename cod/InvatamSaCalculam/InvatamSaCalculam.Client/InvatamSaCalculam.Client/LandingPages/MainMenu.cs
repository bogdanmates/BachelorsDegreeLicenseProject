using System;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class MainMenu : UserControl
    {
        private readonly MainPage callback;

        public MainMenu(MainPage callback)
        {
            InitializeComponent();
            this.callback = callback;
        }

        private void MainMenu_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                SetGuestButtons();
            }
        }

        private void SetGuestButtons()
        {
            if (BusinessStructure.Instance.IsGuest)
            {
                btnHallOfFame.Enabled = false;
                btnTop.Enabled = false;
            }
            else
            {
                btnHallOfFame.Enabled = true;
                btnTop.Enabled = true;
            }
        }

        public void SetTeachersScreens()
        {
            btnManageStudents.Visible = BusinessStructure.Instance.IsTeacher;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            callback.ShowOperation(Operations.Add);
        }

        private void btnDiff_Click(object sender, EventArgs e)
        {
            callback.ShowOperation(Operations.Diff);
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            callback.ShowOperation(Operations.Mul);
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            callback.ShowOperation(Operations.Div);
        }

        private void btnHallOfFame_Click(object sender, EventArgs e)
        {
            callback.ShowHallOfFame();
        }

        private void btnBlocks_Click(object sender, EventArgs e)
        {
            callback.ShowBlocks();
        }

        private void btnPuzzleAdd_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Add, false); //false = fromOperation
        }

        private void btnPuzzleDiff_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Diff, false);
        }

        private void btnPuzzleMul_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Mul, false);
        }

        private void btnPuzzleDiv_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(Operations.Div, false);
        }

        private void btnHangman_Click(object sender, EventArgs e)
        {
            callback.ShowHangman();
        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            callback.ShowTop();
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            callback.ShowManageStudents();
        }
    }
}
