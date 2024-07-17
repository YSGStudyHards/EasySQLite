using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Services;

namespace WebUI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            //将 BootstrapBlazor 库添加到 ASP.NET Core 项目中的依赖关系注入容器中
            builder.Services.AddBootstrapBlazor();

            builder.Services.AddTransient<DataLoader>();

            builder.Services.AddScoped(sp => new HttpClient(new HttpClientHandler { AllowAutoRedirect = false })
            {
                BaseAddress = new Uri("https://localhost:7240/")
            });

            await builder.Build().RunAsync();
        }
    }
}
