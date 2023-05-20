using Forum.Extensions;
using Forum.Models;
using Forum.Service.Abstracts;
using Forum.Service.ViewModels.Comments;
using Forum.Service.ViewModels.Themes;
using Microsoft.EntityFrameworkCore;

namespace Forum.Service.ThemeServices;

public class ThemeService : IThemeService
{
    private readonly ForumContext _db;

    public ThemeService(ForumContext db)
    {
        _db = db;
    }

    public void Add(CreateThemeViewModel model, string userId)
    {
        Theme theme = model.MapToUserModel();
        theme.UserId = userId;
        theme.DateOfCreate = DateTime.Now;

        _db.Themes.Add(theme);
        _db.SaveChanges();
    }

    public List<ThemeViewModel> GetAllTheme()
    {
        List<Theme> themes = _db.Themes
            .Include(x => x.User)
            .Include(x=> x.Messages)
            .OrderByDescending(x=> x.DateOfCreate)
            .ToList();
        List<ThemeViewModel> themeViewModel = themes.MapToThemesViewModel();
        return themeViewModel;
    }

    public FullThemeViewModel GetThemeById(int themeId)
    {
        Theme theme = _db.Themes
            .Include(x => x.Messages)
            .ThenInclude(x=> x.User)
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == themeId);
        FullThemeViewModel themeViewModel = theme.MapToFullThemeViewModel();
        
        return themeViewModel;
    }

    public Message AddComment(CreateMessageViewModel model, string userId)
    {
        Message message = model.MapToFullThemeViewModel();
        message.UserId = userId;
        message.DateOfSend = DateTime.Now;

        _db.Messages.Add(message);
        _db.SaveChanges();
        
        return message;
    }
}