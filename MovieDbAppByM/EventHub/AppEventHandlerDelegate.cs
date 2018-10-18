namespace MovieDbAppByM.EventHub
{
    public delegate void MovieSuccessfullyProcessedEventHandler(object sender, MovieSuccessfullyProcessedEventArgs e);
    public delegate void MovieErrorneouslyProcessedEventHandler(object sender, MovieErrorneouslyProcessedEventArgs e);
    public delegate void MovieProcessProgressChangedEventHandler(object sender, MovieProcessProgressChangedEventArgs e);
    public delegate void MovieProcessingCompletedEventHandler(object sender, MovieProcessingCompletedEventArgs e);

    public delegate void AppThemeChangedEventHandler(object sender, AppThemeChangedEventArgs e);
}
