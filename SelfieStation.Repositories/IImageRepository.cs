

using System.Collections.Generic;
using SelfieStationApi.Models.Entities;

namespace SelfieStation.Repositories
{
    public interface IImageRepository
    {
        imageInfoEntity getImageInfo(int id);
        IEnumerable<imageInfoEntity> getAllImageInfo();
        imageInfoEntity addImageInfo(imageInfoEntity imageInfo);



    }
}