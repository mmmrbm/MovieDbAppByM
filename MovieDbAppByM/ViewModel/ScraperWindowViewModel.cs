﻿using Autofac;
using Microsoft.Win32;
using MovieDbAppByM.Core;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.EventHub;
using MovieDbAppByM.Service;
using MovieDbAppByM.View.Contract;
using MovieDbAppByM.View.Helpers;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace MovieDbAppByM.ViewModel
{
    public class ScraperWindowViewModel : BindableBase
    {
        #region Constants
        private static readonly char spaceCharacter = ' ';
        private static readonly SolidColorBrush successBackground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF008000"));
        private static readonly SolidColorBrush failedBackground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFB22222"));
        #endregion

        #region Class variabloes
        private int progressBarMaxValue;
        private int currentProgressValue;

        private string selectedFilePath;
        private ObservableCollection<LoadedMovieItem> loadedMovieIdCollection;

        private SolidColorBrush borderLineColor;
        private SolidColorBrush titleTextFillColor;
        private SolidColorBrush inputSectionFillColor;
        private SolidColorBrush backgroundFillColor;
        private SolidColorBrush folderPathTextForegroundColor;
        private SolidColorBrush folderPathTextBackgroundColor;
        private SolidColorBrush progressBarBackgroundColor;
        private SolidColorBrush processInfoLabelFillColor;
        private SolidColorBrush processResultBackgroundColor;
        
        private Visibility shouldProgressVisible;
        private IContainer iocContainer;
        private MovieProcessingService movieProcessingService;
        #endregion


        public ScraperWindowViewModel()
        {
            this.iocContainer = IocContainerSingleton.Instance.Container;

            movieProcessingService = this.iocContainer.Resolve<MovieProcessingService>();
            movieProcessingService.MovieSuccessfullyProcessed += new EventHandler<MovieSuccessfullyProcessedEventArgs>(HandleMovieSuccessfullyProcessed);
            movieProcessingService.MovieErrorneouslyProcessed += new EventHandler<MovieErrorneouslyProcessedEventArgs>(this.HandleMovieErrorneouslyProcessed);
            movieProcessingService.MovieProcessProgressChanged += new EventHandler<MovieProcessProgressChangedEventArgs>(this.HandleMovieProcessProgressChanged);
            movieProcessingService.MovieProcessingCompleted += new EventHandler<MovieProcessingCompletedEventArgs>(this.HandleMovieProcessingCompleted);

            this.WindowLoadedCommand = new RelayCommand(this.WindowLoadedCommandHandler);
            this.CloseCommand = new RelayCommand<IClosable>(this.CloseCommandHandler);
            this.MinimizeCommand = new RelayCommand<IMinimizable>(this.MinimizeCommandHandler);
            this.BrowseCommand = new RelayCommand(this.BrowseCommandHandler);
            this.StartCommand = new RelayCommand(this.StartCommandHandler);
        }
        
        #region Properties
        public int CurrentProgressValue
        {
            get { return this.currentProgressValue; }
            set { this.SetProperty(ref this.currentProgressValue, value); }
        }

        public int ProgressBarMaxValue
        {
            get { return this.progressBarMaxValue; }
            set { this.SetProperty(ref this.progressBarMaxValue, value); }
        }

        public string SelectedFilePath
        {
            get { return this.selectedFilePath; }
            set { this.SetProperty(ref this.selectedFilePath, value); }
        }

        public ObservableCollection<LoadedMovieItem> LoadedMovieIdCollection
        {
            get { return this.loadedMovieIdCollection; }
            set { this.SetProperty(ref this.loadedMovieIdCollection, value); }
        }

        public SolidColorBrush BorderLineColor
        {
            get { return this.borderLineColor; }
            set { this.SetProperty(ref this.borderLineColor, value); }
        }

        public SolidColorBrush InputSectionFillColor
        {
            get { return this.inputSectionFillColor; }
            set { this.SetProperty(ref this.inputSectionFillColor, value); }
        }
        
        public SolidColorBrush TitleTextFillColor
        {
            get { return this.titleTextFillColor; }
            set { this.SetProperty(ref this.titleTextFillColor, value); }
        }

        public SolidColorBrush BackgroundFillColor
        {
            get { return this.backgroundFillColor; }
            set { this.SetProperty(ref this.backgroundFillColor, value); }
        }

        public SolidColorBrush FolderPathTextForegroundColor
        {
            get { return this.folderPathTextForegroundColor; }
            set { this.SetProperty(ref this.folderPathTextForegroundColor, value); }
        }

        public SolidColorBrush FolderPathTextBackgroundColor
        {
            get { return this.folderPathTextBackgroundColor; }
            set { this.SetProperty(ref this.folderPathTextBackgroundColor, value); }
        }
        
        public SolidColorBrush ProgressBarBackgroundColor
        {
            get { return this.progressBarBackgroundColor; }
            set { this.SetProperty(ref this.progressBarBackgroundColor, value); }
        }

        public SolidColorBrush ProcessInfoLabelFillColor
        {
            get { return this.processInfoLabelFillColor; }
            set { this.SetProperty(ref this.processInfoLabelFillColor, value); }
        }

        public SolidColorBrush ProcessResultBackgroundColor
        {
            get { return this.processResultBackgroundColor; }
            set { this.SetProperty(ref this.processResultBackgroundColor, value); }
        }

        public Visibility ShouldProgressVisible
        {
            get { return this.shouldProgressVisible; }
            set { this.SetProperty(ref this.shouldProgressVisible, value); }
        }
        #endregion

        #region Commands
        public ICommand WindowLoadedCommand { get; private set; }

        public ICommand CloseCommand { get; private set; }

        public ICommand MinimizeCommand { get; private set; }

        public ICommand BrowseCommand { get; private set; }

        public ICommand StartCommand { get; set; }
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
                DeregisterFromServiceEvents();
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

        private void BrowseCommandHandler()
        {
            OpenFileDialog openExcelDataFileDialog = new OpenFileDialog();
			openExcelDataFileDialog.Filter = "CSV Files|*.csv";
			openExcelDataFileDialog.InitialDirectory = @"F:\";

			if (openExcelDataFileDialog.ShowDialog().Value)
			{
                this.SelectedFilePath = openExcelDataFileDialog.FileName;
			}
        }

        private void StartCommandHandler()
        {
            string[] movieIdLinesToPersist = File.ReadAllLines(SelectedFilePath);
            this.LoadedMovieIdCollection = new ObservableCollection<LoadedMovieItem>();
            this.CurrentProgressValue = 0;

            foreach (string fileLineWithMovieIds in movieIdLinesToPersist)
            {
                string[] movieIds = fileLineWithMovieIds.Split(',');
                foreach (string movieId in movieIds)
                {
                    this.LoadedMovieIdCollection.Add(new LoadedMovieItem(movieId.Trim(spaceCharacter)));
                }
            }

            this.ProgressBarMaxValue = this.LoadedMovieIdCollection.Count;
            this.ShouldProgressVisible = Visibility.Visible;

            Mouse.OverrideCursor = Cursors.Wait;
            movieProcessingService.BackgroundWorker.RunWorkerAsync(this.LoadedMovieIdCollection);
        }
        #endregion

        #region Implementation Method
        private void SetupApplicationTheme()
        {
            ThemeColorHolder themeColors = this.iocContainer.Resolve<SettingManagementService>().GetThemeAscent();
            SetMainWindowElements(themeColors.ForegroundColor, themeColors.BackgroundColor);
        }

        private void SetMainWindowElements(string lightColor, string deepColor)
        {
            SolidColorBrush foregroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(lightColor));
            SolidColorBrush backgroundColor = (SolidColorBrush)(new BrushConverter().ConvertFrom(deepColor));

            this.FolderPathTextBackgroundColor = foregroundColor;
            this.ProgressBarBackgroundColor = foregroundColor;
            this.ProcessResultBackgroundColor = foregroundColor;
            this.BorderLineColor = foregroundColor;

            this.BackgroundFillColor = backgroundColor;
            this.InputSectionFillColor = backgroundColor;
            this.TitleTextFillColor = backgroundColor;
            this.ProcessInfoLabelFillColor = backgroundColor;
            this.FolderPathTextForegroundColor = backgroundColor;

            this.ShouldProgressVisible = Visibility.Hidden;
        }
        #endregion

        #region Event Handling
        private void HandleMovieSuccessfullyProcessed(object sender, MovieSuccessfullyProcessedEventArgs e)
        {
            LoadedMovieItem foundMovie = this.LoadedMovieIdCollection[this.LoadedMovieIdCollection.IndexOf(e.ProcessedMovie)];
            foundMovie.Background = successBackground;
        }

        private void HandleMovieErrorneouslyProcessed(object sender, MovieErrorneouslyProcessedEventArgs e)
        {
            LoadedMovieItem foundMovie = this.LoadedMovieIdCollection[this.LoadedMovieIdCollection.IndexOf(e.ProcessedMovie)];
            foundMovie.Background = failedBackground;
        }

        private void HandleMovieProcessProgressChanged(object sender, MovieProcessProgressChangedEventArgs e)
        {
            this.CurrentProgressValue = e.Progress;
        }

        private void HandleMovieProcessingCompleted(object sender, MovieProcessingCompletedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void DeregisterFromServiceEvents()
        {
            if (movieProcessingService != null)
            {
                movieProcessingService.MovieSuccessfullyProcessed -= new EventHandler<MovieSuccessfullyProcessedEventArgs>(HandleMovieSuccessfullyProcessed);
                movieProcessingService.MovieErrorneouslyProcessed -= new EventHandler<MovieErrorneouslyProcessedEventArgs>(this.HandleMovieErrorneouslyProcessed);
                movieProcessingService.MovieProcessProgressChanged -= new EventHandler<MovieProcessProgressChangedEventArgs>(this.HandleMovieProcessProgressChanged);
                movieProcessingService.MovieProcessingCompleted -= new EventHandler<MovieProcessingCompletedEventArgs>(this.HandleMovieProcessingCompleted);
                movieProcessingService = null;
            }
        }
        #endregion

        #region Finalizer
        ~ScraperWindowViewModel()
        {
            DeregisterFromServiceEvents();
        }
        #endregion
    }
}
