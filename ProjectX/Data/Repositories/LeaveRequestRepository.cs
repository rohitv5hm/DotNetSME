using ProjectX.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProjectX.Data.Repositories
{
    public class LeaveRequestRepository:ILeaveRequestRepository
    {
        private readonly DataContext _context;

        public LeaveRequestRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<LeaveRequest> GetLeaveRequestsForEmployee(int employeeId)
        {
            return _context.LeaveRequests.Where(lr => lr.EmployeeId == employeeId).ToList();
        }

        public void AddLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            _context.SaveChanges();
        }

        public void UpdateLeaveRequest(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Update(leaveRequest);
            _context.SaveChanges();
        }

        // Other methods like DeleteLeaveRequest, GetLeaveRequestById, etc.
    }

}
