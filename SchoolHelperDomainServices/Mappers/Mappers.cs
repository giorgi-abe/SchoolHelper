using AutoMapper;
using SchoolHelperDomainModels.Abstraction;
using SchoolHelperDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAppDomainServices.Mappers
{
    public static class Mappers
    {
        public static T2 Map<T1, T2>(this T1 item)
        {
            IConfigurationProvider configuration = new MapperConfiguration(conf =>
            {
                conf.AddProfile(new DefaultMapper());
            });
            IMapper mapper = new Mapper(configuration);
            return mapper.Map<T2>(item);
        }
    }
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<IStudentAccount, AccountDto>().ReverseMap();
            CreateMap<IStudent, StudentDto>().ReverseMap();
            CreateMap<ISubject, SubjectDto>().ReverseMap();
            CreateMap<ITeacherAccount, AccountDto>().ReverseMap();
            CreateMap<FullAccountDto, IStudentAccount>().ReverseMap();
            CreateMap<FullAccountDto, ITeacherAccount>().ReverseMap();
            CreateMap<IAccount, ITeacherAccount>().ReverseMap();
            CreateMap<IAccount, IStudentAccount>().ReverseMap();
        }
    }
}
