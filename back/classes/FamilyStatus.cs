using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("family_status")]
    public class FamilyStatus
    {
        [Column("id_family_status")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get;set;}
        public string status_name { get;set;}
    }
}
