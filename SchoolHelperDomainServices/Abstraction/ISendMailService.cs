using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction
{
    public interface ISendMailService
    {
        Task<bool> SentMail(MailUserDto Sender, MailUserDto receiver, MailMessageDto messageDto);
    }
}
