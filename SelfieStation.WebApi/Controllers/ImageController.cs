using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using SelfieStation.Services;

namespace SelfieStation.WebApi.Controllers
{
    [ApiController]
    [Route("api/Images")]
    public class ImageController : ControllerBase
    {
        public IImageService _imageService;
        //public IShopifyService _shopifyService;
        //private readonly ILogger<ImageController> _logger;

        public ImageController(IImageService imgServ)
        {
            _imageService = imgServ;
        }

        [HttpGet]
        public IActionResult getAllImageInfo()
        {
            IEnumerable<imageInfoEntity> allInfo = _imageService.getAllImageInfo(this.HttpContext);
            System.Console.WriteLine("check");
            return Ok(allInfo);
        }


        [Route("{id:int}", Name = "GetImageInfoById")]
        [HttpGet]
        public IActionResult getImageInfoById(int id)
        {
            var author = _imageService.getImageInfoById(id, this.HttpContext);
            return Ok(author);
        }

        //[Route("/ad/{id:int}", Name = "GetImageInfoById")]
        //public IActionResult getImageByIdLowResAd(int id)
        // {
        //     return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> CreateNewImageInfo([FromBody] ImageInfoInputModel body)
        {
            if (!ModelState.IsValid) { return BadRequest("Model is not properly formatted."); }

            string lowresUrl = _imageService.getLowresImgUrlWithAd(body);
            var entity = await _imageService.addImageInfo(body, lowresUrl, this.HttpContext);


            return CreatedAtRoute("GetImageInfoById", new { id = entity.ID }, null);
        }


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
