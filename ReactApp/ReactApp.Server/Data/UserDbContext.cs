using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Models;

namespace ReactApp.Server.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<TheoryExam> TheoryExams { get; set; }

        public DbSet<PracticalExam> PracticalExams { get; set; }
    }
}
