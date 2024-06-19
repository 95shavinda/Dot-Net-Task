﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USerFormSubmission.BusinessServices.Interfaces;
using UserFormSubmission.DTO;
using UserFormSubmission.Models;

namespace USerFormSubmission.BusinessServices.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionBusinessService _questionBusinessService;

        public QuestionService(IQuestionBusinessService questionBusinessService)
        {
            _questionBusinessService = questionBusinessService;
        }

        public async Task<int> CreateQuestionAsync(QuestionDto questionDto)
        {
            var question = MapToQuestion(questionDto);
            return await _questionBusinessService.AddAsync(question);
        }

        public async Task UpdateQuestionAsync(int id, QuestionDto questionDto)
        {
            var existingQuestion = await _questionBusinessService.GetByIdAsync(id);
            if (existingQuestion == null)
            {
                throw new ArgumentException($"Question with ID {id} not found.");
            }

            MapToQuestion(questionDto, existingQuestion);

            await _questionBusinessService.UpdateAsync(existingQuestion);
        }

        public async Task<QuestionDto> GetQuestionByIdAsync(int id)
        {
            var question = await _questionBusinessService.GetByIdAsync(id);
            return MapToQuestionDto(question);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await _questionBusinessService.DeleteAsync(id);
        }

        private Question MapToQuestion(QuestionDto questionDto, Question existingQuestion = null)
        {
            if (existingQuestion == null)
            {
                existingQuestion = new Question();
            }

            existingQuestion.QuestionText = questionDto.QuestionText;
            existingQuestion.Type = questionDto.Type;
            existingQuestion.Options = questionDto.Options;

            return existingQuestion;
        }

        private QuestionDto MapToQuestionDto(Question question)
        {
            return new QuestionDto
            {
                QuestionText = question.QuestionText,
                Type = question.Type,
                Options = question.Options
            };
        }
    }
}