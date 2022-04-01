using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface ITopicEngine : IBusinessEngine
    {
        public IDataResult<Topic> AddTopic(Topic topic);

        public IDataResult<Topic> UpdateTopic(Topic topic);

        public IResult DeleteTopic(Topic topic);

        public IDataResult<Topic> GetTopic(Expression<Func<Topic, bool>> expression);

        public IDataResult<ICollection<Topic>> GetTopics(Expression<Func<Topic, bool>> expression);
    }
}