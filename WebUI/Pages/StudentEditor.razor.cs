using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Json;
using BootstrapBlazor.Components;
using Entity;
using Entity.ViewModel;
using Microsoft.AspNetCore.Components;

namespace WebUI.Pages
{
    public partial class StudentEditor
    {
        [Parameter]
        public StudentViewModel? Value { get; set; }

        [Parameter]
        public EventCallback<StudentViewModel> ValueChanged { get; set; }

        [NotNull]
        private List<SelectedItem>? Items { get; set; }

        protected override async void OnInitialized()
        {
            base.OnInitialized();

            var getResults = await _httpClient
                .GetFromJsonAsync<ApiResponse<List<SchoolClass>>>("api/SchoolClass/GetAllClass")
                .ConfigureAwait(false);

            Items = new List<SelectedItem>();
            if (getResults.Success)
            {
                foreach (var item in getResults.Data)
                {
                    Items.Add(
                        new SelectedItem { Value = item.ClassID.ToString(), Text = item.ClassName }
                    );
                }
            }

            Value.ClassName = Items.First().Value;
        }
    }
}
