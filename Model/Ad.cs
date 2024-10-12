using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Ad
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(500)]
        public string? Link { get; set; }

        [StringLength(30)]
        public string? CreateTime { get; set; }
    }
}
