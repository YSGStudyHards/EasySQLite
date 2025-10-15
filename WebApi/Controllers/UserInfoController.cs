using Entity;
using Entity.ViewModel;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// 使用 Mapster 映射 UserInfo 示例
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="mapper">mapper</param>
        public UserInfoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// GetUserInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserInfoViewModel> GetUserInfos()
        {
            var userInfos = new List<UserInfo>
            {
                new UserInfo
                {
                    Id = 999,
                    FirstName = "李",
                    LastName = "四",
                    Email = "lisi@qq.com",
                    CreatedAt = DateTime.Now.AddYears(-5)
                },
                new UserInfo
                {
                    Id = 666,
                    FirstName = "张",
                    LastName = "三",
                    Email = "zhangsan@example.com",
                    CreatedAt = DateTime.UtcNow.AddDays(-10)
                }
            };

            // 使用 Mapster 映射
            var getUserInfoViewModels = _mapper.Map<List<UserInfoViewModel>>(userInfos);
            return getUserInfoViewModels;
        }
    }
}
