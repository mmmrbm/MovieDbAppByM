using Newtonsoft.Json;
using System.Collections.Generic;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbMovieInformatonDto
    {
        [JsonProperty(PropertyName = "adult")]
        public bool Adult { get; set; }

        [JsonProperty(PropertyName = "backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty(PropertyName = "belongs_to_collection")]
        public TmdbBelongsToCollectionDto BelongsToCollection { get; set; }

        [JsonProperty(PropertyName = "budget")]
        public int Budget { get; set; }

        [JsonProperty(PropertyName = "genres")]
        public List<TmdbGenreDto> Genres { get; set; }

        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty(PropertyName = "original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty(PropertyName = "original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "popularity")]
        public double Popularity { get; set; }

        [JsonProperty(PropertyName = "poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty(PropertyName = "production_companies")]
        public List<TmdbProductionCompanyDto> ProductionCompanies { get; set; }

        [JsonProperty(PropertyName = "production_countries")]
        public List<TmdbProductionCountryDto> ProductionCountries { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "revenue")]
        public int Revenue { get; set; }

        [JsonProperty(PropertyName = "runtime")]
        public int Runtime { get; set; }

        [JsonProperty(PropertyName = "spoken_languages")]
        public List<TmdbSpokenLanguageDto> SpokenLanguages { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "video")]
        public bool Video { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public float VoteAverage { get; set; }

        [JsonProperty(PropertyName = "vote_count")]
        public int VoteCount { get; set; }
    }
}
