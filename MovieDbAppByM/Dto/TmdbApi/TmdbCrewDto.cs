using Newtonsoft.Json;

namespace MovieDbAppByM.Dto.TmdbApi
{
    /// <summary>
    /// Dto to represent movie crew information obtained via TMDB API.
    /// </summary>
    public class TmdbCrewDto
    {
        [JsonProperty(PropertyName = "credit_id")]
        public string CreditId { get; set; }

        [JsonProperty(PropertyName = "department")]
        public string Department { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public int Gender { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "profile_path")]
        public string ProfilePath { get; set; }
    }
}
