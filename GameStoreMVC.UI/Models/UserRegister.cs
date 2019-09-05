using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStoreMVC.UI.Models
{
    
    public class UserRegister
    {
        [Required(ErrorMessage = "Мило потрібно ввести обов'язково")]
        [EmailAddress(ErrorMessage ="Мило має невірний формат")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Мило")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль потрібно ввести обов'язково")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
        [Compare("Password",ErrorMessage = "Паролі повинні співпадати")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пароль потрібно ввести обов'язково")]
        [Display(Name = "Повторіть пароль")]
        public string ConfirmPassword { get; set; }
    }
}