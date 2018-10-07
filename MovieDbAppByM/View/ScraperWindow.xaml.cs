using MovieDbAppByM.View.Contract;
using System.Windows;

namespace MovieDbAppByM.View
{
    /// <summary>
    /// Interaction logic for ScraperWindow.xaml
    /// </summary>
    public partial class ScraperWindow : Window, IClosable, IMinimizable
    {
        public ScraperWindow()
        {
            InitializeComponent();
        }

        public void CloseWindow()
        {
            this.Close();
        }

        public void MinimizeWindow()
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
