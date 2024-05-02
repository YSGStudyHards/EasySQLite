using SQLite;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Student
    {
        /// <summary>
        /// 学生ID [主键，自动递增]
        /// </summary>
        [PrimaryKey, AutoIncrement]
        [Display(Name = "学生ID")]
        public int StudentID { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        [Display(Name = "班级ID")]
        public int ClassID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Display(Name = "学生姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        [Display(Name = "学生年龄")]
        public int Age { get; set; }

        /// <summary>
        /// 学生性别
        /// </summary>
        [Display(Name = "学生性别")]
        public string Gender { get; set; }
    }
}
