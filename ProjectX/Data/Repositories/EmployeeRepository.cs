using AutoMapper;
using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.Data.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee AddEmployee(AddEmployeeDTO addEmployee)
        {
            Employee employee = _mapper.Map<Employee>(addEmployee);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public void UpdateEmployee(AddEmployeeDTO addEmployee)
        {
            Employee employee = _mapper.Map<Employee>(addEmployee);
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        // Other methods like DeleteEmployee, GetEmployeesByDepartment, etc.
    }

}
