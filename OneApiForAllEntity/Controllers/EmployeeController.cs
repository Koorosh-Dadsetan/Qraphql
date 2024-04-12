using Application.Repository.Employee;
using Microsoft.AspNetCore.Mvc;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository EmployeeRepository) => _employeeRepository = EmployeeRepository;

        [HttpGet]
        public IActionResult GetAll() => Ok(_employeeRepository.GetAll());
    }
}
