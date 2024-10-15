namespace Services;


public class CollectedThingDto{
    //Thing 的 ID
    public required long id { get; set;}
    public required string ThingName { get; set;}
    public required string Cover{ get; set;}
    public required string Title{ get; set;}
}
public class WishedThingDto{
    public required long id { get; set;}
    public required string ThingName { get; set;}

    public required string Cover{ get; set;}
    public required string Title{ get; set;}

}
