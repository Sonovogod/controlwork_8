using Forum.Models;

namespace Forum.Service.ViewModels.Themes;

public class FullThemeViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime DateOfCreate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public List<Message>? Messages { get; set; } = new List<Message>();
}