using System;
using System.Windows.Forms;
using System.Windows.Input;
using InvatamSaCalculam.Client.Common;
using InvatamSaCalculam.Client.EquationsLandingPages;
using InvatamSaCalculam.Client.LandingPages;
using InvatamSaCalculam.Client.OperationsLandingPages;
using InvatamSaCalculam.Client.TestsLandingPages;
using MainMenu = InvatamSaCalculam.Client.LandingPages.MainMenu;

namespace InvatamSaCalculam.Client
{
    /// <summary>
    /// MainPage incarca LandingPage-urile
    /// Acesta este singurul Form din aplicatie
    /// </summary>
    public partial class MainPage : Form
    {
        private int isPlaying = 1;
        private WMPLib.WindowsMediaPlayer wp = new WMPLib.WindowsMediaPlayer();

        private Operations operation;

        private Login loginPage;
        private Register registerPage;
        private PuzzleMenu puzzleMenuPage;
        private Puzzle puzzlePage;
        private MainMenu mainMenuPage;

        private Add addOperationPage;
        private Diff diffOperationPage;
        private Mul mulOperationPage;
        private Div divOperationPage;

        private AddTest addTestPage;
        private DiffTest diffTestPage;
        private DivTest divTestPage;
        private MulTest mulTestPage;

        private AddEquation addEquationPage;
        private DiffEquation diffEquationPage;
        private DivEquation divEquationPage;
        private MulEquation mulEquationPage;

        private HallOfFame hallOfFamePage;
        private Top topPage;
        private Blocks blocksPage;
        private Hangman hangmanPage;
        private ManageStudents manageStudentsPage;
        private ICommand backCommand;

        public MainPage()
        {
            InitializeComponent();
            CenterToScreen();

            InitializeLandingPages();
            ShowLoginLandingPage();
            SetMusic();
        }

        private void SetMusic()
        {
            wp.URL = @".\colaj.mp3";
            wp.controls.play();
            wp.settings.setMode("loop", true);

            btnStopMusic.Image = imageList.Images[0];
            btnPlayPauseMusic.Image = imageList.Images[1];
        }

