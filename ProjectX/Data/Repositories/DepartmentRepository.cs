using AutoMapper;
using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.Data.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id);
        }

        public Department AddDepartment(AddDepartmentDTO AddDepartment)
        {
            Department department = _mapper.Map<Department>(AddDepartment);
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public void UpdateDepartment(AddDepartmentDTO AddDepartment)
        {
            Department department = _mapper.Map<Department>(AddDepartment);
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        // Other methods like DeleteDepartment, GetEmployeesInDepartment, etc.
    }

}
