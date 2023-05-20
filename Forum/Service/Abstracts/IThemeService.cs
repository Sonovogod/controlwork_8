using Forum.Service.ViewModels.Themes;

namespace Forum.Service.Abstracts;

public interface IThemeService
{
    void Add(CreateThemeViewModel model, string userId);
    List<ThemeViewModel> GetAllTheme();
    FullThemeViewModel GetThemeById(int themeId);
}