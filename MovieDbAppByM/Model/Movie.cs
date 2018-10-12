using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents movie information.
    /// </summary>
    [Table("Movie")]
    public class Movie
    {
        /// <summary>
        /// Constructs <see cref="Movie"/>
        /// </summary>
        public Movie()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
        }

        /// <summary>
        /// Identifier for the Movie.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Imdb ID of the Movie.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ImdbId { get; set; }

        /// <summary>
        /// Imdb votes for the Movie.
        /// </summary>
        [Required]
        public float ImdbVote { get; set; }

        /// <summary>
        /// Popularity for the Movie.
        /// </summary>
        [Required]
        public int Popularity { get; set; }

        /// <summary>
        /// Original Title of the Movie.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string OriginalTitle { get; set; }

        /// <summary>
        /// Title of the Movie.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        /// <summary>
        /// Tagline of the Movie.
        /// </summary>
        [MaxLength(1000)]
        public string Tagline { get; set; }

        /// <summary>
        /// Overview of the Movie.
        /// </summary>
        [MaxLength(4000)]
        public string Overview { get; set; }

        /// <summary>
        /// Genres of the Movie.
        /// </summary>
        [MaxLength(200)]
        public string Genres { get; set; }

        /// <summary>
        /// Runtime of the Movie.
        /// </summary>
        public int Runtime { get; set; }

        /// <summary>
        /// ReleaseDate of the Movie.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        /// Backdrop Image of the Movie.
        /// </summary>
        public byte[] BackdropImage { get; set; }

        /// <summary>
        /// Poster Image of the Movie.
        /// </summary>
        public byte[] PosterImage { get; set; }

        /// <summary>
        /// Homepage of the Movie.
        /// </summary>
        [MaxLength(200)]
        public string Homepage { get; set; }

        /// <summary>
        /// Indication of user has watched the Movie.
        /// </summary>
        public bool HasWatched { get; set; }

        /// <summary>
        /// Personal comments for the Movie.
        /// </summary>
        [MaxLength(4000)]
        public string PersonalComments { get; set; }

        /// <summary>
        /// A free text column to be used in future developments.
        /// </summary>
        [MaxLength(4000)]
        public string FreeText1 { get; set; }

        /// <summary>
        /// A free text column to be used in future developments.
        /// </summary>
        [MaxLength(4000)]
        public string FreeText2 { get; set; }

        /// <summary>
        /// A free text column to be used in future developments.
        /// </summary>
        [MaxLength(4000)]
        public string FreeText3 { get; set; }

        /// <summary>
        /// A free text column to be used in future developments.
        /// </summary>
        [MaxLength(4000)]
        public string FreeText4 { get; set; }

        /// <summary>
        /// A free text column to be used in future developments.
        /// </summary>
        [MaxLength(4000)]
        public string FreeText5 { get; set; }

        /// <summary>
        /// The set of <see cref="Actor"/> associated with the movie.
        /// </summary>
        public ICollection<Actor> Actors { get; set; }

        /// <summary>
        /// The set of <see cref="Director"/> associated with the movie.
        /// </summary>
        public ICollection<Director> Directors { get; set; }
    }
}
