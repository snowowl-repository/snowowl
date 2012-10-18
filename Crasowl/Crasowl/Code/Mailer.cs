using System;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using Crasowl.Models;

namespace Crasowl.Code
{
    public class Mailer
    {
        private const string ContactUsMailTemplate =
        @"<div style='font-family: Segoe UI;'>
        <h2>
            New request from potentially client!</h2>
        <p style='padding-left: 30px; text-indent: 20px'>
            <i>{0}</i></p>
        <h3>
            Potentially client information:</h3>
        <div>
            <table style='width: 100%; padding-left: 30px;'>
                <tr>
                    <td style='width: 10%;'>
                        <b>Name</b>
                    </td>
                    <td>
                        <i>{1}</i>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Email</b>
                    </td>
                    <td>
                        <i><a href='mailto:{2}'>{2}</a></i>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Phone</b>
                    </td>
                    <td>
                        <i>{3}</i>
                    </td>
                </tr>
                <tr>
                    <td>
                        <b>Company</b>
                    </td>
                    <td>
                        <i>{4}</i>
                    </td>
                </tr>
            </table>
        </div>
    </div>";

        private const string ContactUsMailSubject = "Reply imediately!Potentially client!";

        public static bool SendContactUsMail(ContactModel contactModel)
        {

            string messageBody = string.Format(ContactUsMailTemplate, contactModel.Message, contactModel.Name,
                                               contactModel.Email, contactModel.PhoneNumber, contactModel.CompanyName);
            var smtp = new SmtpClient();
            var message = new MailMessage { IsBodyHtml = true, Body = messageBody, Subject = ContactUsMailSubject };
            string mailTo = ConfigurationManager.AppSettings["ContactUsMailTo"];
            string mailsCc = ConfigurationManager.AppSettings["ContactUsMailCC"];
            try
            {
                message.To.Add(mailTo);
                if (!string.IsNullOrWhiteSpace(mailsCc))
                    message.CC.Add(mailsCc);
                if (contactModel.Attachment != null)
                {
                    var attach = new Attachment(contactModel.Attachment.InputStream, contactModel.Attachment.FileName)
                                     {
                                         ContentType = new ContentType(contactModel.Attachment.ContentType),
                                     };
                    message.Attachments.Add(attach);
                }
                smtp.Send(message);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}