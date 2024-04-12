using Application.DTO;
using Domain.Context;

namespace Application.Repository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TestDbContext _db;
        public EmployeeRepository(TestDbContext db) => _db = db;

        public List<EmployeeDetails> GetEmployees()
        {
            return _db.Employees.Select(a => new EmployeeDetails
            {
                Id = a.Id,
                FullName = a.FullName,
                Age = a.Age,
                Mobile = a.Mobile
            }).ToList();
        }

        public List<EmployeeDetails> GetEmployee(int empId)
        {
            return _db.Employees.Where(a => a.Id == empId).Select(a => new EmployeeDetails
            {
                Id = a.Id,
                FullName = a.FullName,
                Age = a.Age,
                Mobile = a.Mobile
            }).ToList();
        }

        public List<EmployeeResponse> GetAll()
        {
            var response = _db.Employees.Select(a => new EmployeeResponse { Id = a.Id, FullName = a.FullName, Mobile = a.Mobile }).ToList();
            return response;
        }
    }
}
