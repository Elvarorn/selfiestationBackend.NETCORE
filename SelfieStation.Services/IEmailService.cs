using System.Threading.Tasks;
using SelfieStation.Models.InputModels;
using SelfieStation.Models.Entities;

namespace SelfieStation.Services
{
    // EmailService handles Mandrill and Mailchimp. it sends emails, believe it or not.
    public interface IEmailService
    {
        Task<string> SendEmailWithTemplate(ImageInfoInputModel imageInfo, string freeUrl);
        Task<string> SendPremiumEmailWithTemplate(ImageInfoEntity imageInfo);
    }
}
