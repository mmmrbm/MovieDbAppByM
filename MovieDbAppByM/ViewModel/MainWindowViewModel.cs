using MovieDbAppByM.Core;
using System.Windows.Input;

namespace MovieDbAppByM.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        public ICommand CloseCommand { get; private set; }

        public ICommand MinimizeCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand ToolCommand { get; private set; }

        public ICommand SettingCommand { get; private set; }

        public ICommand ScrollRightCommand { get; private set; }

        public ICommand ScrollLeftCommand { get; private set; }

        public MainWindowViewModel()
        {
            this.CloseCommand = new RelayCommand<IClosable>(this.CloseCommandHandler);
            this.MinimizeCommand = new RelayCommand<IMinimizable>(this.MinimizeCommandHandler);
            this.SearchCommand = new RelayCommand(this.SearchCommandHandler);
            this.RefreshCommand = new RelayCommand(this.RefreshCommandHandler);
            this.ToolCommand = new RelayCommand(this.ToolCommandHandler);
            this.SettingCommand = new RelayCommand(this.SettingCommandHandler);
            this.ScrollRightCommand = new RelayCommand(this.ScrollRightCommandHandler);
            this.ScrollLeftCommand = new RelayCommand(this.ScrollLeftCommandHandler);
        }

        private void CloseCommandHandler(IClosable window)
        {
            if (window != null)
            {
                window.CloseWindow();
            }
        }

        private void MinimizeCommandHandler(IMinimizable window)
        {
            if (window != null)
            {
                window.MinimizeWindow();
            }
        }

        private void SearchCommandHandler()
        {
            //this.SearchMovieInfo();
        }

        private void RefreshCommandHandler()
        {
            //this.RefreshInfo();
        }

        private void ToolCommandHandler()
        {
            //this.DisplayToolWindow();
            Service.MoviePersistanceService service = new Service.MoviePersistanceService();
            service.PersistMoive();
        }

        private void SettingCommandHandler()
        {
            //this.DisplaySettingsWindow();
        }

        private void ScrollRightCommandHandler()
        {
            //this.ScrollRight();
        }

        private void ScrollLeftCommandHandler()
        {
            //this.ScrollLeft();
        }
    }
}
