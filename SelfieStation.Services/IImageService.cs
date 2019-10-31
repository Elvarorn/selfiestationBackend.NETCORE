

using System.Collections.Generic;
using SelfieStationApi.Models.Entities;

namespace SelfieStation.Services
{
    public interface IImageService
    {
        imageInfoEntity getImageInfo(int id);
        IEnumerable<imageInfoEntity> getAllImageInfo();
        imageInfoEntity addImageInfo(imageInfoEntity imageInfo);



    }
}