namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie language information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbSpokenLanguageDto
    {
        public string Iso_639_1 { get; set; }
        public string Name { get; set; }
    }
}
