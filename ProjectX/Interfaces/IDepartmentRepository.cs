using ProjectX.Data.Entities;
using System.Collections.Generic;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetAllDepartments();
    Department GetDepartmentById(int id);
    Department AddDepartment(AddDepartmentDTO department);
    void UpdateDepartment(AddDepartmentDTO department);
    // Other methods like DeleteDepartment, GetEmployeesInDepartment, etc.
}
