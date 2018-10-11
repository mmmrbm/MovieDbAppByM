using Autofac;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.Dto.TmdbApi;
using MovieDbAppByM.Mapping;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;
using MovieDbAppByM.Persistance.UnitOfWork;
using MovieDbAppByM.Utility;
using System.Linq;

namespace MovieDbAppByM.Service
{
    public class MoviePersistanceService
    {
        #region Class Variables
        /// <summary>
        /// Reference to hold <see cref="IMovieRepository"/>
        /// </summary>
        private readonly IMovieRepository movieRepository;

        /// <summary>
        /// Reference to hold <see cref="IActorRepository"/>
        /// </summary>
        private readonly IActorRepository actorRepository;

        /// <summary>
        /// Reference to hold <see cref="IDirectorRepository"/>
        /// </summary>
        private readonly IDirectorRepository directorRepository;

        /// <summary>
        /// Reference to hold <see cref="IMovieActorRepository"/>
        /// </summary>
        private readonly IMovieActorRepository movieActorRepository;

        /// <summary>
        /// Reference to hold <see cref="IMovieDirectorRepository"/>
        /// </summary>
        private readonly IMovieDirectorRepository movieDirectorRepository;

        /// <summary>
        /// Reference to hold <see cref="IUnitOfWork"/>
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Reference to hold <see cref="MovieInfoFetchUtil"/>
        /// </summary>
        private readonly MovieInfoFetchUtil movieInfoFetchService;

        /// <summary>
        /// Reference to hold <see cref="AutoMapperConfig"/>
        /// </summary>
        private readonly AutoMapperConfig mapper;
        #endregion

        /// <summary>
        /// Constructs <see cref="MoviePersistanceService"/>
        /// </summary>
        /// <param name="movieRepository"><see cref="IMovieRepository"/> injected via Autofac.</param>
        /// <param name="actorRepository"><see cref="IActorRepository"/> injected via Autofac.</param>
        /// <param name="directorRepository"><see cref="IDirectorRepository"/> injected via Autofac.</param>
        /// <param name="movieActorRepository"><see cref="IMovieActorRepository"/> injected via Autofac.</param>
        /// <param name="movieDirectorRepository"><see cref="IMovieDirectorRepository"/> injected via Autofac.</param>
        /// <param name="unitOfWork"><see cref="IUnitOfWork"/> injected via Autofac.</param>
        /// <param name="movieInfoFetchService"><see cref="MovieInfoFetchUtil"/> injected via Autofac.</param>
        /// <param name="mapper"><see cref="AutoMapperConfig"/> injected via Autofac.</param>
        public MoviePersistanceService(
            IMovieRepository movieRepository,
            IActorRepository actorRepository,
            IDirectorRepository directorRepository,
            IMovieActorRepository movieActorRepository,
            IMovieDirectorRepository movieDirectorRepository,
            IUnitOfWork unitOfWork,
            MovieInfoFetchUtil movieInfoFetchService,
            AutoMapperConfig mapper)
        {
            this.movieRepository = movieRepository;
            this.actorRepository = actorRepository;
            this.directorRepository = directorRepository;
            this.movieActorRepository = movieActorRepository;
            this.movieDirectorRepository = movieDirectorRepository;
            this.unitOfWork = unitOfWork;
            this.movieInfoFetchService = movieInfoFetchService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Responsible for persisting movie information after fetching information from TMDB endpoint.
        /// </summary>
        /// <param name="movieId">The Imdb movie id for the movie needs to be persisted.</param>
        public void PersistMoive(string movieId)
        {
            IContainer continer = IocContainerSingleton.Instance.Container;

            IMovieRepository movieRepository = continer.Resolve<IMovieRepository>();

            if (movieRepository.CheckMovieExist(movieId))
            {
                return;
            }

            IActorRepository actorRepository = continer.Resolve<IActorRepository>();
            IDirectorRepository directorRepository = continer.Resolve<IDirectorRepository>();
            IMovieActorRepository movieActorRepository = continer.Resolve<IMovieActorRepository>();
            IMovieDirectorRepository movieDirectorRepository = continer.Resolve<IMovieDirectorRepository>();
            IUnitOfWork unitOfWork = continer.Resolve<IUnitOfWork>();

            TmdbMovieInformatonDto movieFromApi = movieInfoFetchService.GetMovieAsync(movieId);
            TmdbMovieCastInfoDto movieCastFromApi = movieInfoFetchService.GetMovieCreditsAsync(movieId);

            Movie movie = mapper.GetMapper().Map<Movie>(movieFromApi);
            movieRepository.PersistMovie(movie);

            foreach (var castedActor in movieCastFromApi.Cast.Take(6))
            {
                if (!actorRepository.CheckExistById(castedActor.Id))
                {
                    Actor actor = mapper.GetMapper().Map<Actor>(castedActor);
                    actorRepository.PersistActor(actor);
                }
                
                MovieActor movieActor = new MovieActor()
                {
                    MovieId = movieCastFromApi.Id,
                    ActorId = castedActor.Id,
                    CastOrder = castedActor.Order
                };
                movieActorRepository.PersistMovieActor(movieActor);
            }

            TmdbCrewDto directorDtoFromApi = movieCastFromApi.Crew
                .Where(crew => crew.Job == "Director")
                .FirstOrDefault();

            if (!directorRepository.CheckExistById(directorDtoFromApi.Id))
            {
                Director director = mapper.GetMapper().Map<Director>(directorDtoFromApi);
                directorRepository.PersistDirector(director);
            }
            
            MovieDirector movieDirector = new MovieDirector()
            {
                MovieId = movieCastFromApi.Id,
                DirectorId = directorDtoFromApi.Id
            };
            movieDirectorRepository.PersistMovieDirector(movieDirector);

            unitOfWork.Complete();
        }
    }
}
