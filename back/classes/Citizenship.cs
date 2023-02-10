using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("Citizenship")]
    public class Citizenship
    {
        [Key]
        [Column("citizenship_id")]
        public int id { get; set; }
        [Column("nationality")]
        public string nationality { get; set; }
    }
}
