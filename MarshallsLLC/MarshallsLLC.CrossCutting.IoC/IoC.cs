using MarshallsLLC.Data.Context;
using MarshallsLLC.Data.Repository;
using MarshallsLLC.Domain.Services;
using Microsoft.EntityFrameworkCore;
using MarshallsLLC.Application.Mapping;
using Microsoft.Extensions.Configuration;
using MarshallsLLC.Application.Interfaces;
using MarshallsLLC.Application.AppServices;
using MarshallsLLC.Domain.Interfaces.Service;
using Microsoft.Extensions.DependencyInjection;
using MarshallsLLC.Domain.Interfaces.Repository;
using MarshallsLLC.CrossCutting.IoC.ConfigurationModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MarshallsLLC.CrossCutting.IoC
{
    public static class IoC
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
            services.AddScoped<ISalaryDetailService, SalaryDetailService>();
            services.AddScoped<IEmployeeMonthlySalaryService, EmployeeMonthlySalaryService>();

            services.AddScoped<IDivisionService, DivisionService>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUriAppService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriAppService(uri);
            });
        }
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeAppService, EmployeeAppService>();
            services.AddScoped<IEnrollmentAppService, EnrollmentAppService>();
            services.AddScoped<ISalaryDetailAppService, SalaryDetailAppService>();
            services.AddScoped<IEmployeeMonthlySalaryAppService, EmployeeMonthlySalaryAppService>();

            services.AddScoped<IDivisionAppService, DivisionAppService>();
            services.AddScoped<IOfficeAppService, OfficeAppService>();
            services.AddScoped<IPositionAppService, PositionAppService>();
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<ISalaryDetailRepository, SalaryDetailRepository>();
            services.AddScoped<IEmployeeMonthlySalaryRepository, EmployeeMonthlySalaryRepository>();

            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
        }
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("ConnectionStrings").Get<DatabaseConfiguration>();
            services.AddDbContext<MarshallContext>(options =>
                      options.UseSqlServer(databaseConfig.DefaultConnection));
        }
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}