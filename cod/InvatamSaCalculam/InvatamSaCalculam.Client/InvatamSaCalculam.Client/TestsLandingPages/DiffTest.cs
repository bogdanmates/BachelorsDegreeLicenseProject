using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;

namespace InvatamSaCalculam.Client.TestsLandingPages
{
    public partial class DiffTest : UserControl
    {
        private int num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, num13, num14, num15;
        private string[] awards;
        private bool cup;
        private Random random = new Random();

        public DiffTest()
        {
            InitializeComponent();
            awards = Directory.GetFiles(@".\..\..\Resources\Premii");
        }

        private void DiffTest_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                GenerateTest();
                pctCup.Image = Image.FromFile(awards[4]);
                SetAdminButton();
            }
        }

        private void SetAdminButton()
        {
            btnAdmin.Visible = BusinessStructure.Instance.IsTeacher;
        }

        private void GenerateTest()
        {
            SetRandomNumbers();
            GenerateQuestions();
            ResetFields();
            btnCheckTest.Enabled = true;
        }

        private void SetRandomNumbers()
        {
            do
            {
                num1 = random.Next(100);
                num2 = random.Next(100);
            } while (num1 < num2);
            num3 = random.Next(100);
            num4 = random.Next(100);
            do
            {
                num5 = random.Next(100);
                num6 = random.Next(100);
            } while (num5 < num6);
            do
            {
                num7 = random.Next(100);
                num8 = random.Next(100);
                num9 = random.Next(100);
            } while ((num7 < num8) || ((num7 - num8) < num9));
            do
            {
                num10 = random.Next(100);
                num11 = random.Next(100);
            } while (num10 < num11);
            do
            {
                num12 = random.Next(100);
                num13 = random.Next(100);
            } while (num12 < num13);
            do
            {
                num14 = random.Next(100);
                num15 = random.Next(100);
            } while (num14 < num15);
        }

        private void GenerateQuestions()
        {
            lblQuestion1.Text = Convert.ToString(num1) + " - " + Convert.ToString(num2) + " =";
            lblQuestion2.Text = "- " + Convert.ToString(num3) + " = " + Convert.ToString(num4);
            lblQuestion3Left.Text = Convert.ToString(num5) + " -";
            lblQuestion3Right.Text = "= " + Convert.ToString(num6);
            lblQuestion4.Text = Convert.ToString(num7) + " - " + Convert.ToString(num8) + " - " + Convert.ToString(num9) + " =";
            lblQuestion5.Text = "Diferenta dintre " + Convert.ToString(num10) + " şi " + Convert.ToString(num11) + " este";
            lblQuestion6Top.Text = "Mihai are " + Convert.ToString(num12) + " bomboane, iar Simona are cu " + Convert.ToString(num13) + " mai puţine.";
            lblQuestion6Bottom.Text = "Câte bomboane are Simona?";
            lblQuestion7Top.Text = "Descăzutul este " + Convert.ToString(num14) + ", iar diferenţa este " + Convert.ToString(num15) + '.';
            lblQuestion7Bottom.Text = "Care este scăzătorul?";
        }

        private void ResetFields()
        {
            Font fb = new Font("Microsoft Sans Serif", 8);
            lblNote.Text = "";

            lblAnswer1.Text = "";
            lblAnswer2.Text = "";
            lblAnswer3.Text = "";
            lblAnswer4.Text = "";
            lblAnswer5.Text = "";
            lblAnswer6.Text = "";
            lblAnswer7.Text = "";
            lblCup.Text = "";

            pctAnswer1.Image = null;
            pctAnswer2.Image = null;
            pctAnswer3.Image = null;
            pctAnswer4.Image = null;
            pctAnswer5.Image = null;
            pctAnswer6.Image = null;
            pctAnswer7.Image = null;

            txtAnswer1.Font = fb;
            txtAnswer2.Font = fb;
            txtAnswer3.Font = fb;
            txtAnswer4.Font = fb;
            txtAnswer5.Font = fb;
            txtAnswer6.Font = fb;
            txtAnswer7.Font = fb;

            txtAnswer1.Text = "";
            txtAnswer2.Text = "";
            txtAnswer3.Text = "";
            txtAnswer4.Text = "";
            txtAnswer5.Text = "";
            txtAnswer6.Text = "";
            txtAnswer7.Text = "";
            txtAnswer1.Focus();
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            GenerateTest();
            SetAdminButton();
        }

        private void btnCheckTest_Click(object sender, EventArgs e)
        {
            int answer1 = txtAnswer1.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer1.Text);
            int answer2 = txtAnswer2.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer2.Text);
            int answer3 = txtAnswer3.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer3.Text);
            int answer4 = txtAnswer4.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer4.Text);
            int answer5 = txtAnswer5.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer5.Text);
            int answer6 = txtAnswer6.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer6.Text);
            int answer7 = txtAnswer7.Text.Equals("") ? 0 : Convert.ToInt16(txtAnswer7.Text);


            int finalNote = 1;
            Font fontStrikeout = new Font("Microsoft Sans Serif", 8, FontStyle.Strikeout);

            if ((txtAnswer1.Text != "") && (num1 - num2 == answer1))
            {
                finalNote++;
                pctAnswer1.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer1.Image = imageList.Images[1];
                txtAnswer1.Font = fontStrikeout;
                lblAnswer1.Text = "Raspuns corect: " + Convert.ToString(num1 - num2);
            }
            if ((txtAnswer2.Text != "") && (num4 + num3 == answer2))
            {
                finalNote++;
                pctAnswer2.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer2.Image = imageList.Images[1];
                txtAnswer2.Font = fontStrikeout;
                lblAnswer2.Text = "Raspuns corect: " + Convert.ToString(num4 + num3);
            }
            if ((txtAnswer3.Text != "") && (num5 - num6 == answer3))
            {
                finalNote++;
                pctAnswer3.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer3.Image = imageList.Images[1];
                txtAnswer3.Font = fontStrikeout;
                lblAnswer3.Text = "Raspuns corect: " + Convert.ToString(num5 - num6);
            }
            if ((txtAnswer4.Text != "") && (num7 - num8 - num9 == answer4))
            {
                finalNote++;
                pctAnswer4.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer4.Image = imageList.Images[1];
                txtAnswer4.Font = fontStrikeout;
                lblAnswer4.Text = "Raspuns corect: " + Convert.ToString(num7 - num8 - num9);
            }
            if ((txtAnswer5.Text != "") && (num10 - num11 == answer5))
            {
                finalNote++;
                pctAnswer5.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer5.Image = imageList.Images[1];
                txtAnswer5.Font = fontStrikeout;
                lblAnswer5.Text = "Raspuns corect: " + Convert.ToString(num10 - num11);
            }
            if ((txtAnswer6.Text != "") && (num12 - num13 == answer6))
            {
                finalNote += 2;
                pctAnswer6.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer6.Image = imageList.Images[1];
                txtAnswer6.Font = fontStrikeout;
                lblAnswer6.Text = "Raspuns corect: " + Convert.ToString(num12 - num13);
            }
            if ((txtAnswer7.Text != "") && (num14 - num15 == answer7))
            {
                finalNote += 2;
                pctAnswer7.Image = imageList.Images[0];
            }
            else
            {
                pctAnswer7.Image = imageList.Images[1];
                txtAnswer7.Font = fontStrikeout;
                lblAnswer7.Text = "Raspuns corect: " + Convert.ToString(num14 - num15);
            }

            lblNote.Text = " Ai obtinut nota " + finalNote + "!";

            if (finalNote == 8)
            {
                cup = true;
                pctCup.Image = pctCup.Image = Image.FromFile(awards[5]);
                lblCup.Text = "Felicitări, ai obţinut cupa de bronz!";
                BusinessStructure.Instance.ClapSound.Play();
            }
            if (finalNote == 9)
            {
                cup = true;
                pctCup.Image = pctCup.Image = Image.FromFile(awards[6]);
                lblCup.Text = "Felicitări, ai obţinut cupa de argint!";
                BusinessStructure.Instance.ClapSound.Play();
            }
            if (finalNote == 10)
            {
                cup = true;
                pctCup.Image = pctCup.Image = Image.FromFile(awards[7]);
                lblCup.Text = "Felicitări, ai obţinut cupa de aur!";
                BusinessStructure.Instance.ClapSound.Play();
            }
            if (cup == true)
            {
                if (!BusinessStructure.Instance.IsGuest)
                {
                    BusinessStructure.Instance.BDService.AddCup(Operations.Diff.ToString(),
                        BusinessStructure.Instance.UserId);
                }
            }
            btnAdmin.Visible = false;
            btnCheckTest.Enabled = false;
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
            int answer;
            answer = num1 - num2;
            txtAnswer1.Text = answer.ToString();
            answer = num4 + num3;
            txtAnswer2.Text = answer.ToString();
            answer = num5 - num6;
            txtAnswer3.Text = answer.ToString();
            answer = num7 - num8 - num9;
            txtAnswer4.Text = answer.ToString();
            answer = num10 - num11;
            txtAnswer5.Text = answer.ToString();
            answer = num12 - num13;
            txtAnswer6.Text = answer.ToString();
            answer = num14 - num15;
            txtAnswer7.Text = answer.ToString();
        }
    }
}
