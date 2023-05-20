using System.Text.RegularExpressions;
using Forum.Extensions;
using Forum.Models;
using Forum.Service.Abstracts;
using Forum.Service.ViewModels.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Forum.Service.UserServices;

public class AccountService : IAccountService
{
    private readonly UserManager<User> _db;
    private readonly ForumContext _dbChat;

    public AccountService(UserManager<User> db, ForumContext dbChat)
    {
        _db = db;
        _dbChat = dbChat;
    }

    public bool UserNameUnique(string userName)
        => !_db.Users.Any(x => x.UserName != null && x.UserName.ToLower().Equals(userName.ToLower()));

    public bool UserEmailUnique(string email)
        => !_db.Users.Any(x => x.Email != null && x.Email.ToLower().Equals(email.ToLower()));
    
    public async Task<User?> FindByEmailOrLoginAsync(string? key)
    {
        User? user = new User();
        if (key is null)
            return null;

        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        bool isMail = Regex.IsMatch(key, pattern);

        if (isMail)
            user = await _dbChat.Users.Include(x=> x.Messages)
                .Include(x=> x.Themes)
                .FirstOrDefaultAsync(x => x.NormalizedEmail != null && x.NormalizedEmail.Equals(key.ToUpper()));
        else
            user = await _dbChat.Users
                .Include(x=> x.Messages)
                .Include(x=> x.Themes)
                .FirstOrDefaultAsync(x => x.NormalizedUserName != null && x.NormalizedUserName.Equals(key.ToUpper()));
        return user;
    }

    public async Task<IdentityResult> Add(UserRegisterViewModel model)
    {
        User user = model.MapToUserModel();
        user.UserName = model.UserName.ToLower();
        user.DateOfCreate = DateTime.Now;
        IdentityResult result = await _db.CreateAsync(user, model.Password);
        return result;
    }
}