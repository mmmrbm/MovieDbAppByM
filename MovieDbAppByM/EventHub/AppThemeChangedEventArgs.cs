using System;

namespace MovieDbAppByM.EventHub
{
    public class AppThemeChangedEventArgs : EventArgs
    {
        public string SelectedTheme { get; set; }
    }
}
