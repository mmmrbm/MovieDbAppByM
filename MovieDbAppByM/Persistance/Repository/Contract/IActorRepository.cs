using MovieDbAppByM.Model;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /// <summary>
    /// Contract for repository for <see cref="Model.Actor"/>
    /// </summary>
    public interface IActorRepository
    {
        /// <summary>
        /// Responsible to fetch <see cref="Actor"/> information using a provided identifier.
        /// </summary>
        /// <param name="id">Identifier for <see cref="Actor"/></param>
        /// <returns>The <see cref="Actor"/> object retrieved from database.</returns>
        Actor GetActorById(int id);

        /// <summary>
        /// Reponsible to check if a <see cref="Actor"/> instance is already in database.
        /// </summary>
        /// <param name="id">Identifier for <see cref="Actor"/></param>
        /// <returns>A <see cref="bool"/> to notify if information on <see cref="Actor"/> is alread persisted.</returns>
        bool CheckExistById(int id);

        /// <summary>
        /// Reponsible to persis a <see cref="Actor"/>
        /// </summary>
        /// <param name="actorToBePersisted">The <see cref="Actor"/> instance to be persisted.</param>
        void PersistActor(Actor actorToBePersisted);
    }
}
