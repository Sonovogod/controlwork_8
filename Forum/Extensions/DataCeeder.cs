using Forum.Models;
using Microsoft.EntityFrameworkCore;

namespace Forum.Extensions;

public static class DataCeeder
{
    public static void SeedPredictions(this ModelBuilder builder)
    {
        string avatar = Path.Combine(@"\Logo", "primalLogo.png");
        builder.Entity<User>()
            .HasData(new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@test.com",
                UserName = "testera",
                Avatar = avatar,
                DateOfCreate = DateTime.Now,
                
            });
        builder.Entity<User>()
            .HasData(new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "testb@testb.com",
                UserName = "testerb",
                Avatar = avatar,
                DateOfCreate = DateTime.Now
            });
        builder.Entity<User>()
            .HasData(new User()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "testc@testc.com",
                UserName = "testerc",
                Avatar = avatar,
                DateOfCreate = DateTime.Now
            });
    }
}