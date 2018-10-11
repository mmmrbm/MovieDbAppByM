using Newtonsoft.Json;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie genre information obtained via TMDB API.
    /// </summary>
    public class TmdbGenreDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
