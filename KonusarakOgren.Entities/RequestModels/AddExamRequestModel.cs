using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.RequestModels
{
    public class AddExamRequestModel : IRequestModel
    {
        public string TopicPath { get; set; }
        public ICollection<AddQuestionRequestModel> Questions { get; set; }
    }
}