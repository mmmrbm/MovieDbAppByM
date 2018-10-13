using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDbAppByM.Model
{
    /// <summary>
    /// Represents the data entered by user with manual labor.
    /// This data will be used to fetch information using API.
    /// </summary>
    [Table("ImdbMovie")]
    public class ImdbMovie
    {
        /// <summary>
        /// Identifier for the ImdbMovie.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ImdbId { get; set; }

        /// <summary>
        /// Status of the process of fetching information from end point.
        /// Can have two values Success or Error.
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Status { get; set; }

        /// <summary>
        /// A description of status. Useful for identify and understand errorneous records.
        /// </summary>
        [Required]
        [MaxLength(4000)]
        public string StatusText { get; set; }
    }
}
