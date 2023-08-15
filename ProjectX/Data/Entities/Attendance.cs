using System;

namespace ProjectX.Data.Entities
{
    public class Attendance:BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public Employee Employee { get; set; }
    }

}
