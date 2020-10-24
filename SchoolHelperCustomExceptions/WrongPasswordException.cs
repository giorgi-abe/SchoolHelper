using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperCustomExceptions
{
    public class WrongPasswordException : Exception
    {
        private static readonly string DefaultMessage = "Wrong Password";
        public WrongPasswordException() : base(DefaultMessage)
        {

        }
        public WrongPasswordException(string message, Exception inner)
       : base(message, inner)
        {
        }
    }
}
