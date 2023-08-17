using Microsoft.AspNetCore.Mvc;
using ProjectX.Data.Entities;

namespace ProjectX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public LeaveRequestController(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }

        [HttpGet("employee/{employeeId}")]
        public IActionResult GetLeaveRequestsForEmployee(int employeeId)
        {
            var leaveRequests = _leaveRequestRepository.GetLeaveRequestsForEmployee(employeeId);
            return Ok(leaveRequests);
        }

        [HttpPost]
        public IActionResult AddLeaveRequest(LeaveRequest leaveRequest)
        {
            _leaveRequestRepository.AddLeaveRequest(leaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequestsForEmployee), new { employeeId = leaveRequest.EmployeeId }, leaveRequest);
        }

        // Other actions for updating, deleting, etc.
    }

}
