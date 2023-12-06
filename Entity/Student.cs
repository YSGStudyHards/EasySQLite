using SQLite;

namespace Entity
{
    public class Student
    {
        /// <summary>
        /// 学生ID [主键，自动递增]
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int StudentID { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public int ClassID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        public string Gender { get; set; }
    }
}
