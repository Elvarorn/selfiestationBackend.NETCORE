using System;
using System.Collections.Generic;
using SelfieStation.Repositories;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    public class imageService : IImageService
    {
        private IImageRepository _ImageRepository;

        public imageService(IImageRepository imgRep)
        {
            _ImageRepository = imgRep;
        }

        public imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo)
        {
            return _ImageRepository.addImageInfo(imageInfo);
        }

        public IEnumerable<imageInfoEntity> getAllImageInfo() => _ImageRepository.getAllImageInfo();

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