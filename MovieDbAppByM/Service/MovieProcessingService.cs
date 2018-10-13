using MovieDbAppByM.EventHub;
using MovieDbAppByM.View.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MovieDbAppByM.Service
{
    public class MovieProcessingService
    {

        private static readonly string successFlagText = "SUCCESS";
        private static readonly string successDescText = "SUCCESS";
        private static readonly string errorFlagText = "ERROR";

        private UserFileInfoPersistanceService userFileInfoPersistanceService;
        private MoviePersistanceService moviePersistanceService;

        public event MovieSuccessfullyProcessedEventHandler MovieSuccessfullyProcessed;
        public event MovieErrorneouslyProcessedEventHandler MovieErrorneouslyProcessed;
        public event MovieProcessProgressChangedEventHandler MovieProcessProgressChanged;
        public event MovieProcessingCompletedEventHandler MovieProcessingCompleted;

        public MovieProcessingService(
            UserFileInfoPersistanceService userFileInfoPersistanceService,
            MoviePersistanceService moviePersistanceService)
        {
            this.userFileInfoPersistanceService = userFileInfoPersistanceService;
            this.moviePersistanceService = moviePersistanceService;

            this.BackgroundWorker = new BackgroundWorker();
            this.BackgroundWorker.WorkerReportsProgress = true;
            this.BackgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
            this.BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            this.BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);
        }

        public BackgroundWorker BackgroundWorker { get; private set; }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int processed = 0;
            ObservableCollection<LoadedMovieItem> LoadedMovieIdCollection =
                (ObservableCollection<LoadedMovieItem>) e.Argument;

            if (LoadedMovieIdCollection == null)
            {
                throw new Exception("Loaded movie list has no entriess");
            }

            foreach (LoadedMovieItem loadedMovieItem in LoadedMovieIdCollection)
            {
                ProcessUserInfo(loadedMovieItem);
                processed += 1;
                this.BackgroundWorker.ReportProgress(processed);
            }
        }

        private void ProcessUserInfo(LoadedMovieItem loadedMovieItem)
        {
            try
            {
                moviePersistanceService.PersistMoive(loadedMovieItem.ImdbId);

                userFileInfoPersistanceService.PersistMovieProcessInfo(
                    loadedMovieItem.ImdbId,
                    successFlagText,
                    successDescText);

                this.MovieSuccessfullyProcessed(loadedMovieItem);
            }
            catch (Exception ex)
            {
                userFileInfoPersistanceService.PersistMovieProcessInfo(
                    loadedMovieItem.ImdbId,
                    errorFlagText,
                    ex.Message);

                this.MovieErrorneouslyProcessed(loadedMovieItem);
            }
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.MovieProcessProgressChanged(e.ProgressPercentage);
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.MovieProcessingCompleted(0, 0);
        }
    }
}
