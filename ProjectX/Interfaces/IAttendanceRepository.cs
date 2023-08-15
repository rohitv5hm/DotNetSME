using ProjectX.Data.Entities;
using System.Collections.Generic;

public interface IAttendanceRepository
{
    IEnumerable<Attendance> GetAttendancesForEmployee(int employeeId);
    void AddAttendance(Attendance attendance);
    void UpdateAttendance(Attendance attendance);
    // Other methods like DeleteAttendance, GetAttendanceById, etc.
}
