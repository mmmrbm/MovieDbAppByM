using System.Linq;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;

namespace MovieDbAppByM.Persistance.Repository.Implementation
{
    public class ActorRepository : IActorRepository
    {
        private MovieAppDbContext movieAppDbContext = null;

        public ActorRepository(MovieAppDbContext movieAppDbContext)
        {
            this.movieAppDbContext = movieAppDbContext;
        }


        public Actor GetActorById(int id)
        {
            return movieAppDbContext.Actors.Where(actor => actor.Id == id).FirstOrDefault();
        }

        public void PersistActor(Actor actorToBePersisted)
        {
            movieAppDbContext.Actors.Add(actorToBePersisted);
        }

        public bool CheckExistById(int id)
        {
            return (movieAppDbContext.Actors.Where(actor => actor.Id == id).FirstOrDefault() != null);
        }
    }
}
