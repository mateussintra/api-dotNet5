using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Login can't be empty.")]
        public string  Login { get; set; }

        [Required(ErrorMessage = "The Password can't be empty.")]
        public string  Password { get; set; }
    }
}
