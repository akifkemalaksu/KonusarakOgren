using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class TakeExamResponseModel : IResponseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<TakeQuestionModel> Questions { get; set; }
    }
}