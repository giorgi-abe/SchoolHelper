using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Abstraction
{
    public interface IPhotoService
    {
        void Upload(string path);
        string PhotoLink(string id);
    }
}
