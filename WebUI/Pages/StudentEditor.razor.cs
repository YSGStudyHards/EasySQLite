using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Json;
using System.Xml.Linq;
using BootstrapBlazor.Components;
using Entity;
using Entity.ViewModel;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using WebUI.Services;

namespace WebUI.Pages
{
    public partial class StudentEditor
    {
        [Parameter]
        public StudentViewModel Value { get; set; }

        [Parameter]
        public EventCallback<StudentViewModel> ValueChanged { get; set; }

        [NotNull]
        private List<SelectedItem>? Items { get; set; }

        [NotNull]
        private List<SelectedItem>? GenderItems { get; set; }

        protected override async void OnInitialized()
        {
            base.OnInitialized();
            List<SchoolClass>? getSchoolClass;
            if (_memoryCache.TryGetValue("SchoolClassData", out string data))
            {
                getSchoolClass = JsonConvert.DeserializeObject<List<SchoolClass>>(data);
            }
            else
            {
                getSchoolClass = await _dataLoader.LoadSchoolClassDataAsync().ConfigureAwait(false);
            }

            Items = [];
            foreach (var item in getSchoolClass.OrderBy(x => x.ClassID).ToList())
            {
                Items.Add(new SelectedItem { Value = item.ClassID.ToString(), Text = item.ClassName });
            }

            if (string.IsNullOrWhiteSpace(Value.ClassName))
            {
                Value.ClassName = Items.First().Text;
                Value.ClassID = Convert.ToInt32(Items.First().Value);
            }

            GenderItems = [new SelectedItem { Value = "男", Text = "男" }, new SelectedItem { Value = "女", Text = "女" }];

            if (string.IsNullOrWhiteSpace(Value.Gender))
            {
                Value.Gender = GenderItems.First().Text;
            }
        }

        /// <summary>
        /// 下拉框选项改变时触发此事件
        /// </summary>
        /// <param name="item">item</param>
        /// <returns></returns>
        async Task OnSelectedItemChanged(SelectedItem item)
        {
            await Task.Delay(1);
            Value.ClassID = Convert.ToInt32(item.Value);
        }
    }
}
