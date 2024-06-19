using UserFormSubmission.BusinessServices.DTO;
using UserFormSubmission.Models;
using USerFormSubmission.BusinessServices.Interfaces;
using UserFormSubmittion.DataService.Interfaces;

namespace USerFormSubmission.BusinessServices.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;

        public ApplicantService(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;
        }

        public async Task<int> CreateApplicantAsync(ApplicantDto applicantDto)
        {
            var applicant = MapToApplicant(applicantDto);
            return await _applicantRepository.AddAsync(applicant);
        }

        public async Task UpdateApplicantAsync(int id, ApplicantDto applicantDto)
        {
            var existingApplicant = await _applicantRepository.GetByIdAsync(id);
            if (existingApplicant == null)
            {
                throw new ArgumentException($"Applicant with ID {id} not found.");
            }

            MapToApplicant(applicantDto, existingApplicant);

            await _applicantRepository.UpdateAsync(existingApplicant);
        }

        public async Task<ApplicantDto> GetApplicantByIdAsync(int id)
        {
            var applicant = await _applicantRepository.GetByIdAsync(id);
            return MapToApplicantDto(applicant);
        }

        public async Task DeleteApplicantAsync(int id)
        {
            await _applicantRepository.DeleteAsync(id);
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
                //Questions = new Question
            };
        }
    }
}
