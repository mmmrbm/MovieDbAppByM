using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;
using MovieDbAppByM.Persistance.UnitOfWork;

namespace MovieDbAppByM.Service
{
    public class UserFileInfoPersistanceService
    {
        #region Class Variables
        /// <summary>
        /// Reference to hold <see cref="IImdbMovieRepository"/>
        /// </summary>
        private readonly IImdbMovieRepository movieRepository;

        /// <summary>
        /// Reference to hold <see cref="IUnitOfWork"/>
        /// </summary>
        private readonly IUnitOfWork unitOfWork;
        #endregion

        /// <summary>
        /// Constructs <see cref="UserFileInfoPersistanceService"/>
        /// </summary>
        /// <param name="movieRepository"><see cref="IImdbMovieRepository"/> injected by AutoFac.</param>
        /// <param name="unitOfWork"><see cref="IUnitOfWork"/> injected by AutoFac.</param>
        public UserFileInfoPersistanceService(
            IImdbMovieRepository movieRepository,
            IUnitOfWork unitOfWork)
        {
            this.movieRepository = movieRepository;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Responsible for persisting process information for a movie uploaded by user.
        /// </summary>
        /// <param name="imdbId">Imdb ID for movie.</param>
        /// <param name="status">Process status.</param>
        /// <param name="statusText">Description of process.</param>
        public void PersistMovieProcessInfo(
            string imdbId, 
            string status, 
            string statusText)
        {
            if (!movieRepository.CheckMovieExist(imdbId))
            {
                ImdbMovie imdbMovie = new ImdbMovie()
                {
                    ImdbId = imdbId,
                    Status = status,
                    StatusText = statusText,
                };

                this.movieRepository.PersistMovie(imdbMovie);
                this.unitOfWork.Complete();
            }
        }
    }
}
