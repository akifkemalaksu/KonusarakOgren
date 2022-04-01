using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class TopicRepository : RepositoryBase<KonusarakOgrenContext, Topic, int>, ITopicRepository
    {
        public TopicRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}