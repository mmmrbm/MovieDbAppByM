using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents actor who acts in a movie.
    /// </summary>
    [Table("Actor")]
    public class Actor
    {
        /// <summary>
        /// Constructs <see cref="Actor"/>
        /// </summary>
        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

        /// <summary>
        /// Identifier for the Actor.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Actor.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Profile image of the Actor.
        /// </summary>
        public byte[] ProfileImage { get; set; }

        /// <summary>
        /// The set of <see cref="Movie"/> directed by <see cref="Actor"/>.
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
    }
}
