using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using InvatamSaCalculam.Client.Common;
using InvatamSaCalculam.Client.ServiceReference;
using MathAssistant.Client.LandingPages.Helpers;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class ManageStudents : UserControl
    {
        private DataGridViewColumn oldColumn = null;
        private ListSortDirection oldDirection;

        public ManageStudents()
        {
            InitializeComponent();
        }

        private void ManageStudents_ParentChanged(object sender, System.EventArgs e)
        {
            if (Parent != null)
            {
                GetTeachersStudents();
            }
        }

        private void GetTeachersStudents()
        {
            dsStudentsLocal.Students.Clear();
            var studentsList = BusinessStructure.Instance.BDService.GetTeachersStudents(BusinessStructure.Instance.UserId);
            foreach (User student in studentsList)
            {
                dsStudents.StudentsRow studentRow = dsStudentsLocal.Students.NewStudentsRow();
                studentRow.Id = student.Id;
                studentRow.Name = student.Username;
                studentRow.Score = student.UserScores.First().Score;

                UserSmallMedal smallMedals = student.UserSmallMedals.First();
                studentRow.SmallBronzeMedals = smallMedals.BronzeMedals;
                studentRow.SmallSilverMedals = smallMedals.SilverMedals;
                studentRow.SmallGoldMedals = smallMedals.GoldMedals;

                UserBigMedal bigMedals = student.UserBigMedals.First();
                studentRow.BigBronzeMedals = bigMedals.BronzeMedals;
                studentRow.BigSilverMedals = bigMedals.SilverMedals;
                studentRow.BigGoldMedals = bigMedals.GoldMedals;

                UserCup cups = student.UserCups.First();
                studentRow.AddCups = cups.AddCup;
                studentRow.DiffCups = cups.DiffCup;
                studentRow.DivCups = cups.DivCup;
                studentRow.MulCups = cups.MulCup;

                UserGame games = student.UserGames.First();
                studentRow.Hangman = games.Hangman;
                studentRow.Blocks = games.Blocks;

                dsStudentsLocal.Students.AddStudentsRow(studentRow);
            }
        }

        private void gvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvStudents.Rows[e.RowIndex];
                int studentId = (int)row.Cells[0].Value;
                if (e.ColumnIndex == 15)
                {
                    ResetStudent(studentId);
                }

                if (e.ColumnIndex == 16)
                {
                    DeleteStudent(studentId);
                }
            }
        }

        private void ResetStudent(int studentId)
        {
            BusinessStructure.Instance.BDService.Reset(studentId);
            GetTeachersStudents();
        }

        private void DeleteStudent(int studentId)
        {
            BusinessStructure.Instance.BDService.Delete(studentId);
            GetTeachersStudents();
        }

        private void gvStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn newColumn = gvStudents.Columns[e.ColumnIndex];
            ListSortDirection direction = ListSortDirection.Ascending;
            if (oldColumn != null)
            {
                if (oldColumn == newColumn)
                {
                    direction = oldDirection == ListSortDirection.Descending ? ListSortDirection.Ascending : ListSortDirection.Descending;
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
            }

            gvStudents.Sort(newColumn, direction);
            oldColumn = newColumn;
            oldDirection = direction;
        }
    }
}
