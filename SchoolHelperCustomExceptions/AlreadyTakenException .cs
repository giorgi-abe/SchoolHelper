using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperCustomExceptions
{
    public class AlreadyTakenException : Exception
    {
        private static readonly string DefaultMessage = "This username or mail is already taken";
        public AlreadyTakenException() : base(DefaultMessage)
        {

        }
        public AlreadyTakenException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
