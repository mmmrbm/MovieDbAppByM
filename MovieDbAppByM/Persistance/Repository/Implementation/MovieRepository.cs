using System.Collections.Generic;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    /// <summary>
    /// Implementation of the <see cref="IMovieRepository"/>
    /// </summary>
    public class MovieRepository : IMovieRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="MovieRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public MovieRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<Movie> GetMovies()
        {
            return movieAppDbContext.Movies;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<dynamic> GetMoviesForScrollView()
        {
            IEnumerable<dynamic> result = movieAppDbContext.Movies
                .Select(movie => new { movie.Id, movie.PosterImage })
                .Distinct()
                .ToList();
            return result;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool CheckMovieExist(string imdbId)
        {
            return (movieAppDbContext.Movies.Where(movie => movie.ImdbId == imdbId).FirstOrDefault() != null);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Movie GetMovieById(int id)
        {
            return movieAppDbContext.Movies.Where(movie => movie.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistMovie(Movie movieToBePersisted)
        {
            movieAppDbContext.Movies.Add(movieToBePersisted);
        }
    }
}
