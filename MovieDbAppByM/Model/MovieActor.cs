using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents the many to many relationship between <see cref="Actor"> and <see cref="Movie">
    /// </summary>
    [Table("MovieActor")]
    public class MovieActor
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
        /// Associated identifier of <see cref="Actor">
        /// </summary>
        [ForeignKey("Actor")]
        public int ActorId { get; set; }

        /// <summary>
        /// Associated <see cref="Actor">
        /// </summary>
        public Actor Actor { get; set; }

        /// <summary>
        /// Order of cast mentioned in the movie credits.
        /// </summary>
        public int CastOrder { get; set; }
    }
}
