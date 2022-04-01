﻿using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class AnswerEngine : IAnswerEngine
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IUserQuestionAnswerEngine _userQuestionAnswerEngine;

        public AnswerEngine(IAnswerRepository answerRepository, IUserQuestionAnswerEngine userQuestionAnswerEngine)
        {
            _answerRepository = answerRepository;
            _userQuestionAnswerEngine = userQuestionAnswerEngine;
        }

        public IDataResult<Answer> GetAnswer(Expression<Func<Answer, bool>> expression)
        {
            return new SuccessDataResult<Answer>(_answerRepository.Get(expression));
        }

        public IDataResult<ICollection<Answer>> GetAnswers(Expression<Func<Answer, bool>> expression)
        {
            return new SuccessDataResult<ICollection<Answer>>(_answerRepository.GetMany(expression));
        }

        public IDataResult<Answer> AddAnswer(Answer answer)
        {
            _answerRepository.Insert(answer);
            _answerRepository.SaveChanges();
            return new SuccessDataResult<Answer>(answer);
        }

        public IDataResult<UserQuestionAnswer> AddUserAnswerQuestion(UserQuestionAnswer userQuestionAnswer)
        {
            return _userQuestionAnswerEngine.AddUserAnswer(userQuestionAnswer);
        }
    }
}