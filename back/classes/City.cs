using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("city")]
    public class City
    {
        [Column("id")]
        [Key]
        [Required]
        public int id { get; set; }
        [Column("name")]
        public string name { get; set; }
    }
}
