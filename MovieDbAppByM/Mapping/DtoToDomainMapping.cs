using AutoMapper;
using MovieDbAppByM.Dto;
using MovieDbAppByM.Model;
using MovieDbAppByM.Service;
using System.Collections.Generic;
using System.Text;

namespace MovieDbAppByM.Mapping
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<TmdbCastDto, Actor>()
                .ForMember(actor => actor.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(actor => actor.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(actor => actor.ProfileImage, opt => opt.MapFrom(dto => this.GetImage(MovieImageTypes.Actor, dto.Name)));

            CreateMap<TmdbMovieInformatonDto, Movie>()
                .ForMember(movie => movie.Id, opt => opt.MapFrom(dto => dto.id))
                .ForMember(movie => movie.ImdbId, opt => opt.MapFrom(dto => dto.imdb_id))
                .ForMember(movie => movie.ImdbVote, opt => opt.MapFrom(dto => dto.Vote_average))
                .ForMember(movie => movie.OriginalTitle, opt => opt.MapFrom(dto => dto.Original_title))
                .ForMember(movie => movie.Title, opt => opt.MapFrom(dto => dto.Title))
                .ForMember(movie => movie.Tagline, opt => opt.MapFrom(dto => dto.Tagline))
                .ForMember(movie => movie.Overview, opt => opt.MapFrom(dto => dto.Overview))
                .ForMember(movie => movie.Homepage, opt => opt.MapFrom(dto => dto.homepage))
                .ForMember(movie => movie.BackdropImage, opt => opt.MapFrom(dto => this.GetImage(MovieImageTypes.Backdrop, dto.Backdrop_path)))
                .ForMember(movie => movie.PosterImage, opt => opt.MapFrom(dto => this.GetImage(MovieImageTypes.Poster, dto.Poster_path)))
                .ForMember(movie => movie.Genres, opt => opt.MapFrom(dto => this.GetGenreAsString(dto.Genres)));
        }

        private byte[] GetImage(MovieImageTypes imageType, string imageName)
        {
            ImageFetchService imageFetch = new ImageFetchService();
            return imageFetch.FetchFromUrl(imageType, imageName);
        }

        private string GetGenreAsString(List<TmdbGenreDto> Genres)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var genre in Genres)
            {
                stringBuilder.Append(genre.Name);
                stringBuilder.Append(", ");
            }

            string genreString = stringBuilder.ToString();
            return genreString.Remove(genreString.Length - 2);
        }
    }
}
