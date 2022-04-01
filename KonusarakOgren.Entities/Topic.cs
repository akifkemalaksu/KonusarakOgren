using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities
{
    public class Topic : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}