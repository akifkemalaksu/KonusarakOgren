using AutoMapper;
using KonusarakOgren.Business.Constants;
using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Business.Services;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class TopicEngine : ITopicEngine
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IExamEngine _examEngine;
        private readonly IMapper _mapper;

        public TopicEngine(ITopicRepository topicRepository, IExamEngine examEngine, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _examEngine = examEngine;
            _mapper = mapper;
        }

        public IDataResult<Topic> AddTopic(Topic topic)
        {
            _topicRepository.Insert(topic);
            _topicRepository.SaveChanges();
            return new SuccessDataResult<Topic>(topic);
        }

        public IResult CreateTopicAndExam(AddExamRequestModel addExam)
        {
            Topic topic = _topicRepository.Get(t => t.UrlPath.Equals(addExam.TopicPath));
            if (topic == null)
            {
                topic = _mapper.Map<Topic>(WiredComService.GetTopicInfo(addExam.TopicPath));
                AddTopic(topic);
            }

            var exam = new Exam { TopicId = topic.Id };
            _examEngine.AddExam(exam);

            (addExam.Questions as List<AddQuestionRequestModel>).ForEach(q =>
            {
                var question = _mapper.Map<Question>(q);
                question.ExamId = exam.Id;
                var questionResult = _examEngine.AddQuestion(question);
                (q.answers as List<AddAnswerRequestModel>).ForEach(a =>
                {
                    var answer = _mapper.Map<Answer>(a);
                    answer.QuestionId = questionResult.Data.Id;
                    _examEngine.AddAnswer(answer);
                });
            });

            return new SuccessResult(Messages.ExamIsCreated);
        }

        public IResult DeleteTopic(Topic topic)
        {
            _topicRepository.Delete(topic);
            _topicRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<ICollection<TopicFromWebResponseModel>> GetMostTopics()
        {
            return new SuccessDataResult<ICollection<TopicFromWebResponseModel>>(WiredComService.GetMostTopics());
        }

        public IDataResult<Topic> GetTopic(Expression<Func<Topic, bool>> expression)
        {
            return new SuccessDataResult<Topic>(_topicRepository.Get(expression));
        }

        public IDataResult<Topic> GetTopicFromPath(string path)
        {
            var result = GetTopic(t => t.UrlPath.Equals(path));
            if (result.Data != null)
            {
                return result;
            }
            return new SuccessDataResult<Topic>(_mapper.Map<Topic>(WiredComService.GetTopicInfo(path)));
        }

        public IDataResult<ICollection<Topic>> GetTopics(Expression<Func<Topic, bool>> expression)
        {
            return new SuccessDataResult<ICollection<Topic>>(_topicRepository.GetMany(expression));
        }

        public IDataResult<Topic> UpdateTopic(Topic topic)
        {
            _topicRepository.Update(topic);
            _topicRepository.SaveChanges();
            return new SuccessDataResult<Topic>(topic);
        }
    }
}