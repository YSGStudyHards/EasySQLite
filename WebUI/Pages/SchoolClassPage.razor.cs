using BootstrapBlazor.Components;
using System.Diagnostics.CodeAnalysis;
using WebUI.Model;

namespace WebUI.Pages
{
    public partial class SchoolClassPage
    {
        //这里只是演示，没有增加修改数据
        protected static Task<bool> OnSaveAsync(UserInfo userInfo, ItemChangedType changedType)
        {
            return Task.FromResult(true);
        }
    }
}
