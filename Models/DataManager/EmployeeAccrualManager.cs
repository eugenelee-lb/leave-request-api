using System.Collections.Generic;
using System.Linq;
using LeaveRequestAPI.Models.Repository;

namespace LeaveRequestAPI.Models.DataManager
{
    public class EmployeeAccrualManager : IEmployeeAccrualRepository<EmployeeAccrual>
    {
        readonly RepositoryContext _repositoryContext;

        public EmployeeAccrualManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public IEnumerable<EmployeeAccrual> GetAll()
        {
            return _repositoryContext.EmployeeAccruals.ToList();
        }

        public EmployeeAccrual Get(string employeeId, string accrualType)
        {
            return _repositoryContext.EmployeeAccruals.FirstOrDefault(e => e.EmployeeId == employeeId && e.AccrualType == accrualType);
        }

        public IEnumerable<EmployeeAccrual> GetByEmployee(string employeeId)
        {
            return _repositoryContext.EmployeeAccruals.Where(e => e.EmployeeId == employeeId).ToList();
        }

        public void Add(EmployeeAccrual entity)
        {
            _repositoryContext.EmployeeAccruals.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void Update(EmployeeAccrual employeeAccrual, EmployeeAccrual entity)
        {
            employeeAccrual.Hours = entity.Hours;

            _repositoryContext.SaveChanges();
        }

        public void Delete(EmployeeAccrual employeeAccrual)
        {
            _repositoryContext.EmployeeAccruals.Remove(employeeAccrual);
            _repositoryContext.SaveChanges();
        }
    }
}
