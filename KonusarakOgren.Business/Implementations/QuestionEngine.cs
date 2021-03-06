using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class QuestionEngine : IQuestionEngine
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerEngine _answerEngine;

        public QuestionEngine(IQuestionRepository questionRepository, IAnswerEngine answerEngine)
        {
            _questionRepository = questionRepository;
            _answerEngine = answerEngine;
        }

        public IDataResult<Question> AddQuestion(Question question)
        {
            _questionRepository.Insert(question);
            _questionRepository.SaveChanges();
            return new SuccessDataResult<Question>(question);
        }

        public IResult DeleteQuestion(Question question)
        {
            var questionAnswersResult = _answerEngine.GetAnswers(a => a.QuestionId == question.Id);
            if (questionAnswersResult.Data != null)
            {
                (questionAnswersResult.Data as List<Answer>).ForEach(answer => _answerEngine.DeleteAnswer(answer));
            }
            _questionRepository.Delete(question.Id);
            _questionRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<Question> GetQuestion(Expression<Func<Question, bool>> expression)
        {
            return new SuccessDataResult<Question>(_questionRepository.Get(expression));
        }

        public IDataResult<ICollection<Question>> GetQuestions(Expression<Func<Question, bool>> expression)
        {
            return new SuccessDataResult<ICollection<Question>>(_questionRepository.GetMany(expression));
        }

        public IDataResult<Question> UpdateQuestion(Question question)
        {
            _questionRepository.Update(question);
            _questionRepository.SaveChanges();
            return new SuccessDataResult<Question>(question);
        }

        public IDataResult<ICollection<UserQuestionDto>> UserAnsweredQuestions(Expression<Func<UserQuestionDto, bool>> expression)
        {
            return new SuccessDataResult<ICollection<UserQuestionDto>>(_questionRepository.UserAnsweredQuestions(expression));
        }
    }
}