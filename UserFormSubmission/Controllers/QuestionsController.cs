using Microsoft.AspNetCore.Mvc;
using UserFormSubmission.DTO;
using USerFormSubmission.BusinessServices.Interfaces;

namespace UserFormSubmission.Controllers
{
    [ApiController]
    [Route("api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // POST api/questions
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questionId = await _questionService.CreateQuestionAsync(questionDto);

            return CreatedAtAction(nameof(GetQuestionById), new { id = questionId }, null);
        }

        // PUT api/questions/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _questionService.UpdateQuestionAsync(id, questionDto);

            return NoContent();
        }

        // GET api/questions/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var questionDto = await _questionService.GetQuestionByIdAsync(id);

            if (questionDto == null)
            {
                return NotFound();
            }

            return Ok(questionDto);
        }

        // DELETE api/questions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteQuestionAsync(id);

            return NoContent();
        }
    }
}
