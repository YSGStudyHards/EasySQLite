using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    /// <summary>
    /// Student管理
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet(Name = "GetStudents")]
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>();
        }
    }
}
