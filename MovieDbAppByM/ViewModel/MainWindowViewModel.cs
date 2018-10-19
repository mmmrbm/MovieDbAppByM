using Autofac;
using MovieDbAppByM.Core;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.Dto.AppDomain;
using MovieDbAppByM.EventHub;
using MovieDbAppByM.Service;
using MovieDbAppByM.View.Contract;
using MovieDbAppByM.View.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieDbAppByM.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        #region Constants
        private static readonly string runtimeUnitText = " mins";
        private static readonly string imdbBaseUrl = "https://www.imdb.com/title/";
        #endregion

        #region Class variables
        private IContainer iocContainer;
        private SettingManagementService settingManagementService;

        private float progressValue;

        private string titleTextValue;
        private string searchQueryTextValue;
        private string directorTextValue;
        private string taglineTextValue;
        private string runtimeTextValue;
        private string ratingTextValue;
        private string popularityTextValue;
        private string imdbpageTextValue;
        private string homepageTextValue;
        private string releaseYearTextValue;
        private string genreTextValue;
        private string overviewTextValue;
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
        private SolidColorBrush searchBoxForegroundColor;
        private SolidColorBrush searchBarFillColor;
        private SolidColorBrush titleTextForegroundColor;
        private SolidColorBrush directorTextForegroundColor;
        private SolidColorBrush taglineTextForegroundColor;
        private SolidColorBrush homepageTextForegroundColor;
        private SolidColorBrush runtimeTextForegroundColor;
        private SolidColorBrush ratingTextForegroundColor;
        private SolidColorBrush popularityTextForegroundColor;
        private SolidColorBrush yearTextForegroundColor;
        private SolidColorBrush overviewTextForegroundColor;
        private SolidColorBrush castTextForegroundColor;
        private SolidColorBrush movieActorNameForegroundColor;
        private SolidColorBrush movieCastBackgroundColor;
        private SolidColorBrush movieCastForegroundColor;
        private SolidColorBrush genreTextForegroundColor;
        private SolidColorBrush movieListBackgroundColor;
        private SolidColorBrush movieListItemPanelBackgroundColor;
        private SolidColorBrush movieListItemTemplateBackgroundColor;

        private List<AppMovieListItemDto> simpleMovieListFromServer;
        private ObservableCollection<AppMovieListItemDto> appMovieListItemCollection;
        private ObservableCollection<AppMovieActorDto> appMovieCastInfoCollection;
        private AppMovieListItemDto selectedMovie;
        private Visibility shouldDisplayImdbpage;
        private Visibility shouldDisplayHomepage;
        private Visibility shouldRatingBarVisible;
        private Visibility shouldDisplayPopularity;
        #endregion

        public MainWindowViewModel()
        {
            this.iocContainer = IocContainerSingleton.Instance.Container;
            this.settingManagementService = this.iocContainer.Resolve<SettingManagementService>();
            this.settingManagementService.AppThemeChanged += new EventHandler<AppThemeChangedEventArgs>(this.HandleAppThemeChanged);

            this.WindowLoadedCommand = new RelayCommand(this.WindowLoadedCommandHandler);
            this.CloseCommand = new RelayCommand<IClosable>(this.CloseCommandHandler);
            this.MinimizeCommand = new RelayCommand<IMinimizable>(this.MinimizeCommandHandler);
            this.SearchCommand = new RelayCommand(this.SearchCommandHandler);
            this.RefreshCommand = new RelayCommand(this.RefreshCommandHandler);
            this.ToolCommand = new RelayCommand(this.ToolCommandHandler);
            this.SettingCommand = new RelayCommand(this.SettingCommandHandler);
            this.ScrollRightCommand = new RelayCommand(this.ScrollRightCommandHandler);
            this.ScrollLeftCommand = new RelayCommand(this.ScrollLeftCommandHandler);
            this.NavigateToMovieImdbpageCommand = new RelayCommand(this.NavigateToMovieImdbpageCommandHandler);
            this.NavigateToMovieHomepageCommand = new RelayCommand(this.NavigateToMovieHomepageCommandHandler);
        }

        #region Properties
        public float ProgressValue
        {
            get { return this.progressValue; }
            set { this.SetProperty(ref this.progressValue, value); }
        }

        public string TitleTextValue
        {
            get { return this.titleTextValue; }
            set { this.SetProperty(ref this.titleTextValue, value); }
        }

        public string SearchQueryTextValue
        {
            get { return this.searchQueryTextValue; }
            set { this.SetProperty(ref this.searchQueryTextValue, value); }
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

        public string PopularityTextValue
        {
            get { return this.popularityTextValue; }
            set { this.SetProperty(ref this.popularityTextValue, value); }
        }

        public string ReleaseYearTextValue
        {
            get { return this.releaseYearTextValue; }
            set { this.SetProperty(ref this.releaseYearTextValue, value); }
        }

        public string ImdbpageTextValue
        {
            get { return this.imdbpageTextValue; }
            set { this.SetProperty(ref this.imdbpageTextValue, value); }
        }
        
        public string HomepageTextValue
        {
            get { return this.homepageTextValue; }
            set { this.SetProperty(ref this.homepageTextValue, value); }
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

        public string StatusTextValue
        {
            get { return this.statusTextValue; }
            set { this.SetProperty(ref this.statusTextValue, value); }
        }

        public string CastTextValue
        {
            get { return this.castTextValue; }
            set { this.SetProperty(ref this.castTextValue, value); }
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

        public SolidColorBrush SearchBoxForegroundColor
        {
            get { return this.searchBoxForegroundColor; }
            set { this.SetProperty(ref this.searchBoxForegroundColor, value); }
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
            get { return this.runtimeTextForegroundColor; }
            set { this.SetProperty(ref this.runtimeTextForegroundColor, value); }
        }

        public SolidColorBrush RatingTextForegroundColor
        {
            get { return this.ratingTextForegroundColor; }
            set { this.SetProperty(ref this.ratingTextForegroundColor, value); }
        }

        public SolidColorBrush PopularityTextForegroundColor
        {
            get { return this.popularityTextForegroundColor; }
            set { this.SetProperty(ref this.popularityTextForegroundColor, value); }
        }

        public SolidColorBrush YearTextForegroundColor
        {
            get { return this.yearTextForegroundColor; }
            set { this.SetProperty(ref this.yearTextForegroundColor, value); }
        }

        public SolidColorBrush HomepageTextForegroundColor
        {
            get { return this.homepageTextForegroundColor; }
            set { this.SetProperty(ref this.homepageTextForegroundColor, value); }
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

        public SolidColorBrush MovieActorNameForegroundColor
        {
            get { return this.movieActorNameForegroundColor; }
            set { this.SetProperty(ref this.movieActorNameForegroundColor, value); }
        }

        public SolidColorBrush MovieCastBackgroundColor
        {
            get { return this.movieCastBackgroundColor; }
            set { this.SetProperty(ref this.movieCastBackgroundColor, value); }
        }

        public SolidColorBrush MovieCastForegroundColor
        {
            get { return this.movieCastForegroundColor; }
            set { this.SetProperty(ref this.movieCastForegroundColor, value); }
        }

        public SolidColorBrush MovieListBackgroundColor
        {
            get { return this.movieListBackgroundColor; }
            set { this.SetProperty(ref this.movieListBackgroundColor, value); }
        }

        public SolidColorBrush MovieListItemPanelBackgroundColor
        {
            get { return this.movieListItemPanelBackgroundColor; }
            set { this.SetProperty(ref this.movieListItemPanelBackgroundColor, value); }
        }

        public SolidColorBrush MovieListItemTemplateBackgroundColor
        {
            get { return this.movieListItemTemplateBackgroundColor; }
            set { this.SetProperty(ref this.movieListItemTemplateBackgroundColor, value); }
        }


        public ObservableCollection<AppMovieListItemDto> AppMovieListItemCollection
        {
            get { return this.appMovieListItemCollection; }
            set { this.SetProperty(ref this.appMovieListItemCollection, value); }
        }

        public ObservableCollection<AppMovieActorDto> AppMovieCastInfoCollection
        {
            get { return this.appMovieCastInfoCollection; }
            set { this.SetProperty(ref this.appMovieCastInfoCollection, value); }
        }

        public AppMovieListItemDto SelectedMovie
        {
            get { return this.selectedMovie; }
            set {
                this.SetProperty(ref this.selectedMovie, value);
                this.PopulateSelectedMovieInfo();
            }
        }

        public Visibility ShouldDisplayImdbpage
        {
            get { return this.shouldDisplayImdbpage; }
            set { this.SetProperty(ref this.shouldDisplayImdbpage, value); }
        }

        public Visibility ShouldDisplayHomepage
        {
            get { return this.shouldDisplayHomepage; }
            set { this.SetProperty(ref this.shouldDisplayHomepage, value); }
        }

        public Visibility ShouldRatingBarVisible
        {
            get { return this.shouldRatingBarVisible; }
            set { this.SetProperty(ref this.shouldRatingBarVisible, value); }
        }

        public Visibility ShouldDisplayPopularity
        {
            get { return this.shouldDisplayPopularity; }
            set { this.SetProperty(ref this.shouldDisplayPopularity, value); }
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

        public ICommand NavigateToMovieImdbpageCommand { get; private set; }

        public ICommand NavigateToMovieHomepageCommand { get; private set; }
        #endregion

        #region Command Handlers
        private void WindowLoadedCommandHandler()
        {
            SetupApplicationTheme();
            PopulateScrollviewWithMovies();
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
            this.DisplayFilteredMoviesForSearch();
        }

        private void RefreshCommandHandler()
        {
            this.PopulateScrollviewWithMovies();
        }

        private void ToolCommandHandler()
        {
            View.ScraperWindow scraperDialog = new View.ScraperWindow();
            scraperDialog.ShowDialog();
        }

        private void SettingCommandHandler()
        {
            View.SettingsWindow settingsDialog = new View.SettingsWindow();
            settingsDialog.ShowDialog();
        }

        private void ScrollRightCommandHandler()
        {
            int indexOfCurrentlySelectedItem = this.AppMovieListItemCollection.IndexOf(this.SelectedMovie);
            if (indexOfCurrentlySelectedItem < (this.AppMovieListItemCollection.Count - 1))
            {
                this.SelectedMovie = this.AppMovieListItemCollection[(indexOfCurrentlySelectedItem + 1)];
            }
        }

        private void ScrollLeftCommandHandler()
        {
            int indexOfCurrentlySelectedItem = this.AppMovieListItemCollection.IndexOf(this.SelectedMovie);
            if (indexOfCurrentlySelectedItem > 0)
            {
                this.SelectedMovie = this.AppMovieListItemCollection[(indexOfCurrentlySelectedItem - 1)];
            }
        }

        private void NavigateToMovieImdbpageCommandHandler()
        {
            System.Diagnostics.Process.Start(this.ImdbpageTextValue);
        }

        private void NavigateToMovieHomepageCommandHandler()
        {
            System.Diagnostics.Process.Start(this.HomepageTextValue);
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
            this.TaglineTextForegroundColor = foregroundColor;
            this.RatingTextForegroundColor = foregroundColor;
            this.PopularityTextForegroundColor = foregroundColor;
            this.YearTextForegroundColor = foregroundColor;
            this.HomepageTextForegroundColor = foregroundColor;
            this.RuntimeTextForegroundColor = foregroundColor;
            this.OverviewTextForegroundColor = foregroundColor;
            this.CastTextForegroundColor = foregroundColor;
            this.DirectorTextForegroundColor = foregroundColor;
            this.GenreTextForegroundColor = foregroundColor;
            this.MovieActorNameForegroundColor = foregroundColor;
            this.SearchBoxBackgroundColor = foregroundColor;

            SolidColorBrush backgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(deepColor));
            BackgroundFillColor = backgroundColor;
            SearchBarFillColor = backgroundColor;
            this.TopLeftRectangleFillColor = backgroundColor;
            this.HeaderBarRectangleFillColor = backgroundColor;
            this.AppNameBackgroundColor = backgroundColor;
            this.SearchBoxForegroundColor = backgroundColor;


            this.MovieListBackgroundColor = Brushes.Transparent;
            this.MovieListItemPanelBackgroundColor = Brushes.Transparent;
            this.MovieListItemTemplateBackgroundColor = Brushes.Transparent;
            this.MovieCastBackgroundColor = Brushes.Transparent;
            this.MovieCastForegroundColor = Brushes.Transparent;

            this.TitleTextValue = "Welcome to your Movie Catalog";
            this.TaglineTextValue = "Let's get started...";
            this.OverviewTextValue = $@"
Click + below to launch Scraper Tool add movies to your collection.
Load the file containing IMDB IDs of the movie and click on Start button.
The tool will add your movies to the collection automatically.";

            this.ShouldDisplayImdbpage = Visibility.Hidden;
            this.ShouldDisplayHomepage = Visibility.Hidden;
            this.ShouldRatingBarVisible = Visibility.Hidden;
            this.ShouldDisplayPopularity = Visibility.Hidden;
        }

        private void PopulateScrollviewWithMovies()
        {
            IContainer continer = IocContainerSingleton.Instance.Container;
            MovieRetrieveService service = continer.Resolve<MovieRetrieveService>();
            this.simpleMovieListFromServer = service.GetScrollViewInfo();
            this.AppMovieListItemCollection = new ObservableCollection<AppMovieListItemDto>(this.simpleMovieListFromServer);
        }

        private void PopulateSelectedMovieInfo()
        {
            if (this.selectedMovie != null)
            {
                IContainer continer = IocContainerSingleton.Instance.Container;
                MovieRetrieveService service = continer.Resolve<MovieRetrieveService>();
                AppMovieDto selectedMovieInfo = service.GetSelectedMovieInfo(this.selectedMovie.MovieId);

                this.TitleTextValue = selectedMovieInfo.Title;
                this.DirectorImgRawData = selectedMovieInfo.Director.ProfileImage;
                this.DirectorTextValue = selectedMovieInfo.Director.Name;
                this.TaglineTextValue = selectedMovieInfo.Tagline;
                this.ReleaseYearTextValue = selectedMovieInfo.ReleasedDate;

                this.ProgressValue = (selectedMovieInfo.ImdbVote * 10);
                this.RatingTextValue = selectedMovieInfo.ImdbVote.ToString();

                this.PopularityTextValue = selectedMovieInfo.Popularity.ToString();

                this.GenreTextValue = selectedMovieInfo.Genres;
                this.RuntimeTextValue = selectedMovieInfo.Runtime.ToString() + runtimeUnitText;
                this.OverviewTextValue = selectedMovieInfo.Overview;
                this.PosterImgRawData = selectedMovieInfo.PosterImage;
                this.BackdropImgRawData = selectedMovieInfo.BackdropImage;

                this.HomepageTextValue = selectedMovieInfo.Homepage;
                if (this.HomepageTextValue != null)
                {
                    this.ShouldDisplayHomepage = Visibility.Visible;
                }
                else
                {
                    this.ShouldDisplayHomepage = Visibility.Hidden;
                }

                StringBuilder imdbUrlBuilder = new StringBuilder();
                imdbUrlBuilder.Append(imdbBaseUrl);
                imdbUrlBuilder.Append(selectedMovieInfo.ImdbId);
                this.ImdbpageTextValue = imdbUrlBuilder.ToString();
                if (this.ImdbpageTextValue != null)
                {
                    this.ShouldDisplayImdbpage = Visibility.Visible;
                }
                else
                {
                    this.ShouldDisplayImdbpage = Visibility.Hidden;
                }

                this.ShouldRatingBarVisible = Visibility.Visible;
                this.ShouldDisplayPopularity = Visibility.Visible;

                this.AppMovieCastInfoCollection = new ObservableCollection<AppMovieActorDto>(selectedMovieInfo.MovieActors);
            }
        }

        private void DisplayFilteredMoviesForSearch()
        {
            this.SelectedMovie = null;

            this.AppMovieListItemCollection =
                new ObservableCollection<AppMovieListItemDto>(this.simpleMovieListFromServer
                .Where(movieDto => movieDto.MovieTitle.ToUpper().Contains(this.SearchQueryTextValue.ToUpper())));
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
                settingManagementService.AppThemeChanged -= new EventHandler<AppThemeChangedEventArgs>(HandleAppThemeChanged);
                settingManagementService = null;
            }
        }
        #endregion

        #region Finalizer
        ~MainWindowViewModel()
        {
            this.DeregisterFromServiceEvents();
        }
        #endregion
    }
}
