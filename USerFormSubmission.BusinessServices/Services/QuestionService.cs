using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USerFormSubmission.BusinessServices.Interfaces;
using UserFormSubmission.DTO;
using UserFormSubmission.Models;
using UserFormSubmittion.DataService.Interfaces;
using UserFormSubmission.Enum;

namespace USerFormSubmission.BusinessServices.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<int> CreateQuestionAsync(QuestionDto questionDto)
        {
            var question = MapToQuestion(questionDto);
            return await _questionRepository.AddAsync(question);
        }

        public async Task UpdateQuestionAsync(int id, QuestionDto questionDto)
        {
            var existingQuestion = await _questionRepository.GetByIdAsync(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException($"Question with ID {id} not found.");
            }

            MapToQuestion(questionDto, existingQuestion);

            await _questionRepository.UpdateAsync(existingQuestion);
        }

        public async Task<IEnumerable<QuestionDto>> GetQuestionByQuestionTypeAsync(QuestionType type)
        {
            var questions = await _questionRepository.GetByQuestionTypeAsync(type);
            return questions.Select(MapToQuestionDto);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionRepository.DeleteAsync(id);
        }

        private Question MapToQuestion(QuestionDto questionDto, Question existingQuestion = null)
        {
            if (existingQuestion == null)
            {
                existingQuestion = new Question();
            }

            existingQuestion.UserId = questionDto.UserId;
            existingQuestion.QuestionText = questionDto.QuestionText;
            existingQuestion.Type = questionDto.Type;

            return existingQuestion;
        }

        private QuestionDto MapToQuestionDto(Question question)
        {
            return new QuestionDto
            {
                QuestionText = question.QuestionText,
                Type = question.Type,
                UserId = question.UserId
            };
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(int id)
        {
            var questions = await _questionRepository.GetByIdAsync(id);
            return MapToQuestionDto(questions);
        }
    }
}
