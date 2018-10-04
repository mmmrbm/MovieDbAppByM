using MovieDbAppByM.ViewModel;
using System.Windows;

namespace MovieDbAppByM.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable, IMinimizable
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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
