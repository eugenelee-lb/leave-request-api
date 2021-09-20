using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveRequestAPI.Models.Repository
{
    public interface IEmployeeRepository<Employee> : IDataRepository<Employee>
    {
        Employee Get(string id);
    }
}
