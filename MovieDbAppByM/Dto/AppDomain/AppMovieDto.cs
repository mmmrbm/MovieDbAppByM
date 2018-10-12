using System.Collections.Generic;

namespace MovieDbAppByM.Dto.AppDomain
{
    /// <summary>
    /// Dto to represent movie data to be sent to client side holding complete information.
    /// </summary>
    public class AppMovieDto
    {

        public AppMovieDto()
        {
            MovieActors = new List<AppMovieActorDto>();
            MovieDirectors = new List<AppMovieDirectorDto>();
        }

        public string ImdbId { get; set; }

        public float ImdbVote { get; set; }

        public int Popularity { get; set; }

        public string OriginalTitle { get; set; }

        public string Title { get; set; }

        public string Tagline { get; set; }

        public string ReleasedDate { get; set; }

        public string Overview { get; set; }

        public string Genres { get; set; }

        public int Runtime { get; set; }

        public byte[] BackdropImage { get; set; }

        public byte[] PosterImage { get; set; }

        public string Homepage { get; set; }

        public AppMovieDirectorDto Director { get; set; }

        public List<AppMovieActorDto> MovieActors { get; set; }

        public List<AppMovieDirectorDto> MovieDirectors { get; set; }

        public bool HasWatched { get; set; }

        public string PersonalComments { get; set; }
    }
}
