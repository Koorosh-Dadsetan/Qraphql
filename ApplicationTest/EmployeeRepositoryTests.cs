using Application.DTO;
using Application.Repository.Employee;
using Domain.Context;
using Moq;

namespace ApplicationTest
{
    public class EmployeeRepositoryTests
    {
        public readonly TestDbContext _db;
        public EmployeeRepositoryTests(TestDbContext db) => _db = db;

        [Fact]
        public void GetAllEmployees_ShouldRetrieveAllEmployeesFromRepository()
        {
            var mockEmployeeRepo = new Mock<IEmployeeRepository>();
            var expectedEmployees = new List<EmployeeResponse>
            {
                new EmployeeResponse { Id = 1, FullName = "Employee A", Mobile = "09151234567" },
                new EmployeeResponse { Id = 2, FullName = "Employee B", Mobile = "09151234568" }
            };
            mockEmployeeRepo.Setup(repo => repo.GetAll()).Returns(expectedEmployees.ToList());
            var employeeRepository = new EmployeeRepository(_db);

            var actualEmployees = employeeRepository.GetAll();

            Assert.NotNull(actualEmployees);
            Assert.Equal(expectedEmployees.Count, actualEmployees.Count);
        }
    }
}