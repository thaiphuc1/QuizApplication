using System.Security.Claims;
using ExamApplication.Database;
using ExamApplication.Models.DTO;
using ExamApplication.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        //Database
        private readonly ApplicationDbContext dbContext;

        public QuizController(ApplicationDbContext context)
        {
            this.dbContext = context;

        }

        //start quiz
        [HttpPost("{quizId}/start")]
        public IActionResult StartQuiz(long quizId, string fullname)
        {

            var user = dbContext.Users.FirstOrDefault(a => a.Fullname == fullname);
            if (user == null)
                return NotFound("User not found");

            var userDoExam = new UserDoExam
            {
                QuizId = quizId,
                UserId = user.UserId,
                Starttime = DateTime.Now,
                Passed = false
            };

            dbContext.AttemptExam.Add(userDoExam);
            dbContext.SaveChanges();

            return Ok(new { DoExamId = userDoExam.DoExamId, QuizId = quizId });
        }

        //Get a list of question for the quiz
        [HttpGet("{quizId}/questions")]

        public IActionResult GetQuiz(long quizId)
        {
            var quizQuestions = dbContext.Questions.Include(a => a.Answers).Where(q => q.QuizId == quizId).Select
                (q => new QuestionDto
                {
                    QuestionId = q.QuestionId,
                    Description = q.Content,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        AnswerId = a.AnswerId,
                        Content = a.Content,
                    }).ToList()
                }).ToList();
            return Ok(quizQuestions);
        }

        //User answer and return feedback
        [HttpPost]
        public IActionResult AnswerQuestion( UserAnswerDto userAnswerDto)
        {
            var question = dbContext.Questions.Include(a => a.Answers).Where(q => q.QuestionId == userAnswerDto.QuestionId && q.QuizId == userAnswerDto.QuizId).First();
            if (question == null)
            {
                return BadRequest();
            }
            var answers = question.Answers;

            //check answer is valid or not
            var selectedAnswer = question.Answers.FirstOrDefault(a => a.AnswerId == userAnswerDto.AnswerId);
            if (selectedAnswer == null)
            {
                return BadRequest("Answer not found.");
            }
            //confirm answer
            bool isCorrect = selectedAnswer.IsCorrect;

            var useranswer = new UserAnswer
            {
                DoExamId = userAnswerDto.DoExamId,
                QuestionId = userAnswerDto.QuestionId,
                AnswerId = userAnswerDto.AnswerId,
                UserDoExam = dbContext.AttemptExam.Where(ud => ud.DoExamId == userAnswerDto.DoExamId).FirstOrDefault(),
                IsCorrect = isCorrect,
            };
            var existing = dbContext.UserAnswers.FirstOrDefault(a => a.DoExamId == userAnswerDto.DoExamId && a.QuestionId == userAnswerDto.QuestionId);

            if (existing != null)
            {
                existing.AnswerId = userAnswerDto.AnswerId;
                existing.IsCorrect = isCorrect;
                dbContext.UserAnswers.Update(existing);
            }
            else
            {
                dbContext.UserAnswers.Add(useranswer);
            }

            dbContext.SaveChanges();
            return Ok(isCorrect);
        }


        //Take each question in quiz
        [HttpGet("{quizid}/question/{index}")]
        public IActionResult GetEachQuestion(long quizid, int index)
        {
            int quantity = dbContext.Questions.Count(q => q.QuizId == quizid);
            var question = dbContext.Questions.Include(a => a.Answers).Where(q => q.QuizId == quizid)
                .OrderBy(q => q.QuestionId).Skip(index).Take(1).Select
                (q => new QuestionDto
                {
                    QuestionId = q.QuestionId,
                    Description = q.Content,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        AnswerId = a.AnswerId,
                        Content = a.Content,
                    }).ToList()
                }).FirstOrDefault();
            if (index == null || index < 0 || index >quantity)
            {
                return NotFound("No question");
            }
            return Ok(question);
        }


        [HttpPost("{doExamId}/submit")]
        public IActionResult SubmitQuiz(long doExamId)
        {
            var doExam = dbContext.AttemptExam.Where(x => x.DoExamId == doExamId).FirstOrDefault();
            if (doExam == null)
                return NotFound("Exam not found");

            var totalQuestions = dbContext.Questions
                .Where(q => q.QuizId == doExam.QuizId).Count();

            var correctAnswers = dbContext.UserAnswers
                .Where(x => x.DoExamId == doExamId && x.IsCorrect).Count();

            float score = (float)correctAnswers / totalQuestions;

            var user = dbContext.Users.Where(u => u.UserId == doExam.UserId).FirstOrDefault();
            var ispassed = score * 100 >= dbContext.Quizes
                .Where(q => q.QuizId == doExam.QuizId)
                .Select(q => q.PassPercent)
                .FirstOrDefault();
            doExam.UserId = user.UserId;
            doExam.Score = score;
            doExam.Endtime = DateTime.Now;
            doExam.Passed = ispassed;
            doExam.DoExamId = doExamId;
            dbContext.AttemptExam.Update(doExam);
            dbContext.SaveChanges();

            return Ok(new
            {
                TotalTime = doExam.Endtime - doExam.Starttime,
                NumberCorrect = correctAnswers,
                Message = ispassed == true ? "You are Passed" : "You are Failed"
            });
        }

        //Review User Answer
        [HttpGet("{quizid}/result/{fullname}/{attempt}")]
        public IActionResult GetReviewExam(long quizid, long attempt, string fullname)
        {         
            //get user
            var user = dbContext.Users.FirstOrDefault(u => u.Fullname == fullname);
            if (user == null)
            {
                return NotFound("User not found");
            }

            //get UserDoExam
            var doExam = dbContext.AttemptExam.Include(e => e.Quiz).FirstOrDefault(x => x.DoExamId == attempt && x.UserId == user.UserId && x.QuizId == quizid);

            if (doExam == null)
                return NotFound("Exam attempt not found for this user.");

            //Get list question of quizz
            var questions = dbContext.Questions.Where(q => q.QuizId == quizid).Include(q => q.Answers).ToList();

            //Get all answer user choose in quiz
            var userAnswers = dbContext.UserAnswers.Where(ua => ua.DoExamId == attempt).ToList();

            //Get list of question include answer right and user answer
            var result = questions.Select(q =>
            {
                var selectedAnswer = userAnswers.FirstOrDefault(a => a.QuestionId == q.QuestionId);
                var correctAnswer = q.Answers.FirstOrDefault(a => a.IsCorrect);

                return new
                {
                    Question = q.Content,
                    SelectedAnswer = selectedAnswer != null
                        ? q.Answers.FirstOrDefault(a => a.AnswerId == selectedAnswer.AnswerId)?.Content
                        : "No answer",
                    CorrectAnswer = correctAnswer?.Content,
                    IsCorrect = selectedAnswer != null && selectedAnswer.IsCorrect ? true : false
                };
            });

            return Ok(new
            {
                User = user.Fullname,
                Quiz = doExam.Quiz.Title,
                Score = doExam.Score,
                Passed = doExam.Passed,
                TotalTime = doExam.Endtime - doExam.Starttime,
                Answers = result
            });
        }
    }
}
