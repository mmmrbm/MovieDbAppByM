using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /// <summary>
    /// Contract for repository for <see cref="Model.MovieActor">
    /// </summary>
    public interface IMovieActorRepository
    {
        /// <summary>
        /// Responsible to fetch <see cref="MovieActor"/> information for a particular <see cref="Movie" /> identifier.
        /// </summary>
        /// <param name="movieId">Identifier for <see cref="Movie"/></param>
        /// <returns>The collection of <see cref="MovieActor"/> associated with <see cref="Movie" /> retrieved from database.</returns>
        IEnumerable<MovieActor> GetMovieActorsByMovieId(int movieId);

        /// <summary>
        /// Reponsible to persis a <see cref="MovieActor"/>
        /// </summary>
        /// <param name="movieActorToBePersisted">The <see cref="MovieActor"/> instance to be persisted.</param>
        void PersistMovieActor(MovieActor movieActorToBePersisted);
    }
}
