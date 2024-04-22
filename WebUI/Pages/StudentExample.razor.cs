using BootstrapBlazor.Components;
using WebUI.Model;

namespace WebUI.Pages
{
    public partial class StudentExample
    {
        private static readonly Random random = new Random();
        public static List<StudentViewModel>? StudentInfoList;

        public StudentExample()
        {
            StudentInfoList = GenerateUserInfos();
        }

        /// <summary>
        /// 模拟数据库用户信息生成
        /// </summary>
        /// <returns></returns>
        public static List<StudentViewModel> GenerateUserInfos()
        {
            return new List<StudentViewModel>(Enumerable.Range(1, 200).Select(i => new StudentViewModel()
            {
                StudentID = i,
                ClassName = $"时光 {i} 班",
                Name = GenerateRandomName(),
                Age = random.Next(20, 50),
                Gender = GenerateRandomGender()
            }));
        }

        /// <summary>
        /// 生成随机性别
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomGender()
        {
            string[] genders = { "男", "女" };
            return genders[random.Next(genders.Length)];
        }

        /// <summary>
        /// 生成随机姓名
        /// </summary>
        /// <returns></returns>
        public static string GenerateRandomName()
        {
            string[] surnames = { "张", "王", "李", "赵", "刘" };
            string[] names = { "明", "红", "强", "丽", "军" };
            string surname = surnames[random.Next(surnames.Length)];
            string name = names[random.Next(names.Length)];
            return surname + name;
        }

        /// <summary>
        /// 数据查询
        /// </summary>
        /// <param name="options">options</param>
        /// <returns></returns>
        private async Task<QueryData<StudentViewModel>> OnQueryAsync(QueryPageOptions options)
        {
            List<StudentViewModel> studentInfoData = StudentInfoList;

            // 数据模糊过滤筛选
            if (!string.IsNullOrWhiteSpace(options.SearchText))
            {
                studentInfoData = studentInfoData.Where(x => x.Name.Contains(options.SearchText)).ToList();
            }

            return await Task.FromResult(new QueryData<StudentViewModel>()
            {
                Items = studentInfoData.Skip((options.PageIndex - 1) * options.PageItems).Take(options.PageItems).ToList(),
                TotalCount = studentInfoData.Count()
            });
        }

        /// <summary>
        /// 模拟数据增加和修改操作
        /// </summary>
        /// <param name="studentInfo">studentInfo</param>
        /// <param name="changedType">changedType</param>
        /// <returns></returns>
        public async Task<bool> OnSaveAsync(StudentViewModel studentInfo, ItemChangedType changedType)
        {
            if (changedType.ToString() == "Update")
            {
                var queryInfo = StudentInfoList.FirstOrDefault(x => x.StudentID == studentInfo.StudentID);
                if (queryInfo != null)
                {
                    queryInfo.Age = studentInfo.Age;
                    queryInfo.ClassName = studentInfo.ClassName;
                    queryInfo.Name = studentInfo.Name;
                    queryInfo.Gender = studentInfo.Gender;
                }
            }
            else if (changedType.ToString() == "Add")
            {
                StudentInfoList.Add(studentInfo);
            }
            return await Task.FromResult(true);
        }

        /// <summary>
        /// 数据删除
        /// </summary>
        /// <param name="items">items</param>
        /// <returns></returns>
        private async Task<bool> OnDeleteAsync(IEnumerable<StudentViewModel> items)
        {
            items.ToList().ForEach(i => StudentInfoList.Remove(i));
            return await Task.FromResult(true);
        }
    }
}
