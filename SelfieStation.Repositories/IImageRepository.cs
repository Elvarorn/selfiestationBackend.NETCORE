

using System.Collections.Generic;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Repositories
{
    public interface IImageRepository
    {
        imageInfoEntity getImageInfoById(int id);
        IEnumerable<imageInfoEntity> getAllImageInfo();
        imageInfoEntity addImageInfo(ImageInfoInputModel imageInfo, string freeUrl, string succsess);
        void UpdateImageInfoById(ImageInfoEditInputModel model, int id);

    }
}