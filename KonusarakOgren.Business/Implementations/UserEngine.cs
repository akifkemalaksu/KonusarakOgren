using AutoMapper;
using KonusarakOgren.Business.Constants;
using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Core.Business;
using KonusarakOgren.Core.Utilities.Results;
using KonusarakOgren.Core.Utilities.Security.Hashing;
using KonusarakOgren.DataAccess.Interfaces;
using KonusarakOgren.Entities;
using KonusarakOgren.Entities.RequestModels;
using KonusarakOgren.Entities.ResponseModels;
using System.Linq.Expressions;

namespace KonusarakOgren.Business.Implementations
{
    public class UserEngine : IUserEngine
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserEngine(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IDataResult<UserResponseModel> AddUser(AddUserRequestModel addUser)
        {
            var rules = BusinessRules.Run(
                UsernameIsUsing(addUser.Username)
                );
            if (rules != null)
            {
                return (IDataResult<UserResponseModel>)rules;
            }

            var user = _mapper.Map<User>(addUser);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(addUser.Password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userRepository.Insert(user);
            _userRepository.SaveChanges();
            return new SuccessDataResult<UserResponseModel>(_mapper.Map<UserResponseModel>(user));
        }

        public IDataResult<UserResponseModel> GetUser(Expression<Func<User, bool>> expression)
        {
            return new SuccessDataResult<UserResponseModel>(_mapper.Map<UserResponseModel>(_userRepository.Get(expression)));
        }

        public IDataResult<UserResponseModel> Login(UserLoginRequestModel userLogin)
        {
            var userToLogin = _userRepository.Get(u => u.Username == userLogin.Username);
            if (userToLogin == null)
            {
                return new ErrorDataResult<UserResponseModel>(default, Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userLogin.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt))
            {
                return new ErrorDataResult<UserResponseModel>(default, Messages.WrongPassword);
            }

            return new SuccessDataResult<UserResponseModel>(_mapper.Map<UserResponseModel>(userToLogin));
        }

        private IResult UsernameIsUsing(string username)
        {
            var userCheck = _userRepository.Get(u => u.Username.Equals(username));
            if (userCheck != null)
            {
                return new ErrorResult(Messages.UsernameIsUsing);
            }
            return new SuccessResult();
        }
    }
}