using System.Collections.Generic;

namespace MovieDbAppByM.Dto
{
    /// <summary>
    /// Dto to represent movie data to be sent to client side.
    /// </summary>
    public class AppMovieDto
    {
        public string ImdbId { get; set; }

        public float ImdbVote { get; set; }

        public string OriginalTitle { get; set; }

        public string Title { get; set; }

        public string Tagline { get; set; }

        public string Overview { get; set; }

        public string Genres { get; set; }

        public byte[] BackdropImage { get; set; }

        public byte[] PosterImage { get; set; }

        public string Homepage { get; set; }

        public List<AppMovieActorDto> MovieActors { get; set; }

        public bool HasWatched { get; set; }

        public string PersonalComments { get; set; }

        public AppMovieDto()
        {
            MovieActors = new List<AppMovieActorDto>();
        }
    }
}
