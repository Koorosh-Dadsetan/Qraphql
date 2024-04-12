using Application.Extension;
using Dapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private IDbConnection? _db;
        private readonly IConfiguration _configuration;
        public DapperController(IConfiguration Configuration) => _configuration = Configuration;

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    string query = "SELECT * FROM Employees";
            //    return Ok(db.Query<Employee>(query).ToList());
            //}

            _db = ConfigureServices.GetConnection(_configuration);

            string query = "SELECT * FROM Employees";
            return Ok(_db.Query<Employee>(query).ToList());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                _db = ConfigureServices.GetConnection(_configuration);

                string query = "INSERT INTO Employees (FullName, Mobile, Age, Address) VALUES (@FullName, @Mobile, @Age, @Address)";
                _db.Execute(query, employee);
                return Ok($"{employee.FullName} با موفقیت اضافه شد");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
