using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents the relationship between <see cref="Director"> and <see cref="Movie">
    /// </summary>
    [Table("MovieDirector")]
    public class MovieDirector
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Director")]
        public int DirectorId { get; set; }

        public Director Director { get; set; }
    }
}
