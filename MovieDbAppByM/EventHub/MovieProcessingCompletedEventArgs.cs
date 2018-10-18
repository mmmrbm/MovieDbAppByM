using System;

namespace MovieDbAppByM.EventHub
{
    public class MovieProcessingCompletedEventArgs : EventArgs
    {
        public int SuccessfullyProcessedMovieCount { get; set; }

        public int ErrorneouslyProcessedMovieCount { get; set; }
    }
}
