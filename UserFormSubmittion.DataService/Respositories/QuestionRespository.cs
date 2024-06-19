using Microsoft.EntityFrameworkCore;
using UserFormSubmission.Enum;
using UserFormSubmission.Models;
using UserFormSubmittion.DataService.Data;
using UserFormSubmittion.DataService.Interfaces;

namespace UserFormSubmittion.DataService.Respositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly UserDbContext _context;

        public QuestionRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question.Id; // return the generated ID
        }

        public async Task UpdateAsync(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetByQuestionTypeAsync(QuestionType type)
        {
            return await _context.Questions.Where(x => x.Type == type).ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Question> GetByIdAsync(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<IEnumerable<Question>> GetByUserIdAsync(int userId)
        {
            return await _context.Questions.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
