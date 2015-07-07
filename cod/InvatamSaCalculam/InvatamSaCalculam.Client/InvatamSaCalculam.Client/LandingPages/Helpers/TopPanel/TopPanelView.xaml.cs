using System.Windows.Controls;

namespace InvatamSaCalculam.Client.LandingPages.Helpers.TopPanel
{
    /// <summary>
    /// Interaction logic for TopPanelView.xaml
    /// </summary>
    public partial class TopPanelView : UserControl
    {
        public TopPanelView()
        {
            InitializeComponent();
            DataContext = new TopPanelViewModel();
        }

        public void SetPlayers()
        {
            ((TopPanelViewModel)DataContext).SetPlayers();
        }

        public void ClearPlayers()
        {
            ((TopPanelViewModel)DataContext).ClearPlayers();
        }
    }
}
