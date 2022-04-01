using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime CreateDate { get; set; }
    }
}