using Application.DTO;

namespace Application.Repository.Employee
{
    public interface IEmployeeRepository
    {
        List<EmployeeDetails> GetEmployees();
        List<EmployeeDetails> GetEmployee(int empId);

        List<EmployeeResponse> GetAll();
    }
}
