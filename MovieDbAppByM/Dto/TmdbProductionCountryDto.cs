using Newtonsoft.Json;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie production country information obtained via TMDB API.
    /// </summary>
    public class TmdbProductionCountryDto
    {
        [JsonProperty(PropertyName = "iso_3166_1")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
