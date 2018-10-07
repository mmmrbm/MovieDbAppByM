using System.Collections.Generic;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private MovieAppDbContext movieAppDbContext = null;

        public MovieRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movieAppDbContext.Movies;
        }

        public IEnumerable<dynamic> GetMoviesForScrollView()
        {
            IEnumerable<dynamic> result = movieAppDbContext.Movies
                .Select(movie => new { movie.Id, movie.PosterImage })
                .Distinct()
                .ToList();
            return result;
        }

        public bool CheckMovieExist(string imdbId)
        {
            return (movieAppDbContext.Movies.Where(movie => movie.ImdbId == imdbId).FirstOrDefault() != null);
        }

        public Movie GetMovieById(int id)
        {
            return movieAppDbContext.Movies.Where(movie => movie.Id == id).FirstOrDefault();
        }

        public void PersistMovie(Movie movieToBePersisted)
        {
            movieAppDbContext.Movies.Add(movieToBePersisted);
        }
    }
}
