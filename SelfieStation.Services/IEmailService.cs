
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using System.Globalization;
using MailChimp;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    // EmailService handles Mandrill and Mailchimp. it sends emails, believe it or not.
    public interface IEmailService
    {
        Task<string> SendEmailWithTemplate(ImageInfoInputModel imageInfo, string freeUrl);
    }
}
