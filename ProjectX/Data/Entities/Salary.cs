using System;

namespace ProjectX.Data.Entities
{
    public class Salary:BaseEntity
    {
        
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DatePaid { get; set; }

        public Employee Employee { get; set; }
    }

}
