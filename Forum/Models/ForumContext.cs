using Forum.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Forum.Models;

public class ForumContext : IdentityDbContext<User>
{
    public DbSet<Message> Messages { get; set; }
    public DbSet<Theme> Themes { get; set; }
    
    public ForumContext (DbContextOptions<ForumContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedPredictions();
    }
}