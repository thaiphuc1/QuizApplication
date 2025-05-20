using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ExamApplication.Models.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Fullname { get; set; }
        
    }
}
