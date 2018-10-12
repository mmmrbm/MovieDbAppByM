using AutoMapper;
using MovieDbAppByM.Dto.AppDomain;
using MovieDbAppByM.Dto.TmdbApi;
using MovieDbAppByM.Model;
using MovieDbAppByM.Utility;
using System.Collections.Generic;
using System.Text;

namespace MovieDbAppByM.Mapping
{
    /// <summary>
    /// Represents the mapping information of domain and dto objects.
    /// </summary>
    public class AutoMapperConfig
    {
        /// <summary>
        /// Creates the <see cref="IMapper"/> to be used in application with mapping config.
        /// </summary>
        /// <returns>The <see cref="IMapper"/> with mapping configurations.</returns>
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TmdbCastDto, Actor>()
                    .ForMember(actor => actor.Id, opt => opt.MapFrom(dto => dto.Id))
                    .ForMember(actor => actor.Name, opt => opt.MapFrom(dto => dto.Name))
                    .ForMember(actor => actor.ProfileImage, opt => opt.MapFrom(dto => GetImage(MovieImageTypes.Actor, dto.ProfilePath)));

                cfg.CreateMap<TmdbMovieInformatonDto, Movie>()
                    .ForMember(movie => movie.Id, opt => opt.MapFrom(dto => dto.Id))
                    .ForMember(movie => movie.ImdbId, opt => opt.MapFrom(dto => dto.ImdbId))
                    .ForMember(movie => movie.ImdbVote, opt => opt.MapFrom(dto => dto.VoteAverage))
                    .ForMember(movie => movie.Popularity, opt => opt.MapFrom(dto => dto.Popularity))
                    .ForMember(movie => movie.OriginalTitle, opt => opt.MapFrom(dto => dto.OriginalTitle))
                    .ForMember(movie => movie.Title, opt => opt.MapFrom(dto => dto.Title))
                    .ForMember(movie => movie.Tagline, opt => opt.MapFrom(dto => dto.Tagline))
                    .ForMember(movie => movie.Overview, opt => opt.MapFrom(dto => dto.Overview))
                    .ForMember(movie => movie.Homepage, opt => opt.MapFrom(dto => dto.Homepage))
                    .ForMember(movie => movie.ReleaseDate, opt => opt.MapFrom(dto => dto.ReleaseDate))
                    .ForMember(movie => movie.Runtime, opt => opt.MapFrom(dto => dto.Runtime))
                    .ForMember(movie => movie.BackdropImage, opt => opt.MapFrom(dto => GetImage(MovieImageTypes.Backdrop, dto.BackdropPath)))
                    .ForMember(movie => movie.PosterImage, opt => opt.MapFrom(dto => GetImage(MovieImageTypes.Poster, dto.PosterPath)))
                    .ForMember(movie => movie.Genres, opt => opt.MapFrom(dto => GetGenreAsString(dto.Genres)));

                cfg.CreateMap<TmdbCrewDto, Director>()
                    .ForMember(director => director.Id, opt => opt.MapFrom(dto => dto.Id))
                    .ForMember(director => director.Name, opt => opt.MapFrom(dto => dto.Name))
                    .ForMember(director => director.ProfileImage, opt => opt.MapFrom(dto => GetImage(MovieImageTypes.Director, dto.ProfilePath)));

                cfg.CreateMap<Movie, AppMovieDto>()
                    .ForMember(appMovieDto => appMovieDto.ImdbId, opt => opt.MapFrom(movie => movie.ImdbId))
                    .ForMember(appMovieDto => appMovieDto.ImdbVote, opt => opt.MapFrom(movie => movie.ImdbVote))
                    .ForMember(appMovieDto => appMovieDto.Popularity, opt => opt.MapFrom(movie => movie.Popularity))
                    .ForMember(appMovieDto => appMovieDto.OriginalTitle, opt => opt.MapFrom(movie => movie.OriginalTitle))
                    .ForMember(appMovieDto => appMovieDto.Title, opt => opt.MapFrom(movie => movie.Title))
                    .ForMember(appMovieDto => appMovieDto.Tagline, opt => opt.MapFrom(movie => movie.Tagline))
                    .ForMember(appMovieDto => appMovieDto.ReleasedDate, opt => opt.MapFrom(movie => movie.ReleaseDate))
                    .ForMember(appMovieDto => appMovieDto.Overview, opt => opt.MapFrom(movie => movie.Overview))
                    .ForMember(appMovieDto => appMovieDto.Genres, opt => opt.MapFrom(movie => movie.Genres))
                    .ForMember(appMovieDto => appMovieDto.Runtime, opt => opt.MapFrom(movie => movie.Runtime))
                    .ForMember(appMovieDto => appMovieDto.BackdropImage, opt => opt.MapFrom(movie => movie.BackdropImage))
                    .ForMember(appMovieDto => appMovieDto.PosterImage, opt => opt.MapFrom(movie => movie.PosterImage))
                    .ForMember(appMovieDto => appMovieDto.Homepage, opt => opt.MapFrom(movie => movie.Homepage))
                    .ForMember(appMovieDto => appMovieDto.HasWatched, opt => opt.MapFrom(movie => movie.HasWatched))
                    .ForMember(appMovieDto => appMovieDto.PersonalComments, opt => opt.MapFrom(movie => movie.PersonalComments))
                    .ForMember(appMovieDto => appMovieDto.MovieActors, opt => opt.MapFrom(movie => movie.Actors))
                    .ForMember(appMovieDto => appMovieDto.MovieDirectors, opt => opt.MapFrom(movie => movie.Directors));

                cfg.CreateMap<Director, AppMovieDirectorDto>()
                    .ForMember(appMovieDirectorDto => appMovieDirectorDto.Name, opt => opt.MapFrom(director => director.Name))
                    .ForMember(appMovieDirectorDto => appMovieDirectorDto.ProfileImage, opt => opt.MapFrom(director => director.ProfileImage));

                cfg.CreateMap<Actor, AppMovieActorDto>()
                    .ForMember(appMovieActorDto => appMovieActorDto.Name, opt => opt.MapFrom(actor => actor.Name))
                    .ForMember(appMovieActorDto => appMovieActorDto.ProfileImage, opt => opt.MapFrom(actor => actor.ProfileImage));

            });

            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        /// <summary>
        /// A helper refirect a call to fetch image from end point.
        /// </summary>
        /// <param name="imageType">Type of the image represented by <see cref="MovieImageTypes"/></param>
        /// <param name="imageName">The name of the image in the service.</param>
        /// <returns></returns>
        private static byte[] GetImage(MovieImageTypes imageType, string imageName)
        {
            ImageFetchUtil imageFetch = new ImageFetchUtil();
            return imageFetch.FetchFromUrl(imageType, imageName);
        }

        /// <summary>
        /// A helper to convert the <see cref="List{TmdbGenreDto}"/> from api as a single string.
        /// </summary>
        /// <param name="Genres">The <see cref="List{TmdbGenreDto}"/> from api.</param>
        /// <returns>The string generated by appending genres.</returns>
        private static string GetGenreAsString(List<TmdbGenreDto> Genres)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var genre in Genres)
            {
                stringBuilder.Append(genre.Name);
                stringBuilder.Append(" ");
            }

            return stringBuilder.ToString();
        }
    }
}