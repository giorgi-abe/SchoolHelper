
using MailKit.Net.Smtp;
using MimeKit;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDomainServices.Abstraction;
using SchoolHelperDomainServices.Implementation.LoginServices;
using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentMSDomainServices.implementations
{
    public class SendMailService : ISendMailService
    {
        public async Task<bool> SentMail(MailUserDto Sender, MailUserDto receiver, MailMessageDto messageDto)
        {
            try
            {
                var LoginedAccount = await LoginUserHelperManager.GetCurrentUser();
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(Sender.Username, Sender.Mail));
                message.To.Add(new MailboxAddress(receiver.Username, receiver.Mail));
                message.Subject = messageDto.subject;
                message.Body = new TextPart("plain") { Text = messageDto.text };

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("MPDCMessageSender@gmail.com", "asdasd123A@");
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
