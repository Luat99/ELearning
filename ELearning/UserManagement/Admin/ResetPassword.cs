using System.ComponentModel.DataAnnotations;
namespace ELearning.UserManagement.Admin
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "User Name is required")]

        public string? UserName { get; set; }
        [Required(ErrorMessage = "NewPassword is required")]

        public string? NewPassword { get; set; }
        [Required(ErrorMessage = "ComfirmNewPassword is required")]

        public string? ComfirmNewPassword { get; set; }
        public string? Token { get; set; }
    }
}
