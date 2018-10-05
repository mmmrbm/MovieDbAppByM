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

        public Movie GetMovieById(int id)
        {
            return movieAppDbContext.Movies.Where(movie => movie.Id == id).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return movieAppDbContext.Movies;
        }

        public void PersistMovie(Movie movieToBePersisted)
        {
            movieAppDbContext.Movies.Add(movieToBePersisted);
        }
    }
}
