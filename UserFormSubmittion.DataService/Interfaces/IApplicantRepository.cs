using UserFormSubmission.Models;

namespace UserFormSubmittion.DataService.Interfaces
{
    public interface IApplicantRepository
    {
        Task<int> AddAsync(Applicant User);
        Task UpdateAsync(Applicant User);
        Task<Applicant> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
