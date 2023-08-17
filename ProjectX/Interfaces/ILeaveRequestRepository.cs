using ProjectX.Data.Entities;
using System.Collections.Generic;

public interface ILeaveRequestRepository
{
    IEnumerable<LeaveRequest> GetLeaveRequestsForEmployee(int employeeId);
    void AddLeaveRequest(LeaveRequest leaveRequest);
    void UpdateLeaveRequest(LeaveRequest leaveRequest);
    // Other methods like DeleteLeaveRequest, GetLeaveRequestById, etc.
}
