using System.Collections.Generic;
using System.Linq;
using SelfieStation.Repositories.data;
using SelfieStationApi.Models.Entities;
using System;

namespace SelfieStation.Repositories
{
    public class ImageRepository : IImageRepository
    {
        protected databaseContext _context;

        public ImageRepository(databaseContext context)
        {
            _context = context;
        }

        public imageInfoEntity addImageInfo(imageInfoEntity imageInfo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<imageInfoEntity> getAllImageInfo()
        {
            return _context.imageInfo;
        }

        public imageInfoEntity getImageInfo(int id)
        {
            throw new NotImplementedException();
        }


    }
}