using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("Disabilities")]
    public class Disabilities
    {
        [Key]
        [Column("dis_id")]

        public int id { get; set; }
        
        [Column("dis_name")]
        public string name { get; set; }
    }
}
