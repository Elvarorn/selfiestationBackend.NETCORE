

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using CloudinaryDotNet;

namespace SelfieStation.Services
{
    public interface IImageService
    {
        imageInfoEntity getImageInfoById(int id, HttpContext context);
        IEnumerable<imageInfoEntity> getAllImageInfo(HttpContext context);
        Task<imageInfoEntity> addImageInfo(ImageInfoInputModel imageInfo, string freeUrl, HttpContext context);

        void UpdateImageInfoById(ImageInfoEditInputModel model, int id, HttpContext context);
        string getLowresImgUrlWithAd(ImageInfoInputModel body);



    }
}