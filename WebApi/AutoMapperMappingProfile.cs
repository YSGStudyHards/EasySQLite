using AutoMapper;
using Entity;
using Entity.ViewModel;

namespace WebApi
{
    /// <summary>
    /// AutoMapper映射配置文件
    /// </summary>
    public class AutoMapperMappingProfile : Profile
    {
        /// <summary>
        /// 添加映射规则
        /// </summary>
        public AutoMapperMappingProfile()
        {
            CreateMap<Student, StudentViewModel>();
        }
    }
}
