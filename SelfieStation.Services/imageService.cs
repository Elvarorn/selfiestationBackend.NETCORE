using System;
using System.Collections.Generic;
using SelfieStation.Repositories;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using Microsoft.AspNetCore.Http;

namespace SelfieStation.Services
{
    public class imageService : IImageService
    {
        private IImageRepository _ImageRepository;
        //private AuthenticationService _authService;
        public imageService(IImageRepository imgRep)
        {
            _ImageRepository = imgRep;
            //_authService = new AuthenticationService();
        }

        public imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo)
        {
            return _ImageRepository.addImageInfo(imageInfo);
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
    }
}