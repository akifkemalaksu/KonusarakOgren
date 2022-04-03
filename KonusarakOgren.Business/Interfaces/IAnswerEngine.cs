using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IAnswerEngine : IBusinessEngine
    {
        public IDataResult<Answer> AddAnswer(Answer answer);

        public IDataResult<Answer> GetAnswer(Expression<Func<Answer, bool>> expression);

        public IDataResult<ICollection<Answer>> GetAnswers(Expression<Func<Answer, bool>> expression);

        public IResult DeleteAnswer(Answer answer);
    }
}