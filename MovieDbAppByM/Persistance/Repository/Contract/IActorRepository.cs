using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /*
    // Contract for repository for <see cref="Model.Actor">
    */
    public interface IActorRepository
    {
        Actor GetActorById(int id);

        void PersistActor(Actor actorToBePersisted);
    }
}
