using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var headers = Request.Headers;
            return new string[] { "value1", "value2" };
        }

        [HttpGet("GetName")]
        public string GetName([FromServices]IUtil util)
        {
            return util.GetName();
        }

    }
}
