using Entity;
using Microsoft.AspNetCore.Mvc;
using Utility;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    /// <summary>
    /// 学生管理
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly SQLiteAsyncHelper<Student> _studentHelper;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="studentHelper">studentHelper</param>
        public StudentController(SQLiteAsyncHelper<Student> studentHelper)
        {
            _studentHelper = studentHelper;
        }

        /// <summary>
        /// 创建新的学生记录
        /// </summary>
        /// <param name="student">添加的学生信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse<int>> CreateAsync([FromBody] Student student)
        {
            var response = new ApiResponse<int>();
            try
            {
                var insertNumbers = await _studentHelper.InsertAsync(student).ConfigureAwait(false);
                if (insertNumbers > 0)
                {
                    response.Success = true;
                    response.Message = "添加成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "插入失败";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 查询所有学生记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ApiResponse<List<Student>>> GetAllAsync()
        {
            var response = new ApiResponse<List<Student>>();
            try
            {
                var students = await _studentHelper.QueryAllAsync().ConfigureAwait(false);
                response.Success = true;
                response.Data = students;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 根据学生ID查询学生信息
        /// </summary>
        /// <param name="studentID">学生ID</param>
        /// <returns></returns>
        [HttpGet("{studentID}")]
        public async Task<ApiResponse<Student>> GetByIdAsync(int studentID)
        {
            var response = new ApiResponse<Student>();
            try
            {
                var student = await _studentHelper.QuerySingleAsync(x => x.StudentID == studentID).ConfigureAwait(false);
                if (student != null)
                {
                    response.Success = true;
                    response.Data = student;
                }
                else
                {
                    response.Success = false;
                    response.Message = "未找到学生信息";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 更新学生记录
        /// </summary>
        /// <param name="studentID">学生ID</param>
        /// <param name="editstudent">更新的学生信息</param>
        /// <returns></returns>
        [HttpPut("{studentID}")]
        public async Task<ApiResponse<int>> UpdateAsync(int studentID, [FromBody] Student editstudent)
        {
            var response = new ApiResponse<int>();
            try
            {
                var student = await _studentHelper.QuerySingleAsync(x => x.StudentID == studentID).ConfigureAwait(false);
                if (student != null)
                {
                    student.Age = editstudent.Age;
                    student.Name = editstudent.Name;
                    student.Gender = editstudent.Gender;
                    student.ClassID = editstudent.ClassID;

                    int updateResult = await _studentHelper.UpdateAsync(student).ConfigureAwait(false);
                    if (updateResult > 0)
                    {
                        response.Success = true;
                        response.Message = "学生信息更新成功";
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "学生信息更新失败";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "未找到学生信息";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        /// <summary>
        /// 删除学生记录
        /// </summary>
        /// <param name="studentID">学生ID</param>
        /// <returns></returns>
        [HttpDelete("{studentID}")]
        public async Task<ApiResponse<int>> DeleteAsync(int studentID)
        {
            var response = new ApiResponse<int>();
            try
            {
                int deleteResult = await _studentHelper.DeleteAsync(studentID).ConfigureAwait(false);
                if (deleteResult > 0)
                {
                    response.Success = true;
                    response.Message = "删除成功";
                }
                else
                {
                    response.Success = false;
                    response.Message = "未找到学生信息";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
