using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShop.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "ФИО")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'ФИО' не заполнено")]
        [StringLength(200, ErrorMessage = "Поле 'ФИО' должно быть от {2} до {1} символов в длину", MinimumLength = 10)]
        public string FullName { get; set; }
       
        [Display(Name = "Адрес")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Адрес' не заполнено")]
        [StringLength(100, ErrorMessage = "Поле 'Адрес' должно быть от {2} до {1} символов в длину", MinimumLength = 10)]
        public string Address { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Display(Name = "Почта")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Почта' не заполнено")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Телефон' не заполнено")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$", ErrorMessage =
            "Неверный формат телефона")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
