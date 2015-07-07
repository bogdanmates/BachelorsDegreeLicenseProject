using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Puzzle : UserControl
    {
        private MainPage callback;
        private int puzzleIndex, puzzleSize;
        private Operations puzzleOperation;

        private int num1, num2, num3;

        private long score;
        private int questionIndex, piecesShown, oldPiece, i;
        private int[] piecesIndex = new int[24];
        private List<PictureBox> imageList = new List<PictureBox>();
        private Random random = new Random();
        private string[] pictures;
        private string[] fullPuzzleImages;
        private string[] awards;

        public bool FromOperation { get; set; }

        private QuestionHandler questionHandler;

        public Puzzle(MainPage callback)
        {
            InitializeComponent();

            this.callback = callback;
            SetImageList();
            fullPuzzleImages = Directory.GetFiles(@".\..\..\Resources\Intreg");
            awards = Directory.GetFiles(@".\..\..\Resources\Premii");
            imageList[0].Image = Image.FromFile(awards[0]);
            questionHandler = new QuestionHandler(20, 55, 44, txtAnswer, btnCheckSolution, lblQuestionTop, lblQuestionBottom);
        }

        private void SetImageList()
        {
            foreach (Control pictureBox in this.Controls)
            {
                if (pictureBox is PictureBox)
                {
                    imageList.Add(pictureBox as PictureBox);
                    pictureBox.Visible = false;
                }
            }
        }

        private void Puzzle_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                ResetScreen();
                questionHandler.GenerateQuestion();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            callback.ShowPuzzleMenu(puzzleOperation, FromOperation);
        }

        private void CheckPrize()
        {
            int points = 0, medalType = 0;
            CheckFinishedPuzzle(ref points, ref medalType);
            if (points != 0)
            {
                SetWinnerStatus(medalType);
                if (!BusinessStructure.Instance.IsGuest)
                {
                    BusinessStructure.Instance.BDService.AddMedal(puzzleSize, medalType, points,
                        BusinessStructure.Instance.UserId);
                }
            }
        }

        private void CheckFinishedPuzzle(ref int points, ref int medalType)
        {
            if ((puzzleSize == 1 &&  piecesShown == 12) || (puzzleSize == 2 && piecesShown == 24))
            {
                MarkPuzzleAsCompleted();
                switch (score)
                {
                    case 1200:
                        points = 40;
                        medalType = 1;
                        break;
                    case 1150:
                        points = 30;
                        medalType = 2;
                        break;
                    case 1100:
                        points = 20;
                        medalType = 3;
                        break;
                    case 2400:
                        points = 100;
                        medalType = 1;
                        break;
                    case 2350:
                        points = 70;
                        medalType = 2;
                        break;
                    case 2300:
                        points = 50;
                        medalType = 3;
                        break;
                }
            }
        }

        private void MarkPuzzleAsCompleted()
        {
            imageList[1].Image = Image.FromFile(fullPuzzleImages[puzzleIndex]);
            imageList[1].Parent = imageList[27 - oldPiece - 1];
            imageList[1].Location = new Point(0, 0);
            imageList[1].Visible = true;
            Font fl = new Font("Microsoft Sans Serif", 36);
            lblQuestionTop.Text = "Felicitari! Ai obtinut un score de " + Convert.ToString(score) + ".";
            lblQuestionTop.ForeColor = Color.DarkSlateGray;
            lblQuestionTop.Font = fl;
            lblQuestionBottom.Visible = false;
            lblPuzzleNumber.Visible = false;
            lblScore.Visible = false;
            txtAnswer.Visible = false;
            txtScore.Visible = false;
            btnCheckSolution.Visible = false;
            btnAdmin.Visible = false;
            BusinessStructure.Instance.ClapSound.Play();
        }

        private void ResetScreen()
        {
            for (i = 2; i < 27; i++)
            {
                imageList[27 - i].Visible = false;
            }
            for (i = 0; i < 24; i++)
            {
                piecesIndex[i] = 0;
            }
            oldPiece = 0;
            piecesShown = 0;
            score = 0;
            txtScore.Text = Convert.ToString(score);
            Font fl = new Font("Microsoft Sans Serif", 16);
            lblQuestionTop.Font = fl;
            lblQuestionBottom.Font = fl;
            lblQuestionTop.ForeColor = SystemColors.ControlText;
            lblQuestionBottom.ForeColor = SystemColors.ControlText;
            lblQuestionBottom.Location = new Point(44, 113);
            btnCheckSolution.Visible = true;
            lblScore.Visible = true;
            lblPuzzleNumber.Visible = true;
            txtScore.Visible = true;
            btnAdmin.Visible = BusinessStructure.Instance.IsTeacher;
            imageList[0].Image = Image.FromFile(awards[0]);
        }

        private void SetWinnerStatus(int awardsIndex)
        {
            string medalType = "";
            switch (awardsIndex)
            {
                case 1:
                    medalType = "aur";
                    break;
                case 2:
                    medalType = "argint";
                    break;
                case 3:
                    medalType = "bronz";
                    break;
            }
            imageList[0].Image = Image.FromFile(awards[awardsIndex]);
            Font fc = new Font("Microsoft Sans Serif", 18);
            lblQuestionBottom.Font = fc;
            lblQuestionBottom.ForeColor = Color.DarkSlateGray;
            lblQuestionBottom.Location = new Point(785, 450);
            lblQuestionBottom.Text = "Ai obţinut medalia de " + medalType + "!";
            lblQuestionBottom.Visible = true;
        }

        private void btnCheckSolution_Click(object sender, EventArgs e)
        {
            int answerNumber, piece = 0;
            string answerString = txtAnswer.Text;
            if (txtAnswer.Text == "")
            {
                answerString = "0";
            }
            answerNumber = Convert.ToInt16(answerString);

            bool showPiece = questionHandler.CheckAnswer(answerNumber);

            if (showPiece)
            {
                piecesShown++;
                score += 100;
                BusinessStructure.Instance.RightAnswerSound.Play();
                if (puzzleSize == 1)
                {
                    do
                    {
                        piece = random.Next(1, 13);

                    } while (piecesIndex[piece - 1] != 0);
                }
                if (puzzleSize == 2)
                {
                    do
                    {
                        piece = random.Next(1, 25);

                    } while (piecesIndex[piece - 1] != 0);
                }

                piecesIndex[piece - 1] = 1;
                imageList[27 - piece - 1].Image = Image.FromFile(pictures[23 * piece + puzzleIndex]);
                imageList[27 - piece - 1].Parent = imageList[27 - oldPiece - 1];
                imageList[27 - piece - 1].Location = new Point(0, 0);
                imageList[27 - piece - 1].Visible = true;
                oldPiece = piece;
            }
            else
            {
                score -= 50;
                BusinessStructure.Instance.WrongAnswerSound.Play();
            }

            txtScore.Text = Convert.ToString(score);
            txtAnswer.Text = "";

            questionHandler.GenerateQuestion();
            CheckPrize();
            txtAnswer.Focus();
        }

        public void SetPuzzle(int puzzleIndex, int puzzleSize)
        {
            this.puzzleIndex = puzzleIndex;
            SetPuzzleSize(puzzleSize);
            imageList[27 - 1].Image = Image.FromFile(pictures[puzzleIndex]);
            imageList[0].Visible = true;
            imageList[27 - 1].Visible = true;
            lblPuzzleNumber.Text = "Puzzle " + Convert.ToString(puzzleIndex) + "/23";
            for (i = 2; i < 26; i++)
            {
                imageList[27 - i].Visible = false;
            }
            for (i = 0; i < 24; i++)
            {
                piecesIndex[i] = 0;
            }
            oldPiece = 0;
            piecesShown = 0;
            score = 0;
            txtScore.Text = Convert.ToString(score);

            MakeAllPiecesTransparent();
        }

        private void MakeAllPiecesTransparent()
        {
            for (i = 1; i < 27; i++)
            {
                imageList[27 - i].BackColor = Color.Transparent;
            }
        }

        private void SetPuzzleSize(int puzzleSize)
        {
            this.puzzleSize = puzzleSize;
            switch (puzzleSize)
            {
                case 1:
                    pictures = Directory.GetFiles(@".\..\..\Resources\Mic");
                    break;
                case 2:
                    pictures = Directory.GetFiles(@".\..\..\Resources\Mare");
                    break;
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            ResetScreen();
            questionHandler.GenerateQuestion();
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

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            int piece = 0;
            piecesShown++;
            score = score + 100;

            if (puzzleSize == 1)
            {
                do
                {
                    piece = random.Next(1, 13);
                } while (piecesIndex[piece - 1] != 0);

            }
            if (puzzleSize == 2)
            {
                do
                {
                    piece = random.Next(1, 25);
                } while (piecesIndex[piece - 1] != 0);
            }

            piecesIndex[piece - 1] = 1;
            imageList[27 - piece - 1].Image = Image.FromFile(pictures[23 * piece + puzzleIndex]);
            imageList[27 - piece - 1].Parent = imageList[27 - oldPiece - 1];
            imageList[27 - piece - 1].Location = new Point(0, 0);
            imageList[27 - piece - 1].Visible = true;
            oldPiece = piece;

            txtScore.Text = Convert.ToString(score);
            txtAnswer.Text = "";

            questionHandler.GenerateQuestion();
            CheckPrize();
            txtAnswer.Focus();
        }

        public void SetOperation(Operations operation)
        {
            puzzleOperation = operation;
            questionHandler.SetOperation(operation);
        }
    }
}
