using Forum.Models;
using Forum.Service.ViewModels.Comments;

namespace Forum.Extensions;

public static class MessageExtension
{
    public static Message MapToFullThemeViewModel(this CreateMessageViewModel model)
    {
        return new Message()
        {
            Content = model.Content,
            ThemeId = model.ThemeId
        };
    }
    
    public static CommentViewModel MapToCommentViewModel(this Message model)
    {
        return new CommentViewModel()
        {
            Content = model.Content,
            Date = model.DateOfSend
        };
    }
}