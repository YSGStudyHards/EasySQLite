using Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using System.Reflection;
using Utility;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //添加 AutoMapper 的配置
            //使用AddAutoMapper()方法可以将AutoMapper所需的服务添加到该集合中，以便在应用程序的其他部分中使用。
            //该方法需要传入一个Assembly数组，以告诉AutoMapper要扫描哪些程序集来查找映射配置(在当前作用域的所有程序集里面扫描AutoMapper的配置文件)。
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                //修改属性名称的序列化方式[前端想要使用与后端模型本身命名格式输出]
                options.SerializerSettings.ContractResolver = null;
                //日期类型默认格式化处理 
                //options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            });

            // 添加Swagger服务
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EasySQLite API",
                    Version = "V1",
                    Description = ".NET 8操作SQLite入门到实战",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHub源码地址",
                        Url = new Uri("https://github.com/YSGStudyHards/EasySQLite")
                    }
                });

                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                options.IncludeXmlComments(xmlPath, true);
                // 对action的名称进行排序，如果有多个，就可以看见效果了
                options.OrderActionsBy(o => o.RelativePath);
            });

            // 添加OpenApi服务，这是Scalar所需的
            builder.Services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new()
                    {
                        Title = "EasySQLite API",
                        Version = "V1",
                        Description = ".NET 8操作SQLite入门到实战"
                    };
                    return Task.CompletedTask;
                });
            });

            var PolicyCorsName = "EasySQLitePolicy";

            builder.Services.AddCors(option =>
            {
                option.AddPolicy(PolicyCorsName, builder =>
                {
                    builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
                });
            });

            // 注册服务
            builder.Services.AddScoped<SQLiteAsyncHelper<SchoolClass>>();
            builder.Services.AddScoped<SQLiteAsyncHelper<Student>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.MapScalarApiReference();//映射Scalar的API参考文档路径
                app.MapOpenApi();//映射OpenApi文档路径
            }

            app.UseHttpsRedirection();

            app.UseCors(PolicyCorsName);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
