namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie collection information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbBelongsToCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Poster_path { get; set; }
        public string Backdrop_path { get; set; }
    }
}
