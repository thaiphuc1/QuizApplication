using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamApplication.Models.Entities
{
    public class UserAnswer
    {
        [Key]
        public long UserAnswerId { get; set; }

        public long DoExamId { get; set; }  // Foreign Key
        public UserDoExam UserDoExam { get; set; }


        public long QuestionId { get; set; }
        public long AnswerId { get; set; }
       


        [Required]
        public bool IsCorrect { get; set; }
    }
}
