using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class ThingWish
    {
        [Key]
        public long Id { get; set; }

        public required long ThingId { get; set; }

        public required long UserId { get; set; }
    }
}
