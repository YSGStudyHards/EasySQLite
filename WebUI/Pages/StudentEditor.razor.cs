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

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            var getSchoolClass = new List<SchoolClass>();
            if (_memoryCache.TryGetValue("SchoolClassData", out string data))
            {
                getSchoolClass = JsonConvert.DeserializeObject<List<SchoolClass>>(data);
            }
            else
            {
                getSchoolClass = await _dataLoader.LoadSchoolClassDataAsync().ConfigureAwait(false);
            }

            Items = [new SelectedItem { Value = "0", Text = "...请选择班级..." }];

            foreach (var item in getSchoolClass)
            {
                Items.Add(new SelectedItem { Value = item.ClassID.ToString(), Text = item.ClassName });
            }

            if (string.IsNullOrEmpty(Value.ClassName))
            {
                Value.ClassName = Items.First().Text;
            }
        }
    }
}
