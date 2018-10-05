using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /*
    // Contract for repository for <see cref="Model.MovieActor">
    */
    public interface IMovieActorRepository
    {
        IEnumerable<MovieActor> GetMovieActorsByMovieId(int movieId);

        void PersistMovieActor(MovieActor movieActorToBePersisted);
    }
}
