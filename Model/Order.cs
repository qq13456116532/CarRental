using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Order
    {
        [Key]
        public long? Id { get; set; }

        [StringLength(2)]
        public required string Status { get; set; }

        [StringLength(30)]
        public required string OrderTime { get; set; }

        [StringLength(30)]
        public required string PayTime { get; set; }

        public long ThingId { get; set; }

        public long UserId { get; set; }

        public required int Count { get; set; }

        [StringLength(13)]
        public required string OrderNumber { get; set; }

        [StringLength(50)]
        public required string ReceiverAddress { get; set; }

        [StringLength(20)]
        public required string ReceiverName { get; set; }

        [StringLength(20)]
        public required string ReceiverPhone { get; set; }

        [StringLength(30)]
        public required string Remark { get; set; }
    }
}
