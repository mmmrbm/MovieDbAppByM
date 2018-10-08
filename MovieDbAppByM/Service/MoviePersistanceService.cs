using Autofac;
using MovieDbAppByM.DependencyInjection;
using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using MovieDbAppByM.Persistance.Repository.Contract;
using MovieDbAppByM.Persistance.UnitOfWork;
using MovieDbAppByM.Utility;
using System.Linq;

namespace MovieDbAppByM.Service
{
    public class MoviePersistanceService
    {
        private readonly IMovieRepository movieRepository;
        private readonly IActorRepository actorRepository;
        private readonly IDirectorRepository directorRepository;
        private readonly IMovieActorRepository movieActorRepository;
        private readonly IMovieDirectorRepository movieDirectorRepository;
        private readonly IUnitOfWork unitOfWork;

        private readonly MovieInfoFetchUtil movieInfoFetchService;
        private readonly AutoMapperConfig mapper;

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
