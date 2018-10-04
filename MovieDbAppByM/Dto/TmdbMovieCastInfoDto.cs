using System.Collections.Generic;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie cast information obtained via TMDB API.
    /// </summary>
    public class TmdbMovieCastInfoDto
    {
        public int Id { get; set; }
        public List<TmdbCastDto> Cast { get; set; }
        public List<TmdbCrewDto> Crew { get; set; }
    }
}
