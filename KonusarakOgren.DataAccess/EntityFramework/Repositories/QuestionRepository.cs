using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using System.Linq.Expressions;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class QuestionRepository : RepositoryBase<KonusarakOgrenContext, Question, int>, IQuestionRepository
    {
        public QuestionRepository(KonusarakOgrenContext context) : base(context)
        {
        }

        public ICollection<UserQuestionDto> UserAnsweredQuestions(Expression<Func<UserQuestionDto, bool>> expression)
        {
            return (
                from q in _dbSet
                join uqa in _context.UserQuestionAnswers on q.Id equals uqa.QuestionId
                join a in _context.Answers on uqa.AnswerId equals a.Id
                select new UserQuestionDto
                {
                    Id = q.Id,
                    ExamId = q.ExamId,
                    AnswerId = a.Id,
                    UserId = uqa.UserId,
                    QuestionText = q.QuestionText
                }
             ).Where(expression).ToList();
        }
    }
}