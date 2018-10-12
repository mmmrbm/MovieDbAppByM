using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents director who directs a movie.
    /// </summary>
    [Table("Director")]
    public class Director
    {
        /// <summary>
        /// Constructs <see cref="Director"/>
        /// </summary>
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        /// <summary>
        /// Identifier for the Director.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Director.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        /// <summary>
        /// Profile image of the Director.
        /// </summary>
        public byte[] ProfileImage { get; set; }

        /// <summary>
        /// The set of <see cref="Movie"/> directed by <see cref="Director"/>.
        /// </summary>
        public ICollection<Movie> Movies { get; set; }
    }
}
