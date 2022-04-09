using System.ComponentModel.DataAnnotations;
namespace ELearning.UserManagement.Administrators
{
    public class LoginAdministrators
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
