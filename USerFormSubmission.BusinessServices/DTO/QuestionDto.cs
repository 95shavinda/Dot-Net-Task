using UserFormSubmission.Enum;

namespace UserFormSubmission.DTO
{
    public class QuestionDto
    {
        public int UserId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
    }
}
