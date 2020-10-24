using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using SchoolHelperDomainServices.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolHelperDomainServices.Implementation
{
    public class PhotoService : IPhotoService
    {
        private string _path = default;
        private static readonly Cloudinary cloud = new Cloudinary(new Account
        #region
            ("ddmz8jevk", "262695729563648", "aohXKaomfpBG5SbFTXR3w6Pz_A0")
        #endregion
            );
        public string PhotoLink(string id)
        {
            string tmp = "https://res.cloudinary.com/ddmz8jevk/image/upload/" + id;
            return tmp;
        }

        public void Upload(string path)
        {
            
            string tmpPath = path.Split('\\').LastOrDefault().Split('.').FirstOrDefault();
            cloud.Upload(new ImageUploadParams()
            {
                File = new FileDescription(path),
                PublicId = tmpPath
            });
        }
    }
}
