namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie actor information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbCastDto
    {
        public int Cast_id { get; set; }
        public string Character { get; set; }
        public string Credit_id { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Profile_path { get; set; }
    }
}
