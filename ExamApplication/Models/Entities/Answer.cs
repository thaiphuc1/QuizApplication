using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Models.Entities
{
    public class Answer
    {
        [Key]
        public long AnswerId { get; set; }
        public required string Content { get; set; }
        public required bool IsCorrect { get; set; }
        [ForeignKey("Question")]

        public long QuestionId { get; set; }
        
        public Question Question { get; set; }
    }
}
