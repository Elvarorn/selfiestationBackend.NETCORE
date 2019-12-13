using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    public interface IImageService
    {
        ImageInfoEntity GetImageInfoById(int id, HttpContext context);
        IEnumerable<ImageInfoEntity> GetAllImageInfo(HttpContext context);
        Task<ImageInfoEntity> AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, HttpContext context);
        void UpdateImageInfoById(ImageInfoEditInputModel model, int id, HttpContext context);
        string GetLowresImgUrlWithAd(ImageInfoInputModel body);
        Task<string> RegisterImagePurchase(string premiumCode);
        Task DeleteImageInfo(int id, HttpContext httpContext);
    }
}