using Application.DTO;
using Application.Repository.Employee;
using Domain.Context;
using Domain.Models;

namespace ApplicationTest
{
    public class EmployeeRepositoryTests
    {
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;

        public EmployeeRepositoryTests()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();

            var employeeMock = new Mock<DbSet<Employee>>();

            var mockContext = new Mock<TestDbContext>();

            mockContext.Setup(m => m.Employees).Returns(employeeMock.Object);
        }

        [Fact]
        public void GetAllEmployees_ShouldRetrieveAllEmployeesFromRepository()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseSqlServer("Data Source=DESKTOP-90OC7A4\\SQLEXPRESS;Initial Catalog=Test_db;User Id=sa;Password=4121;MultipleActiveResultSets=True;TrustServerCertificate=True").Options;

            using (var _db = new TestDbContext(options))
            {
                var _lst = _db.Employees.ToList();

                ///////////////////////////////////////////////

                var expectedEmployees = new List<EmployeeResponse>
                {
                    new EmployeeResponse { Id = 1, FullName = "Employee A", Mobile = "09151234567" },
                    new EmployeeResponse { Id = 2, FullName = "Employee B", Mobile = "09151234568" }
                };
                _employeeRepositoryMock.Setup(repo => repo.GetAll()).Returns(expectedEmployees);
                var employeeRepository = new EmployeeRepository(_db);

                var actualEmployees = employeeRepository.GetAll();

                Assert.NotNull(actualEmployees);
                Assert.Equal(expectedEmployees.Count, actualEmployees.Count);
            }
        }
    }
}