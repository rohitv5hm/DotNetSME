using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.Data.Repositories
{
    public class SalaryRepository:ISalaryRepository
    {
        private readonly DataContext _context;

        public SalaryRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Salary> GetSalariesForEmployee(int employeeId)
        {
            return _context.Salaries.Where(s => s.EmployeeId == employeeId).ToList();
        }

        public void AddSalary(Salary salary)
        {
            _context.Salaries.Add(salary);
            _context.SaveChanges();
        }

        public void UpdateSalary(Salary salary)
        {
            _context.Salaries.Update(salary);
            _context.SaveChanges();
        }

        // Other methods like DeleteSalary, GetSalaryById, etc.
    }

}
