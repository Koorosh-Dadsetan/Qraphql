using Dapper;
using Microsoft.AspNetCore.Mvc;
using OneApiForAllEntity.Data.Models;
using OneApiForAllEntity.Extensions;
using System.Data;

namespace OneApiForAllEntity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        private readonly IDbConnection _db;
        public DapperController(DbConnectionService db) => _db = db.GetConnection();

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            //using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            //{
            //    string query = "SELECT * FROM Employees";
            //    return Ok(db.Query<Employee>(query).ToList());
            //}

            string query = "SELECT * FROM Employees";
            return Ok(_db.Query<Employee>(query).ToList());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
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
