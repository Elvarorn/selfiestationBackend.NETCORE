using System.Collections.Generic;
using System.Linq;
using SelfieStation.Repositories.data;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using System;
using System.Threading.Tasks;

namespace SelfieStation.Repositories
{
    // Reads and writes to the ImageInfo table in the database.
    public class ImageRepository : IImageRepository
    {
        protected databaseContext _context;

        public ImageRepository(databaseContext context)
        {
            _context = context;
        }

        public ImageInfoEntity AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, string success)
        {
            bool emailSent = false;
            if (success.ToLower() == "sent")
            {
                emailSent = true;
            }

            // Create the entity to add to the database.
            ImageInfoEntity newEnt = new ImageInfoEntity()
            {
                imageGUID = imageInfo.imageGUID,
                email = imageInfo.email,
                timeStamp = imageInfo.timeStamp,
                hasEmailBeenSent = emailSent,
                success = false,
                hasImageBeenBought = false,
                premiumUrl = imageInfo.Url,
                freeUrl = freeUrl

            };
            _context.imageInfo.Add(newEnt);
            _context.SaveChanges();
            return newEnt;

        }

        public IEnumerable<ImageInfoEntity> GetAllImageInfo()
        {
            return _context.imageInfo;
        }

        public ImageInfoEntity GetImageInfoById(int id)
        {
            var entity = _context.imageInfo.FirstOrDefault(r => r.ID == id);
            if (entity == null)
            {
                return null;
            }
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