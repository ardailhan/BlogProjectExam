using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogProjectExam.ViewModels.Auth.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Last Name can't be empty")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email adress can't be empty")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Username can't be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        [DataType(DataType.Password)]
        [RegularExpression("[a-zA-Z0-9]{8,16}", ErrorMessage ="Password should be between 8 and 16 characters")]
        public string Password { get; set; }
        [Display(Name ="Profile Picture")]
        public IFormFile ProfilePicture { get; set; }
    }
}
