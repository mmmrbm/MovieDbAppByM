namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie production company information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbProductionCompanyDto
    {
        public int Id { get; set; }
        public string Logo_path { get; set; }
        public string Name { get; set; }
        public string Origin_country { get; set; }
    }
}
