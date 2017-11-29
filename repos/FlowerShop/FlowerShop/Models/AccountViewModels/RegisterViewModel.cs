using System.ComponentModel.DataAnnotations;

namespace FlowerShop.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false,ErrorMessage = "Поле 'Адрес' не заполнено")]
        [StringLength(100, ErrorMessage = "Поле 'Адрес' должно быть от {2} до {1} символов в длину", MinimumLength = 10)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'ФИО' не заполнено")]
        [StringLength(200, ErrorMessage = "Поле 'ФИО' должно быть от {2} до {1} символов в длину", MinimumLength = 10)]
        public string FullName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Телефон' не заполнено")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$", ErrorMessage =
             "Неверный формат телефона")]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Почта' не заполнено")]
        [EmailAddress(ErrorMessage = "Неверный формат почты")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Пароль' не заполнено")]
        [StringLength(100, ErrorMessage = "Поле 'Пароль' должно быть от {2} до {1} символов в длину", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат пароля (должен " +
                                                    "содержать буквы большого и малого регистра, цифры и спец символ)")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле 'Повторите пароль' не заполнено")]
        [DataType(DataType.Password, ErrorMessage = "Неверный формат пароля (должен " +
                                                    "содержать буквы большого и малого регистра, цифры и спец символ)")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

    }
}
