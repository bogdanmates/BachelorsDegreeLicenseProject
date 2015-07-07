using System.Drawing;

namespace InvatamSaCalculam.Client.LandingPages.Helpers.TopPlayer
{
    public class TopPlayerViewModel : ViewModelBase
    {
        public TopPlayerViewModel()
        {
            CupsBitmap = InvatamSaCalculam.Client.Properties.Resources.cups;
            BlocksBitmap = InvatamSaCalculam.Client.Properties.Resources.blocks;
            HangmanBitmap = InvatamSaCalculam.Client.Properties.Resources.hangman;
            ScoreBitmap = InvatamSaCalculam.Client.Properties.Resources.score;
            SmallPuzzleBitmap = InvatamSaCalculam.Client.Properties.Resources.smallPuzzle;
            BigPuzzleBitmap = InvatamSaCalculam.Client.Properties.Resources.bigPuzzle;
        }

        private string rank;

        public string Rank
        {
            get { return rank; }
            set
            {
                if (rank != value)
                {
                    rank = value;
                    OnPropertyChanged("Rank");
                }
            }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        private string cups;

        public string Cups
        {
            get { return cups; }
            set
            {
                if (cups != value)
                {
                    cups = value;
                    OnPropertyChanged("Cups");
                }
            }
        }

        private string smallPuzzle;

        public string SmallPuzzle
        {
            get { return smallPuzzle; }
            set
            {
                if (smallPuzzle != value)
                {
                    smallPuzzle = value;
                    OnPropertyChanged("SmallPuzzle");
                }
            }
        }

        private string bigPuzzle;

        public string BigPuzzle
        {
            get { return bigPuzzle; }
            set
            {
                if (bigPuzzle != value)
                {
                    bigPuzzle = value;
                    OnPropertyChanged("BigPuzzle");
                }
            }
        }

        private string blocks;

        public string Blocks
        {
            get { return blocks; }
            set
            {
                if (blocks != value)
                {
                    blocks = value;
                    OnPropertyChanged("Blocks");
                }
            }
        }

        private string hangman;

        public string Hangman
        {
            get { return hangman; }
            set
            {
                if (hangman != value)
                {
                    hangman = value;
                    OnPropertyChanged("Hangman");
                }
            }
        }

        private string score;

        public string Score
        {
            get { return score; }
            set
            {
                if (score != value)
                {
                    score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        public Bitmap CupsBitmap { get; set; }
        public Bitmap BlocksBitmap { get; set; }
        public Bitmap HangmanBitmap { get; set; }
        public Bitmap ScoreBitmap { get; set; }
        public Bitmap SmallPuzzleBitmap { get; set; }
        public Bitmap BigPuzzleBitmap { get; set; }
    }
}
