using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class UserQuestionAnswerEngine : IUserQuestionAnswerEngine
    {
        private readonly IUserQuestionAnswerRepository _userQuestionAnswerRepository;

        public UserQuestionAnswerEngine(IUserQuestionAnswerRepository userQuestionAnswerRepository)
        {
            _userQuestionAnswerRepository = userQuestionAnswerRepository;
        }

        public IDataResult<UserQuestionAnswer> GetUserAnswer(Expression<Func<UserQuestionAnswer, bool>> expression)
        {
            return new SuccessDataResult<UserQuestionAnswer>(_userQuestionAnswerRepository.Get(expression));
        }

        public IDataResult<UserQuestionAnswer> AddUserAnswer(UserQuestionAnswer userQuestionAnswer)
        {
            _userQuestionAnswerRepository.Insert(userQuestionAnswer);
            _userQuestionAnswerRepository.SaveChanges();
            return new SuccessDataResult<UserQuestionAnswer>(userQuestionAnswer);
        }
    }
}