using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequestAPI.Models.Repository
{
    public interface IEmployeeAccrualRepository<EmployeeAccrual> : IDataRepository<EmployeeAccrual>
    {
        EmployeeAccrual Get(string employeeId, string accrualType);
        IEnumerable<EmployeeAccrual> GetByEmployee(string employeeId);
    }
}
