using KonusarakOgren.Core.Entities;
using System;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class ResultExamModel : IResponseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<ResultQuestionModel> Questions { get; set; }
    }
}