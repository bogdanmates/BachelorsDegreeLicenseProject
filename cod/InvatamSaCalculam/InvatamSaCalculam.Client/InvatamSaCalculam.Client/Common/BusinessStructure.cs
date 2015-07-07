using System.Media;
using InvatamSaCalculam.Client.ServiceReference;

namespace InvatamSaCalculam.Client.Common
{
    public class BusinessStructure
    {
        private BusinessStructure()
        {
            BDService = new ServerServiceClient();
            SetSounds();
        }

        private static BusinessStructure instance;
        public static BusinessStructure Instance
        {
            get { return instance ?? (instance = new BusinessStructure()); }
        }

        public ServerServiceClient BDService { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool IsTeacher { get; set; }
        public bool IsGuest { get; set; }
        public SoundPlayer ClapSound { get; set; }
        public SoundPlayer WrongAnswerSound { get; set; }
        public SoundPlayer RightAnswerSound { get; set; }
        public SoundPlayer WinnerSound { get; set; }

        private void SetSounds()
        {
            ClapSound = new SoundPlayer(@".\..\..\Sounds\applause-2.wav");
            WrongAnswerSound = new SoundPlayer(@".\..\..\Sounds\beep-3.wav");
            RightAnswerSound = new SoundPlayer(@".\..\..\Sounds\button-14.wav");
            WinnerSound = new SoundPlayer(@".\..\..\Sounds\button-9.wav");
        }
    }

    public enum PuzzleSize
    {
        Small,
        Big
    }

    public enum Operations
    {
        Add,
        Diff,
        Mul, 
        Div
    }
}
