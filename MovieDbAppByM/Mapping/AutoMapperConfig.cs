using AutoMapper;
using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using MovieDbAppByM.Service;
using System.Collections.Generic;
using System.Text;

public static class AutoMapperConfig
{
    public static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<TmdbCastDto, Actor>()
                .ForMember(actor => actor.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(actor => actor.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(actor => actor.ProfileImage, opt => opt.MapFrom(dto => GetImage(MovieImageTypes.Actor, dto.ProfilePath)));

            cfg.CreateMap<TmdbMovieInformatonDto, Movie>()
                .ForMember(movie => movie.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(movie => movie.ImdbId, opt => opt.MapFrom(dto => dto.ImdbId))
                .ForMember(movie => movie.ImdbVote, opt => opt.MapFrom(dto => dto.VoteAverage))
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
        });

        IMapper mapper = config.CreateMapper();
        return mapper;
    }

    private static byte[] GetImage(MovieImageTypes imageType, string imageName)
    {
        ImageFetchService imageFetch = new ImageFetchService();
        return imageFetch.FetchFromUrl(imageType, imageName);
    }

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
