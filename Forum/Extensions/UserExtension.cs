using Forum.Models;
using Forum.Service.ViewModels.Users;

namespace Forum.Extensions;

public static class UserExtension
{
    public static User MapToUserModel(this UserRegisterViewModel model)
    {
        return new User()
        {
            UserName = model.UserName,
            Email = model.Email,
            Avatar = model.Avatar
        };
    }
    
    public static UserProfileViewModel MapToUserProfileViewModel(this User model)
    {
        return new UserProfileViewModel()
        {
            UserName = model.UserName,
            Email = model.Email,
            Avatar = model.Avatar,
            Messages = model.Messages
        };
    }
}