using Microsoft.AspNetCore.Mvc;
using UserFormSubmission.DTO;
using USerFormSubmission.BusinessServices.Interfaces;

namespace UserFormSubmission.Controllers
{
    [ApiController]
    [Route("api/applicants")]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantService _applicantService;

        public ApplicantsController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        // POST api/applicants
        [HttpPost]
        public async Task<IActionResult> CreateApplicant([FromBody] ApplicantDto applicantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var applicantId = await _applicantService.CreateApplicantAsync(applicantDto);

            return CreatedAtAction(nameof(GetApplicantById), new { id = applicantId }, null);
        }

        // PUT api/applicants/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant(int id, [FromBody] ApplicantDto applicantDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _applicantService.UpdateApplicantAsync(id, applicantDto);

            return NoContent();
        }

        // GET api/applicants/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicantById(int id)
        {
            var applicantDto = await _applicantService.GetApplicantByIdAsync(id);

            if (applicantDto == null)
            {
                return NotFound();
            }

            return Ok(applicantDto);
        }

        // DELETE api/applicants/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicant(int id)
        {
            await _applicantService.DeleteApplicantAsync(id);

            return NoContent();
        }
    }
}
