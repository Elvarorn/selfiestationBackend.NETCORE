using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using SelfieStation.Services;

namespace SelfieStation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        public IImageService _imageService;
        //private readonly ILogger<ImageController> _logger;

        public ImageController(IImageService imgServ)
        {
            _imageService = imgServ;
        }

        [HttpGet]
        public IActionResult getAllImageInfo()
        {
            IEnumerable<imageInfoEntity> allInfo = _imageService.getAllImageInfo();
            return Ok(allInfo);
        }


        [Route("{id:int}", Name = "GetImageInfoById")]
        public IActionResult getImageInfoById(int id)
        {
            var author = _imageService.getImageInfoById(id);
            return Ok(author);
        }


        [HttpPost]
        public IActionResult CreateNewImageInfo([FromBody] ImageInfoInputModel body)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            var entity = _imageService.addImageInfo(body);

            return CreatedAtRoute("GetImageInfoById", new { id = entity.ID }, null);
        }

        [Route("{id:int}")]
        [HttpPut]
        public IActionResult UpdateImageInfoById([FromBody] ImageInfoEditInputModel body, int id)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            _imageService.UpdateImageInfoById(body, id);

            return NoContent();
        }
    }
}
