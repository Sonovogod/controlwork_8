using Forum.Models;
using Forum.Service.Abstracts;
using Forum.Service.ViewModels.Themes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers;

public class ThemesController : Controller
{
    private readonly IThemeService _themeService;
    private readonly IAccountService _accountService;

    public ThemesController(IThemeService themeService, IAccountService accountService)
    {
        _themeService = themeService;
        _accountService = accountService;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Main()
    {
        List<ThemeViewModel> model = _themeService.GetAllTheme();
        return View(model);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CreateTheme()
    {
        CreateThemeViewModel model = new CreateThemeViewModel();
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateTheme(CreateThemeViewModel model)
    {
        string currentUserName = User.Identity.Name;
        User user = await _accountService.FindByEmailOrLoginAsync(currentUserName);
        _themeService.Add(model, user.Id);
        
        return RedirectToAction("Main", "Themes");
    }

    [HttpGet]
    [Authorize]
    public IActionResult About(int themeId)
    {
        if (themeId == 0)
            return NotFound();
        
        FullThemeViewModel model = _themeService.GetThemeById(themeId);
        return View(model);
    }
}