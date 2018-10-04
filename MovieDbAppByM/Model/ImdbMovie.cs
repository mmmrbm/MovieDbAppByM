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
        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ImdbId { get; set; }

        [Required]
        public string MovieName { get; set; }
    }
}
