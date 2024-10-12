using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class ThingTag
    {
        [Key]
        public required long Id { get; set; }

        public required long ThingId { get; set; }

        public required long TagId { get; set; }
    }
}
