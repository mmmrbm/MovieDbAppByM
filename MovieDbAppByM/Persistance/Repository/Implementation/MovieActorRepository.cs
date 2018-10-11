using System.Collections.Generic;
using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    /// <summary>
    /// Implementation of the <see cref="IDirectorRepository"/>
    /// </summary>
    public class MovieActorRepository : IMovieActorRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="MovieActorRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public MovieActorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public IEnumerable<MovieActor> GetMovieActorsByMovieId(int movieId)
        {
            return movieAppDbContext.MovieActors
                .Where(movieActor => movieActor.MovieId == movieId)
                .OrderBy(movieActor=> movieActor.CastOrder);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistMovieActor(MovieActor movieActorToBePersisted)
        {
            movieAppDbContext.MovieActors.Add(movieActorToBePersisted);
        }
    }
}
