using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using SelfieStation.Models.Entities;
using System;


namespace SelfieStation.Services
{
    public class CloudinaryService
    {
        private Cloudinary cloudinary;

        public CloudinaryService(Account account)
        {
            cloudinary = new Cloudinary(account);
        }

        internal string getImgWithAd(string url)
        {
            var _url = cloudinary.Api.UrlImgUp.Transform(new Transformation().Named("SeptAd")).CloudinaryAddr(url).ToString();
            return _url;
        }
    }
}
