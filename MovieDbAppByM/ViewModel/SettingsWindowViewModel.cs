using Autofac;
using MovieDbAppByM.Core;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.EventHub;
using MovieDbAppByM.Service;
using MovieDbAppByM.View.Contract;
using MovieDbAppByM.View.Helpers;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieDbAppByM.ViewModel
{
    public class SettingsWindowViewModel : BindableBase
    {
        #region Class Variables
        private IContainer iocContainer;
        private SettingManagementService settingManagementService;

        private string selectedThemeValueText;

        private SolidColorBrush backgroundFillColor;
        private SolidColorBrush borderLineColor;
        private SolidColorBrush titleTextForegroundColor;
        private SolidColorBrush themeSelectorFillColor;
        private SolidColorBrush themeSelectorLabelForegroundColor;
        private SolidColorBrush themeSelectorComboBoxBackgroundColor;
        #endregion

        public SettingsWindowViewModel()
        {
            this.iocContainer = IocContainerSingleton.Instance.Container;
            this.settingManagementService = this.iocContainer.Resolve<SettingManagementService>();
            this.settingManagementService.AppThemeChanged += new AppThemeChangedEventHandler(this.HandleAppThemeChanged);

            this.WindowLoadedCommand = new RelayCommand(this.WindowLoadedCommandHandler);
            this.CloseCommand = new RelayCommand<IClosable>(this.CloseCommandHandler);
            this.MinimizeCommand = new RelayCommand<IMinimizable>(this.MinimizeCommandHandler);
            this.PersistTheme = new RelayCommand(this.PersistThemeCommandHandler);
        }

        #region Commands
        public ICommand WindowLoadedCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand MinimizeCommand { get; private set; }

        public ICommand PersistTheme { get; private set; }
        #endregion

        #region Properties
        public string SelectedThemeValueText
        {
            get { return this.selectedThemeValueText; }
            set { this.SetProperty(ref this.selectedThemeValueText, value); }
        }

        public SolidColorBrush BackgroundFillColor
        {
            get { return this.backgroundFillColor; }
            set { this.SetProperty(ref this.backgroundFillColor, value); }
        }

        public SolidColorBrush BorderLineColor
        {
            get { return this.borderLineColor; }
            set { this.SetProperty(ref this.borderLineColor, value); }
        }
        
        public SolidColorBrush TitleTextForegroundColor
        {
            get { return this.titleTextForegroundColor; }
            set { this.SetProperty(ref this.titleTextForegroundColor, value); }
        }

        public SolidColorBrush ThemeSelectorFillColor
        {
            get { return this.themeSelectorFillColor; }
            set { this.SetProperty(ref this.themeSelectorFillColor, value); }
        }


        public SolidColorBrush ThemeSelectorLabelForegroundColor
        {
            get { return this.themeSelectorLabelForegroundColor; }
            set { this.SetProperty(ref this.themeSelectorLabelForegroundColor, value); }
        }


        public SolidColorBrush ThemeSelectorComboBoxBackgroundColor
        {
            get { return this.themeSelectorComboBoxBackgroundColor; }
            set { this.SetProperty(ref this.themeSelectorComboBoxBackgroundColor, value); }
        }
        
        #endregion

        #region Command Handlers
        private void WindowLoadedCommandHandler()
        {
            SetupApplicationTheme();
        }

        private void CloseCommandHandler(IClosable window)
        {
            if (window != null)
            {
                this.DeregisterFromServiceEvents();
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

        private void PersistThemeCommandHandler()
        {
            this.settingManagementService.PersistApplicationTheme(this.SelectedThemeValueText);
        }
        #endregion

        #region Implementation Methods
        private void SetupApplicationTheme()
        {
            ThemeColorHolder themeColors = this.settingManagementService.GetThemeAscent();
            SetMainWindowElements(themeColors.ForegroundColor, themeColors.BackgroundColor);
        }

        private void SetMainWindowElements(string lightColor, string deepColor)
        {
            // Ideally one can use fewer variables in XAML to set the color for all these items.
            // But this approach was used to make it easy for someone who has better UI / UX perspective,
            // so that if needed these values can be set in more UX friendly manner.
            SolidColorBrush foregroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(lightColor));
            this.TitleTextForegroundColor = foregroundColor;
            this.ThemeSelectorLabelForegroundColor = foregroundColor;
            this.ThemeSelectorComboBoxBackgroundColor = foregroundColor;
            this.BorderLineColor = foregroundColor;

            SolidColorBrush backgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(deepColor));
            this.BackgroundFillColor = backgroundColor;
            this.ThemeSelectorFillColor = backgroundColor;

            this.SelectedThemeValueText = this.settingManagementService.GetCurrentTheme();
        }
        #endregion

        #region Event Handling
        private void HandleAppThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            this.SetupApplicationTheme();
        }

        private void DeregisterFromServiceEvents()
        {
            if (settingManagementService != null)
            {
                settingManagementService.AppThemeChanged -= new AppThemeChangedEventHandler(HandleAppThemeChanged);
                settingManagementService = null;
            }
        }
        #endregion

        #region Finalizer
        ~SettingsWindowViewModel()
        {
            this.DeregisterFromServiceEvents();
        }
        #endregion
    }
}
