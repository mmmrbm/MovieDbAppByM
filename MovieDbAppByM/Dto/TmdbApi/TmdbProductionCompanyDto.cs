using Newtonsoft.Json;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie production company information obtained via TMDB API.
    /// </summary>
    public class TmdbProductionCompanyDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "logo_path")]
        public string LogoPath { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "origin_country")]
        public string OriginCountry { get; set; }
    }
}
