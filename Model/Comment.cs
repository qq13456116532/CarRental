using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }

        [StringLength(200)]
        public required string Content { get; set; }

        [StringLength(30)]
        public required string CommentTime { get; set; }

        public required int LikeCount { get; set; }

        public long? UserId { get; set; }

        public long? ThingId { get; set; }
    }
}
