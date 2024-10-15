namespace Services;

public class OrderDto{

    public required long Id { get; set; }
    public required string OrderNumber { get; set; }
    public required string OrderTime { get; set; }
    public long ThingId { get; set; }
    public required string Status { get; set; }
    public required int Count { get; set; }
    public required string Cover { get; set; }
    public required string Title { get; set; }
    public required string Price { get; set; }


}










