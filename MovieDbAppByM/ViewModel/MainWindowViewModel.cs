using Autofac;
using MovieDbAppByM.Core;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.Service;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieDbAppByM.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        #region Constants
        private static readonly string redDeep = "#642424";
        private static readonly string redLight = "#E7B7B7";
        private static readonly string blueDeep = "#102540";
        private static readonly string blueLight = "#8BB4E2";
        private static readonly string greenDeep = "#4F6328";
        private static readonly string greenLight = "#D7E3BF";
        private static readonly string greyDeep = "#000000";
        private static readonly string greyLight = "#D9D9D9";
        private static readonly string purpleDeep = "#3F3152";
        private static readonly string purpleLight = "#CDBFD8";
        private static readonly string orangeDeep = "#984907";
        private static readonly string orangeLight = "#FCD4B1";
        #endregion

        #region Class variables
        private string titleTextValue;
        private string directorTextValue;
        private string taglineTextValue;
        private string runtimeTextValue;
        private string ratingTextValue;
        private string releaseYearTextValue;
        private string genreTextValue;
        private string overviewTextValue;
        private string actorOneTextValue;
        private string actorTwoTextValue;
        private string actorThreeTextValue;
        private string actorFourTextValue;
        private string actorFiveTextValue;
        private string actorSixTextValue;
        private string castTextValue;
        private string statusTextValue;

        private byte[] backdropImgRawData;
        private byte[] posterImgRawData;
        private byte[] directorImgRawData;
        private byte[] actorOneImgRawData;
        private byte[] actorTwoImgRawData;
        private byte[] actorThreeImgRawData;
        private byte[] actorFourImgRawData;
        private byte[] actorFiveImgRawData;
        private byte[] actorSixImgRawData;


        private SolidColorBrush backgroundFillColor;
        private SolidColorBrush appNameBackgroundColor;
        private SolidColorBrush topLeftRectangleFillColor;
        private SolidColorBrush headerBarRectangleFillColor;
        private SolidColorBrush searchBoxBackgroundColor;
        private SolidColorBrush searchBarFillColor;
        private SolidColorBrush titleTextForegroundColor;
        private SolidColorBrush directorTextForegroundColor;
        private SolidColorBrush taglineTextForegroundColor;
        private SolidColorBrush runtimeTextForegroundColor;
        private SolidColorBrush ratingTextForegroundColor;
        private SolidColorBrush yearTextForegroundColor;
        private SolidColorBrush overviewTextForegroundColor;
        private SolidColorBrush castTextForegroundColor;
        private SolidColorBrush actorOneTextForegroundColor;
        private SolidColorBrush actorTwoTextForegroundColor;
        private SolidColorBrush actorThreeTextForegroundColor;
        private SolidColorBrush actorFourTextForegroundColor;
        private SolidColorBrush actorFiveTextForegroundColor;
        private SolidColorBrush actorSixTextForegroundColor;
        private SolidColorBrush genreTextForegroundColor;
        #endregion

        public MainWindowViewModel()
        {
            this.WindowLoadedCommand = new RelayCommand(this.WindowLoadedCommandHandler);
            this.CloseCommand = new RelayCommand<IClosable>(this.CloseCommandHandler);
            this.MinimizeCommand = new RelayCommand<IMinimizable>(this.MinimizeCommandHandler);
            this.SearchCommand = new RelayCommand(this.SearchCommandHandler);
            this.RefreshCommand = new RelayCommand(this.RefreshCommandHandler);
            this.ToolCommand = new RelayCommand(this.ToolCommandHandler);
            this.SettingCommand = new RelayCommand(this.SettingCommandHandler);
            this.ScrollRightCommand = new RelayCommand(this.ScrollRightCommandHandler);
            this.ScrollLeftCommand = new RelayCommand(this.ScrollLeftCommandHandler);
        }

        #region Properties
        public string TitleTextValue
        {
            get { return this.titleTextValue; }
            set { this.SetProperty(ref this.titleTextValue, value); }
        }

        public string DirectorTextValue
        {
            get { return this.directorTextValue; }
            set { this.SetProperty(ref this.directorTextValue, value); }
        }

        public string TaglineTextValue
        {
            get { return this.taglineTextValue; }
            set { this.SetProperty(ref this.taglineTextValue, value); }
        }

        public string RuntimeTextValue
        {
            get { return this.runtimeTextValue; }
            set { this.SetProperty(ref this.runtimeTextValue, value); }
        }

        public string RatingTextValue
        {
            get { return this.ratingTextValue; }
            set { this.SetProperty(ref this.ratingTextValue, value); }
        }

        public string ReleaseYearTextValue
        {
            get { return this.releaseYearTextValue; }
            set { this.SetProperty(ref this.releaseYearTextValue, value); }
        }

        public string GenreTextValue
        {
            get { return this.genreTextValue; }
            set { this.SetProperty(ref this.genreTextValue, value); }
        }

        public string OverviewTextValue
        {
            get { return this.overviewTextValue; }
            set { this.SetProperty(ref this.overviewTextValue, value); }
        }

        public string ActorOneTextValue
        {
            get { return this.actorOneTextValue; }
            set { this.SetProperty(ref this.actorOneTextValue, value); }
        }

        public string ActorTwoTextValue
        {
            get { return this.actorTwoTextValue; }
            set { this.SetProperty(ref this.actorTwoTextValue, value); }
        }

        public string ActorThreeTextValue
        {
            get { return this.actorThreeTextValue; }
            set { this.SetProperty(ref this.actorThreeTextValue, value); }
        }

        public string ActorFourTextValue
        {
            get { return this.actorFourTextValue; }
            set { this.SetProperty(ref this.actorFourTextValue, value); }
        }

        public string ActorFiveTextValue
        {
            get { return this.actorFiveTextValue; }
            set { this.SetProperty(ref this.actorFiveTextValue, value); }
        }

        public string ActorSixTextValue
        {
            get { return this.actorSixTextValue; }
            set { this.SetProperty(ref this.actorSixTextValue, value); }
        }

        public string StatusTextValue
        {
            get { return this.statusTextValue; }
            set { this.SetProperty(ref this.statusTextValue, value); }
        }

        public byte[] BackdropImgRawData
        {
            get { return this.backdropImgRawData; }
            set { this.SetProperty(ref this.backdropImgRawData, value); }
        }

        public byte[] PosterImgRawData
        {
            get { return this.posterImgRawData; }
            set { this.SetProperty(ref this.posterImgRawData, value); }
        }

        public byte[] DirectorImgRawData
        {
            get { return this.directorImgRawData; }
            set { this.SetProperty(ref this.directorImgRawData, value); }
        }

        public byte[] ActorOneImgRawData
        {
            get { return this.actorOneImgRawData; }
            set { this.SetProperty(ref this.actorOneImgRawData, value); }
        }

        public byte[] ActorTwoImgRawData
        {
            get { return this.actorTwoImgRawData; }
            set { this.SetProperty(ref this.actorTwoImgRawData, value); }
        }

        public byte[] ActorThreeImgRawData
        {
            get { return this.actorThreeImgRawData; }
            set { this.SetProperty(ref this.actorThreeImgRawData, value); }
        }

        public byte[] ActorFourImgRawData
        {
            get { return this.actorFourImgRawData; }
            set { this.SetProperty(ref this.actorFourImgRawData, value); }
        }

        public byte[] ActorFiveImgRawData
        {
            get { return this.actorFiveImgRawData; }
            set { this.SetProperty(ref this.actorFiveImgRawData, value); }
        }

        public byte[] ActorSixImgRawData
        {
            get { return this.actorSixImgRawData; }
            set { this.SetProperty(ref this.actorSixImgRawData, value); }
        }



        public SolidColorBrush BackgroundFillColor
        {
            get { return this.backgroundFillColor; }
            set { this.SetProperty(ref this.backgroundFillColor, value); }
        }

        public SolidColorBrush TopLeftRectangleFillColor
        {
            get { return this.topLeftRectangleFillColor; }
            set { this.SetProperty(ref this.topLeftRectangleFillColor, value); }
        }

        public SolidColorBrush HeaderBarRectangleFillColor
        {
            get { return this.headerBarRectangleFillColor; }
            set { this.SetProperty(ref this.headerBarRectangleFillColor, value); }
        }

        public SolidColorBrush AppNameBackgroundColor
        {
            get { return this.appNameBackgroundColor; }
            set { this.SetProperty(ref this.appNameBackgroundColor, value); }
        }

        public SolidColorBrush SearchBoxBackgroundColor
        {
            get { return this.searchBoxBackgroundColor; }
            set { this.SetProperty(ref this.searchBoxBackgroundColor, value); }
        }

        public SolidColorBrush SearchBarFillColor
        {
            get { return this.searchBarFillColor; }
            set { this.SetProperty(ref this.searchBarFillColor, value); }
        }

        public SolidColorBrush TitleTextForegroundColor
        {
            get { return this.titleTextForegroundColor; }
            set { this.SetProperty(ref this.titleTextForegroundColor, value); }
        }

        public SolidColorBrush DirectorTextForegroundColor
        {
            get { return this.directorTextForegroundColor; }
            set { this.SetProperty(ref this.directorTextForegroundColor, value); }
        }

        public SolidColorBrush TaglineTextForegroundColor
        {
            get { return this.taglineTextForegroundColor; }
            set { this.SetProperty(ref this.taglineTextForegroundColor, value); }
        }

        public SolidColorBrush RuntimeTextForegroundColor
        {
            get { return this.ratingTextForegroundColor; }
            set { this.SetProperty(ref this.ratingTextForegroundColor, value); }
        }

        public SolidColorBrush RatingTextForegroundColor
        {
            get { return this.ratingTextForegroundColor; }
            set { this.SetProperty(ref this.ratingTextForegroundColor, value); }
        }

        public SolidColorBrush YearTextForegroundColor
        {
            get { return this.yearTextForegroundColor; }
            set { this.SetProperty(ref this.yearTextForegroundColor, value); }
        }

        public SolidColorBrush GenreTextForegroundColor
        {
            get { return this.genreTextForegroundColor; }
            set { this.SetProperty(ref this.genreTextForegroundColor, value); }
        }

        public SolidColorBrush OverviewTextForegroundColor
        {
            get { return this.overviewTextForegroundColor; }
            set { this.SetProperty(ref this.overviewTextForegroundColor, value); }
        }

        public SolidColorBrush CastTextForegroundColor
        {
            get { return this.castTextForegroundColor; }
            set { this.SetProperty(ref this.castTextForegroundColor, value); }
        }

        public string CastTextValue
        {
            get { return this.castTextValue; }
            set { this.SetProperty(ref this.castTextValue, value); }
        }


        public SolidColorBrush ActorOneTextForegroundColor
        {
            get { return this.actorOneTextForegroundColor; }
            set { this.SetProperty(ref this.actorOneTextForegroundColor, value); }
        }

        public SolidColorBrush ActorTwoTextForegroundColor
        {
            get { return this.actorTwoTextForegroundColor; }
            set { this.SetProperty(ref this.actorTwoTextForegroundColor, value); }
        }

        public SolidColorBrush ActorThreeTextForegroundColor
        {
            get { return this.actorThreeTextForegroundColor; }
            set { this.SetProperty(ref this.actorThreeTextForegroundColor, value); }
        }

        public SolidColorBrush ActorFourTextForegroundColor
        {
            get { return this.actorFourTextForegroundColor; }
            set { this.SetProperty(ref this.actorFourTextForegroundColor, value); }
        }

        public SolidColorBrush ActorFiveTextForegroundColor
        {
            get { return this.actorFiveTextForegroundColor; }
            set { this.SetProperty(ref this.actorFiveTextForegroundColor, value); }
        }

        public SolidColorBrush ActorSixTextForegroundColor
        {
            get { return this.actorSixTextForegroundColor; }
            set { this.SetProperty(ref this.actorSixTextForegroundColor, value); }
        }
        #endregion

        #region Commands
        public ICommand WindowLoadedCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand MinimizeCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        public ICommand RefreshCommand { get; private set; }

        public ICommand ToolCommand { get; private set; }

        public ICommand SettingCommand { get; private set; }

        public ICommand ScrollRightCommand { get; private set; }

        public ICommand ScrollLeftCommand { get; private set; }
        #endregion

        #region Command Handlers
        private void WindowLoadedCommandHandler()
        {
            string selectedTheme = new Service.AppSettings()["Theme"].ToString();
            switch (selectedTheme)
            {
                case "Red":
                    SetMainWindowElements(redLight, redDeep);
                    break;

                case "Green":
                    SetMainWindowElements(greenLight, greenDeep);
                    break;

                case "Blue":
                    SetMainWindowElements(blueLight, blueDeep);
                    break;

                case "Grey":
                    SetMainWindowElements(greyLight, greyDeep);
                    break;

                case "Purple":
                    SetMainWindowElements(purpleLight, purpleDeep);
                    break;

                case "Orange":
                    SetMainWindowElements(orangeLight, orangeDeep);
                    break;

                default:
                    SetMainWindowElements(greyLight, greyDeep);
                    break;
            }
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
            IContainer continer = IocContainerSingleton.Instance.Container;
            MoviePersistanceService service = continer.Resolve<MoviePersistanceService>();
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
        #endregion

        #region Implementation Methods
        private void SetMainWindowElements(string lightColor, string deepColor)
        {
            SolidColorBrush foregroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(lightColor));
            this.TitleTextForegroundColor = foregroundColor;
            this.TaglineTextForegroundColor = foregroundColor;
            this.RatingTextForegroundColor = foregroundColor;
            this.YearTextForegroundColor = foregroundColor;
            this.OverviewTextForegroundColor = foregroundColor;
            this.CastTextForegroundColor = foregroundColor;
            this.DirectorTextForegroundColor = foregroundColor;
            this.GenreTextForegroundColor = foregroundColor;
            SearchBoxBackgroundColor = foregroundColor;

            SolidColorBrush backgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(deepColor));
            BackgroundFillColor = backgroundColor;
            SearchBarFillColor = backgroundColor;
            this.TopLeftRectangleFillColor = backgroundColor;
            this.HeaderBarRectangleFillColor = backgroundColor;
            this.AppNameBackgroundColor = backgroundColor;

            this.TitleTextValue = "Welcome to your Movie Catalog";
            this.TaglineTextValue = "Let's get started...";
            this.OverviewTextValue = $@"
Click + below to launch Scraper Tool add movies to your collection.
Load the file containing IMDB IDs of the movie and click on Start button.
The tool will add your movies to the collection automatically.";
        }
        #endregion

    }
}
