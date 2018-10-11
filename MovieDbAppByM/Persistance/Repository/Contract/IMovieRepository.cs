using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /// <summary>
    /// Contract for repository for <see cref="Model.Movie">
    /// </summary>
    public interface IMovieRepository
    {
        /// <summary>
        /// Responsible to fetch all <see cref="Movie"/> information.
        /// </summary>
        /// <returns>The collection of all <see cref="Movie"/> from database.</returns>
        IEnumerable<Movie> GetMovies();

        /// <summary>
        /// Responsible to fetch a projection of <see cref="Movie"/> information.
        /// </summary>
        /// <returns>The collection of a projection of <see cref="Movie"/> from database.</returns>
        IEnumerable<dynamic> GetMoviesForScrollView();

        /// <summary>
        /// Responsible to fetch a <see cref="Movie"/> information for a provided identifier.
        /// </summary>
        /// <param name="id">The identifier of the <see cref="Movie"/></param>
        /// <returns>The <see cref="Movie"/> information for the identifier.</returns>
        Movie GetMovieById(int id);

        /// <summary>
        /// Reponsible to check if a <see cref="Movie"/> instance is already in database.
        /// </summary>
        /// <param name="id">Identifier for <see cref="Movie"/></param>
        /// <returns>A <see cref="bool"/> to notify if information on <see cref="Movie"/> is alread persisted.</returns>
        bool CheckMovieExist(string id);

        /// <summary>
        /// Reponsible to persis a <see cref="Movie"/>
        /// </summary>
        /// <param name="movieToBePersisted">The <see cref="Movie"/> instance to be persisted.</param>
        void PersistMovie(Movie movieToBePersisted);
    }
}
