using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.Data.Repositories
{
    public class AttendanceRepository:IAttendanceRepository
    {
        private readonly DataContext _context;

        public AttendanceRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetAttendancesForEmployee(int employeeId)
        {
            return _context.Attendances.Where(a => a.EmployeeId == employeeId).ToList();
        }

        public void AddAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }

        public void UpdateAttendance(Attendance attendance)
        {
            _context.Attendances.Update(attendance);
            _context.SaveChanges();
        }

        // Other methods like DeleteAttendance, GetAttendanceById, etc.
    }

}
