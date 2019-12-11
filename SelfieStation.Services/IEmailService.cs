
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mandrill.Models;
using System.Globalization;
using MailChimp;
using MailChimp.Helper;
using MailChimp.Lists;
using Newtonsoft.Json;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    public interface IEmailService
    {
        Task<string> sendEmailWithTemplate(ImageInfoInputModel imageInfo, string freeUrl);
        //Task<string> SendEmail(EmailMessage emailMessage, EmailAddress emailAddress = null, Dictionary<string, string> dictionary = null, string emailTemplate = "");
        //Task<string> SendHTMLEmail(List<EmailAddress> to, string html, string subject, string from);
    }
}
