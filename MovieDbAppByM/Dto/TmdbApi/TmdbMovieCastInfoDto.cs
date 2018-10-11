using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie cast information obtained via TMDB API.
    /// </summary>
    public class TmdbMovieCastInfoDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "cast")]
        public List<TmdbCastDto> Cast { get; set; }

        [JsonProperty(PropertyName = "crew")]
        public List<TmdbCrewDto> Crew { get; set; }
    }
}
