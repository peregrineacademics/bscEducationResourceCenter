using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PAS.ResourceCenter.Web.Administration.Common
{
    public class Email
    {
        public enum Result
        {
            Success,
            Error
        }

        public static Result Send(string toEmail, string subject, string body, bool isHTML)
        {
            try
            {
                bool enabled = MiscUtilities.GetDBValue<bool>(Constants._settingSMTPEnable);
                string smtpServer = MiscUtilities.GetDBValue<string>(Constants._settingSMTPServer);
                bool useCredential = MiscUtilities.GetDBValue<bool>(Constants._settingSMTPUseCredential);
                string userName = MiscUtilities.GetDBValue<string>(Constants._settingSMTPUserName);
                string password = MiscUtilities.GetDBValue<string>(Constants._settingSMTPPassword);
                int port = MiscUtilities.GetDBValue<int>(Constants._settingSMTPPort);
                string fromEmail = MiscUtilities.GetDBValue<string>(Constants._settingSMTPFromAddress);
                string fromName = MiscUtilities.GetDBValue<string>(Constants._settingSMTPFromName);
                bool enableSSL = MiscUtilities.GetDBValue<bool>(Constants._settingSMTPEnableSSL);

                if (enabled)
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(fromName, fromEmail));
                    message.To.Add(new MailboxAddress(toEmail));
                    message.Subject = subject;                    

                    if (isHTML)
                    {
                        var bodyBuilder = new BodyBuilder();
                        bodyBuilder.HtmlBody = body;
                        message.Body = bodyBuilder.ToMessageBody();
                    }
                    else
                    {
                        message.Body = new TextPart("plain") { Text = body };
                    }

                    using (var smtpClient = new SmtpClient())
                    {
                        smtpClient.Connect(smtpServer, port, enableSSL);

                        if (useCredential)
                            smtpClient.Authenticate(userName, password);
                        
                        smtpClient.Send(message);
                        smtpClient.Disconnect(true);
                    }

                    return Result.Success;
                }
                else
                {
                    return Result.Success;
                }
            }
            catch
            {
                return Result.Error;
            }
        }

        public static Result SendCredentials(string emailAddress, string username, string fullName, string callBackUrl)
        {
            if (!string.IsNullOrEmpty(emailAddress.Trim()))
            {
                string body =
                        "Hello " + fullName + ",<br /><br />" +
                        "Your email login is " + username + "." + "<br />" +
                        "Please click <a href=\"" + callBackUrl + "\">here</a> to reset your password.<br />" +
                        "(Note: The link above will expire after 24 hours.)<br /><br />" +
                        "Thanks,<br />" +
                        "PAS Administrator";

                return Send(
                    emailAddress,
                    "[Peregrine Academic Services] Welcome to B-School Connection - Education Resource Center",
                    body,
                    true);
            }
            else
            {
                return Result.Success;
            }
        }
    }
}
