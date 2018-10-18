using System;

namespace MovieDbAppByM.EventHub
{
    public class MovieProcessProgressChangedEventArgs : EventArgs
    {
        public int Progress { get; set; }
    }
}
