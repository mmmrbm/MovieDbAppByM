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
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [StringLength(200)]
        public string ImdbId { get; set; }

        [Required]
        public float ImdbVote { get; set; }

        [Required]
        [StringLength(200)]
        public string OriginalTitle { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Tagline { get; set; }

        [Required]
        [StringLength(4000)]
        public string Overview { get; set; }

        [Required]
        [StringLength(200)]
        public string Genres { get; set; }

        public byte[] BackdropImage { get; set; }

        public byte[] PosterImage { get; set; }

        [StringLength(200)]
        public string Homepage { get; set; }

        public bool HasWatched { get; set; }

        [StringLength(4000)]
        public string PersonalComments { get; set; }
    }
}
