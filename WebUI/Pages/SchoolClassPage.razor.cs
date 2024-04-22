using BootstrapBlazor.Components;
using Entity;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace WebUI.Pages
{
    public partial class SchoolClassPage
    {
        private readonly HttpClient _httpClient;

        public SchoolClassPage(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="options">options</param>
        /// <returns></returns>
        private async Task<QueryData<SchoolClass>> OnQueryAsync(QueryPageOptions options)
        {
            var getClass = await _httpClient.GetFromJsonAsync<List<SchoolClass>>("api/SchoolClass/GetClass") ?? new List<SchoolClass>();
            // 数据模糊过滤筛选
            if (!string.IsNullOrWhiteSpace(options.SearchText))
            {
                getClass = getClass.Where(x => x.ClassName.Contains(options.SearchText)).ToList();
            }

            return await Task.FromResult(new QueryData<SchoolClass>()
            {
                Items = getClass.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = getClass.Count()
            });
        }

        /// <summary>
        /// 模拟数据增加和修改操作
        /// </summary>
        /// <param name="studentInfo">studentInfo</param>
        /// <param name="changedType">changedType</param>
        /// <returns></returns>
        //public Task<bool> OnSaveAsync(SchoolClass studentInfo, ItemChangedType changedType)
        //{
        //    //if (changedType.ToString() == "Update")
        //    //{
        //    //    var queryInfo = StudentInfoList.FirstOrDefault(x => x.StudentID == studentInfo.StudentID);
        //    //    if (queryInfo != null)
        //    //    {
        //    //        queryInfo.Age = studentInfo.Age;
        //    //        queryInfo.ClassName = studentInfo.ClassName;
        //    //        queryInfo.Name = studentInfo.Name;
        //    //        queryInfo.Gender = studentInfo.Gender;
        //    //    }
        //    //}
        //    //else if (changedType.ToString() == "Add")
        //    //{
        //    //    StudentInfoList.Add(studentInfo);
        //    //}
        //    return Task.FromResult(true);
        //}

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="items">items</param>
        /// <returns></returns>
        //private Task<bool> OnDeleteAsync(IEnumerable<SchoolClass> items)
        //{
        //    //items.ToList().ForEach(i => StudentInfoList.Remove(i));
        //    return Task.FromResult(true);
        //}
    }
}
