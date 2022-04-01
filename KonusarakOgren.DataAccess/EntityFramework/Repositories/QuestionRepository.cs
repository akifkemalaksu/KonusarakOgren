using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class QuestionRepository : RepositoryBase<KonusarakOgrenContext, Question, int>, IQuestionRepository
    {
        public QuestionRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}