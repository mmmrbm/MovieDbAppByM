namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie production country information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbProductionCountryDto
    {
        public string Iso_3166_1 { get; set; }
        public string Name { get; set; }
    }
}
