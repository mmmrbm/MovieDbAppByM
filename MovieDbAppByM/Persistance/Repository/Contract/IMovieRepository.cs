using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /*
    // Contract for repository for <see cref="Model.Movie">
    */
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetMovies();

        IEnumerable<dynamic> GetMoviesForScrollView();

        Movie GetMovieById(int id);

        void PersistMovie(Movie movieToBePersisted);
    }
}
