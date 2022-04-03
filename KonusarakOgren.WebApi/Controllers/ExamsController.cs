using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamEngine _examEngine;

        public ExamsController(IExamEngine examEngine)
        {
            _examEngine = examEngine;
        }

        [HttpGet("GetExamsWithTopic")]
        public IActionResult GetExamsWithTopic()
        {
            var result = _examEngine.GetExamWithTopic();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _examEngine.DeleteExam(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("UserIsTakeExam/{id}")]
        public IActionResult UserIsTakeExam(int id, int userId)
        {
            var result = _examEngine.UserTakeExam(e => e.ExamId.Equals(id) && e.UserId.Equals(userId));
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateExam")]
        public IActionResult CreateExam(AddExamRequestModel addExam)
        {
            var result = _examEngine.CreateExam(addExam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetTakeExam/{id}")]
        public IActionResult GetTakeExam(int id)
        {
            var result = _examEngine.GetTakeExam(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("SolveExam")]
        public IActionResult SolveExam(ICollection<AnswerQuestionRequestModel> answerQuestions)
        {
            var result = _examEngine.SolveExam(answerQuestions);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}