using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFormSubmission.Models;

namespace USerFormSubmission.BusinessServices.Interfaces
{
    public interface IApplicantBusinessService
    {
        Task<int> AddAsync(Applicant applicant);
        Task UpdateAsync(Applicant applicant);
        Task<Applicant> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
