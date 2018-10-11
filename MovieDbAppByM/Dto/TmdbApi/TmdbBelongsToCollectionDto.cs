using Newtonsoft.Json;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie collection information obtained via TMDB API.
    /// </summary>
    public class TmdbBelongsToCollectionDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }
    }
}
