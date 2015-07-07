using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Hangman : UserControl
    {
        private int wrongAnswers;
        private int bestScore, currentScore;
        private List<PictureBox> imageList = new List<PictureBox>();
        private QuestionHandler questionHandler;
        private string[] pictures;

        public Hangman()
        {
            InitializeComponent();
            questionHandler = new QuestionHandler(220, 255, 374, txtAnswer, btnCheckSolution, lblQuestionTop, lblQuestionBottom);
            InitImageList();
        }

        private void Hangman_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                SetBestScore();
                questionHandler.GetRandomQuestion();
                ResetScreen();
            }
        }

        private void InitImageList()
        {
            pictures = Directory.GetFiles(@".\..\..\Resources\Hangman");

            imageList.Add(pctBoxScaffold);
            imageList.Add(pictureBox1);
            imageList.Add(pictureBox2);
            imageList.Add(pictureBox3);
            imageList.Add(pictureBox4);
            imageList.Add(pictureBox5);
            imageList.Add(pictureBox6);

            pictureBox1.Parent = pctBoxScaffold;
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox2;
            pictureBox4.Parent = pictureBox3;
            pictureBox5.Parent = pictureBox4;
            pictureBox6.Parent = pictureBox5;

            pctBoxScaffold.Image = Image.FromFile(pictures[0]);
        }

        private void SetBestScore()
        {
            if (!BusinessStructure.Instance.IsGuest)
            {
                bestScore = BusinessStructure.Instance.BDService.GetHangmanScore(BusinessStructure.Instance.UserId);
                txtBestScore.Text = bestScore.ToString();
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

        private void btnCheckSolution_Click(object sender, EventArgs e)
        {
            string answerString = txtAnswer.Text;
            if (txtAnswer.Text == "")
            {
                answerString = "0";
            }
            int answerNumber = Convert.ToInt16(answerString);

            bool showPiece = questionHandler.CheckAnswer(answerNumber);

            if (!showPiece)
            {
                wrongAnswers++;
                imageList[wrongAnswers].Image = Image.FromFile(pictures[wrongAnswers]);
                imageList[wrongAnswers].Parent = imageList[wrongAnswers - 1];
                imageList[wrongAnswers].Location = new Point(0, 0);
                imageList[wrongAnswers].Visible = true;
                CheckFinish();
            }
            else
            {
                questionHandler.GetRandomQuestion();
                currentScore++;
                txtCurrentScore.Text = currentScore.ToString();
            }

            txtAnswer.Text = "";
            txtAnswer.Focus();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            currentScore = 0;
            txtCurrentScore.Text = currentScore.ToString();
            SetBestScore();
            questionHandler.GetRandomQuestion();
            txtAnswer.Text = "";
            txtAnswer.Focus();
            ResetScreen();
        }

        private void CheckFinish()
        {
            if (wrongAnswers == 6)
            {
                MarkGameAsFinished();
                CheckBestScore();
            }
        }

        private void MarkGameAsFinished()
        {
            Font fl = new Font("Microsoft Sans Serif", 16);
            lblQuestionTop.Text = "Felicitari! Ai obtinut un scor de " + Convert.ToString(currentScore) + " puncte";
            lblQuestionTop.ForeColor = Color.DarkSlateGray;
            lblQuestionTop.Font = fl;
            lblQuestionBottom.Visible = false;
            lblBestScore.Visible = false;
            lblCurrentScore.Visible = false;
            txtAnswer.Visible = false;
            txtBestScore.Visible = false;
            txtCurrentScore.Visible = false;
            btnCheckSolution.Visible = false;
            BusinessStructure.Instance.ClapSound.Play();
        }

        private void ResetScreen()
        {
            Font fl = new Font("Microsoft Sans Serif", 16);
            lblQuestionTop.Font = fl;
            lblQuestionTop.ForeColor = Color.Black;
            lblBestScore.Visible = true;
            lblCurrentScore.Visible = true;
            txtAnswer.Visible = true;
            txtBestScore.Visible = true;
            txtCurrentScore.Visible = true;
            btnCheckSolution.Visible = true;
            wrongAnswers = 0;
            currentScore = 0;//////////////
            txtCurrentScore.Text = currentScore.ToString();////////////
            ResetImages();
        }

        private void ResetImages()
        {
            foreach (PictureBox pictureBox in imageList)
            {
                pictureBox.Image = null;
            }
            pctBoxScaffold.Image = Image.FromFile(pictures[0]);
        }

        private void CheckBestScore()
        {
            if (!BusinessStructure.Instance.IsGuest)
            {
                if (currentScore > bestScore)
                {
                    BusinessStructure.Instance.BDService.SetHangmanScore(currentScore, BusinessStructure.Instance.UserId);
                }
            }
        }
    }
}
