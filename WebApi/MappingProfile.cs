using AutoMapper;
using Entity;
using Entity.ViewModel;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
