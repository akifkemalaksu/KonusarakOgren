using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class ExamRepository : RepositoryBase<KonusarakOgrenContext, Exam, int>, IExamRepository
    {
        public ExamRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}