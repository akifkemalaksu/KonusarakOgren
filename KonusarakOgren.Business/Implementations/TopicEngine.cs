using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class TopicEngine : ITopicEngine
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IQuestionEngine _questionEngine;

        public TopicEngine(ITopicRepository topicRepository, IQuestionEngine questionEngine)
        {
            _topicRepository = topicRepository;
            _questionEngine = questionEngine;
        }

        public IDataResult<Topic> AddTopic(Topic topic)
        {
            _topicRepository.Insert(topic);
            _topicRepository.SaveChanges();
            return new SuccessDataResult<Topic>(topic);
        }

        public IResult DeleteTopic(Topic topic)
        {
            _topicRepository.Delete(topic);
            _topicRepository.SaveChanges();
            return new SuccessResult();
        }

        public IDataResult<Topic> GetTopic(Expression<Func<Topic, bool>> expression)
        {
            return new SuccessDataResult<Topic>(_topicRepository.Get(expression));
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