
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mandrill.Models;
using SelfieStation.Models.Entities;
using SelfieStation.Models.InputModels;

namespace SelfieStation.Services
{
    // EmailService handles Mandrill and Mailchimp. it sends emails, believe it or not.
    public class EmailService : IEmailService
    {
        // býr til email með fríu myndinni til að senda.
        public async Task<string> SendEmailWithTemplate(ImageInfoInputModel imageInfo, string freeUrl)
        {
            // populate the MailChimp merge tags.
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"IMAGEURL", freeUrl},
                {"CURRENT_YEAR", "2019"},
                {"COMPANY", "Selfie Station"}
            };

            //EmailAddress to send to 
            EmailAddress address = new EmailAddress();
            address.Type = "to";
            address.Email = imageInfo.email;

            //Adding email address to list
            List<EmailAddress> toEmail = new List<EmailAddress>();
            toEmail.Add(address);

            //Creating the email to send.
            EmailMessage emailMsg = new EmailMessage();
            emailMsg.FromName = "Selfie Station";
            emailMsg.FromEmail = "photos@selfiestation.is";
            emailMsg.To = toEmail;
            emailMsg.Subject = "Your Selfie Station Photo";

            // send with template
            string template = "SelfieStationFreeImgTag";

            var success = await SendEmail(emailMsg, address, dict, template);
            return success;
        }

        public async Task<string> SendPremiumEmailWithTemplate(ImageInfoEntity imageInfo)
        {
            // populate the MailChimp merge tags.
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"IMAGEURL", imageInfo.premiumUrl},
                {"CURRENT_YEAR", "2019"},
                {"COMPANY", "Selfie Station"}
            };

            //EmailAddress to send to 
            EmailAddress address = new EmailAddress();
            address.Type = "to";
            address.Email = imageInfo.email;

            //Adding email address to list
            List<EmailAddress> toEmail = new List<EmailAddress>();
            toEmail.Add(address);

            //Creating the email to send.
            EmailMessage emailMsg = new EmailMessage();
            emailMsg.FromName = "Selfie Station";
            emailMsg.FromEmail = "photos@selfiestation.is";
            emailMsg.To = toEmail;
            emailMsg.Subject = "Your Premium Selfie Station Photo";

            // send with template
            string template = "SelfieStationPremiumImgTag";

            var success = await SendEmail(emailMsg, address, dict, template);
            return success;
        }

        private static async Task<string> SendEmail(EmailMessage emailMessage, EmailAddress emailAddress = null, Dictionary<string, string> dictionary = null, string emailTemplate = "")
        {
            // Sensitive information, needs to be properly encoded before deployment.
            Mandrill.MandrillApi api = new Mandrill.MandrillApi("rtHftXQYhGroTsPBzWBnbQ");
            List<EmailResult> results = new List<EmailResult>();

            if (String.IsNullOrEmpty(emailTemplate))
            {
                Mandrill.Requests.Messages.SendMessageRequest request = new Mandrill.Requests.Messages.SendMessageRequest(emailMessage);
                results = await api.SendMessage(request);
            }
            else
            {
                if (dictionary != null)
                {
                    foreach (var item in dictionary)
                    {
                        if (emailAddress != null)
                        {
                            emailMessage.AddRecipientVariable(emailAddress.Email, item.Key, item.Value);
                        }
                    }
                }
                Mandrill.Requests.Messages.SendMessageTemplateRequest request = new Mandrill.Requests.Messages.SendMessageTemplateRequest(emailMessage, emailTemplate);
                results = await api.SendMessageTemplate(request);
            }
            return results.FirstOrDefault().Status.ToString();
        }

    }
}
