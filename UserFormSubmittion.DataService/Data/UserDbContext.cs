using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserFormSubmission.Models;

namespace UserFormSubmittion.DataService.Data
{
    public class UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration config) : DbContext(options)
    {
        private readonly IConfiguration _config = config;
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Question> Questions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            //.UseLazyLoadingProxies()
            .UseSqlServer(_config.GetConnectionString("DefaultConnection"));
    }
}
