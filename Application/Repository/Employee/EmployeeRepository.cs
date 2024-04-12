using Application.DTO;
using Domain.Context;

namespace Application.Repository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TestDbContext _context;
        public EmployeeRepository(TestDbContext context) => _context = context;

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
