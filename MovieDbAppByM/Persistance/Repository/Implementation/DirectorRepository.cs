using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    /// <summary>
    /// Implementation of the <see cref="IDirectorRepository"/>
    /// </summary>
    public class DirectorRepository : IDirectorRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="DirectorRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public DirectorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Director GetDirectorById(int id)
        {
            return movieAppDbContext.Directors.Where(director => director.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistDirector(Director directorToBePersisted)
        {
            movieAppDbContext.Directors.Add(directorToBePersisted);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool CheckExistById(int id)
        {
            return (movieAppDbContext.Directors.Where(director => director.Id == id).FirstOrDefault() != null);
        }
    }
}
