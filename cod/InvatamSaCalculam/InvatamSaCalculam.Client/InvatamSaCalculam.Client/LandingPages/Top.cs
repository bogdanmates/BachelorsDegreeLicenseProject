using System;
using System.Windows.Forms;

namespace InvatamSaCalculam.Client.LandingPages
{
    public partial class Top : UserControl
    {
        public Top()
        {
            InitializeComponent();
        }

        private void Top_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                topPanelView.SetPlayers();
            }
            else
            {
                topPanelView.ClearPlayers();
            }
        }
    }
}
