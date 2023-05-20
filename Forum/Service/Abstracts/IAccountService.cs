using Forum.Models;
using Forum.Service.ViewModels.Users;
using Microsoft.AspNetCore.Identity;

namespace Forum.Service.Abstracts;

public interface IAccountService
{
    public bool UserNameUnique(string userName);
    public bool UserEmailUnique(string email);
    public Task<User?> FindByEmailOrLoginAsync(string key);
    public Task<IdentityResult> Add(UserRegisterViewModel model);
}