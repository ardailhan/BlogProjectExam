using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogProjectExam.ViewModels.Auth.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email adress can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
