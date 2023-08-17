using System.Collections.Generic;
using System;

namespace ProjectX.Data.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int DepartmentId { get; set; }
        // Other properties like Address, Position, etc.
        public Salary Salary { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        // Other navigation properties
        public ICollection<LeaveRequest> LeaveRequests { get; set; }

    }

}
