using Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }
    private async Task LogOperation(string method, string content)
    {
        var log = new OpLog
        {
            ReIp = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            ReTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            ReUa = Request.Headers["User-Agent"].ToString(),
            ReUrl = HttpContext.Request.Path,
            ReMethod = method,
            ReContent = content,
            AccessTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        _context.OpLogs.Add(log);
        await _context.SaveChangesAsync();
    }

    //-------------------------------- User ---------------------------------
    [HttpGet("users")]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        await LogOperation("GET", "获取用户列表");
        return Ok(users);
    }
    //  POST 请求：创建用户
    [HttpPost("users")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        await LogOperation("POST", $"创建用户: {user.Username}");
        return Ok(user);
    }

    //  PUT 请求：更新用户
    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUser(long id, User updatedUser)
    {
        if (id != updatedUser.Id)
        {
            return BadRequest("用户ID不匹配");
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        // 更新用户的各个属性
        user.Username = updatedUser.Username;
        user.Password = updatedUser.Password;
        user.Role = updatedUser.Role;
        user.Status = updatedUser.Status;
        user.Nickname = updatedUser.Nickname;
        user.Avatar = updatedUser.Avatar;
        user.Mobile = updatedUser.Mobile;
        user.Email = updatedUser.Email;
        user.Gender = updatedUser.Gender;
        user.Description = updatedUser.Description;
        user.CreateTime = updatedUser.CreateTime;
        user.Score = updatedUser.Score;
        user.PushEmail = updatedUser.PushEmail;
        user.PushSwitch = updatedUser.PushSwitch;
        user.Token = updatedUser.Token;

        await _context.SaveChangesAsync();
        await LogOperation("PUT", $"更新用户: {updatedUser.Username}");
        return NoContent();
    }

    //  DELETE 请求：删除用户
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        await LogOperation("DELETE", $"删除用户ID: {id}");
        return NoContent();
    }
    //-------------------------------- Oplog ---------------------------------
    [HttpGet("oplogs")]
    public async Task<ActionResult<List<Thing>>> GetOplogs()
    {
        var oplogs = await _context.OpLogs.ToListAsync();
        await LogOperation("GET", "获取Oplogs列表");
        return Ok(oplogs);
    }

    //-------------------------------- Thing ---------------------------------
    //  GET 请求：获取所有 Thing
    [HttpGet("things")]
    public async Task<ActionResult<List<Thing>>> GetThings()
    {
        var things = await _context.Things.ToListAsync();
        await LogOperation("GET", "获取商品列表");
        return Ok(things);
    }

    //  POST 请求：创建 Thing
    [HttpPost("things")]
    public async Task<ActionResult<Thing>> CreateThing(Thing thing)
    {
        _context.Things.Add(thing);
        await _context.SaveChangesAsync();
        await LogOperation("POST", $"创建商品: {thing.Title}");
        return Ok(thing);
    }

    //  PUT 请求：更新 Thing
    [HttpPut("things/{id}")]
    public async Task<IActionResult> UpdateThing(long id, Thing updatedThing)
    {
        if (id != updatedThing.Id)
        {
            return BadRequest("Thing ID does not match.");
        }

        var thing = await _context.Things.FindAsync(id);
        if (thing == null)
        {
            return NotFound();
        }

        // 更新 Thing 的各个属性
        thing.Title = updatedThing.Title;
        thing.Cover = updatedThing.Cover;
        thing.Description = updatedThing.Description;
        thing.Price = updatedThing.Price;
        thing.Status = updatedThing.Status;
        thing.Score = updatedThing.Score;
        thing.Mobile = updatedThing.Mobile;
        thing.Age = updatedThing.Age;
        thing.Location = updatedThing.Location;
        thing.CreateTime = updatedThing.CreateTime;
        thing.Pv = updatedThing.Pv;
        thing.RecommendCount = updatedThing.RecommendCount;
        thing.WishCount = updatedThing.WishCount;
        thing.CollectCount = updatedThing.CollectCount;
        thing.ClassificationId = updatedThing.ClassificationId;
        thing.UserId = updatedThing.UserId;
        thing.Xuhang = updatedThing.Xuhang;
        thing.Dongli = updatedThing.Dongli;
        thing.Xianzhi = updatedThing.Xianzhi;

        await _context.SaveChangesAsync();
        await LogOperation("PUT", $"更新商品: {thing.Title}");
        return NoContent();
    }

    //  DELETE 请求：删除 Thing
    [HttpDelete("things/{id}")]
    public async Task<IActionResult> DeleteThing(long id)
    {
        var thing = await _context.Things.FindAsync(id);
        if (thing == null)
        {
            return NotFound();
        }

        _context.Things.Remove(thing);
        await _context.SaveChangesAsync();
        await LogOperation("DELETE", $"删除商品ID: {id}");
        return NoContent();
    }

    //-------------------------------- Order ---------------------------------

    //  GET 请求：获取所有 Order
    [HttpGet("orders")]
    public async Task<ActionResult<List<Order>>> GetOrders()
    {
        var orders = await _context.Orders.ToListAsync();
        await LogOperation("GET", "获取订单列表");
        return Ok(orders);
    }

    //  POST 请求：创建 Order
    [HttpPost("orders")]
    public async Task<ActionResult<Order>> CreateOrder(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        await LogOperation("POST", $"创建订单: {order.Id}");
        return Ok(order);
    }

    //  PUT 请求：更新 Order
    [HttpPut("orders/{id}")]
    public async Task<IActionResult> UpdateOrder(long id, Order updatedOrder)
    {
        if (id != updatedOrder.Id)
        {
            return BadRequest("Order ID does not match.");
        }

        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        // 更新 Order 的各个属性
        order.Status = updatedOrder.Status;
        order.OrderTime = updatedOrder.OrderTime;
        order.PayTime = updatedOrder.PayTime;
        order.ThingId = updatedOrder.ThingId;
        order.UserId = updatedOrder.UserId;
        order.Count = updatedOrder.Count;
        order.OrderNumber = updatedOrder.OrderNumber;
        order.ReceiverAddress = updatedOrder.ReceiverAddress;
        order.ReceiverName = updatedOrder.ReceiverName;
        order.ReceiverPhone = updatedOrder.ReceiverPhone;
        order.Remark = updatedOrder.Remark;

        await _context.SaveChangesAsync();
        await LogOperation("PUT", $"更新订单: {id}");
        return NoContent();
    }

    //  DELETE 请求：删除 Order
    [HttpDelete("orders/{id}")]
    public async Task<IActionResult> DeleteOrder(long id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
        {
            return NotFound();
        }

        _context.Orders.Remove(order);
        await _context.SaveChangesAsync();
        await LogOperation("DELETE", $"删除订单ID: {id}");
        return NoContent();
    }

    //-------------------------------- Address ---------------------------------

    //  GET 请求：获取所有 Address
    [HttpGet("addresses")]
    public async Task<ActionResult<List<Address>>> GetAddresses()
    {
        var addresses = await _context.Addresses.ToListAsync();
        await LogOperation("GET", "获取地址列表");
        return Ok(addresses);
    }

    //  POST 请求：创建 Address
    [HttpPost("addresses")]
    public async Task<ActionResult<Address>> CreateAddress(Address address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        await LogOperation("POST", $"创建地址: {address.Name}");
        return Ok(address);
    }

    //  PUT 请求：更新 Address
    [HttpPut("addresses/{id}")]
    public async Task<IActionResult> UpdateAddress(long id, Address updatedAddress)
    {
        if (id != updatedAddress.Id)
        {
            return BadRequest("Address ID does not match.");
        }

        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }

        // 更新 Address 的各个属性
        address.Name = updatedAddress.Name;
        address.Mobile = updatedAddress.Mobile;
        address.Description = updatedAddress.Description;
        address.Default = updatedAddress.Default;
        address.CreateTime = updatedAddress.CreateTime;
        address.UserId = updatedAddress.UserId;

        await _context.SaveChangesAsync();
        await LogOperation("PUT", $"更新地址: {updatedAddress.Name}");
        return NoContent();
    }

    //  DELETE 请求：删除 Address
    [HttpDelete("addresses/{id}")]
    public async Task<IActionResult> DeleteAddress(long id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        await LogOperation("DELETE", $"删除地址ID: {id}");
        return NoContent();
    }
    //-------------------------------- Notice ---------------------------------
    [HttpGet("latest-notice")]
    public async Task<ActionResult<Notice>> GetLatestNotice()
    {
        // 查询最新的Notice，按CreateTime降序排序，取第一条
        var latestNotice = await _context.Notices
                                        .OrderByDescending(n => n.CreateTime)
                                        .FirstOrDefaultAsync();

        // 如果不存在Notice，则返回404
        if (latestNotice == null)
        {
            return NotFound("没有可用的公告");
        }

        // 记录操作日志
        await LogOperation("GET", "获取最新公告");

        // 返回最新的公告
        return Ok(latestNotice);
    }




}

