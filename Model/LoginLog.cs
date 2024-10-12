using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class LoginLog
    {
        [Key]
        public required long Id { get; set; }

        [StringLength(50)]
        public required string Username { get; set; }

        [StringLength(100)]
        public required string Ip { get; set; }

        [StringLength(200)]
        public required string Ua { get; set; }

        public required DateTime LogTime { get; set; }
    }
}
