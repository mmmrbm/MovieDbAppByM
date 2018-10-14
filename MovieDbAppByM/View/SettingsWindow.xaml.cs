using MovieDbAppByM.View.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieDbAppByM.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window, IClosable, IMinimizable
    {
        public SettingsWindow()
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
