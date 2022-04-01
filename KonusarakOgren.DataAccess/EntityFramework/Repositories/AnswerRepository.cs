using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class AnswerRepository : RepositoryBase<KonusarakOgrenContext, Answer, int>, IAnswerRepository
    {
        public AnswerRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}