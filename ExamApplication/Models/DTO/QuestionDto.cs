namespace ExamApplication.Models.DTO
{
    public class QuestionDto
    {
        public long QuestionId { get; set; }
        public string Description { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
