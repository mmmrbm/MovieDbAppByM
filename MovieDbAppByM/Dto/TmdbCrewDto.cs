namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie crew information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbCrewDto
    {
        public string Credit_id { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
        public int Id { get; set; }
        public string Job { get; set; }
        public string Name { get; set; }
        public string Profile_path { get; set; }
    }
}
