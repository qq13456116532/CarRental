using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class ErrorLog
    {
        [Key]
        public required long Id { get; set; }

        [StringLength(100)]
        public required string Ip { get; set; }

        [StringLength(200)]
        public required string Url { get; set; }

        [StringLength(10)]
        public required string Method { get; set; }

        public required string Content { get; set; }

        [StringLength(30)]
        public required string LogTime { get; set; }
    }
}
