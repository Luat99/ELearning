
using System.ComponentModel.DataAnnotations;
namespace ELearning.UserManagement.Admin
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "CurrentPassword is required")]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "NewPassword is required")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        public string? ConfirmPassword { get; set; }
    }
}
