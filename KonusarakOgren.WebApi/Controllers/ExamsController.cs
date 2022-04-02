using KonusarakOgren.Business.Interfaces;
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
    }
}