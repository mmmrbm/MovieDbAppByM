using MovieDbAppByM.Model;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /*
    // Contract for repository for <see cref="Model.MovieDirector">
    */
    public interface IMovieDirectorRepository
    {
        MovieDirector GetMovieDirectorByMovieId(int movieId);

        void PersistMovieDirector(MovieDirector movieDirectorToBePersisted);
    }
}
