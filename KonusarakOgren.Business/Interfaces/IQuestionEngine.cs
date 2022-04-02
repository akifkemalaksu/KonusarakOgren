using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IQuestionEngine : IBusinessEngine
    {
        public IDataResult<Question> AddQuestion(Question question);

        public IDataResult<Question> UpdateQuestion(Question question);

        public IResult DeleteQuestion(Question question);

        public IDataResult<Question> GetQuestion(Expression<Func<Question, bool>> expression);

        public IDataResult<ICollection<Question>> GetQuestions(Expression<Func<Question, bool>> expression);

        public IDataResult<Answer> AddAnswer(Answer answer);
    }
}