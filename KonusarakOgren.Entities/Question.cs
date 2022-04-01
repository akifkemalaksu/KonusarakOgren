using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities
{
    public class Question : IEntity<int>
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreateDate { get; set; }
    }
}