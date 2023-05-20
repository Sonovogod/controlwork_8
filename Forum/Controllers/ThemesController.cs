using Forum.Extensions;
using Forum.Models;
using Forum.Service.Abstracts;
using Forum.Service.ViewModels.Comments;
using Forum.Service.ViewModels.Themes;
using Forum.Views.Themes;
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
    public IActionResult About(int themeId, int currentPage = 1)
    {
        if (themeId == 0)
            return NotFound();
        
        FullThemeViewModel model = _themeService.GetThemeById(themeId);
        int pageSize = 3;
        int count = model.Messages.Count();
        PaginationThemesViewModel paginationThemesViewModel = new PaginationThemesViewModel()
        {
            FullThemeViewModel = model,
            Pagination = new PaginationViewModel(count, currentPage, pageSize)
        };
        
        return View(paginationThemesViewModel);
    }
    
    [HttpPost]
    [Authorize]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CommentTheme(CreateMessageViewModel model)
    {
        string currentUserName = User.Identity.Name;
        User user = await _accountService.FindByEmailOrLoginAsync(currentUserName);
        Message message = _themeService.AddComment(model, user.Id);
        CommentViewModel newModel = message.MapToCommentViewModel();
        newModel.Avatar = user.Avatar;
        newModel.UserName = user.UserName;
        
        return Ok(newModel);
    }
}