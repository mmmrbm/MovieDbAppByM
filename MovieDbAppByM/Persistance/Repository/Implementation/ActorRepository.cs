using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    /// <summary>
    /// Implementation of the <see cref="IActorRepository"/>
    /// </summary>
    public class ActorRepository : IActorRepository
    {
        /// <summary>
        /// Reference to <see cref="MovieAppDbContext" />.
        /// </summary>
        private MovieAppDbContext movieAppDbContext = null;

        /// <summary>
        /// Constructs <see cref="ActorRepository"/>
        /// </summary>
        /// <param name="movieAppDbContext">The <see cref="MovieAppDbContext" /> injected by Autofac.</param>
        public ActorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Actor GetActorById(int id)
        {
            return movieAppDbContext.Actors.Where(actor => actor.Id == id).FirstOrDefault();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public void PersistActor(Actor actorToBePersisted)
        {
            movieAppDbContext.Actors.Add(actorToBePersisted);
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public bool CheckExistById(int id)
        {
            return (movieAppDbContext.Actors.Where(actor => actor.Id == id).FirstOrDefault() != null);
        }
    }
}
