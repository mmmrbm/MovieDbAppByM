namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie genre information obtained via TMDB API.
    /// </summary>
    public class TmdbGenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
