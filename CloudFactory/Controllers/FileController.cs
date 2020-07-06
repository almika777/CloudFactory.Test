using BL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CloudFactory.Controllers
{
    [ApiController]
    [Route("file")]
    public class FileController : BaseController
    {
        private readonly IReadFileService _readService;

        public FileController(IReadFileService readService)
        {
            _readService = readService;
        }

        public IActionResult Index()
        {
            return JsonResult("Hello");
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string filename)
        {
            return JsonResult(await _readService.ReadFileContentAsync(filename));
        }
    }
}
