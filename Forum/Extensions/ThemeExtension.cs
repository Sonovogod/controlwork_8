using Forum.Models;
using Forum.Service.ViewModels.Themes;

namespace Forum.Extensions;

public static class ThemeExtension
{
    public static Theme MapToUserModel(this CreateThemeViewModel model)
    {
        return new Theme()
        {
            Title = model.Title,
            Content = model.Content
        };
    }
    
    public static FullThemeViewModel MapToFullThemeViewModel(this Theme model)
    {
        return new FullThemeViewModel()
        {
            Id = model.Id,
            Title = model.Title,
            Content = model.Content,
            DateOfCreate = model.DateOfCreate,
            UserId = model.UserId,
            User = model.User
        };
    }
    
    public static List<ThemeViewModel> MapToThemesViewModel(this IEnumerable<Theme> self)
    {
        return self.Select(b=> new ThemeViewModel
        {
            Id = b.Id,
            Title = b.Title,
            UserId = b.UserId,
            User = b.User,
            Messages = b.Messages,
            DateOfCreate = b.DateOfCreate
        }).ToList();
    }
}