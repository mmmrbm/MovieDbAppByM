using System.Collections.Generic;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class ImdbMovieRepository : IImdbMovieRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="ImdbMovieRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public ImdbMovieRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool CheckMovieExist(string imdbId)
        {
            return (this.movieAppDbContext.ImdbMovies.Where(iMovie => iMovie.ImdbId == imdbId) != null);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<ImdbMovie> GetAllImdbMovies()
        {
            return this.movieAppDbContext.ImdbMovies;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<ImdbMovie> GetErrorneousImdbMovies()
        {
            return this.movieAppDbContext.ImdbMovies.Where(iMovie => iMovie.Status == "ERROR"); ;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistMovie(ImdbMovie movieToBePersisted)
        {
            this.movieAppDbContext.ImdbMovies.Add(movieToBePersisted);
        }
    }
}
