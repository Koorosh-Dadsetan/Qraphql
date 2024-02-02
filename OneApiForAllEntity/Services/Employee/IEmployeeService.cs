using OneApiForAllEntity.DTO;

namespace OneApiForAllEntity.Services.Employee
{
    public interface IEmployeeService
    {
        public List<EmployeeDetails> GetEmployees();
        public List<EmployeeDetails> GetEmployee(int empId);
    }
}
