using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using KonusarakOgren.Entities.ResponseModels;
using System.Linq.Expressions;

namespace KonusarakOgren.DataAccess.Interfaces
{
    public interface IExamRepository : IRepository<Exam, int>
    {
        public ICollection<ExamDto> ExamWithTopic(Expression<Func<Exam, bool>> expression = null);

        public ICollection<UserTakeExamResponseModel> UserTakeExam(Expression<Func<UserTakeExamResponseModel, bool>> expression);
    }
}