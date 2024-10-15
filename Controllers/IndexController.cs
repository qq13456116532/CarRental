using Microsoft.AspNetCore.Mvc;

using Data;
using Microsoft.EntityFrameworkCore;
using Services;
using System.Linq.Dynamic.Core;

[ApiController]
[Route("api/[controller]")]
public class IndexController : ControllerBase
{
    private readonly AppDbContext _context;

    public IndexController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("classifications")]
    public async Task<ActionResult<List<Classification>>> GetClassifications()
    {
        var classification = await _context.Classifications.ToListAsync();
        return Ok(classification);
    }
    [HttpGet("tags")]
    public async Task<ActionResult<List<Tag>>> GetTags()
    {
        var tags = await _context.Tags.ToListAsync();
        return Ok(tags);
    }
    [HttpGet("things")]
    public async Task<ActionResult<List<Thing>>> GetThings([FromQuery] Dictionary<string, string> parameters)
    {
        IQueryable<Thing> query = _context.Things;
        if(parameters.ContainsKey("keyword")){
            //这是在搜索框的逻辑
            var key = parameters["keyword"];
            // 使用 OR 逻辑来在多个字段中进行查询
            query = query.Where(x => x.Title.Contains(key) || x.Description.Contains(key) || x.Location.Contains(key));

        }
        // Apply filtering based on parameters if provided
        if (parameters.ContainsKey("c"))
        {
            var t = parameters["c"];
            var category = await _context.Classifications.FirstOrDefaultAsync(c => c.Title == t);
            if (category == null)
            {
                return NotFound(new { message = "Category not found" });
            }
            query = query.Where(t => t.ClassificationId == category.Id);
        }
        if (parameters.ContainsKey("tag"))
        {
            // var tagId = parameters["tag"];
            // query = query.Where(c => c.Title.Contains(tagId));
            var tagId = long.Parse(parameters["tag"]);
            query = query.Where(t => _context.ThingTags.Any(tt => tt.ThingId == t.Id && tt.TagId == tagId));
        }
        if (parameters.ContainsKey("sort"))
        {
            var sort = parameters["sort"];
            switch (sort)
            {
                case "recent":
                    query = query.OrderByDescending(t => t.CreateTime);
                    break;
                case "hot":
                    query = query.OrderByDescending(t => t.Pv);
                    break;
                case "recommend":
                    query = query.OrderByDescending(t => t.RecommendCount);
                    break;
                default:
                    query = query.OrderByDescending(t => t.CreateTime);
                    break;
            }
        }
        var things = await query.ToListAsync();
        return Ok(things);
    }
    [HttpPost("things/collect")]
    public async Task<ActionResult> CollectThing([FromBody] DetailRequest request)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Token==request.Token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 查找 Thing
        var thing = await _context.Things.FirstOrDefaultAsync(t => t.Id == request.ThingId);
        if (thing == null)
        {
            return NotFound("Thing not found.");
        }

        // 检查是否已收藏
        var existingCollect = await _context.ThingCollects
            .FirstOrDefaultAsync(tc => tc.ThingId == request.ThingId && tc.UserId == user.Id);

        if (existingCollect != null)
        {
            return BadRequest("Thing already collected.");
        }

        // 添加收藏记录
        var newCollect = new ThingCollect
        {
            ThingId = request.ThingId??0,
            UserId = user.Id??0
        };
        _context.ThingCollects.Add(newCollect);

        // 更新 Thing 的收藏计数
        thing.CollectCount += 1;

        // 保存更改
        await _context.SaveChangesAsync();

        return Ok("Thing collected successfully.");
    }
    [HttpGet("things/collect")]
    public async Task<ActionResult> GetCollectThingList([FromQuery] string token)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        
        // 获取用户收藏的东西，一次查询解决
        List<CollectedThingDto> collectThings = await _context.ThingCollects
            .Where(tc => tc.UserId == user.Id)
            .Join(_context.Things,
                tc => tc.ThingId,  // 连接条件
                t => t.Id,
                (tc, t) => new CollectedThingDto
                {
                    id = tc.ThingId,
                    ThingName = t.Title ?? "default",
                    Cover = t.Cover ?? "default-cover.jpg",
                    Title = t.Title ?? "default-title"
                })
            .ToListAsync();


        return Ok(collectThings);
    }
    [HttpDelete("things/collect/{id}")]
    public async Task<ActionResult> DeleteCollect(int id, [FromQuery] string token)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 查找用户的收藏记录
        var thingCollect = await _context.ThingCollects.FirstOrDefaultAsync(tc => tc.UserId == user.Id && tc.ThingId == id);
        if (thingCollect == null)
        {
            return NotFound("Item not found in your collection");
        }

        // 删除收藏
        _context.ThingCollects.Remove(thingCollect);
        await _context.SaveChangesAsync();

        return Ok("Item removed from collection");
    }


    [HttpPost("things/wish")]
    public async Task<ActionResult> AddToWishList([FromBody] DetailRequest request)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Token==request.Token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 查找 Thing
        var thing = await _context.Things.FirstOrDefaultAsync(t => t.Id == request.ThingId);
        if (thing == null)
        {
            return NotFound("Thing not found.");
        }

        // 检查是否已经在愿望单中
        var existingWish = await _context.ThingWishes
            .FirstOrDefaultAsync(tw => tw.ThingId == request.ThingId && tw.UserId == user.Id);

        if (existingWish != null)
        {
            return BadRequest("Thing already in wish list.");
        }

        // 添加到愿望单
        var newWish = new ThingWish
        {
            ThingId = request.ThingId??0,
            UserId = user.Id??0
        };
        _context.ThingWishes.Add(newWish);

        // 更新 Thing 的愿望单计数
        thing.WishCount += 1;

        // 保存更改
        await _context.SaveChangesAsync();

        return Ok("Thing added to wish list successfully.");
    }
    [HttpGet("things/wish")]
    public async Task<ActionResult> GetWishThingList([FromQuery] string token)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }


        List<WishedThingDto> wishThings = await _context.ThingWishes
            .Where(tc => tc.UserId == user.Id)
            .Join(_context.Things,
                tc => tc.ThingId,  // 连接条件
                t => t.Id,
                (tc, t) => new WishedThingDto
                {
                    id = tc.ThingId,
                    ThingName = t.Title ?? "default",
                    Cover = t.Cover ?? "default-cover.jpg",
                    Title = t.Title ?? "default-title"
                })
            .ToListAsync();


        return Ok(wishThings);
    }

    [HttpDelete("things/wish/{id}")]
        public async Task<ActionResult> DeleteWish(int id, [FromQuery] string token)
        {
            // 验证用户通过传入的 token
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
            if (user == null)
            {
                return Unauthorized("Invalid token");
            }

            // 查找用户的收藏记录
            var thingCollect = await _context.ThingWishes.FirstOrDefaultAsync(tc => tc.UserId == user.Id && tc.ThingId == id);
            if (thingCollect == null)
            {
                return NotFound("Item not found in your collection");
            }

            // 删除收藏
            _context.ThingWishes.Remove(thingCollect);
            await _context.SaveChangesAsync();

            return Ok("Item removed from collection");
        }
    [HttpGet("thing")]
    public async Task<ActionResult<Thing>> GetThingById([FromQuery] long id)
    {
        // Query the database for the Thing with the provided id
        var thing = await _context.Things.FindAsync(id);

        if (thing == null)
        {
            return NotFound($"No Thing found with id = {id}");
        }

        return Ok(thing);
    }

    [HttpGet("comments")]
    public async Task<ActionResult<List<Comment>>> GetCommentsByThingId([FromQuery] long thingId,[FromQuery]string order)
    {
        if (thingId <= 0)
        {
            return BadRequest("Invalid ThingId.");
        }

        // Retrieve comments related to the specified ThingId.
        var query = _context.Comments
            .Where(c => c.ThingId == thingId)
            .Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                CommentTime = c.CommentTime,
                LikeCount = c.LikeCount,
                Username = _context.Users.Where(u => u.Id == c.UserId).Select(u => u.Username).FirstOrDefault(), // Join to get the username
                ThingId = c.ThingId
            });

        if(order.Equals("recent")){
            query.OrderByDescending(c => c.CommentTime); // Sort by CommentTime or any other criteria.
        }
        else query.OrderByDescending(c => c.LikeCount);

        var comments = await query.ToListAsync();
        // if (comments == null || !comments.Any())
        // {
        //     return NotFound($"No comments found for ThingId = {thingId}");
        // }

        return Ok(comments);
    }

    [HttpPost("comments")]
    public async Task<ActionResult> AddComment([FromBody] DetailRequest request)
    {
        // 验证用户通过传入的 token
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Token==request.Token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 检查评论内容是否为空
        if (string.IsNullOrWhiteSpace(request.Content))
        {
            return BadRequest("Comment content cannot be empty.");
        }

        // 创建新的评论
        var newComment = new Comment
        {
            Content = request.Content,
            CommentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // 格式化时间
            LikeCount = 0, // 新评论初始时的点赞数为 0
            UserId = user.Id,
            ThingId = request.ThingId
        };

        // 添加评论到数据库
        _context.Comments.Add(newComment);
        await _context.SaveChangesAsync();

        return Ok("Comment added successfully.");
    }

    [HttpPost("comments/like")]
    public async Task<ActionResult> LikeComment([FromBody] DetailRequest request)
    {
        // 验证用户身份
        var user = await _context.Users.FirstOrDefaultAsync(u=>u.Token==request.Token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 查找评论
        var comment = await _context.Comments.FirstOrDefaultAsync(c => c.Id == request.CommentId);
        if (comment == null)
        {
            return NotFound("Comment not found.");
        }

        // 增加点赞数
        comment.LikeCount += 1;

        // 保存更改
        _context.Comments.Update(comment);
        await _context.SaveChangesAsync();

        return Ok("Comment liked successfully.");
    }



    [HttpGet("recommendations")]
    public async Task<ActionResult<List<Thing>>> GetRecommendedThings()
    {
        // Retrieve a list of recommended things (e.g., top-rated, popular, etc.)
        var recommendedThings = await _context.Things
            .OrderByDescending(t => t.RecommendCount) // Example: Sort by Rating or any criteria
            .Take(6) // Example: Return top 6 recommendations
            .ToListAsync();

        if (recommendedThings == null || !recommendedThings.Any())
        {
            return NotFound("No recommended items found.");
        }

        return Ok(recommendedThings);
    }

    [HttpGet("addresses")]
    public async Task<ActionResult<List<Address>>> GetUserAddresses([FromQuery] string token)
    {
        // 验证用户身份
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }

        // 查找用户的地址列表
        var addresses = await _context.Addresses.Where(a => a.UserId == user.Id).ToListAsync();

        return Ok(addresses);
    }

    [HttpGet("orders/{status}")]
    public async Task<ActionResult<List<OrderDto>>> GetOrders([FromQuery] string token,string status){
        // 验证用户身份
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }
        var orders = await _context.Orders
        .Where(a => a.UserId == user.Id && a.Status==status)
        .Join(
            _context.Things, // 连接的表
            order => order.ThingId, // 连接的键
            thing => thing.Id, // 另一个表的键
            (order, thing) => new OrderDto
            {
                Id = order.Id??0,
                OrderNumber = order.OrderNumber,
                OrderTime = order.OrderTime,
                ThingId = order.ThingId,
                Status = order.Status,
                Count = order.Count,
                Cover = thing.Cover, // 从 Thing 表获取
                Title = thing.Title, // 从 Thing 表获取
                Price = thing.Price // 从 Thing 表获取
            }
        )
        .ToListAsync();

        return Ok(orders);

    }

    [HttpDelete("orders/{id}")]
    public async Task<ActionResult> DeleteOrders([FromQuery] string token,long id){
        // 验证用户身份
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }        
        // 查找满足条件的订单
        var order = await _context.Orders
            .Where(a => a.UserId == user.Id && a.Id == id)
            .FirstOrDefaultAsync();

        if (order != null)
        {
            // 从上下文中移除订单
            _context.Orders.Remove(order);

            // 保存更改
            await _context.SaveChangesAsync();
        }
        else
        {
            // 处理未找到订单的情况
            Console.WriteLine("Order not found");
        }

        return Ok();

    }
    //添加order
    [HttpPost("orders/{thingId}")]
    public async Task<ActionResult> addOrders([FromQuery] string token,long thingId){
        // 验证用户身份
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Token == token);
        if (user == null)
        {
            return Unauthorized("Invalid token");
        }    

        // 检查该用户是否已经为该商品下过订单
        var existingOrder = await _context.Orders
            .FirstOrDefaultAsync(o => o.UserId == user.Id && o.ThingId == thingId);

        if (existingOrder != null)
        {
            // 如果订单已存在，返回 Conflict（冲突）状态码或其他适当响应
            return Conflict("Order already exists for this item.");
        }
            // 创建新的订单实体
        var newOrder = new Order
        {
            UserId = user.Id??1,
            Status = "1", // 订单状态
            OrderTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // 订单时间
            PayTime = "default", // 支付时间，可能为空或由其他逻辑设置
            ThingId = thingId, // 商品ID
            Count = 1, // 购买数量
            OrderNumber = "default", // 订单编号
            ReceiverAddress = "default", // 收货地址，可以根据需求填充
            ReceiverName = "default", // 收货人姓名，可以根据需求填充
            ReceiverPhone = "default", // 收货人电话，可以根据需求填充
            Remark = "default" // 备注，可以根据需求填充
        };

        // 将新订单添加到上下文中
        _context.Orders.Add(newOrder);

        // 保存更改
        await _context.SaveChangesAsync();          
        return Ok();                                            
    }


}

