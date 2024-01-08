using BootstrapBlazor.Components;
using System.Diagnostics.CodeAnalysis;

namespace WebUI.Pages
{
    public partial class Home
    {
        [NotNull]
        private ConsoleLogger? NormalLogger { get; set; }

        private Task OnChanged(CollapseItem item)
        {
            NormalLogger.Log($"{item.Text}: {item.IsCollapsed}");
            return Task.CompletedTask;
        }

        private bool State { get; set; }

        private void OnToggle()
        {
            State = !State;
        }

        /// <summary>
        /// 获得属性方法
        /// </summary>
        /// <returns></returns>
        private AttributeItem[] GetAttributes() =>
        [
            new()
            {
                Name = "CollapseItems",
                Description = "内容",
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new()
            {
                Name = "IsAccordion",
                Description = "是否手风琴效果",
                Type = "bool",
                ValueList = "true|false",
                DefaultValue = "false"
            },
            new()
            {
                Name = "OnCollapseChanged",
                Description = "项目收起展开状态改变回调方法",
                Type = "Func<CollapseItem, Task>",
                ValueList = " — ",
                DefaultValue = " — "
            }
        ];
    }

    public class AttributeItem
    {
        /// <summary>
        /// 获取或设置属性的名称。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 获取或设置属性的描述。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 获取或设置属性的类型。
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 获取或设置属性的取值列表（如果有）。
        /// </summary>
        public string ValueList { get; set; }

        /// <summary>
        /// 获取或设置属性的默认值。
        /// </summary>
        public string DefaultValue { get; set; }
    }
}
