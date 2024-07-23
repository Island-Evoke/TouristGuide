using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TouristGuide.Application.Content.IServices;
using TouristGuide.Application.Content.Services;

namespace TouristGuide.API.Controllers.Content
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;
       

        public GalleryController(IGalleryService galleryService)
        {

            _galleryService = galleryService;
        }

        [HttpPost]
        [Route("UploadGallery")]
        public async Task<IActionResult> UploadGallery([FromQuery] string Title, List<IFormFile> files, [FromQuery] string Description )
        {
            var response = await _galleryService.UploadGallery( Title,  files,  Description);
            return Ok(new { result = response });
        }
    }
}
