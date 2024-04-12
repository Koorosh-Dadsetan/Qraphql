using Application.DTO;

namespace Application.Repository.Employee
{
    public interface IEmployeeRepository
    {
        public List<EmployeeDetails> GetEmployees();
        public List<EmployeeDetails> GetEmployee(int empId);
    }
}
