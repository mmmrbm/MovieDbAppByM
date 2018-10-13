using MovieDbAppByM.View.Helpers;

namespace MovieDbAppByM.EventHub
{
    public delegate void MovieSuccessfullyProcessedEventHandler(LoadedMovieItem processedMovie);
    public delegate void MovieErrorneouslyProcessedEventHandler(LoadedMovieItem processedMovie);
    public delegate void MovieProcessProgressChangedEventHandler(int progress);
    public delegate void MovieProcessingCompletedEventHandler(int successfullyProcessedMovieCount, int errorneouslyProcessedMovieCount);
}
