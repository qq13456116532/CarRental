using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Banner
    {
        [Key]
        public long Id { get; set; }

        [StringLength(100)]
        public required string Image { get; set; }

        [StringLength(30)]
        public required string CreateTime { get; set; }

        public long? ThingId { get; set; }
    }
}
