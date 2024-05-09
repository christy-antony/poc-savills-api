using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using poc_savills_api.Services;

namespace poc_savills_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private const string MimeType = "application/octet-stream";
        public TemplatesController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        [HttpGet("{name}")]
        public IActionResult GetFIleAsByteArray(string name)
        {
            var file = _templateService.GetTemplateAsByteArray(name);
            return File(file, MimeType, name);
        }
    }
}
