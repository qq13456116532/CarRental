using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Classification
    {
        [Key]
        public long Id { get; set; }

        [Required, StringLength(100)]
        public required string Title { get; set; }

        [Required, StringLength(30)]
        public required string CreateTime { get; set; }
    }
}
