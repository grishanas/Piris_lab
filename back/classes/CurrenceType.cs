using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{

    [Table("type_of_currency")]
    public class type_of_currency
    {
        [Required]
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set;}


    }
}
