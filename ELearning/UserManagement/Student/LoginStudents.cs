using System.ComponentModel.DataAnnotations;
namespace ELearning.UserManagement.Student
{
    public class LoginStudents
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
