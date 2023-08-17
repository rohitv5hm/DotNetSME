using ProjectX.Data.Entities;
using System.Collections.Generic;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    Employee AddEmployee(AddEmployeeDTO employee);
    void UpdateEmployee(AddEmployeeDTO employee);
    // Other methods like DeleteEmployee, GetEmployeesByDepartment, etc.
}
