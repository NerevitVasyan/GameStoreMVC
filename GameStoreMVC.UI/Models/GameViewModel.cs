using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameStoreMVC.UI.Models
{
    public class GameViewModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage ="Потрібно заповнити назву гри")]
        [StringLength(100,ErrorMessage = "Задовге ім'я")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Потрібно заповнити виробника")]
        [StringLength(100, ErrorMessage = "Задовге ім'я")]
        [Display(Name = "Виробник")]
        public string Producer { get; set; }

        [Required(ErrorMessage = "Потрібно вказати рік")]
        [Display(Name="Рік")]
        [Range(1950,2100,ErrorMessage ="Wrong Year")]
        public int Year { get; set; }
    }
}