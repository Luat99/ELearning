using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ELearning.UserManagement.Admin;
using ELearning.Models;
using ELearning.DataContext;
using System.Linq;

namespace ELearning.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ClassListManagement> ClassListManagements { get; set; } = null!;
        public DbSet<JoinOnlineTeaching> JoinOnlineTeachings { get; set; } = null!;
        public DbSet<ManageLearningOutcomes> ManageLearningOutcomess { get; set; } = null!;
        public DbSet<ManageStudentList> ManageStudentLists { get; set; } = null!;
        public DbSet<ManageTeachersList> ManageTeachersLists { get; set; } = null!;
        public DbSet<ManageTeachingMaterials> ManageTeachingMaterialss { get; set; } = null!;
        public DbSet<OnlineTestManager> OnlineTestManagers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
