using System.Collections.Generic;
using System.Linq;
using LeaveRequestAPI.Models.Repository;

namespace LeaveRequestAPI.Models.DataManager
{
    public class EmployeeManager : IEmployeeRepository<Employee>
    {
        readonly RepositoryContext _repositoryContext;

        public EmployeeManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repositoryContext.Employees.ToList();
        }

        public Employee Get(string id)
        {
            return _repositoryContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee entity)
        {
            _repositoryContext.Employees.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.IsSupervisor = entity.IsSupervisor;
            employee.SupervisorId = entity.SupervisorId;

            _repositoryContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _repositoryContext.Employees.Remove(employee);
            _repositoryContext.SaveChanges();
        }
    }
}
