

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
        ImageInfoEntity GetImageInfoById(int id, HttpContext context);
        IEnumerable<ImageInfoEntity> GetAllImageInfo(HttpContext context);
        Task<ImageInfoEntity> AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, HttpContext context);

        void UpdateImageInfoById(ImageInfoEditInputModel model, int id, HttpContext context);
        string GetLowresImgUrlWithAd(ImageInfoInputModel body);



    }
}