using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Services.Auth;
public class AuthService
{
    public bool IsUserLoggedIn => !string.IsNullOrEmpty(UserToken);
    public bool IsAdminLoggedIn => !string.IsNullOrEmpty(AdminToken);
    private readonly string[] _allowList = {"admin/", "admin/login","userCenter", "login", "register", "portal", "search", "403", "404" };

    public string? UserToken { get; set; }
    public string? AdminToken { get; set; }

    public string? GetRedirectUrl(string relativeUri)
    {
        if (_allowList.Contains(relativeUri))
        {
            return null; // 不进行重定向
        }

        var isAdminPage = relativeUri.Contains("admin");
        if (isAdminPage && !IsAdminLoggedIn)
        {
            return "/admin/login";
        }
        else if (!isAdminPage && !IsUserLoggedIn)
        {
            return "/login";
        }
        return null;
    }
    public void LoginIn(string? token)
    {
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("Token is null or empty");
            return;
        }
        UserToken = token;
    }
    public void Logout(){
        UserToken = null;
    }
}
public class LoginForm
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
}
public class RegisterForm
{
    [Required(ErrorMessage = "邮箱不能为空")]
    [EmailAddress(ErrorMessage = "请输入有效的邮箱地址")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "密码不能为空")]
    [MinLength(6, ErrorMessage = "密码长度至少为 6 位")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "请再次输入密码")]
    [Compare(nameof(Password), ErrorMessage = "两次输入的密码不一致")]
    public string RePassword { get; set; } = string.Empty;
}
