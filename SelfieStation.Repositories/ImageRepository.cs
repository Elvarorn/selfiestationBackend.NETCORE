using System.Collections.Generic;
using System.Linq;
using SelfieStation.Repositories.data;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        public ImageInfoEntity AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, string freeSuccess)
        {

            // checking if something went wrong in email sending process
            bool ok = true;
            bool emailSent = false;
            if (freeSuccess.ToLower() == "sent")
            {
                emailSent = true;
            }
            else
            {
                ok = false;
            }

            // Create the entity to add to the database.
            ImageInfoEntity newEnt = new ImageInfoEntity()
            {
                imageGUID = imageInfo.imageGUID,
                email = imageInfo.email,
                timeStamp = imageInfo.timeStamp,
                hasFreeEmailBeenSent = emailSent,
                hasPremiumEmailBeenSent = false,
                success = ok,
                hasImageBeenBought = false,
                premiumUrl = imageInfo.Url,
                freeUrl = freeUrl

            };
            _context.imageInfo.Add(newEnt);
            _context.SaveChanges();
            return newEnt;

        }

        public async Task DeleteImageInfo(int id)
        {
            var entity = await _context.imageInfo.FindAsync(id);
            if (entity == null)
            { }
            else
            {
                _context.imageInfo.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<ImageInfoEntity> GetAllImageInfo()
        {
            return _context.imageInfo;
        }

        public ImageInfoEntity GetImageInfoByGUID(string premiumCode)
        {
            var entity = _context.imageInfo.FirstOrDefault(r => r.imageGUID == premiumCode);
            return entity;

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

        public async Task RegisterImagePurchase(ImageInfoEntity imgInfo, string success)
        {
            try
            {
                var entity = _context.imageInfo.FirstOrDefault(item => item.ID == imgInfo.ID);

                // checking if something went wrong in email sending process
                bool ok = true;
                bool emailSent = false;
                if (success.ToLower() == "sent")
                {
                    emailSent = true;
                }
                else
                {
                    ok = false;
                }

                entity.hasImageBeenBought = true;
                entity.hasPremiumEmailBeenSent = emailSent;
                entity.success = ok;

                _context.imageInfo.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

        }

        public void UpdateImageInfoById(ImageInfoEditInputModel model, int id)
        {
            var entity = _context.imageInfo.FirstOrDefault(item => item.ID == id);

            if (entity != null)
            {
                entity.hasFreeEmailBeenSent = model.hasEmailBeenSent;
                entity.success = model.success;
                entity.hasImageBeenBought = model.hasImageBeenBought;
                _context.imageInfo.Update(entity);
                _context.SaveChanges();
            }
        }
    }
}