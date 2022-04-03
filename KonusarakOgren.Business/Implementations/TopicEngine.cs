using AutoMapper;
using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Business.Services;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.ResponseModels;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class TopicEngine : ITopicEngine
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public TopicEngine(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public IDataResult<Topic> AddTopic(Topic topic)
        {
            _topicRepository.Insert(topic);
            _topicRepository.SaveChanges();
            return new SuccessDataResult<Topic>(topic);
        }

        public IResult DeleteTopic(Topic topic)
        {
            _topicRepository.Delete(topic.Id);
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