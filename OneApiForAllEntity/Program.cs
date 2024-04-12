using Application.DTO;
using Application.Extension;
using Application.Queries;
using Application.Repository.Employee;
using Domain.Context;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using OneApiForAllEntity.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ConfigureServices>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeDetailsType>();
builder.Services.AddScoped<EmployeeQuery>();
builder.Services.AddScoped<ISchema, EmployeeDetailsSchema>();
builder.Services.AddGraphQL(b => b
    .AddAutoSchema<EmployeeQuery>()  // schema
    .AddSystemTextJson());   // serializer

builder.Services.AddScoped<MyAbstractClass, ImplementClass>();

var app = builder.Build();

app.UseMiddleware<Middleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.UseGraphQL<ISchema>("/graphql");  // url to host GraphQL endpoint

app.Run();
