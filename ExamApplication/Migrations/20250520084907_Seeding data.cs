using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExamApplication.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quizes",
                columns: new[] { "QuizId", "Description", "PassPercent", "Title" },
                values: new object[,]
                {
                    { 1L, "Kiểm tra kiến thức lịch sử Việt Nam", 60, "Trắc nghiệm Lịch sử" },
                    { 2L, "Kiểm tra kiến thức địa lý cơ bản", 70, "Trắc nghiệm Địa lý" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Content", "QuizId" },
                values: new object[,]
                {
                    { 1L, "Bác Hồ sinh năm bao nhiêu?", 1L },
                    { 2L, "Nước Việt Nam Dân chủ Cộng hòa ra đời năm nào?", 1L },
                    { 3L, "Chiến dịch Điện Biên Phủ diễn ra năm nào?", 1L },
                    { 4L, "Nhà Trần thành lập năm bao nhiêu?", 1L },
                    { 5L, "Phong trào Cần Vương bùng nổ năm nào?", 1L },
                    { 6L, "Đỉnh núi cao nhất Việt Nam là?", 2L },
                    { 7L, "Sông dài nhất Việt Nam là?", 2L },
                    { 8L, "Vịnh nổi tiếng ở Quảng Ninh là?", 2L },
                    { 9L, "Thủ đô của Việt Nam là?", 2L },
                    { 10L, "Tỉnh nào nằm ở cực Nam của Việt Nam?", 2L }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "Content", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1L, "1890", true, 1L },
                    { 2L, "1900", false, 1L },
                    { 3L, "1885", false, 1L },
                    { 4L, "1911", false, 1L },
                    { 5L, "1945", true, 2L },
                    { 6L, "1930", false, 2L },
                    { 7L, "1954", false, 2L },
                    { 8L, "1975", false, 2L },
                    { 9L, "1954", true, 3L },
                    { 10L, "1946", false, 3L },
                    { 11L, "1975", false, 3L },
                    { 12L, "1930", false, 3L },
                    { 13L, "1225", true, 4L },
                    { 14L, "938", false, 4L },
                    { 15L, "1010", false, 4L },
                    { 16L, "1400", false, 4L },
                    { 17L, "1885", true, 5L },
                    { 18L, "1858", false, 5L },
                    { 19L, "1945", false, 5L },
                    { 20L, "1975", false, 5L },
                    { 21L, "Fansipan", true, 6L },
                    { 22L, "Hoàng Liên Sơn", false, 6L },
                    { 23L, "Ba Vì", false, 6L },
                    { 24L, "Langbiang", false, 6L },
                    { 25L, "Sông Hồng", true, 7L },
                    { 26L, "Sông Đà", false, 7L },
                    { 27L, "Sông Mekong", false, 7L },
                    { 28L, "Sông Cửu Long", false, 7L },
                    { 29L, "Vịnh Hạ Long", true, 8L },
                    { 30L, "Vịnh Cam Ranh", false, 8L },
                    { 31L, "Vịnh Vân Phong", false, 8L },
                    { 32L, "Vịnh Quy Nhơn", false, 8L },
                    { 33L, "Hà Nội", true, 9L },
                    { 34L, "Huế", false, 9L },
                    { 35L, "Hồ Chí Minh", false, 9L },
                    { 36L, "Đà Nẵng", false, 9L },
                    { 37L, "Cà Mau", true, 10L },
                    { 38L, "Kiên Giang", false, 10L },
                    { 39L, "An Giang", false, 10L },
                    { 40L, "Bạc Liêu", false, 10L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 14L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 15L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 16L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 17L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 18L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 19L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 20L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 21L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 22L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 23L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 24L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 25L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 26L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 27L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 28L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 29L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 30L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 31L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 32L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 33L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 34L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 35L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 36L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 37L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 38L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 39L);

            migrationBuilder.DeleteData(
                table: "Answers",
                keyColumn: "AnswerId",
                keyValue: 40L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Quizes",
                keyColumn: "QuizId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Quizes",
                keyColumn: "QuizId",
                keyValue: 2L);
        }
    }
}
