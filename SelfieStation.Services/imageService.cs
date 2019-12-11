using System;
using System.Collections.Generic;
using SelfieStation.Repositories;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using System.Threading.Tasks;

namespace SelfieStation.Services
{
    // ImageService connects the ImageInfo controller to the ImageInfo repository.
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;
        private IEmailService _emailService;
        private AuthenticationService _authService;

        private string whoHasAuth;
        public ImageService(IImageRepository imgRep, IEmailService emailServ)
        {
            _imageRepository = imgRep;
            _emailService = emailServ;
            _authService = new AuthenticationService();
            whoHasAuth = "admin";
        }


        public async Task<ImageInfoEntity> AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            string sucsess = await _emailService.SendEmailWithTemplate(imageInfo, freeUrl);

            return _imageRepository.AddImageInfo(imageInfo, freeUrl, sucsess);
        }

        public IEnumerable<ImageInfoEntity> GetAllImageInfo(HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return _imageRepository.GetAllImageInfo();
        }

        public ImageInfoEntity GetImageInfoById(int id, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            return _imageRepository.GetImageInfoById(id);
        }

        public void UpdateImageInfoById(ImageInfoEditInputModel model, int id, HttpContext context)
        {
            _authService.ValidateAuthorizationPrivilege(context, whoHasAuth);
            _imageRepository.UpdateImageInfoById(model, id);
        }

        // Creates URL for the low-res image with ads.
        public string GetLowresImgUrlWithAd(ImageInfoInputModel body)
        {
            int index = IndexOfNth(body.Url, '/', 6) + 1;
            var freeImgUrl = body.Url.Insert(index, "t_SeptAD/");
            return freeImgUrl;
        }

        // returns the Nth occurance of specific character( the value parameter).
        private static int IndexOfNth(string input, char value, int nth)
        {
            if (nth < 1)
                throw new NotSupportedException("Param 'nth' must be greater than 0!");
            var nResult = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == value)
                    nResult++;
                if (nResult == nth)
                    return i;
            }
            return -1;
        }
    }
}