using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class ResultAnswerModel : IResponseModel
    {
        public int Id { get; set; }
        public string AnswerText { get; set; }
        public bool IsTrue { get; set; }
    }
}