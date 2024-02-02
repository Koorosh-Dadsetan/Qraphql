using OneApiForAllEntity.Data.Context;
using OneApiForAllEntity.DTO;

namespace OneApiForAllEntity.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TestDbContext _context;
        public EmployeeService(TestDbContext context)
        {
            _context = context;
        }

        public List<EmployeeDetails> GetEmployees()
        {
            return _context.Employees.Select(a => new EmployeeDetails
            {
                Id = a.Id,
                FullName = a.FullName,
                Age = a.Age,
                Mobile = a.Mobile
            }).ToList();
        }

        public List<EmployeeDetails> GetEmployee(int empId)
        {
            return _context.Employees.Where(a => a.Id == empId).Select(a => new EmployeeDetails
            {
                Id = a.Id,
                FullName = a.FullName,
                Age = a.Age,
                Mobile = a.Mobile
            }).ToList();
        }
    }
}
