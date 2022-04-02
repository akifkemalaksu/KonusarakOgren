using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IExamEngine : IBusinessEngine
    {
        public IDataResult<Exam> AddExam(Exam exam);

        public IDataResult<Exam> GetExam(Expression<Func<Exam, bool>> expression);

        public IDataResult<ICollection<Exam>> GetExams(Expression<Func<Exam, bool>> expression);

        public IDataResult<Question> AddQuestion(Question question);

        public IDataResult<Answer> AddAnswer(Answer answer);
    }
}