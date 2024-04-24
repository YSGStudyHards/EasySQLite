using Entity;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace WebApi.Controllers
{
    /// <summary>
    /// 学校班级管理
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SchoolClassController : ControllerBase
    {
        private readonly SQLiteAsyncHelper<SchoolClass> _schoolClassHelper;

        /// <summary>
        /// 依赖注入
        /// </summary>
        /// <param name="schoolClassHelper">schoolClassHelper</param>
        public SchoolClassController(SQLiteAsyncHelper<SchoolClass> schoolClassHelper)
        {
            _schoolClassHelper = schoolClassHelper;
        }

        /// <summary>
        /// 班级创建
        /// </summary>
        /// <param name="schoolClass">创建班级信息</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse<int>> CreateClass([FromBody] SchoolClass schoolClass)
        {
            try
            {
                var querySchoolClass = await _schoolClassHelper.QuerySingleAsync(c => c.ClassName == schoolClass.ClassName).ConfigureAwait(false);
                if (querySchoolClass != null)
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Message = $"创建班级失败，班级{schoolClass.ClassName}已存在"
                    };
                }

                schoolClass.CreateTime = DateTime.Now;
                int insertNumbers = await _schoolClassHelper.InsertAsync(schoolClass);
                if (insertNumbers > 0)
                {
                    return new ApiResponse<int>
                    {
                        Success = true,
                        Message = "创建班级成功"
                    };
                }
                else
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Message = "创建班级失败"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        [HttpGet]
        public async Task<ApiResponse<List<SchoolClass>>> GetClass()
        {
            try
            {
                var classes = await _schoolClassHelper.QueryAllAsync().ConfigureAwait(false);
                return new ApiResponse<List<SchoolClass>>
                {
                    Success = true,
                    Data = classes
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<SchoolClass>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// 根据班级ID获取班级信息
        /// </summary>
        /// <param name="classId">班级ID</param>
        /// <returns></returns>
        [HttpGet("{classId}")]
        public async Task<ApiResponse<SchoolClass>> GetClass(int classId)
        {
            try
            {
                var schoolClass = await _schoolClassHelper.QuerySingleAsync(c => c.ClassID == classId).ConfigureAwait(false);
                if (schoolClass != null)
                {
                    return new ApiResponse<SchoolClass>
                    {
                        Success = true,
                        Data = schoolClass
                    };
                }
                else
                {
                    return new ApiResponse<SchoolClass>
                    {
                        Success = false,
                        Message = "班级不存在"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<SchoolClass>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// 更新班级信息
        /// </summary>
        /// <param name="classId">班级ID</param>
        /// <param name="updatedClass">更新的班级信息</param>
        /// <returns></returns>
        [HttpPut("{classId}")]
        public async Task<ApiResponse<int>> UpdateClass(int classId, [FromBody] SchoolClass updatedClass)
        {
            try
            {
                var existingClass = await _schoolClassHelper.QuerySingleAsync(c => c.ClassID == classId).ConfigureAwait(false);

                if (existingClass != null)
                {
                    existingClass.ClassName = updatedClass.ClassName;
                    var updateResult = await _schoolClassHelper.UpdateAsync(existingClass).ConfigureAwait(false);
                    if (updateResult > 0)
                    {
                        return new ApiResponse<int>
                        {
                            Success = true,
                            Message = "班级信息更新成功"
                        };
                    }
                    else
                    {
                        return new ApiResponse<int>
                        {
                            Success = false,
                            Message = "班级信息更新失败"
                        };
                    }
                }
                else
                {
                    return new ApiResponse<int>
                    {
                        Success = false,
                        Message = "班级不存在"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// 班级删除
        /// </summary>
        /// <param name="classId">班级ID</param>
        /// <returns></returns>
        [HttpDelete("{classId}")]
        public async Task<ApiResponse<int>> DeleteClass(int classId)
        {
            try
            {
                var deleteResult = await _schoolClassHelper.DeleteAsync(classId).ConfigureAwait(false);

                if (deleteResult > 0)
                {
                    return new ApiResponse<int>
                    {
                        Success = true,
                        Message = "班级删除成功"
                    };
                }
                else
                {
                    return new ApiResponse<int>
                    {
                        Success = true,
                        Message = "班级删除失败"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
