namespace Entity.ViewModel
{
    public class UserInfoViewModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 合并 FirstName + LastName
        /// </summary>
        public string FullName { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// 格式化日期
        /// </summary>
        public string CreatedDate { get; set; }
    }
}
