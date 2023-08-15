using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectX.Controllers;
using ProjectX.Data.Entities;
using Xunit;


namespace ProjectX.Test.Controllers.Test
{



    public class DepartmentControllerTests
    {
        [Fact]
        public void GetAllDepartments_ReturnsOkResult_WithListOfDepartments()
        {
            // Arrange
            var mockRepository = new Mock<IDepartmentRepository>();
            mockRepository.Setup(repo => repo.GetAllDepartments())
                .Returns(GetTestDepartments());
            var controller = new DepartmentController(mockRepository.Object);

            // Act
            var result = controller.GetAllDepartments();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var departments = Assert.IsAssignableFrom<IEnumerable<Department>>(okResult.Value);
            Assert.Equal(2, departments.Count());
        }

        private IEnumerable<Department> GetTestDepartments()
        {
            return new List<Department>
        {
            new Department { Id=1,  Name = "PES-Microsoft" },
            new Department { Id=2, Name = "HR" },
        };
        }

        // Other test methods for different scenarios

    }


}


