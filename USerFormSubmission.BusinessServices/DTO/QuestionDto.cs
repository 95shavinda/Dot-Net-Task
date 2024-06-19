using UserFormSubmission.Enum;

namespace UserFormSubmission.DTO
{
    public class QuestionDto
    {
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
    }
}
