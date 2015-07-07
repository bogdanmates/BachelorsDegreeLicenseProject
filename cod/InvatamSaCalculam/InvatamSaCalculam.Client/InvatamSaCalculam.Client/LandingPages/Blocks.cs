using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Blocks : UserControl
    {
        private bool showedBlocks;
        private Dictionary<Button, Question> questions = new Dictionary<Button, Question>();
        private List<Button> buttonsList = new List<Button>();
        private Random random = new Random();
        private Button firstButton, secondButton;
        private int bestScore, currentScore, matches;

        public Blocks()
        {
            InitializeComponent();
        }

        private void Blocks_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                SetBestScore();
                GenerateBlocks();
                buttonsList = Shuffle(buttonsList);
                GenerateQuestions();
            }
        }

        private void SetBestScore()
        {
            if (!BusinessStructure.Instance.IsGuest)
            {
                bestScore = BusinessStructure.Instance.BDService.GetBlocksScore(BusinessStructure.Instance.UserId);
                txtBestScore.Text = bestScore.ToString();
            }
        }

        public List<Button> Shuffle(List<Button> source)
        {
            return source.OrderBy(x => random.Next()).ToList();
        }

        private void GenerateQuestions()
        {
            int result = 0;
            currentScore = 0;
            txtCurrentScore.Text = currentScore.ToString();
            foreach (Button button in buttonsList)
            {
                string operation = "";
                if (!showedBlocks)
                {
                    result = random.Next(1,100);
                }
                int firstTerm = 0;
                int secondTerm = 0;
                int operationIndex = random.Next(4);
                switch (operationIndex)
                {
                    case 0:
                        operation = "+";
                        secondTerm = random.Next(result);
                        firstTerm = result - secondTerm;
                        break;
                    case 1:
                        operation = "-";
                        secondTerm = random.Next(result, 100);
                        firstTerm = result + secondTerm;
                        break;
                    case 2:
                        operation = ":";
                        secondTerm = random.Next(1, 100 / result);
                        firstTerm = result * secondTerm;
                        break;
                    case 3:
                        operation = "*";
                        var divisors = GetDivisors(result);
                        int divisorIndex = random.Next(divisors.Count);
                        firstTerm = divisors[divisorIndex];
                        secondTerm = result / firstTerm;
                        break;
                }
                questions.Add(button, new Question(result, firstTerm + " " + operation + " " + secondTerm));
                showedBlocks = !showedBlocks;
            }
            showedBlocks = false;
        }

        private List<int> GetDivisors(int number)
        {
            List<int> divisors = new List<int>();
            divisors.Add(1);
            divisors.Add(number);
            for (int i = 2; i < number / 2 + 1; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }
            return divisors;
        }

        private void GenerateBlocks()
        {
            matches = 0;
            buttonsList.Clear();
            pnlBlocks.Controls.Clear();
            currentScore = 0;
            for (int i = 1; i < 6; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    Button newButton = new Button();
                    newButton.Size = new Size(128, 100);
                    newButton.Location = new Point(i * 30 + (i - 1) * 128, j * 32 + (j - 1) * 100);
                    newButton.BackColor = System.Drawing.Color.LightGray;
                    newButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    newButton.Click += new System.EventHandler(this.btn_Click);
                    buttonsList.Add(newButton);
                    pnlBlocks.Controls.Add(newButton);
                }
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (firstButton != null && secondButton != null)
            {
                timer.Stop();
                timer_Tick(null, null);
            }
            if (!showedBlocks)
            {
                Button clickedButton = (Button) sender;
                clickedButton.Text = questions[clickedButton].QuestionString;
                if (firstButton == null)
                {
                    firstButton = clickedButton;
                }
                else
                {
                    if (firstButton != clickedButton)
                    {
                        secondButton = clickedButton;
                        timer.Start();
                        showedBlocks = true;
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CheckMatch();
            firstButton.Text = "";
            secondButton.Text = "";
            firstButton = null;
            secondButton = null;
            timer.Stop();
            showedBlocks = false;
            currentScore++;
            txtCurrentScore.Text = currentScore.ToString();
        }

        private void CheckMatch()
        {
            if (questions[firstButton].Result == questions[secondButton].Result)
            {
                firstButton.Visible = false;
                secondButton.Visible = false;
                matches++;
                if (matches == 10)
                {
                    CheckBestScore();
                    MarkGameAsFinished();
                }
            }
        }

        private void CheckBestScore()
        {
            if (!BusinessStructure.Instance.IsGuest)
            {
                if (currentScore > bestScore)
                {
                    BusinessStructure.Instance.BDService.SetBlocksScore(currentScore, BusinessStructure.Instance.UserId);
                }
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            SetBestScore();
            GenerateBlocks();
            buttonsList = Shuffle(buttonsList);
            GenerateQuestions();
           
        }

        private void MarkGameAsFinished()
        {
            Label label = new Label();
            pnlBlocks.Controls.Clear();
            pnlBlocks.Controls.Add(label);
            Font fl = new Font("Microsoft Sans Serif", 36);
            label.Text = "Felicitari! Ai obtinut un score de " + Convert.ToString(currentScore) + ".";
            label.ForeColor = Color.DarkSlateGray;
            label.Font = fl;
            label.Location = new Point(30, 260);
            label.Size = new Size(1000,1000);
        }
    }

    public class Question
    {
        public Question(int result, string question)
        {
            Result = result;
            QuestionString = question;
        }

        public int Result { get; set; }
        public string QuestionString { get; set; }
    }
}
