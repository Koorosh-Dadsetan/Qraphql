﻿using GraphQL;
using GraphQL.Types;
using OneApiForAllEntity.DTO;
using OneApiForAllEntity.Services.Employee;

namespace OneApiForAllEntity.Queries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery(IEmployeeService employeeService)
        {
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employees", resolve: x => employeeService.GetEmployees()); //graphql?query={employees{id,fullName,age,mobile}}
            Field<ListGraphType<EmployeeDetailsType>>(Name = "Employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: x => employeeService.GetEmployee(x.GetArgument<int>("id"))); //graphql?query={employee(id:1){id,fullName,age,mobile}}
        }
    }

    public class EmployeeDetailsSchema : Schema
    {
        public EmployeeDetailsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<EmployeeQuery>();
        }
    }
}
