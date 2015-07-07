using System;
using System.Drawing;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.Common
{
    public class QuestionHandler
    {
        private int hTxtQuestionTop = 20;
        private int hTxtQuestionBottom = 55;
        private int yQuestion = 44;

        private int num1, num2, num3;
        private int questionIndex;
        private TextBox txtAnswer;
        private Button btnCheckSolution;
        private Label lblQuestionTop, lblQuestionBottom;

        private Random random = new Random();

        public delegate bool CheckAnswerDelegate(int answer);
        public delegate void GenerateQuestionDelegate();

        public CheckAnswerDelegate CheckAnswer { get; set; }
        public GenerateQuestionDelegate GenerateQuestion { get; set; }

        public QuestionHandler(int hTxtQuestionTop, int hTxtQuestionBottom, int yQuestion, TextBox txtAnswer, Button btnCheckSolution, Label lblQuestionTop, Label lblQuestionBottom)
        {
            this.hTxtQuestionTop = hTxtQuestionTop;
            this.hTxtQuestionBottom = hTxtQuestionBottom;
            this.yQuestion = yQuestion;

            this.txtAnswer = txtAnswer;
            this.btnCheckSolution = btnCheckSolution;
            this.lblQuestionTop = lblQuestionTop;
            this.lblQuestionBottom = lblQuestionBottom;
        }

        public void GetRandomQuestion()
        {
            int operation = random.Next(4);
            switch (operation)
            {
                case 0:
                    SetOperation(Operations.Add);
                    break;
                case 1:
                    SetOperation(Operations.Diff);
                    break;
                case 2 :
                    SetOperation(Operations.Div);
                    break;
                case 3 :
                    SetOperation(Operations.Mul);
                    break;
            }
            GenerateQuestion();
        }

        public void SetOperation(Operations operation)
        {
           switch (operation)
            {
                case Operations.Add:
                    CheckAnswer = new CheckAnswerDelegate(CheckAnswerAdd);
                    GenerateQuestion = new GenerateQuestionDelegate(GenerateQuestionAdd);
                    break;
                case Operations.Diff:
                    CheckAnswer = new CheckAnswerDelegate(CheckAnswerDiff);
                    GenerateQuestion = new GenerateQuestionDelegate(GenerateQuestionDiff);
                    break;
                case Operations.Div:
                    CheckAnswer = new CheckAnswerDelegate(CheckAnswerDiv);
                    GenerateQuestion = new GenerateQuestionDelegate(GenerateQuestionDiv);
                    break;
                case Operations.Mul:
                    CheckAnswer = new CheckAnswerDelegate(CheckAnswerMul);
                    GenerateQuestion = new GenerateQuestionDelegate(GenerateQuestionMul);
                    break;
            }
        }

        #region CheckAnswer

        private bool CheckAnswerAdd(int answer)
        {
            switch (questionIndex)
            {
                case 1:
                    return ((txtAnswer.Text != "") && (num1 + num2 == answer));
                case 2:
                    return ((txtAnswer.Text != "") && (num2 - num1 == answer));
                case 3:
                    return ((txtAnswer.Text != "") && (num2 - num1 == answer));
                case 4:
                    return ((txtAnswer.Text != "") && (num1 + num2 + num3 == answer));
                case 5:
                    return ((txtAnswer.Text != "") && (num1 + num2 == answer));
                case 6:
                    return ((txtAnswer.Text != "") && (num1 + num2 == answer));
                case 7:
                    return ((txtAnswer.Text != "") && (num2 - num1 == answer));
                default:
                    return false;
            }
        }

        private bool CheckAnswerDiff(int answer)
        {
            switch (questionIndex)
            {
                case 1:
                    return ((txtAnswer.Text != "") && (num1 - num2 == answer));
                case 2:
                    return ((txtAnswer.Text != "") && (num1 + num2 == answer));
                case 3:
                    return ((txtAnswer.Text != "") && (num1 - num2 == answer));
                case 4:
                    return ((txtAnswer.Text != "") && (num1 - num2 - num3 == answer));
                case 5:
                    return ((txtAnswer.Text != "") && (num1 - num2 == answer));
                case 6:
                    return ((txtAnswer.Text != "") && (num1 - num2 == answer));
                case 7:
                    return ((txtAnswer.Text != "") && (num1 - num2 == answer));
                default:
                    return false;
            }
        }

        private bool CheckAnswerDiv(int answer)
        {
            switch (questionIndex)
            {
                case 1:
                    return ((txtAnswer.Text != "") && (num1 / num2 == answer));
                case 2:
                    return ((txtAnswer.Text != "") && (num2 * num1 == answer));
                case 3:
                    return ((txtAnswer.Text != "") && (num1 / num2 == answer));
                case 4:
                    return ((txtAnswer.Text != "") && (num1 / num2 / num3 == answer));
                case 5:
                    return ((txtAnswer.Text != "") && (num1 / num2 == answer));
                case 6:
                    return ((txtAnswer.Text != "") && (num1 / num2 == answer));
                case 7:
                    return ((txtAnswer.Text != "") && (num1 / num2 == answer));
                default:
                    return false;
            }
        }

        private bool CheckAnswerMul(int answer)
        {
            switch (questionIndex)
            {
                case 1:
                    return ((txtAnswer.Text != "") && (num1 * num2 == answer));
                case 2:
                    return ((txtAnswer.Text != "") && (num2 / num1 == answer));
                case 3:
                    return ((txtAnswer.Text != "") && (num2 / num1 == answer));
                case 4:
                    return ((txtAnswer.Text != "") && (num1 * num2 * num3 == answer));
                case 5:
                    return ((txtAnswer.Text != "") && (num1 * num2 == answer));
                case 6:
                    return ((txtAnswer.Text != "") && (num1 * num2 == answer));
                case 7:
                    return ((txtAnswer.Text != "") && (num2 / num1 == answer));
                default:
                    return false;
            }
        }

        #endregion CheckAnswer

        #region GenerateQuestion

        private void GenerateQuestionAdd()
        {
            questionIndex = random.Next(1, 8);
            switch (questionIndex)
            {
                case 1:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = Convert.ToString(num1) + " + " + Convert.ToString(num2) + " =";
                    lblQuestionTop.Visible = true;
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 104, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 224, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 2:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 > num2);
                    lblQuestionTop.Text = "+ " + Convert.ToString(num1) + " = " + Convert.ToString(num2);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionTop.Location = new Point(yQuestion + 106, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 226, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 3:
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 > num2);
                    lblQuestionTop.Text = Convert.ToString(num1) + " +";
                    lblQuestionBottom.Text = "= " + Convert.ToString(num2);
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 58, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion + 160, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 230, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 4:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    num3 = random.Next(100);
                    lblQuestionTop.Text = Convert.ToString(num1) + " + " + Convert.ToString(num2) + " + " +
                                          Convert.ToString(num3) + " =";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 153, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 273, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 5:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = "Suma dintre " + Convert.ToString(num1) + " şi " + Convert.ToString(num2) +
                                          " este";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 256, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 376, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 6:
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = "Ana are " + Convert.ToString(num1) + " mere, iar Andrei are cu " +
                                          Convert.ToString(num2) + " mai multe.";
                    lblQuestionBottom.Text = "Câte mere are Andrei?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 233, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 353, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 7:
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 > num2);
                    lblQuestionTop.Text = "Termenul 1 al adunării este " + Convert.ToString(num1) + ", iar suma este " +
                                          Convert.ToString(num2) + '.';
                    lblQuestionBottom.Text = "Care este termenul 2?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 227, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 347, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
            }
        }

        private void GenerateQuestionDiff()
        {
            questionIndex = random.Next(1, 8);
            switch (questionIndex)
            {
                case 1:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 < num2);
                    lblQuestionTop.Text = Convert.ToString(num1) + " - " + Convert.ToString(num2) + " =";
                    lblQuestionTop.Visible = true;
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 101, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 221, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 2:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = "- " + Convert.ToString(num1) + " = " + Convert.ToString(num2);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionTop.Location = new Point(yQuestion + 106, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 226, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 3:
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 < num2);
                    lblQuestionTop.Text = Convert.ToString(num1) + " -";
                    lblQuestionBottom.Text = "= " + Convert.ToString(num2);
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 58, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion + 160, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 240, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 4:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                        num3 = random.Next(100);
                    } while ((num1 < num2) || ((num1 - num2) < num3));
                    lblQuestionTop.Text = Convert.ToString(num1) + " - " + Convert.ToString(num2) + " - " +
                                          Convert.ToString(num3) + " =";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 148, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 268, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 5:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 < num2);
                    lblQuestionTop.Text = "Diferenta dintre " + Convert.ToString(num1) + " şi " + Convert.ToString(num2) +
                                          " este";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 301, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 421, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 6:
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 < num2);
                    lblQuestionTop.Text = "Mihai are " + Convert.ToString(num1) + " bomboane, iar Simona are cu " +
                                          Convert.ToString(num2) + " mai puţine.";
                    lblQuestionBottom.Text = "Câte bomboane are Simona?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 304, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 424, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 7:
                    do
                    {
                        num1 = random.Next(100);
                        num2 = random.Next(100);
                    } while (num1 < num2);
                    lblQuestionTop.Text = "Descăzutul este " + Convert.ToString(num1) + ", iar diferenţa este " +
                                          Convert.ToString(num2) + '.';
                    lblQuestionBottom.Text = "Care este scăzătorul?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 227, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 347, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
            }
        }

        private void GenerateQuestionDiv()
        {
            questionIndex = random.Next(1, 8);
            switch (questionIndex)
            {
                case 1:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    } while (num1 % num2 != 0);
                    lblQuestionTop.Text = Convert.ToString(num1) + " : " + Convert.ToString(num2) + " =";
                    lblQuestionTop.Visible = true;
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 101, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 221, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 2:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = ": " + Convert.ToString(num1) + " = " + Convert.ToString(num2);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionTop.Location = new Point(yQuestion + 106, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 226, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 3:
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    } while (num1 % num2 != 0);
                    lblQuestionTop.Text = Convert.ToString(num1) + " :";
                    lblQuestionBottom.Text = "= " + Convert.ToString(num2);
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 58, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion + 160, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 240, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 4:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 100);
                        num3 = random.Next(1, 100);
                    } while ((num1 % num2 != 0) || ((num1 / num2) % num3 != 0));
                    lblQuestionTop.Text = Convert.ToString(num1) + " : " + Convert.ToString(num2) + " : " +
                                          Convert.ToString(num3) + " =";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 155, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 274, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 5:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    } while (num1 % num2 != 0);
                    lblQuestionTop.Text = "Câtul dintre " + Convert.ToString(num1) + " şi " + Convert.ToString(num2) +
                                          " este";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 261, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 381, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 6:
                    do
                    {
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(2, 100);
                    } while (num1 % num2 != 0);
                    lblQuestionTop.Text = "Alina are " + Convert.ToString(num1) + " flori, iar Bianca are de " +
                                          Convert.ToString(num2) + " ori mai puţine.";
                    lblQuestionBottom.Text = "Câte flori are Bianca?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 224, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 344, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 7:
                    do
                    {
                        num1 = random.Next(1, 1000);
                        num2 = random.Next(1, 100);
                    } while (num1 % num2 != 0);
                    lblQuestionTop.Text = "Deîmpărţitul este " + Convert.ToString(num1) + ", iar câtul este " +
                                          Convert.ToString(num2) + '.';
                    lblQuestionBottom.Text = "Care este împărţitorul?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 233, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 353, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
            }
        }

        private void GenerateQuestionMul()
        {
            questionIndex = random.Next(1, 8);
            switch (questionIndex)
            {
                case 1:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(20);
                    num2 = random.Next(20);
                    lblQuestionTop.Text = Convert.ToString(num1) + " * " + Convert.ToString(num2) + " =";
                    lblQuestionTop.Visible = true;
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 101, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 221, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 2:
                    lblQuestionBottom.Visible = false;
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    } while (num2 % num1 != 0);
                    lblQuestionTop.Text = "* " + Convert.ToString(num1) + " = " + Convert.ToString(num2);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionTop.Location = new Point(yQuestion + 106, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 226, hTxtQuestionTop);
                    txtAnswer.Visible = true;
                    break;
                case 3:
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 100);
                    } while (num2 % num1 != 0);
                    lblQuestionTop.Text = Convert.ToString(num1) + " *";
                    lblQuestionBottom.Text = "= " + Convert.ToString(num2);
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 58, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion + 160, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 240, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 4:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(10);
                    num2 = random.Next(10);
                    num3 = random.Next(10);
                    lblQuestionTop.Text = Convert.ToString(num1) + " * " + Convert.ToString(num2) + " * " +
                                          Convert.ToString(num3) + " =";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 148, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 268, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 5:
                    lblQuestionBottom.Visible = false;
                    num1 = random.Next(30);
                    num2 = random.Next(30);
                    lblQuestionTop.Text = "Produsul dintre " + Convert.ToString(num1) + " şi " + Convert.ToString(num2) +
                                          " este";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    txtAnswer.Location = new Point(yQuestion + 301, hTxtQuestionTop);
                    btnCheckSolution.Location = new Point(yQuestion + 421, hTxtQuestionTop);
                    lblQuestionTop.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 6:
                    num1 = random.Next(100);
                    num2 = random.Next(100);
                    lblQuestionTop.Text = "Cosmin are " + Convert.ToString(num1) + " maşinuţe, iar George are de " +
                                          Convert.ToString(num2) + " ori mai multe.";
                    lblQuestionBottom.Text = "Câte maşinuţe are George?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 291, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 411, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
                case 7:
                    do
                    {
                        num1 = random.Next(1, 100);
                        num2 = random.Next(1, 1000);
                    } while (num2 % num1 != 0);
                    lblQuestionTop.Text = "Factorul 1 al înmulţirii este " + Convert.ToString(num1) +
                                          ", iar produsul este " + Convert.ToString(num2) + '.';
                    lblQuestionBottom.Text = "Care este factorul 2?";
                    lblQuestionTop.Location = new Point(yQuestion, hTxtQuestionTop);
                    lblQuestionBottom.Location = new Point(yQuestion, hTxtQuestionBottom);
                    txtAnswer.Location = new Point(yQuestion + 227, hTxtQuestionBottom);
                    btnCheckSolution.Location = new Point(yQuestion + 347, hTxtQuestionBottom);
                    lblQuestionTop.Visible = true;
                    lblQuestionBottom.Visible = true;
                    txtAnswer.Visible = true;
                    break;
            }
        }

        #endregion GenerateQuestion
    }
}
