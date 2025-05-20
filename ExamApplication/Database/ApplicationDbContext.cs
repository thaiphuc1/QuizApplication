using ExamApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<UserDoExam> AttemptExam { get; set; }

    }
}
