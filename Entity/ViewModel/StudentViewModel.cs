using System.ComponentModel.DataAnnotations;

namespace Entity.ViewModel
{
    public class StudentViewModel : Student
    {
        /// <summary>
        /// 班级名称
        /// </summary>
        [Display(Name = "班级名称")]
        public string ClassName { get; set; }
    }
}
