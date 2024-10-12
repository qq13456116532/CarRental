using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Notice
    {
        [Key]
        public required long Id { get; set; }

        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(1000)]
        public required string Content { get; set; }

        [StringLength(30)]
        public required string CreateTime { get; set; }
    }
}
