using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using SelfieStation.Services;

namespace SelfieStation.WebApi.Controllers
{
    // Endpoints for all requests that target ads.
    [ApiController]
    [Route("api/Images")]
    public class ImageController : ControllerBase
    {
        public IImageService _imageService;

        public ImageController(IImageService imgServ)
        {
            _imageService = imgServ;
        }

        // GET: api/images
        [HttpGet]
        public IActionResult GetAllImageInfo()
        {
            IEnumerable<ImageInfoEntity> allInfo = _imageService.GetAllImageInfo(this.HttpContext);
            System.Console.WriteLine("check");
            return Ok(allInfo);
        }

        // GET: api/images/{id}
        [Route("{id:int}", Name = "GetImageInfoById")]
        [HttpGet]
        public IActionResult GetImageInfoById(int id)
        {
            var imgInfo = _imageService.GetImageInfoById(id, this.HttpContext);
            if (imgInfo != null)
            {
                return Ok(imgInfo);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/images
        [HttpPost]
        public async Task<IActionResult> CreateNewImageInfo([FromBody] ImageInfoInputModel body)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            string lowresUrl = _imageService.GetLowresImgUrlWithAd(body);
            var entity = await _imageService.AddImageInfo(body, lowresUrl, this.HttpContext);

            return CreatedAtRoute("GetImageInfoById", new { id = entity.ID }, null);
        }

        // PUT: api/images/{id}
        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateImageInfoById([FromBody] ImageInfoEditInputModel body, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }
            _imageService.UpdateImageInfoById(body, id, this.HttpContext);

            return NoContent();
        }
    }
}
