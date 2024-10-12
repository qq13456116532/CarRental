using Microsoft.EntityFrameworkCore;
namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<Ad> Ads { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Classification> Classifications { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    public DbSet<LoginLog> LoginLogs { get; set; }
    public DbSet<Notice> Notices { get; set; }
    public DbSet<OpLog> OpLogs { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Thing> Things { get; set; }
    public DbSet<ThingCollect> ThingCollects { get; set; }
    public DbSet<ThingTag> ThingTags { get; set; }
    public DbSet<ThingWish> ThingWishes { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}









