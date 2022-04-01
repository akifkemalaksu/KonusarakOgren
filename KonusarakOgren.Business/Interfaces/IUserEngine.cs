using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Interfaces
{
    public interface IUserEngine : IBusinessEngine
    {
        public IDataResult<UserResponseModel> AddUser(AddUserRequestModel addUser);

        public IDataResult<UserResponseModel> Login(UserLoginRequestModel userLogin);

        public IDataResult<UserResponseModel> GetUser(Expression<Func<User, bool>> expression);
    }
}