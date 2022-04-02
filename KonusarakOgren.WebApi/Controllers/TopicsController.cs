using KonusarakOgren.Business.Interfaces;
using KonusarakOgren.Entities.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace KonusarakOgren.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicEngine _topicEngine;

        public TopicsController(ITopicEngine topicEngine)
        {
            _topicEngine = topicEngine;
        }

        [HttpGet("GetMostTopics")]
        public IActionResult GetMostTopics()
        {
            var result = _topicEngine.GetMostTopics();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetTopicFromWeb")]
        public IActionResult GetTopicWithPath(string path)
        {
            var result = _topicEngine.GetTopicFromPath(path);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("CreateExam")]
        public IActionResult CreateExam(AddExamRequestModel addExam)
        {
            var result = _topicEngine.CreateTopicAndExam(addExam);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}