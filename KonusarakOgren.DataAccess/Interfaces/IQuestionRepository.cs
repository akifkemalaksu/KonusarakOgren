using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Entities;

namespace KonusarakOgren.DataAccess.Interfaces
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
    }
}