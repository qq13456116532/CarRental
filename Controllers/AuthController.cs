using  Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;
//using BCrypt.Net;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginForm loginForm)
    {
        // 模拟用户验证逻辑
        // 检查数据库中是否有匹配的用户
        var user = await _context.Users
            .Where(u => u.Username == loginForm.Username && u.Password == loginForm.Password)
            .FirstOrDefaultAsync();

        if (user != null)
        {
            // 登录成功，返回 JWT Token 或其他信息,注册的时候Token就是Username
            return Ok(new { Token = user.Token });
        }

        // 登录失败，返回 Unauthorized 响应
        return Unauthorized("Invalid username or password.");

    }
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterForm registerForm)
    {
        // 检查表单是否有效
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // 检查用户名是否已经存在
        var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == registerForm.Username);
        if (existingUser != null)
        {
            return Conflict(new { message = "用户名已存在" });
        }

        // 创建新用户
        var user = new User
        {
            Username = registerForm.Username,
            Password = HashPassword(registerForm.Password), // 对密码进行哈希处理，增加安全性
            Role = "1", // 默认角色
            Status = "1", // 默认状态
            Nickname = registerForm.Username, // 默认昵称为用户名
            Avatar = "", // 默认头像为空
            Mobile = "", // 默认手机号为空
            Email = registerForm.Username ?? "", // 使用表单中的邮箱，默认为空
            Gender = "", // 默认性别为空
            Description = "", // 默认描述为空
            CreateTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
            Score = 0, // 默认分数为 0
            PushEmail = "", // 默认推送邮箱为空
            PushSwitch = false, // 默认推送开关为 false
            Token = registerForm.Username??"" // 默认 Token 为空
        };

        // 将用户添加到数据库
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // 返回成功响应
        return Ok(new { message = "注册成功" });
    }

    //to do 这里暂时不使用加密
    private string HashPassword(string password)
    {
        // 这里可以使用安全的哈希算法对密码进行加密，如 BCrypt 或 SHA256
        //return BCrypt.Net.BCrypt.HashPassword(password);
        return password;
    }
    }
