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
        /// <summary>
        /// Identifier for the entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Associated identifier of <see cref="Movie">
        /// </summary>
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        /// <summary>
        /// Associated <see cref="Movie">
        /// </summary>
        public Movie Movie { get; set; }

        /// <summary>
        /// Associated identifier of <see cref="Director">
        /// </summary>
        [ForeignKey("Director")]
        public int DirectorId { get; set; }

        /// <summary>
        /// Associated <see cref="Director">
        /// </summary>
        public Director Director { get; set; }
    }
}
