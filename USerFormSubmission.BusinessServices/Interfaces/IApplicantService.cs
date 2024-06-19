using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFormSubmission.DTO;

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
