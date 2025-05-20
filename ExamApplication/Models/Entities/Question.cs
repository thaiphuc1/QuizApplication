using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Models.Entities
{
    public class Question
    {
        [Key]
        public long QuestionId { get; set; }
        public required string Content { get; set; }
        [ForeignKey("Quiz")]

        public long QuizId { get; set; }

        public Quiz Quiz { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
