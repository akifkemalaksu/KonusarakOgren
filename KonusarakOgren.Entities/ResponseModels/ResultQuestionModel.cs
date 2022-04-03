using KonusarakOgren.Core.Entities;

namespace KonusarakOgren.Entities.ResponseModels
{
    public class ResultQuestionModel : IResponseModel
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public string QuestionText { get; set; }
        public ICollection<ResultAnswerModel> Answers { get; set; }
    }
}