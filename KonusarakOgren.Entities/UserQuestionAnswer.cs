using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities
{
    public class UserQuestionAnswer : IEntity<int>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}