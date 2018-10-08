using MovieDbAppByM.Model;
using System.Collections.Generic;

namespace MovieDbAppByM.Persistance.Repository.Contract
{
    /*
    // Contract for repository for <see cref="Model.Director">
    */
    public interface IDirectorRepository
    {
        Director GetDirectorById(int id);

        void PersistDirector(Director directorToBePersisted);

        bool CheckExistById(int id);
    }
}
