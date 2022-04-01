using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.RequestModels
{
    public class AddUserRequestModel : IRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}