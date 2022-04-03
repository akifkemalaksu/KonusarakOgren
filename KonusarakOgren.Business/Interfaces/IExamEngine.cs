using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IExamEngine : IBusinessEngine
    {
        public IDataResult<Exam> AddExam(Exam exam);

        public IDataResult<Exam> GetExam(Expression<Func<Exam, bool>> expression);

        public IDataResult<ICollection<Exam>> GetExams(Expression<Func<Exam, bool>> expression);

        public IDataResult<ICollection<ExamDto>> GetExamWithTopic(Expression<Func<Exam, bool>> expression = null);

        public IResult DeleteExam(int examId);

        public IDataResult<ICollection<UserTakeExamResponseModel>> UserTakeExam(Expression<Func<UserTakeExamResponseModel, bool>> expression);

        public IDataResult<TakeExamResponseModel> GetTakeExam(int examId);

        public IResult CreateExam(AddExamRequestModel addExam);

        public IResult SolveExam(ICollection<AnswerQuestionRequestModel> answerQuestions);
    }
}