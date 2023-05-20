using Forum.Models;
using Forum.Service.ViewModels.Comments;
using Forum.Service.ViewModels.Themes;

namespace Forum.Service.Abstracts;

public interface IThemeService
{
    void Add(CreateThemeViewModel model, string userId);
    List<ThemeViewModel> GetAllTheme();
    FullThemeViewModel GetThemeById(int themeId);
    Message AddComment(CreateMessageViewModel model , string userId);
}