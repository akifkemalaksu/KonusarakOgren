using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class TakeAnswerModel : IResponseModel
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
    }
}