using Microsoft.AspNetCore.Mvc;
using Data;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CommonController : ControllerBase{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _env;
    public CommonController(AppDbContext context,IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            // 生成唯一文件名，仅保留扩展名
            var fileExtension = Path.GetExtension(file.FileName);
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;

             // 确定保存路径，上传到 wwwroot/images/uploads
            var uploadsFolder = Path.Combine(_env.WebRootPath, "images\\uploads");
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // 返回图片的 URL
            var imageUrl = "uploads/" + uniqueFileName;
            return Ok(imageUrl);
        }

        return BadRequest("File is required.");
    }


}