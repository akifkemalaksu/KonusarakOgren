using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class UserTakeExamResponseModel : IResponseModel
    {
        public int ExamId { get; set; }
        public int TopicId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}