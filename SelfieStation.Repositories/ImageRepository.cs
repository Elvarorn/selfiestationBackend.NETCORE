using System.Collections.Generic;
using System.Linq;
using SelfieStation.Repositories.data;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using System;
using System.Threading.Tasks;

namespace SelfieStation.Repositories
{
    public class ImageRepository : IImageRepository
    {
        protected databaseContext _context;

        public ImageRepository(databaseContext context)
        {
            _context = context;
        }

        public imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo)
        {
            imageInfoEntity newEnt = new imageInfoEntity()
            {
                imageGUID = imageInfo.imageGUID,
                email = imageInfo.email,
                timeStamp = imageInfo.timeStamp,
                hasEmailBeenSent = false,
                success = false,
                hasImageBeenBought = false

            };
            _context.imageInfo.Add(newEnt);
            _context.SaveChanges();
            return newEnt;

        }

        public IEnumerable<imageInfoEntity> getAllImageInfo()
        {
            return _context.imageInfo;
        }

        public imageInfoEntity getImageInfoById(int id)
        {
            var entity = _context.imageInfo.FirstOrDefault(r => r.ID == id);
            if (entity == null) { return null; /* throw some exception */ }
            return entity;
        }

        public void UpdateImageInfoById(ImageInfoEditInputModel model, int id)
        {
            var entity = _context.imageInfo.FirstOrDefault(item => item.ID == id);

            if (entity != null)
            {
                entity.hasEmailBeenSent = model.hasEmailBeenSent;
                entity.success = model.success;
                entity.hasImageBeenBought = model.hasImageBeenBought;
                _context.imageInfo.Update(entity);
                _context.SaveChanges();
            }
        }


    }
}