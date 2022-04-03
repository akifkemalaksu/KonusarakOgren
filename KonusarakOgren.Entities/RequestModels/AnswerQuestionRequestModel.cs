using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.RequestModels
{
    public class AnswerQuestionRequestModel : IRequestModel
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
    }
}