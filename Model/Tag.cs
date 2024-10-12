using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Tag
    {
        [Key]
        public required long Id { get; set; }

        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(30)]
        public required string CreateTime { get; set; }
    }
}
