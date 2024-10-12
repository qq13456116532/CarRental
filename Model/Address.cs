using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Address
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        [StringLength(30)]
        public string? Mobile { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [StringLength(10)]
        public string? Def { get; set; }

        [StringLength(30)]
        public string? CreateTime { get; set; }

        public long? UserId { get; set; }
    }
}
