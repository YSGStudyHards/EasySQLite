using BootstrapBlazor.Components;
using Entity;
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

        public static List<StudentViewModel> GenerateUserInfos()
        {
            return new List<StudentViewModel>(Enumerable.Range(1, 10).Select(i => new StudentViewModel()
            {
                StudentID = i,
                ClassName = $"时光 {i} 班",
                Name = GenerateRandomName(),
                Age = random.Next(20, 50),
                Gender = "男"
            }));
        }

        public static string GenerateRandomName()
        {
            string[] surnames = { "张", "王", "李", "赵", "刘" };
            string[] names = { "明", "红", "强", "丽", "军" };
            string surname = surnames[random.Next(surnames.Length)]; // 随机获取一个姓氏
            string name = names[random.Next(names.Length)]; // 随机获取一个名字
            return surname + name; // 返回生成的姓名
        }

        /// <summary>
        /// 模拟数据增加和修改操作
        /// </summary>
        /// <param name="studentInfo">studentInfo</param>
        /// <param name="changedType">changedType</param>
        /// <returns></returns>
        public static Task<bool> OnSaveAsync(StudentViewModel studentInfo, ItemChangedType changedType)
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
            return Task.FromResult(true);
        }
    }
}
