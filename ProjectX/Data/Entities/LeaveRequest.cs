using System;

namespace ProjectX.Data.Entities
{
    public class LeaveRequest:BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool IsApproved { get; set; }

        public Employee Employee { get; set; }
    }

}
