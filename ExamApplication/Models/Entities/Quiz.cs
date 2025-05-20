using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Models.Entities
{
    public class Quiz
    {
        [Key]
        public long QuizId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int PassPercent { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
