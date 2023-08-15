using ProjectX.Data.Entities;
using System.Collections.Generic;

public interface ISalaryRepository
{
    IEnumerable<Salary> GetSalariesForEmployee(int employeeId);
    void AddSalary(Salary salary);
    void UpdateSalary(Salary salary);
    // Other methods like DeleteSalary, GetSalaryById, etc.
}
