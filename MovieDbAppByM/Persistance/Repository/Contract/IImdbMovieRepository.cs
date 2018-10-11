using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    public interface IImdbMovieRepository
    {
        /// <summary>
        /// Responsible to fetch all <see cref="ImdbMovie"/> information.
        /// </summary>
        /// <returns>The collection of all <see cref="ImdbMovie"/> from database.</returns>
        IEnumerable<ImdbMovie> GetAllImdbMovies();

        /// <summary>
        /// Responsible to fetch <see cref="ImdbMovie"/> information which has not processed due to error.
        /// </summary>
        /// <returns>The <see cref="ImdbMovie"/> information which has not processed due to error from database.</returns>
        IEnumerable<ImdbMovie> GetErrorneousImdbMovies();

        /// <summary>
        /// Reponsible to check if a <see cref="ImdbMovie"/> instance is already in database.
        /// </summary>
        /// <param name="imdbId">Identifier for <see cref="ImdbMovie"/></param>
        /// <returns>A <see cref="bool"/> to notify if information on <see cref="ImdbMovie"/> is alread persisted.</returns>
        bool CheckMovieExist(string imdbId);

        /// <summary>
        /// Reponsible to persis a <see cref="ImdbMovie"/>
        /// </summary>
        /// <param name="movieToBePersisted">The <see cref="ImdbMovie"/> instance to be persisted.</param>
        void PersistMovie(ImdbMovie movieToBePersisted);
    }
}
