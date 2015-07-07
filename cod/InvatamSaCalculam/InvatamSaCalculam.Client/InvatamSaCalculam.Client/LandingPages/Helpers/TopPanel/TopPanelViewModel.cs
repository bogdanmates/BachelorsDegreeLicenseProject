using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using InvatamSaCalculam.Client.Common;
using InvatamSaCalculam.Client.LandingPages.Helpers.TopPlayer;
using InvatamSaCalculam.Client.ServiceReference;

namespace InvatamSaCalculam.Client.LandingPages.Helpers.TopPanel
{
    public class TopPanelViewModel : ViewModelBase
    {
        private ObservableCollection<TopPlayerViewModel> players = new ObservableCollection<TopPlayerViewModel>();

        public ObservableCollection<TopPlayerViewModel> Players
        {
            get { return players; }
            set
            {
                if (players != value)
                {
                    players = value;
                    OnPropertyChanged("Players");
                }
            }
        }

        public void SetPlayers()
        {
            int rank = 1;
            List<User> players = BusinessStructure.Instance.BDService.GetTopPlayers();
            foreach (User user in players)
            {
                var userGame = user.UserGames.First();
                var userCups = user.UserCups.First();
                var userSmallMedals = user.UserSmallMedals.First();
                var userBigMedals = user.UserBigMedals.First();
                Players.Add(new TopPlayerViewModel
                {
                    Rank = rank.ToString(),
                    Username = user.Username,
                    Cups = (userCups.AddCup + userCups.DiffCup + userCups.DivCup + userCups.MulCup).ToString(),
                    SmallPuzzle =
                        (userSmallMedals.BronzeMedals + userSmallMedals.SilverMedals + userSmallMedals.GoldMedals)
                            .ToString(),
                    BigPuzzle =
                        (userBigMedals.BronzeMedals + userBigMedals.SilverMedals + userBigMedals.GoldMedals).ToString(),
                    Blocks = userGame.Blocks.ToString(),
                    Hangman = userGame.Hangman.ToString(),
                    Score = (user.UserScores.First().Score + userGame.Blocks + userGame.Hangman).ToString() 
                });
                rank++;
            }
        }

        public void ClearPlayers()
        {
            Players.Clear();
        }
    }
}
