using UserFormSubmission.DTO;
using UserFormSubmission.Models;

namespace UserFormSubmission.BusinessServices.DTO
{
    public class ApplicantDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsInternal { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string CurrentResidence { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public ICollection<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
    }
}
