using System.Collections.Generic;

namespace ProjectX.Data.Entities
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }

}
