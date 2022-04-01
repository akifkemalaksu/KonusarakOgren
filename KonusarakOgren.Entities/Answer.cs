using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities
{
    public class Answer : IEntity<int>
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string AnswerText { get; set; }
        public bool IsTrue { get; set; }
        public DateTime CreateDate { get; set; }
    }
}