using AutoMapper;
using KonusarakOgren.Business.Constants;
using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Business.Services;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.Dtos;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class ExamEngine : IExamEngine
    {
        private readonly IExamRepository _examRepository;
        private readonly IUserQuestionAnswerEngine _userQuestionAnswerEngine;
        private readonly IAnswerEngine _answerEngine;
        private readonly IQuestionEngine _questionEngine;
        private readonly ITopicEngine _topicEngine;
        private readonly IMapper _mapper;

        public ExamEngine(IExamRepository examRepository, IUserQuestionAnswerEngine userQuestionAnswerEngine, IAnswerEngine answerEngine, IQuestionEngine questionEngine, ITopicEngine topicEngine, IMapper mapper)
        {
            _examRepository = examRepository;
            _userQuestionAnswerEngine = userQuestionAnswerEngine;
            _answerEngine = answerEngine;
            _questionEngine = questionEngine;
            _topicEngine = topicEngine;
            _mapper = mapper;
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

        public IDataResult<ICollection<ExamDto>> GetExamWithTopic(Expression<Func<Exam, bool>> expression = null)
        {
            return new SuccessDataResult<ICollection<ExamDto>>(_examRepository.ExamWithTopic(expression));
        }

        public IResult DeleteExam(int examId)
        {
            var exam = _examRepository.Get(e => e.Id == examId);
            if (exam != null)
            {
                var examQuestionsResult = _questionEngine.GetQuestions(q => q.ExamId == exam.Id);
                if (examQuestionsResult.Data != null)
                {
                    (examQuestionsResult.Data as List<Question>).ForEach(question => _questionEngine.DeleteQuestion(question));
                }
                _examRepository.Delete(exam.Id);
                _examRepository.SaveChanges();

                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotFound);
        }

        public IDataResult<ICollection<UserTakeExamResponseModel>> UserTakeExam(Expression<Func<UserTakeExamResponseModel, bool>> expression)
        {
            return new SuccessDataResult<ICollection<UserTakeExamResponseModel>>(_examRepository.UserTakeExam(expression));
        }

        public IDataResult<TakeExamResponseModel> GetTakeExam(int examId)
        {
            var exam = _examRepository.Get(e => e.Id.Equals(examId));
            if (exam != null)
            {
                var topic = _topicEngine.GetTopic(t => t.Id.Equals(exam.TopicId));
                if (topic.Success && topic.Data != null)
                {
                    TakeExamResponseModel takeExam = _mapper.Map<TakeExamResponseModel>(topic.Data);
                    var questions = _questionEngine.GetQuestions(q => q.ExamId.Equals(exam.Id));
                    if (questions.Success && questions.Data != null)
                    {
                        takeExam.Questions = _mapper.Map<ICollection<TakeQuestionModel>>(questions.Data);
                        (takeExam.Questions as List<TakeQuestionModel>).ForEach(q =>
                        {
                            var answers = _answerEngine.GetAnswers(a => a.QuestionId.Equals(q.Id));
                            q.Answers = _mapper.Map<ICollection<TakeAnswerModel>>(answers.Data);
                        });

                        return new SuccessDataResult<TakeExamResponseModel>(takeExam);
                    }
                }
            }
            return new ErrorDataResult<TakeExamResponseModel>(Messages.NotFound);
        }

        public IResult CreateExam(AddExamRequestModel addExam)
        {
            Topic topic;
            var topicResult = _topicEngine.GetTopic(t => t.UrlPath.Equals(addExam.TopicPath));
            if (topicResult.Success && topicResult.Data == null)
            {
                topic = _mapper.Map<Topic>(WiredComService.GetTopicInfo(addExam.TopicPath));
                _topicEngine.AddTopic(topic);
            }
            else if (topicResult.Data != null)
            {
                topic = topicResult.Data;
            }
            else
            {
                return new ErrorResult(Messages.TopicIsNotCreated);
            }

            var exam = new Exam { TopicId = topic.Id };
            AddExam(exam);

            (addExam.Questions as List<AddQuestionRequestModel>).ForEach(q =>
            {
                var question = _mapper.Map<Question>(q);
                question.ExamId = exam.Id;
                var questionResult = _questionEngine.AddQuestion(question);
                (q.answers as List<AddAnswerRequestModel>).ForEach(a =>
                {
                    var answer = _mapper.Map<Answer>(a);
                    answer.QuestionId = questionResult.Data.Id;
                    _answerEngine.AddAnswer(answer);
                });
            });

            return new SuccessResult(Messages.ExamIsCreated);
        }

        public IResult SolveExam(ICollection<AnswerQuestionRequestModel> answerQuestions)
        {
            var userAnswers = _mapper.Map<ICollection<UserQuestionAnswer>>(answerQuestions);
            foreach (var answer in userAnswers)
            {
                _userQuestionAnswerEngine.AddUserAnswer(answer);
            }
            return new SuccessResult(Messages.ExamIsSolved);
        }

        public IDataResult<ResultExamModel> GetResultExam(int examId, int userId)
        {
            var exam = _examRepository.Get(e => e.Id.Equals(examId));
            if (exam == null)
                return new ErrorDataResult<ResultExamModel>(Messages.NotFound);

            var topicResult = _topicEngine.GetTopic(t => t.Id.Equals(exam.TopicId));

            ResultExamModel result = _mapper.Map<ResultExamModel>(topicResult.Data);

            var questionsResult = _questionEngine.UserAnsweredQuestions(q => q.ExamId.Equals(exam.Id) && q.UserId.Equals(userId));

            result.Questions = _mapper.Map<ICollection<ResultQuestionModel>>(questionsResult.Data);

            (result.Questions as List<ResultQuestionModel>).ForEach(q =>
            {
                var answersResult = _answerEngine.GetAnswers(a => a.QuestionId.Equals(q.Id));
                q.Answers = _mapper.Map<ICollection<ResultAnswerModel>>(answersResult.Data);
            });

            return new SuccessDataResult<ResultExamModel>(result);
        }
    }
}