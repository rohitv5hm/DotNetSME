using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectX.Controllers;
using ProjectX.Data.Entities;
using Xunit;


namespace ProjectX.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void GetAllEmployees_ReturnsOkResult_WithListOfEmployees()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(repo => repo.GetAllEmployees())
                .Returns(GetTestEmployees());
            var controller = new EmployeeController(mockRepository.Object);

            // Act
            var result = controller.GetAllEmployees();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var employees = Assert.IsAssignableFrom<IEnumerable<Employee>>(okResult.Value);
            Assert.Equal(3, employees.Count());
        }

        // Other test methods for different scenarios

        // Helper method to generate test employees
        private IEnumerable<Employee> GetTestEmployees()
        {
            return new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Employee { Id = 3, FirstName = "Bob", LastName = "Johnson" },
        };
        }
    }


}
