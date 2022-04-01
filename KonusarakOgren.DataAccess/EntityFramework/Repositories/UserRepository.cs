using KonusarakOgren.Core.DataAccess.EntityFramework;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using System;

namespace KonusarakOgren.DataAccess.EntityFramework.Repositories
{
    public class UserRepository : RepositoryBase<KonusarakOgrenContext, User, int>, IUserRepository
    {
        public UserRepository(KonusarakOgrenContext context) : base(context)
        {
        }
    }
}