
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
    public class EmailService : IEmailService
    {

        public async Task<EmailResult> sendEmailWithTemplate(ImageInfoInputModel imageInfo, string freeUrl)
        {

            // populate merge tags
            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                {"CUSTOMERNAME", "Dagurching"},
                {"IMAGEURL", freeUrl},
                {"CURRENT_YEAR", "2019"},
                {"COMPANY", "Selfie Station"}
            };



            //EmailAddress to send to 
            EmailAddress address = new EmailAddress();
            address.Type = "to";
            address.Email = imageInfo.email;

            List<EmailAddress> toEmail = new List<EmailAddress>();
            toEmail.Add(address);

            EmailMessage emailMsg = new EmailMessage();
            emailMsg.FromName = "Selfie Station";
            emailMsg.FromEmail = "photos@selfiestation.is";
            emailMsg.To = toEmail;
            emailMsg.Subject = "Your Selfie Station Photo";

            // send with template
            string template = "SelfieStationFreeImgTag";

            var success = await SendEmail(emailMsg, address, dict, template);

            return null;
        }
        private static async Task<string> SendEmail(EmailMessage emailMessage, EmailAddress emailAddress = null, Dictionary<string, string> dictionary = null, string emailTemplate = "")
        {
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

        // -----------------------------------------------------------------------------------------------------------------------


        public static async Task<string> SendHTMLEmail(List<EmailAddress> to, string html, string subject, string from)
        {
            try
            {
                EmailMessage message = new EmailMessage();
                Mandrill.MandrillApi api = new Mandrill.MandrillApi("API key");



                message.FromName = "From name";
                message.FromEmail = from;
                message.To = to;
                message.Subject = subject;

                message.Html = html;

                Mandrill.Requests.Messages.SendMessageRequest request = new Mandrill.Requests.Messages.SendMessageRequest(message);
                List<EmailResult> results = await api.SendMessage(request);

                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



    }
}
