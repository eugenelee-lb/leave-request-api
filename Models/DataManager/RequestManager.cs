using System.Collections.Generic;
using System.Linq;
using LeaveRequestAPI.Models.Repository;

namespace LeaveRequestAPI.Models.DataManager
{
    public class RequestManager : IRequestRepository<LeaveRequest>
    {
        readonly RepositoryContext _repositoryContext;

        public RequestManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public IEnumerable<LeaveRequest> GetAll()
        {
            return _repositoryContext.LeaveRequests.ToList();
        }

        public IEnumerable<LeaveRequest> GetByEmpIdStatus(string empId, string status)
        {
            return _repositoryContext.LeaveRequests.Where(r => r.EmployeeId == empId && r.RequestStatus == status).ToList();
        }

        public LeaveRequest GetById(int id)
        {
            return _repositoryContext.LeaveRequests.FirstOrDefault(e => e.LeaveRequestId == id);
        }

        public void Add(LeaveRequest entity)
        {
            _repositoryContext.LeaveRequests.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void Update(LeaveRequest leaveRequest, LeaveRequest entity)
        {
            //leaveRequest.EmployeeId = entity.EmployeeId;
            leaveRequest.LeaveType = entity.LeaveType;
            leaveRequest.LeaveTimeType = entity.LeaveTimeType;
            leaveRequest.LeaveAt = entity.LeaveAt;
            leaveRequest.InAt = entity.InAt;
            leaveRequest.IsMultiDays = entity.IsMultiDays;
            leaveRequest.StartDate = entity.StartDate;
            leaveRequest.EndDate = entity.EndDate;
            leaveRequest.Hours = entity.Hours;
            leaveRequest.ApproverId = entity.ApproverId;
            leaveRequest.AlternateApproverId = entity.AlternateApproverId;
            leaveRequest.RequestStatus = entity.RequestStatus;
            leaveRequest.SubmitDate = entity.SubmitDate;
            leaveRequest.ApproveDate = entity.ApproveDate;
            leaveRequest.ApproveBy = entity.ApproveBy;

            _repositoryContext.SaveChanges();
        }

        public void Delete(LeaveRequest leaveRequest)
        {
            _repositoryContext.LeaveRequests.Remove(leaveRequest);
            _repositoryContext.SaveChanges();
        }

    }
}
