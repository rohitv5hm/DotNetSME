using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectX.Data;
using ProjectX.Data.Repositories;
using System;


namespace ProjectX.Extensions
{

    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            Console.WriteLine("=================="+ config.GetConnectionString("DefaultConnection"));
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                //for passing connection string for sql server
            });


            services.AddScoped<IAttendanceRepository,AttendanceRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            services.AddScoped<ILeaveRequestRepository,LeaveRequestRepository>();
            services.AddScoped<ISalaryRepository,SalaryRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddCors();






            return services;
        }


    }


}

