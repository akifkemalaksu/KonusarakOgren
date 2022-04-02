using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.RequestModels
{
    public class AddQuestionRequestModel : IRequestModel
    {
        public string QuestionText { get; set; }
        public ICollection<AddAnswerRequestModel> answers { get; set; }
    }
}