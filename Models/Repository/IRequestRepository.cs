using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequestAPI.Models.Repository
{
    public interface IRequestRepository<LeaveRequest> : IDataRepository<LeaveRequest>
    {
        IEnumerable<LeaveRequest> GetByEmpIdStatus(string empId, string status);
        LeaveRequest GetById(int id);
    }
}
