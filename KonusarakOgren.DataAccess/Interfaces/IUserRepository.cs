using KonusarakOgren.Core.DataAccess;
using KonusarakOgren.Entities;
using System;

namespace KonusarakOgren.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}