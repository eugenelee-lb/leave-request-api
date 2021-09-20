using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequestAPI.Models.Repository
{
    public interface ILeaveRequestRepository<LeaveRequest> : IDataRepository<LeaveRequest>
    {
        LeaveRequest Get(int id);
    }
}
