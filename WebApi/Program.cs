using Entity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
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
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // ��� AutoMapper ������
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                //�޸��������Ƶ����л���ʽ[ǰ����Ҫʹ������ģ�ͱ���������ʽ���]
                options.SerializerSettings.ContractResolver = null;
                //��������Ĭ�ϸ�ʽ������ 
                //options.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            });

            // ���Swagger����
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EasySQLite API",
                    Version = "V1",
                    Description = ".NET 8����SQLite���ŵ�ʵս",
                    Contact = new OpenApiContact
                    {
                        Name = "GitHubԴ���ַ",
                        Url = new Uri("https://github.com/YSGStudyHards/EasySQLite")
                    }
                });

                // ��ȡxml�ļ���
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // ��ȡxml�ļ�·��
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // ��ӿ�������ע�ͣ�true��ʾ��ʾ������ע��
                options.IncludeXmlComments(xmlPath, true);
                // ��action�����ƽ�����������ж�����Ϳ��Կ���Ч����
                options.OrderActionsBy(o => o.RelativePath);
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

            // ע�����
            builder.Services.AddScoped<SQLiteAsyncHelper<SchoolClass>>();
            builder.Services.AddScoped<SQLiteAsyncHelper<Student>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(PolicyCorsName);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
