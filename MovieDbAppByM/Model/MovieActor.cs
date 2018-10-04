using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents the relationship between <see cref="Actor"> and <see cref="Movie">
    /// </summary>
    [Table("MovieActor")]
    public class MovieActor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [ForeignKey("Actor")]
        public int ActorId { get; set; }

        public Actor Actor { get; set; }

        public int CastOrder { get; set; }
    }
}
