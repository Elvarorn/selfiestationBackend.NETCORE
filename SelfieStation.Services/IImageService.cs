

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    public interface IImageService
    {
        imageInfoEntity getImageInfoById(int id);
        IEnumerable<imageInfoEntity> getAllImageInfo(HttpContext context);
        imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo);

        void UpdateImageInfoById(ImageInfoEditInputModel model, int id);



    }
}