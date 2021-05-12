using System.Net.Mime;
using System.Threading.Tasks;
using cdnder_backend.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace cdnder_backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;
        
        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpPut]
        [RequestSizeLimit((2 << 20) * 50)]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(Image), 201)]
        public async Task<ActionResult<Image>> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest(new HTTPError(400, "image missing"));
            }

            var image = new Image {Filename = file.FileName, Size = file.Length, Filetype = file.ContentType};
            image.Suffix = image.Id.ToString();

            return Created("image", image);
        }
    }
}