using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFormSubmission.DTO;
using UserFormSubmission.Models;
using USerFormSubmission.BusinessServices.Interfaces;

namespace USerFormSubmission.BusinessServices.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantBusinessService _applicantBusinessService;

        public ApplicantService(IApplicantBusinessService applicantBusinessService)
        {
            _applicantBusinessService = applicantBusinessService;
        }

        public async Task<int> CreateApplicantAsync(ApplicantDto applicantDto)
        {
            var applicant = MapToApplicant(applicantDto);
            return await _applicantBusinessService.AddAsync(applicant);
        }

        public async Task UpdateApplicantAsync(int id, ApplicantDto applicantDto)
        {
            var existingApplicant = await _applicantBusinessService.GetByIdAsync(id);
            if (existingApplicant == null)
            {
                throw new ArgumentException($"Applicant with ID {id} not found.");
            }

            MapToApplicant(applicantDto, existingApplicant);

            await _applicantBusinessService.UpdateAsync(existingApplicant);
        }

        public async Task<ApplicantDto> GetApplicantByIdAsync(int id)
        {
            var applicant = await _applicantBusinessService.GetByIdAsync(id);
            return MapToApplicantDto(applicant);
        }

        public async Task DeleteApplicantAsync(int id)
        {
            await _applicantBusinessService.DeleteAsync(id);
        }

        private Applicant MapToApplicant(ApplicantDto applicantDto, Applicant existingApplicant = null)
        {
            if (existingApplicant == null)
            {
                existingApplicant = new Applicant();
            }

            existingApplicant.FirstName = applicantDto.FirstName;
            existingApplicant.LastName = applicantDto.LastName;
            existingApplicant.Email = applicantDto.Email;
            existingApplicant.Phone = applicantDto.Phone;
            existingApplicant.IsInternal = applicantDto.IsInternal;
            existingApplicant.Nationality = applicantDto.Nationality;
            existingApplicant.CurrentResidence = applicantDto.CurrentResidence;
            existingApplicant.IdNumber = applicantDto.IdNumber;
            existingApplicant.DateOfBirth = applicantDto.DateOfBirth;
            existingApplicant.Gender = applicantDto.Gender;

            return existingApplicant;
        }

        private ApplicantDto MapToApplicantDto(Applicant applicant)
        {
            return new ApplicantDto
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                Phone = applicant.Phone,
                IsInternal = applicant.IsInternal,
                Nationality = applicant.Nationality,
                CurrentResidence = applicant.CurrentResidence,
                IdNumber = applicant.IdNumber,
                DateOfBirth = applicant.DateOfBirth,
                Gender = applicant.Gender
            };
        }
    }
}
