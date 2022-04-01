using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class UserQuestionAnswerRepository : RepositoryBase<KonusarakOgrenContext, UserQuestionAnswer, int>, IUserQuestionAnswerRepository
    {
        public UserQuestionAnswerRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}