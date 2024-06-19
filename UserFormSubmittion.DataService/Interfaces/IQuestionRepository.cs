using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserFormSubmission.Models;

namespace UserFormSubmittion.DataService.Interfaces
{
    public interface IQuestionRepository
    {
        Task<int> AddAsync(Question question);
        Task UpdateAsync(Question question);
        Task<Question> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
