using System.Collections.Generic;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie information obtained via TMDB API.
    /// Variable names deviates from .NET standards due to JSON conversion.
    /// </summary>
    public class TmdbMovieInformatonDto
    {
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public TmdbBelongsToCollectionDto Belongs_to_collection { get; set; }
        public int Budget { get; set; }
        public List<TmdbGenreDto> Genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public List<TmdbProductionCompanyDto> Production_companies { get; set; }
        public List<TmdbProductionCountryDto> Production_countries { get; set; }
        public string Release_date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<TmdbSpokenLanguageDto> Spoken_languages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public int Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
