﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab.classes
{
    [Table("city")]
    public class City
    {
        [Column("id")]
        [Key]
        public int id { get; set; }

        [Column("name")]
        [Required]
        public string name { get; set; }
    }
}
