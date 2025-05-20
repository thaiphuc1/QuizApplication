using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ExamApplication.Models.Entities
{
    public class UserDoExam
    {
        [Key]
        public long DoExamId { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public float Score { get; set; }
        public bool Passed { get; set; }
        [Required]

        public Guid UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Quiz")]

        public long QuizId { get; set; }

        public Quiz Quiz { get; set; }
        


    }
}
