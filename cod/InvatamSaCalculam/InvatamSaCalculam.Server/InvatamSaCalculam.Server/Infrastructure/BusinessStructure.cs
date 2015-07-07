using InvatamSaCalculam.Server.Models;

namespace InvatamSaCalculam.Server.Infrastructure
{
    public class BusinessStructure
    {
        private BusinessStructure()
        {
            Model = new InvatamSaCalculamEntities();
            Model.ContextOptions.LazyLoadingEnabled = true;
        }

        private static BusinessStructure instance;
        public static BusinessStructure Instance
        {
            get { return instance ?? (instance = new BusinessStructure()); }
        }

        public InvatamSaCalculamEntities Model { get; set; }
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