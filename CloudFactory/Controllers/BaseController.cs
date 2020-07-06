using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CloudFactory.Controllers
{
    public class BaseController : ControllerBase
    {
        protected IActionResult JsonResult(object obj = null, JsonSerializerSettings settings = null)
        {
            return new JsonResult(obj, settings);
        }
    }
}
