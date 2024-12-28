using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

            builder.Services.AddTransient<DataLoaderService>();

            // 获取环境变量
            var environment = builder.HostEnvironment.Environment;
            var baseAddress = environment == "Development" ? "https://localhost:7240/" : "http://localhost:8899/";

            // 注册 HttpClient 并设置 BaseAddress
            builder.Services.AddScoped(sp => new HttpClient(new HttpClientHandler { AllowAutoRedirect = false })
            {
                BaseAddress = new Uri(baseAddress)
            });

            await builder.Build().RunAsync();
        }
    }
}
