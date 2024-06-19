using UserFormSubmission.BusinessServices.DTO;

namespace USerFormSubmission.BusinessServices.Interfaces
{
    public interface IApplicantService
    {
        Task<int> CreateApplicantAsync(ApplicantDto applicantDto);
        Task UpdateApplicantAsync(int id, ApplicantDto applicantDto);
        Task<ApplicantDto> GetApplicantByIdAsync(int id);
        Task DeleteApplicantAsync(int id);
    }
}
