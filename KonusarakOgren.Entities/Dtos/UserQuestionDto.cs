using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.Dtos
{
    public class UserQuestionDto : IDto
    {
        public int Id { get; set; }
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public string QuestionText { get; set; }
    }
}