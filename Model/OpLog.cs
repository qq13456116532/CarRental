using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class OpLog
    {
        [Key]
        public long? Id { get; set; }

        [StringLength(100)]
        public required string ReIp { get; set; }

        [StringLength(30)]
        public required string ReTime { get; set; }

        [StringLength(255)]
        public required string ReUa { get; set; }

        [StringLength(200)]
        public required string ReUrl { get; set; }

        [StringLength(10)]
        public required string ReMethod { get; set; }

        [StringLength(200)]
        public required string ReContent { get; set; }

        [StringLength(30)]
        public required string AccessTime { get; set; }
    }
}
