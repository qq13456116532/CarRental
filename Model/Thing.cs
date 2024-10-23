using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Thing
    {
        [Key]
        public long? Id { get; set; }

        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(100)]
        public required string Cover { get; set; }

        public required string Description { get; set; }

        [StringLength(50)]
        public required string Price { get; set; }

        [StringLength(1)]
        public required string Status { get; set; }

        public required int Score { get; set; }

        [StringLength(20)]
        public required string Mobile { get; set; }

        [StringLength(10)]
        public required string Age { get; set; }

        [StringLength(100)]
        public required string Location { get; set; }

        [StringLength(30)]
        public required string CreateTime { get; set; }

        public required int Pv { get; set; }

        public required int RecommendCount { get; set; }

        public required int WishCount { get; set; }

        public required int CollectCount { get; set; }

        public long? ClassificationId { get; set; }

        [StringLength(20)]
        public required string UserId { get; set; }

        [StringLength(20)]
        public required string Xuhang { get; set; }

        [StringLength(50)]
        public required string Dongli { get; set; }

        [StringLength(50)]
        public required string Xianzhi { get; set; }
    }
}
