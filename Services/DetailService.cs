namespace Services;




public class DetailRequest
{
    public long? ThingId { get; set; } // 评论所属的 ThingId
    public string? Token { get; set; }

    public long? CommentId { get; set; }
    public string? Content { get; set; } // 评论内容
}



public class CommentDto
{
    public long Id { get; set; }
    public required string Content { get; set; }
    public required string CommentTime { get; set; }
    public int LikeCount { get; set; }
    public string? Username { get; set; } // New field for the username
    public long? ThingId { get; set; }
}


