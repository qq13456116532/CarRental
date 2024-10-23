using Data;
using CarRental.Components;
using Services.Auth;
using TabBlazor;
using TabBlazor.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.AddSqlite<Data.AppDbContext>("Data Source=carDB.db");
builder.Services.AddSingleton<AuthService>();
builder.Services.AddScoped<ToastService>();  // 注册 ToastService
// 注册 TabBlazor 服务
builder.Services.AddTabler();
builder.Services.AddTabBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");


var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}



app.Run();
