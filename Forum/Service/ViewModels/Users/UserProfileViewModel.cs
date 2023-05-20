using Forum.Models;

namespace Forum.Service.ViewModels.Users;

public class UserProfileViewModel
{
    public string Avatar { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<Message> Messages { get; set; } = new List<Message>();
}