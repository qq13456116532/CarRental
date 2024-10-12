using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class User
    {
        [Key]
        public long? Id { get; set; }

        [StringLength(50)]
        public required string Username { get; set; }

        [StringLength(50)]
        public required string Password { get; set; }

        [StringLength(2)]
        public required string Role { get; set; }

        [StringLength(1)]
        public required string Status { get; set; }

        [StringLength(20)]
        public required string Nickname { get; set; }

        [StringLength(100)]
        public required string Avatar { get; set; }

        [StringLength(13)]
        public required string Mobile { get; set; }

        [StringLength(50)]
        public required string Email { get; set; }

        [StringLength(1)]
        public required string Gender { get; set; }

        public required string Description { get; set; }

        [StringLength(30)]
        public required string CreateTime { get; set; }

        public required int Score { get; set; }

        [StringLength(40)]
        public required string PushEmail { get; set; }

        public required bool PushSwitch { get; set; }

        [StringLength(32)]
        public required string Token { get; set; }
    }
}
