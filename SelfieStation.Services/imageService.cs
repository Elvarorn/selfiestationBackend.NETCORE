using System;
using System.Collections.Generic;
using SelfieStation.Repositories;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;

namespace SelfieStation.Services
{
    public class imageService : IImageService
    {
        private IImageRepository _ImageRepository;
        private CloudinaryService _cloudinaryService;
        private IEmailService _emailService;
        //private AuthenticationService _authService;
        public imageService(IImageRepository imgRep, IEmailService emailServ)
        {
            _ImageRepository = imgRep;
            Account acc = new Account("selfie-station", "731411764737164", "z5_lgjuUEBYBOA3PR_vBqL47cMw");
            _cloudinaryService = new CloudinaryService(acc);
            _emailService = emailServ;
            //_authService = new AuthenticationService();
        }

        public imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo, string freeUrl)
        {
            _emailService.sendEmailWithTemplate(imageInfo, freeUrl);

            return _ImageRepository.addImageInfo(imageInfo, freeUrl);
        }

        public IEnumerable<imageInfoEntity> getAllImageInfo(HttpContext context)
        {
            //_authService.ValidateAuthorizationPrivilege(context, "admin");
            return _ImageRepository.getAllImageInfo();
        }

        public imageInfoEntity getImageInfoById(int id)
        {
            return _ImageRepository.getImageInfoById(id);
        }

        public void UpdateImageInfoById(ImageInfoEditInputModel model, int id)
        {
            _ImageRepository.UpdateImageInfoById(model, id);
        }

        public string getLowresImgUrlWithAd(ImageInfoInputModel body)
        {
            int index = IndexOfNth(body.Url, '/', 6) + 1;

            var freeImgUrl = body.Url.Insert(index, "t_SeptAD/");
            System.Console.WriteLine(freeImgUrl);

            return freeImgUrl;
        }

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