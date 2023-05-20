using System.ComponentModel.DataAnnotations;
using Forum.Models;

namespace Forum.Service.ViewModels.Themes;

public class CreateThemeViewModel
{
    [Display(Name = "Заголовок")]
    [StringLength(30, MinimumLength = 5, ErrorMessage = "Минимальное количество знаков: 5, Максимальное - 30")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    public string Title { get; set; }
    
    [Display(Name = "Описание")]
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Минимальное количество знаков: 10, Максимальное - 1000")]
    [Required(ErrorMessage = "Поле не можен быть пустым")]
    public string Content { get; set; }
}