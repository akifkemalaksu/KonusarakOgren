using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.RequestModels
{
    public class AddAnswerRequestModel : IRequestModel
    {
        public string AnswerText { get; set; }
        public bool IsTrue { get; set; }
    }
}