using AutoMapper;
using Entity;
using Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace WebApi.Controllers
{
    /// <summary>
    /// 学生管理
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly SQLiteAsyncHelper<Student> _studentHelper;
        private readonly SQLiteAsyncHelper<SchoolClass> _schoolClassHelper;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="mapper">mapper</param>
        /// <param name="studentHelper">studentHelper</param>
        /// <param name="schoolClassHelper">schoolClassHelper</param>
        public StudentController(IMapper mapper, SQLiteAsyncHelper<Student> studentHelper, SQLiteAsyncHelper<SchoolClass> schoolClassHelper)
        {
            _mapper = mapper;
            _studentHelper = studentHelper;
            _schoolClassHelper = schoolClassHelper;
        }

        /// <summary>
        /// 创建新的学生记录
        /// </summary>
        /// <param name="student">添加的学生信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse<int>> CreateStudent([FromBody] Student student)
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
        public async Task<ApiResponse<List<StudentViewModel>>> GetAllStudent()
        {
            var response = new ApiResponse<List<StudentViewModel>>();
            try
            {
                var students = await _studentHelper.QueryAllAsync().ConfigureAwait(false);
                var studentsDtoList = await GetStudentClassInfo(students).ConfigureAwait(false);
                response.Success = true;
                response.Data = studentsDtoList;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private async Task<List<StudentViewModel>?> GetStudentClassInfo(List<Student> students)
        {
            var studentsDtoList = _mapper.Map<List<StudentViewModel>>(students);
            if (studentsDtoList?.Count > 0)
            {
                var classIDs = studentsDtoList.Select(x => x.ClassID).Distinct().ToList();
                var querySchoolClassList = await _schoolClassHelper.QueryAsync(x => classIDs.Contains(x.ClassID)).ConfigureAwait(false);
                if (querySchoolClassList?.Count > 0)
                {
                    foreach (var studentItem in studentsDtoList)
                    {
                        var getClassInfo = querySchoolClassList.FirstOrDefault(x => x.ClassID == studentItem.ClassID);
                        if (getClassInfo != null)
                        {
                            studentItem.ClassName = getClassInfo.ClassName;
                        }
                    }
                }
            }

            return studentsDtoList;
        }

        /// <summary>
        /// 根据学生ID查询学生信息
        /// </summary>
        /// <param name="studentID">学生ID</param>
        /// <returns></returns>
        [HttpGet("{studentID}")]
        public async Task<ApiResponse<StudentViewModel>> GetStudentById(int studentID)
        {
            var response = new ApiResponse<StudentViewModel>();
            try
            {
                var student = await _studentHelper
                    .QuerySingleAsync(x => x.StudentID == studentID)
                    .ConfigureAwait(false);
                if (student != null)
                {
                    var studentsDto = await GetStudentClassInfo(new List<Student> { student }).ConfigureAwait(false);
                    response.Success = true;
                    response.Data = studentsDto.FirstOrDefault();
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
        public async Task<ApiResponse<int>> UpdateStudent(
            int studentID,
            [FromBody] Student editstudent
        )
        {
            var response = new ApiResponse<int>();
            try
            {
                var student = await _studentHelper
                    .QuerySingleAsync(x => x.StudentID == studentID)
                    .ConfigureAwait(false);
                if (student != null)
                {
                    student.Age = editstudent.Age;
                    student.Name = editstudent.Name;
                    student.Gender = editstudent.Gender;
                    student.ClassID = editstudent.ClassID;

                    int updateResult = await _studentHelper
                        .UpdateAsync(student)
                        .ConfigureAwait(false);
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
        public async Task<ApiResponse<int>> DeleteStudent(int studentID)
        {
            var response = new ApiResponse<int>();
            try
            {
                int deleteResult = await _studentHelper
                    .DeleteAsync(studentID)
                    .ConfigureAwait(false);
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
