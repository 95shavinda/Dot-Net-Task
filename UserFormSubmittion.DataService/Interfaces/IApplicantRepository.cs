using UserFormSubmission.Models;

namespace UserFormSubmittion.DataService.Interfaces
{
    public interface IApplicantRepository
    {
        Task<int> AddAsync(Applicant applicant);
        Task UpdateAsync(Applicant applicant);
        Task<Applicant> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
