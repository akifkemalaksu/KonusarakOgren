using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using System.Linq.Expressions;

namespace KonusarakOgren.DataAccess.Interfaces
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
        public ICollection<UserQuestionDto> UserAnsweredQuestions(Expression<Func<UserQuestionDto, bool>> expression);
    }
}