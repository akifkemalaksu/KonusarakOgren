using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using KonusarakOgren.Entities.ResponseModels;
using System.Linq.Expressions;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class ExamRepository : RepositoryBase<KonusarakOgrenContext, Exam, int>, IExamRepository
    {
        public ExamRepository(KonusarakOgrenContext context) : base(context)
        {
        }

        public ICollection<UserTakeExamResponseModel> UserTakeExam(Expression<Func<UserTakeExamResponseModel, bool>> expression)
        {
            return (
                from e in _dbSet
                join t in _context.Topics on e.TopicId equals t.Id
                join q in _context.Questions on e.Id equals q.ExamId
                join uqa in _context.UserQuestionAnswers on q.Id equals uqa.QuestionId
                join u in _context.Users on uqa.UserId equals u.Id
                select new UserTakeExamResponseModel
                {
                    ExamId = e.Id,
                    TopicId = t.Id,
                    UserId = u.Id,
                    Title = t.Title
                }
                ).Where(expression).ToList();
        }

        public ICollection<ExamDto> ExamWithTopic(Expression<Func<Exam, bool>> expression = null)
        {
            return (
                from e in _dbSet
                join t in _context.Topics on e.TopicId equals t.Id
                select new ExamDto
                {
                    CreateDate = e.CreateDate,
                    ExamId = e.Id,
                    Title = t.Title
                }
                    ).ToList();
        }
    }
}