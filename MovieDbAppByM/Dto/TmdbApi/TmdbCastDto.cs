using Newtonsoft.Json;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie actor information obtained via TMDB API.
    /// </summary>
    public class TmdbCastDto
    {
        [JsonProperty(PropertyName = "cast_id")]
        public int CastId { get; set; }

        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "credit_id")]
        public string CreditId { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public int Gender { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }

        [JsonProperty(PropertyName = "profile_path")]
        public string ProfilePath { get; set; }
    }
}
