using Application.DTO;
using Application.Queries;
using Application.Repository.AbsrtactTest;
using Application.Repository.Employee;
using Domain.Context;
using GraphQL;
using GraphQL.Types;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Application.Extension
{
    public static class ConfigureServices
    {
        public static IDbConnection GetConnection(IConfiguration configuration)
        {
            return new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TestDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<EmployeeDetailsType>();
            services.AddScoped<EmployeeQuery>();
            services.AddScoped<ISchema, EmployeeDetailsSchema>();
            services.AddGraphQL(b => b
                .AddAutoSchema<EmployeeQuery>()  // schema
                .AddSystemTextJson());   // serializer

            services.AddScoped<AbstractTestRepository, ImplementAbstractTestRepository>();
        }
    }
}
