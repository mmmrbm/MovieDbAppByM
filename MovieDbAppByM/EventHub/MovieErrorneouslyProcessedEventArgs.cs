using MovieDbAppByM.View.Helpers;
using System;

namespace MovieDbAppByM.EventHub
{
    public class MovieErrorneouslyProcessedEventArgs : EventArgs
    {
        public LoadedMovieItem ProcessedMovie { get; set; }
    }
}
