using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFormSubmission.Models;
using UserFormSubmittion.DataService.Data;
using UserFormSubmittion.DataService.Interfaces;

namespace UserFormSubmittion.DataService.Respositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly UserDbContext _context;

        public ApplicantRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();
            return applicant.Id; // return the generated ID
        }

        public async Task UpdateAsync(Applicant User)
        {
            _context.Applicants.Update(User);
            await _context.SaveChangesAsync();
        }

        public async Task<Applicant> GetByIdAsync(int id)
        {
            return await _context.Applicants.FindAsync(id);
        }

        public async Task DeleteAsync(int id)
        {
            var User = await _context.Applicants.FindAsync(id);
            if (User != null)
            {
                _context.Applicants.Remove(User);
                await _context.SaveChangesAsync();
            }
        }
    }
}
