using Microsoft.EntityFrameworkCore;
using UserFormSubmission.Models;

namespace UserFormSubmittion.DataService.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Question> Questions { get; set; }
    }
}
