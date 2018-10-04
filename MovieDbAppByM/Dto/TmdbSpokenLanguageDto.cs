using Newtonsoft.Json;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie language information obtained via TMDB API.
    /// </summary>
    public class TmdbSpokenLanguageDto
    {
        [JsonProperty(PropertyName = "Iso_639_1")]
        public string LanguageCode { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
