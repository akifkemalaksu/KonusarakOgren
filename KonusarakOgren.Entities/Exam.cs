using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities
{
    public class Exam : IEntity<int>
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}