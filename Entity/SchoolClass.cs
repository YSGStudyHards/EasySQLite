using SQLite;

namespace Entity
{
    public class SchoolClass
    {
        /// <summary>
        /// 班级ID [主键，自动递增]
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ClassID { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
