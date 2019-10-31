using System;
using System.Collections.Generic;
using SelfieStation.Repositories;
using SelfieStationApi.Models.Entities;


namespace SelfieStation.Services
{
    public class imageService : IImageService
    {
        private IImageRepository _ImageRepository;

        public imageService(IImageRepository imgRep)
        {
            _ImageRepository = imgRep;
        }

        public imageInfoEntity addImageInfo(imageInfoEntity imageInfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<imageInfoEntity> getAllImageInfo() => _ImageRepository.getAllImageInfo();

        public imageInfoEntity getImageInfo(int id)
        {
            throw new NotImplementedException();
        }
    }
}