using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /// <summary>
    /// Contract for repository for <see cref="Model.Director"/>
    /// </summary>
    public interface IDirectorRepository
    {
        /// <summary>
        /// Responsible to fetch <see cref="Director"/> information using a provided identifier.
        /// </summary>
        /// <param name="id">Identifier for <see cref="Director"/></param>
        /// <returns>The <see cref="Director"/> object retrieved from database.</returns>
        Director GetDirectorById(int id);

        /// <summary>
        /// Reponsible to check if a <see cref="Director"/> instance is already in database.
        /// </summary>
        /// <param name="id">Identifier for <see cref="Director"/></param>
        /// <returns>A <see cref="bool"/> to notify if information on <see cref="Director"/> is alread persisted.</returns>
        bool CheckExistById(int id);

        /// <summary>
        /// Reponsible to persis a <see cref="Actor"/>
        /// </summary>
        /// <param name="actorToBePersisted">The <see cref="Actor"/> instance to be persisted.</param>
        void PersistDirector(Director directorToBePersisted);
    }
}
