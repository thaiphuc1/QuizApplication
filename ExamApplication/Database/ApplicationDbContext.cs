using ExamApplication.Database.SeedingData;
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

        //seeding data question, answer and quiz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var seed = new SeedData();
            modelBuilder.ApplyConfiguration<Quiz>(seed);
            modelBuilder.ApplyConfiguration<Question>(seed);
            modelBuilder.ApplyConfiguration<Answer>(seed);
        }

    }
}
