using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExamApplication.Models.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        public long? Quizid { get; set; }
        public long? AttemptId { get; set; }
        public float? Mark { get; set; }
        public bool? IsPass { get; set; }
    }
}
