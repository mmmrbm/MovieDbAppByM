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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string ImdbId { get; set; }

        [Required]
        public float ImdbVote { get; set; }

        [Required]
        [MaxLength(200)]
        public string OriginalTitle { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Tagline { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Overview { get; set; }

        [Required]
        [MaxLength(200)]
        public string Genres { get; set; }

        [Required]
        public int Runtime { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public byte[] BackdropImage { get; set; }

        [Required]
        public byte[] PosterImage { get; set; }

        [MaxLength(200)]
        public string Homepage { get; set; }

        public bool HasWatched { get; set; }

        [MaxLength(4000)]
        public string PersonalComments { get; set; }

        [MaxLength(4000)]
        public string FreeText1 { get; set; }

        [MaxLength(4000)]
        public string FreeText2 { get; set; }

        [MaxLength(4000)]
        public string FreeText3 { get; set; }

        [MaxLength(4000)]
        public string FreeText4 { get; set; }

        [MaxLength(4000)]
        public string FreeText5 { get; set; }
    }
}
