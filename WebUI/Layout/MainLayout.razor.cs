using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace WebUI.Layout
{
    public partial class MainLayout
    {
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem>? Menus { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Menus = GetIconSideMenuItems();
        }

        private static List<MenuItem> GetIconSideMenuItems()
        {
            var menus = new List<MenuItem>
            {
               new MenuItem() { Text = "Home", Icon = "fa-solid fa-fw fa-flag", Url = "/" , Match = NavLinkMatch.All},
               new MenuItem() { Text = "班级管理", Icon = "fa-solid fa-solid fa-users-gear", Url = "SchoolClass" },
               new MenuItem() { Text = "学生管理", Icon = "fa-solid fa-solid fa-user-gear", Url = "Student" },
               new MenuItem() { Text = "TableExample", Icon = "fa-solid fa-solid fas fa-beer-mug-empty", Url = "StudentExample" },
            };
            return menus;
        }
    }
}
