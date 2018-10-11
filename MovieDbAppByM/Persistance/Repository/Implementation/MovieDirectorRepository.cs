using System;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    /// <summary>
    /// Implementation of the <see cref="IMovieDirectorRepository"/>
    /// </summary>
    public class MovieDirectorRepository : IMovieDirectorRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="MovieActorRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public MovieDirectorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public MovieDirector GetMovieDirectorByMovieId(int movieId)
        {
            return movieAppDbContext.MovieDirectors.Where(movDirector => movDirector.MovieId == movieId).FirstOrDefault();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistMovieDirector(MovieDirector movieDirectorToBePersisted)
        {
            movieAppDbContext.MovieDirectors.Add(movieDirectorToBePersisted);
        }
    }
}
