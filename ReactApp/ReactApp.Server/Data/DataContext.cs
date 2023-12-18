using API.Server.Models;
using Microsoft.EntityFrameworkCore;
using ReactApp.Server.Models;

namespace ReactApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<TheoryExam> TheoryExams { get; set; }

        public DbSet<PracticalExam> PracticalExams { get; set; }
    }
}
