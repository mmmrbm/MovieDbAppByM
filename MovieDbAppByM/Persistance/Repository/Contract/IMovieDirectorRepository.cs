using MovieDbAppByM.Model;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /// <summary>
    /// Contract for repository for <see cref="Model.MovieDirector">
    /// </summary>
    public interface IMovieDirectorRepository
    {
        /// <summary>
        /// Responsible to fetch <see cref="MovieDirector"/> information for a particular <see cref="Movie" /> identifier.
        /// </summary>
        /// <param name="movieId">Identifier for <see cref="Movie"/></param>
        /// <returns>The of <see cref="MovieDirector"/> associated with <see cref="Movie" /> retrieved from database.</returns>
        MovieDirector GetMovieDirectorByMovieId(int movieId);

        /// <summary>
        /// Reponsible to persis a <see cref="MovieDirector"/>
        /// </summary>
        /// <param name="movieDirectorToBePersisted">The <see cref="MovieDirector"/> instance to be persisted.</param>
        void PersistMovieDirector(MovieDirector movieDirectorToBePersisted);
    }
}
