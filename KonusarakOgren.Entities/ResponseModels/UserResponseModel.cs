using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class UserResponseModel : IResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }
}