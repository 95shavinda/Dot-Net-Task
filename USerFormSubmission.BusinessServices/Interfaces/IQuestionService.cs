using UserFormSubmission.DTO;

namespace USerFormSubmission.BusinessServices.Interfaces
{
    public interface IQuestionService
    {
        Task<int> CreateQuestionAsync(QuestionDto questionDto);
        Task UpdateQuestionAsync(int id, QuestionDto questionDto);
        Task<QuestionDto> GetQuestionByIdAsync(int id);
        Task DeleteQuestionAsync(int id);
    }
}
