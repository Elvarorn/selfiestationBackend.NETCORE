using System.Collections.Generic;
using System.Threading.Tasks;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Repositories
{
    // Reads and writes to the ImageInfo table in the database.
    public interface IImageRepository
    {
        ImageInfoEntity GetImageInfoById(int id);
        IEnumerable<ImageInfoEntity> GetAllImageInfo();
        ImageInfoEntity AddImageInfo(ImageInfoInputModel imageInfo, string freeUrl, string succsess);
        void UpdateImageInfoById(ImageInfoEditInputModel model, int id);
        ImageInfoEntity GetImageInfoByGUID(string premiumCode);
        Task RegisterImagePurchase(ImageInfoEntity imgInfo, string success);
    }
}