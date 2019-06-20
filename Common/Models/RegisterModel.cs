using System.ComponentModel.DataAnnotations;

namespace Common.Models
{
    public class RegisterModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength( 100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6 )]
        [DataType( DataType.Password )]
        public string Password { get; set; }

        [Required]
        [Compare( "Password", ErrorMessage = "Passwords are not same" )]
        [DataType( DataType.Password )]
        public string PasswordConfirm { get; set; }
    }
}