using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IActionResult Get()
        {
            return Ok(_imageService.getAllImageInfo());
        }
    }
}
