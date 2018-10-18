using MovieDbAppByM.View.Helpers;
using System;

namespace MovieDbAppByM.EventHub
{
    public class MovieSuccessfullyProcessedEventArgs : EventArgs
    {
        public LoadedMovieItem ProcessedMovie { get; set; }
    }
}