        private void InitializeLandingPages()
        {
            loginPage = new Login(this);
            registerPage = new Register(this);
            mainMenuPage = new MainMenu(this);
            puzzleMenuPage = new PuzzleMenu(this);
            puzzlePage = new Puzzle(this);
            addOperationPage = new Add(this);
            diffOperationPage = new Diff(this);
            mulOperationPage = new Mul(this);
            divOperationPage = new Div(this);
            addTestPage = new AddTest();
            diffTestPage = new DiffTest();
            divTestPage = new DivTest();
            mulTestPage = new MulTest();
            addEquationPage = new AddEquation();
            diffEquationPage = new DiffEquation();
            divEquationPage = new DivEquation();
            mulEquationPage = new MulEquation();
            hallOfFamePage = new HallOfFame();
            topPage = new Top();
            hangmanPage = new Hangman();
            blocksPage = new Blocks();
            manageStudentsPage = new ManageStudents();

            //umplerea Panel-ului
            loginPage.Dock = DockStyle.Fill;
            registerPage.Dock = DockStyle.Fill;
            mainMenuPage.Dock = DockStyle.Fill;
            puzzleMenuPage.Dock = DockStyle.Fill;
            puzzlePage.Dock = DockStyle.Fill;
            addOperationPage.Dock = DockStyle.Fill;
            diffOperationPage.Dock = DockStyle.Fill;
            mulOperationPage.Dock = DockStyle.Fill;
            divOperationPage.Dock = DockStyle.Fill;
            addTestPage.Dock = DockStyle.Fill;
            diffTestPage.Dock = DockStyle.Fill;
            divTestPage.Dock = DockStyle.Fill;
            mulTestPage.Dock = DockStyle.Fill;
            addEquationPage.Dock = DockStyle.Fill;
            diffEquationPage.Dock = DockStyle.Fill;
            divEquationPage.Dock = DockStyle.Fill;
            mulEquationPage.Dock = DockStyle.Fill;
            hallOfFamePage.Dock = DockStyle.Fill;
            topPage.Dock = DockStyle.Fill;
            hangmanPage.Dock = DockStyle.Fill;
            blocksPage.Dock = DockStyle.Fill;
            manageStudentsPage.Dock = DockStyle.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnStopMusic_Click(object sender, EventArgs e)
        {
            isPlaying = 3;
            btnPlayPauseMusic.Image = imageList.Images[2];
            btnStopMusic.Enabled = false;
            wp.controls.stop();
        }

        private void btnPlayPauseMusic_Click(object sender, EventArgs e)
        {
            if (isPlaying == 1)
            {
                isPlaying = 2;
                btnPlayPauseMusic.Image = imageList.Images[2];
                btnStopMusic.Enabled = false;
                wp.controls.pause();
            }
            else
            {
                isPlaying = 1;
                btnPlayPauseMusic.Image = imageList.Images[1];
                btnStopMusic.Enabled = true;
                wp.controls.play();
            }
        }

        public void ShowLoginLandingPage()
        {
            lblTitle.Text = "Login";
            Resize(740, 600);
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(loginPage);
            btnBack.Visible = false;
            btnMainMenu.Visible = false;
        }

        public void ShowRegisterLandingPage()
        {
            lblTitle.Text = "Register";
            Resize(740, 600);
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(registerPage);
        }

        public void ShowMainMenuLandingPage()
        {
            lblTitle.Text = "Meniu";
            Resize(750, 620);
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(mainMenuPage);
            btnLogout.Visible = true;
            btnMainMenu.Visible = false;
            btnBack.Visible = false;
            mainMenuPage.SetTeachersScreens(); //pentru aparitia butonului Administrare elevi 
        }

        public void ShowPuzzleMenu(Operations operation, bool fromOperation)
        {
            lblTitle.Text = "Meniu Puzzle";
            Resize(1080, 710);
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(puzzleMenuPage);
            puzzleMenuPage.SetOpretaion(operation);
            btnMainMenu.Visible = true;
            btnBack.Visible = fromOperation;
            this.operation = operation; //pentru cazul: operatie -> puzzle/test/ecuatii -> btn inapoi
            puzzlePage.FromOperation = fromOperation; //pentru cazul: puzzle -> btn JocNou 
        }

        /// <summary>
        /// Functia se apeleaza la alegerea unui puzzle
        /// </summary>
        /// <param name="puzzleIndex"></param>
        /// <param name="puzzleSize"></param>
        /// <param name="operation"></param>
        public void ShowPuzzle(int puzzleIndex, int puzzleSize, Operations operation)
        {
            puzzlePage.SetPuzzle(puzzleIndex, puzzleSize);
            puzzlePage.SetOperation(operation);
            lblTitle.Text = "Puzzle";
            Resize(1120, 710);
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(puzzlePage);
        }

        /// <summary>
        /// Alegerea operatiei de pe coloana din stanga
        /// </summary>
        /// <param name="operation"></param>
        public void ShowOperation(Operations operation)
        {
            Resize(740, 620);
            pnlWorkArea.Controls.Clear();//sterge continutul
            switch (operation)
            {
                case Operations.Add:
                    lblTitle.Text = "Adunare";
                    pnlWorkArea.Controls.Add(addOperationPage);
                    break;
                case Operations.Diff:
                    lblTitle.Text = "Scadere";
                    pnlWorkArea.Controls.Add(diffOperationPage);
                    break;
                case Operations.Div:
                    lblTitle.Text = "Impartire";
                    pnlWorkArea.Controls.Add(divOperationPage);
                    break;
                case Operations.Mul:
                    lblTitle.Text = "Inmultire";
                    pnlWorkArea.Controls.Add(mulOperationPage);
                    break;
            }
            btnMainMenu.Visible = true;
            btnBack.Visible = false;
        }

        public void ShowEquation(Operations operation)
        {
            Resize(920, 460);
            pnlWorkArea.Controls.Clear();
            switch (operation)
            {
                case Operations.Add:
                    lblTitle.Text = "Ecuatii Adunare";
                    pnlWorkArea.Controls.Add(addEquationPage);
                    break;
                case Operations.Diff:
                    lblTitle.Text = "Ecuatii Scadere";
                    pnlWorkArea.Controls.Add(diffEquationPage);
                    break;
                case Operations.Div:
                    lblTitle.Text = "Ecuatii Impartire";
                    pnlWorkArea.Controls.Add(divEquationPage);
                    break;
                case Operations.Mul:
                    lblTitle.Text = "Ecuatii Inmultire";
                    pnlWorkArea.Controls.Add(mulEquationPage);
                    break;
            }
            btnBack.Visible = true;
            this.operation = operation; //pt cazul: operatie -> ecuatii -> btn back
        }

        public void ShowTest(Operations operation)
        {
            Resize(860, 640);
            pnlWorkArea.Controls.Clear();
            switch (operation)
            {
                case Operations.Add:
                    lblTitle.Text = "Test Adunare";
                    pnlWorkArea.Controls.Add(addTestPage);
                    break;
                case Operations.Diff:
                    lblTitle.Text = "Test Scadere";
                    pnlWorkArea.Controls.Add(diffTestPage);
                    break;
                case Operations.Div:
                    lblTitle.Text = "Test Impartire";
                    pnlWorkArea.Controls.Add(divTestPage);
                    break;
                case Operations.Mul:
                    lblTitle.Text = "Test Inmultire";
                    pnlWorkArea.Controls.Add(mulTestPage);
                    break;
            }
            btnBack.Visible = true;
            this.operation = operation;
        }

        public void ShowHallOfFame()
        {
            Resize(940, 710);
            lblTitle.Text = "Premii";
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(hallOfFamePage);
            btnMainMenu.Visible = true;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            ShowMainMenuLandingPage();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogout.Visible = false;
            ShowLoginLandingPage();
        }

        private void Resize(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            CenterToScreen();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ShowOperation(operation);
        }

        public void ShowBlocks()
        {
            Resize(830, 720);
            lblTitle.Text = "Blocks";
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(blocksPage);
            btnMainMenu.Visible = true;
        }

        public void ShowHangman()
        {
            Resize(1000, 530);
            lblTitle.Text = "Spanzuratoare";
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(hangmanPage);
            btnMainMenu.Visible = true;
        }

        public void ShowTop()
        {
            Resize(830, 700);
            lblTitle.Text = "Top";
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(topPage);
            btnMainMenu.Visible = true;
        }

        public void ShowManageStudents()
        {
            Resize(1060, 400);
            lblTitle.Text = "Administrare Elevi";
            pnlWorkArea.Controls.Clear();
            pnlWorkArea.Controls.Add(manageStudentsPage);
            btnMainMenu.Visible = true;
        }
    }
}
