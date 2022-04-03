using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IUserQuestionAnswerEngine : IBusinessEngine
    {
        public IDataResult<UserQuestionAnswer> AddUserAnswer(UserQuestionAnswer userQuestionAnswer);

        public IDataResult<UserQuestionAnswer> GetUserAnswer(Expression<Func<UserQuestionAnswer, bool>> expression);

        public IDataResult<ICollection<UserQuestionAnswer>> GetUserAnswers(Expression<Func<UserQuestionAnswer, bool>> expression);

        public IResult DeleteUserAnswer(UserQuestionAnswer userQuestionAnswer);
    }
}