    using System.ComponentModel.DataAnnotations;

namespace SaraTort.Admin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Login kiritilishi shart!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Parol kiritilishi shart!")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}