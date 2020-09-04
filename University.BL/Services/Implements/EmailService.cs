using HandlebarsDotNet;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using University.BL.Models;

namespace University.BL.Services.Implements
{
    public class EmailService
    {
        public string GetHtml(string basePathTemplate,
            object data)
        {
            if (!File.Exists(basePathTemplate))
                throw new Exception(string.Format("La plantilla {0} no se ha encontrado en el folder de plantillas", basePathTemplate));

            var templateText = File.ReadAllText(basePathTemplate);
            var template = Handlebars.Compile(templateText);

            return template(data);
        }

        public async Task SendNotification(List<Documents> documents,
            string destination,
            string subject,
            string content)
        {
            var client = SendGridConfig.Instance();
            var myMessage = new SendGridMessage();
            myMessage.HtmlContent = content;

            List<Attachment> attachments = new List<Attachment>();

            foreach (var item in documents)
            {
                byte[] documentArray = File.ReadAllBytes(item.Path);
                string base64Representation = Convert.ToBase64String(documentArray);

                attachments.Add(new Attachment
                {
                    Content = base64Representation,
                    Type = item.Type,
                    Filename = item.Filename,
                    Disposition = item.Disposition,
                    ContentId = item.ContentId
                });
            }

            if (attachments.Any())
                myMessage.AddAttachments(attachments);

            myMessage.AddTo(destination);
            myMessage.From = new EmailAddress("dsantafe@utap.edu.co", "David Santafe");
            myMessage.Subject = subject;
            myMessage.SetClickTracking(false, false);

            await client.SendEmailAsync(myMessage);
        }
    }
}
