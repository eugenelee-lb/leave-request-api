using System.Collections.Generic;
using LeaveRequestAPI.Models;
using LeaveRequestAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeaveRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestRepository<LeaveRequest> _dataRepository;
        public RequestController(IRequestRepository<LeaveRequest> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Request/empId/status
        [HttpGet("{empId}/{status}", Name = "GetLeaveRequestsByEmpIdStatus")]
        public IActionResult GetByEmpIdStatus(string empId, string status)
        {
            IEnumerable<LeaveRequest> leaveRequests = _dataRepository.GetByEmpIdStatus(empId, status);
            return Ok(leaveRequests);
        }
        // GET: api/LeaveRequest/Id
        [HttpGet("{id}", Name = "GetLeaveRequest")]
        public IActionResult Get(int id)
        {
            LeaveRequest leaveRequest = _dataRepository.GetById(id);
            if (leaveRequest == null)
            {
                return NotFound("The LeaveRequest record couldn't be found.");
            }
            return Ok(leaveRequest);
        }
        // POST: api/LeaveRequest
        [HttpPost]
        public IActionResult Post([FromBody] LeaveRequest leaveRequest)
        {
            if (leaveRequest == null)
            {
                return BadRequest("LeaveRequest is null.");
            }
            _dataRepository.Add(leaveRequest);
            return CreatedAtRoute(
                  "Get",
                  new { Id = leaveRequest.LeaveRequestId },
                  leaveRequest);
        }
        // PUT: api/LeaveRequest/Id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LeaveRequest leaveRequest)
        {
            if (leaveRequest == null)
            {
                return BadRequest("LeaveRequest is null.");
            }
            LeaveRequest leaveRequestToUpdate = _dataRepository.GetById(id);
            if (leaveRequestToUpdate == null)
            {
                return NotFound("The LeaveRequest record couldn't be found.");
            }
            _dataRepository.Update(leaveRequestToUpdate, leaveRequest);
            return NoContent();
        }
        // DELETE: api/LeaveRequest/Id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            LeaveRequest leaveRequest = _dataRepository.GetById(id);
            if (leaveRequest == null)
            {
                return NotFound("The LeaveRequest record couldn't be found.");
            }
            _dataRepository.Delete(leaveRequest);
            return NoContent();
        }
    }
}
