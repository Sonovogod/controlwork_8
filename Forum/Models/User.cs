using Microsoft.AspNetCore.Identity;

namespace Forum.Models;

public class User: IdentityUser
{
    public string Avatar { get; set; }
    public DateTime DateOfCreate { get; set; }
    public List<Message>? Messages { get; set; }
    public List<Theme>? Themes { get; set; }
}