using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class TakeQuestionModel : IResponseModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public ICollection<TakeAnswerModel> Answers { get; set; }
    }
}