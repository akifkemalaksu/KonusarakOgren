using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class ExamEngine : IExamEngine
    {
        private readonly IExamRepository _examRepository;
        private readonly IQuestionEngine _questionEngine;

        public ExamEngine(IExamRepository examRepository, IQuestionEngine questionEngine)
        {
            _examRepository = examRepository;
            _questionEngine = questionEngine;
        }

        public IDataResult<Exam> GetExam(Expression<Func<Exam, bool>> expression)
        {
            return new SuccessDataResult<Exam>(_examRepository.Get(expression));
        }

        public IDataResult<ICollection<Exam>> GetExams(Expression<Func<Exam, bool>> expression)
        {
            return new SuccessDataResult<ICollection<Exam>>(_examRepository.GetMany(expression));
        }

        public IDataResult<Exam> AddExam(Exam exam)
        {
            _examRepository.Insert(exam);
            _examRepository.SaveChanges();
            return new SuccessDataResult<Exam>(exam);
        }

        public IDataResult<Question> AddQuestion(Question question)
        {
            return _questionEngine.AddQuestion(question);
        }

        public IDataResult<Answer> AddAnswer(Answer answer)
        {
            return _questionEngine.AddAnswer(answer);
        }
    }
}