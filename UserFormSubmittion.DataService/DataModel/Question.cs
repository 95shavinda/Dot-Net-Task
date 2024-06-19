using UserFormSubmission.Enum;

namespace UserFormSubmission.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; }
    }
}
