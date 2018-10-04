using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MovieDbAppByM.Service
{
    public class MovieInfoFetchService
    {
        private WebClient webClient = null;

        private const string infoFetchUrl = @"https://api.themoviedb.org/3/movie/{0}?api_key={1}";
        private const string creditFetchUrl = @"http://api.themoviedb.org/3/movie/{0}/credits?api_key={1}";
        private const string apiKey = "37aec05da628be043091f9639c579d7e";

        public MovieInfoFetchService()
        {
            webClient = new WebClient();
        }

        public TmdbMovieInformatonDto GetMovieAsync(string imdbId)
        {
            string apiUrl = string.Format(infoFetchUrl, imdbId, apiKey);
            TmdbMovieInformatonDto movie = JsonConvert.DeserializeObject<TmdbMovieInformatonDto>(webClient.DownloadString(apiUrl));
            return movie;
        }

        public TmdbMovieCastInfoDto GetMovieCreditsAsync(string imdbId)
        {
            string apiUrl = string.Format(creditFetchUrl, imdbId, apiKey);
            TmdbMovieCastInfoDto movieCast = JsonConvert.DeserializeObject<TmdbMovieCastInfoDto>(webClient.DownloadString(apiUrl));
            return movieCast;
        }
    }
}
