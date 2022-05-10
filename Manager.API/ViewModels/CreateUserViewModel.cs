using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "The name can't be null.")]
        [MinLength(3, ErrorMessage = "The name must have a miminum of three characters.")]
        [MaxLength(80, ErrorMessage = "The name must have a maximum of eigthy characters.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "The email can't be null.")]
        [MinLength(10, ErrorMessage = "The email must have a minimum of ten characters.")]
        [MaxLength(180, ErrorMessage = "The email must have a maximum of one hundred eigthy characters.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", 
            ErrorMessage = "The email is invalid.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The password can't be null.")]
        [MinLength(6, ErrorMessage = "The password must have a minimum of six characters.")]
        [MaxLength(30, ErrorMessage = "The password must have a maximum of thirty characters.")]
        public string Password { get; set; }
    }
}
