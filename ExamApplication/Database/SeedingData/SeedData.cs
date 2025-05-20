namespace ExamApplication.Database.SeedingData
{
    using ExamApplication.Models.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SeedData :
        IEntityTypeConfiguration<Quiz>,
        IEntityTypeConfiguration<Question>,
        IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasData(
                new Quiz { QuizId = 1, Title = "Trắc nghiệm Lịch sử", Description = "Kiểm tra kiến thức lịch sử Việt Nam", PassPercent = 60 },
                new Quiz { QuizId = 2, Title = "Trắc nghiệm Địa lý", Description = "Kiểm tra kiến thức địa lý cơ bản", PassPercent = 70 }
            );
        }

        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasData(
                // QuizId = 1 
                new Question { QuestionId = 1, QuizId = 1, Content = "Bác Hồ sinh năm bao nhiêu?" },
                new Question { QuestionId = 2, QuizId = 1, Content = "Nước Việt Nam Dân chủ Cộng hòa ra đời năm nào?" },
                new Question { QuestionId = 3, QuizId = 1, Content = "Chiến dịch Điện Biên Phủ diễn ra năm nào?" },
                new Question { QuestionId = 4, QuizId = 1, Content = "Nhà Trần thành lập năm bao nhiêu?" },
                new Question { QuestionId = 5, QuizId = 1, Content = "Phong trào Cần Vương bùng nổ năm nào?" },

                // QuizId = 2
                new Question { QuestionId = 6, QuizId = 2, Content = "Đỉnh núi cao nhất Việt Nam là?" },
                new Question { QuestionId = 7, QuizId = 2, Content = "Sông dài nhất Việt Nam là?" },
                new Question { QuestionId = 8, QuizId = 2, Content = "Vịnh nổi tiếng ở Quảng Ninh là?" },
                new Question { QuestionId = 9, QuizId = 2, Content = "Thủ đô của Việt Nam là?" },
                new Question { QuestionId = 10, QuizId = 2, Content = "Tỉnh nào nằm ở cực Nam của Việt Nam?" }
            );
        }

        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasData(
                // Q1
                new Answer { AnswerId = 1, QuestionId = 1, Content = "1890", IsCorrect = true },
                new Answer { AnswerId = 2, QuestionId = 1, Content = "1900", IsCorrect = false },
                new Answer { AnswerId = 3, QuestionId = 1, Content = "1885", IsCorrect = false },
                new Answer { AnswerId = 4, QuestionId = 1, Content = "1911", IsCorrect = false },

                // Q2
                new Answer { AnswerId = 5, QuestionId = 2, Content = "1945", IsCorrect = true },
                new Answer { AnswerId = 6, QuestionId = 2, Content = "1930", IsCorrect = false },
                new Answer { AnswerId = 7, QuestionId = 2, Content = "1954", IsCorrect = false },
                new Answer { AnswerId = 8, QuestionId = 2, Content = "1975", IsCorrect = false },

                // Q3
                new Answer { AnswerId = 9, QuestionId = 3, Content = "1954", IsCorrect = true },
                new Answer { AnswerId = 10, QuestionId = 3, Content = "1946", IsCorrect = false },
                new Answer { AnswerId = 11, QuestionId = 3, Content = "1975", IsCorrect = false },
                new Answer { AnswerId = 12, QuestionId = 3, Content = "1930", IsCorrect = false },

                // Q4
                new Answer { AnswerId = 13, QuestionId = 4, Content = "1225", IsCorrect = true },
                new Answer { AnswerId = 14, QuestionId = 4, Content = "938", IsCorrect = false },
                new Answer { AnswerId = 15, QuestionId = 4, Content = "1010", IsCorrect = false },
                new Answer { AnswerId = 16, QuestionId = 4, Content = "1400", IsCorrect = false },

                // Q5
                new Answer { AnswerId = 17, QuestionId = 5, Content = "1885", IsCorrect = true },
                new Answer { AnswerId = 18, QuestionId = 5, Content = "1858", IsCorrect = false },
                new Answer { AnswerId = 19, QuestionId = 5, Content = "1945", IsCorrect = false },
                new Answer { AnswerId = 20, QuestionId = 5, Content = "1975", IsCorrect = false },

                // Q6
                new Answer { AnswerId = 21, QuestionId = 6, Content = "Fansipan", IsCorrect = true },
                new Answer { AnswerId = 22, QuestionId = 6, Content = "Hoàng Liên Sơn", IsCorrect = false },
                new Answer { AnswerId = 23, QuestionId = 6, Content = "Ba Vì", IsCorrect = false },
                new Answer { AnswerId = 24, QuestionId = 6, Content = "Langbiang", IsCorrect = false },

                // Q7
                new Answer { AnswerId = 25, QuestionId = 7, Content = "Sông Hồng", IsCorrect = true },
                new Answer { AnswerId = 26, QuestionId = 7, Content = "Sông Đà", IsCorrect = false },
                new Answer { AnswerId = 27, QuestionId = 7, Content = "Sông Mekong", IsCorrect = false },
                new Answer { AnswerId = 28, QuestionId = 7, Content = "Sông Cửu Long", IsCorrect = false },

                // Q8
                new Answer { AnswerId = 29, QuestionId = 8, Content = "Vịnh Hạ Long", IsCorrect = true },
                new Answer { AnswerId = 30, QuestionId = 8, Content = "Vịnh Cam Ranh", IsCorrect = false },
                new Answer { AnswerId = 31, QuestionId = 8, Content = "Vịnh Vân Phong", IsCorrect = false },
                new Answer { AnswerId = 32, QuestionId = 8, Content = "Vịnh Quy Nhơn", IsCorrect = false },

                // Q9
                new Answer { AnswerId = 33, QuestionId = 9, Content = "Hà Nội", IsCorrect = true },
                new Answer { AnswerId = 34, QuestionId = 9, Content = "Huế", IsCorrect = false },
                new Answer { AnswerId = 35, QuestionId = 9, Content = "Hồ Chí Minh", IsCorrect = false },
                new Answer { AnswerId = 36, QuestionId = 9, Content = "Đà Nẵng", IsCorrect = false },

                // Q10
                new Answer { AnswerId = 37, QuestionId = 10, Content = "Cà Mau", IsCorrect = true },
                new Answer { AnswerId = 38, QuestionId = 10, Content = "Kiên Giang", IsCorrect = false },
                new Answer { AnswerId = 39, QuestionId = 10, Content = "An Giang", IsCorrect = false },
                new Answer { AnswerId = 40, QuestionId = 10, Content = "Bạc Liêu", IsCorrect = false }
            );
        }
    }

}
