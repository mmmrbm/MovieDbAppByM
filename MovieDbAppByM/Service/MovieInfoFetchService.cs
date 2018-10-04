using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieDbAppByM.Service
{
    public class MovieInfoFetchService
    {
        private HttpClient client = null;

        private const string infoFetchUrl = @"https://api.themoviedb.org/3/movie/{0}?api_key={1}";
        private const string creditFetchUrl = @"http://api.themoviedb.org/3/movie/{0}/credits?api_key={1}";
        private const string apiKey = "37aec05da628be043091f9639c579d7e";

        public MovieInfoFetchService()
        {
            client = new HttpClient();
        }

        public async Task<TmdbMovieInformatonDto> GetMovieAsync()
        {
            TmdbMovieInformatonDto movie = null;
            string currentID = "tt0133093";
            HttpResponseMessage response = await client.GetAsync(string.Format(infoFetchUrl, currentID, apiKey));
            if (response.IsSuccessStatusCode)
            {
                movie = await response.Content.ReadAsAsync<TmdbMovieInformatonDto>();
            }
            return movie;
        }

        public async Task<TmdbMovieCastInfoDto> GetMovieCreditsAsync()
        {
            TmdbMovieCastInfoDto movieCast = null;
            string currentID = "tt0133093";
            HttpResponseMessage response = await client.GetAsync(string.Format(creditFetchUrl, currentID, apiKey));
            if (response.IsSuccessStatusCode)
            {
                movieCast = await response.Content.ReadAsAsync<TmdbMovieCastInfoDto>();
            }
            return movieCast;
        }

        private List<MovieActor> PopulateMovieActors(TmdbMovieCastInfoDto castInfoDto)
        {
            List<MovieActor> movieActors = new List<MovieActor>();

            foreach (var movieCast in castInfoDto.Cast)
            {
                MovieActor movieActor = new MovieActor()
                {
                    MovieId = castInfoDto.Id,
                    ActorId = movieCast.Id,
                    CastOrder = movieCast.Order
                };

                movieActors.Add(movieActor);

                if (movieActors.Capacity > 5)
                {
                    break;
                }
            }

            return movieActors;
        }
    }
}
