using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.RequestModels
{
    public class UserLoginRequestModel : IRequestModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}