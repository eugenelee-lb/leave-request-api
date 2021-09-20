using System.Collections.Generic;
using LeaveRequestAPI.Models;
using LeaveRequestAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LeaveRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAccrualController : ControllerBase
    {
        private readonly IEmployeeAccrualRepository<EmployeeAccrual> _dataRepository;
        public EmployeeAccrualController(IEmployeeAccrualRepository<EmployeeAccrual> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/EmployeeAccrual
        [HttpGet("{empId}", Name ="GetByEmployee")]
        public IActionResult Get(string empId)
        {
            IEnumerable<EmployeeAccrual> employeeAccruals = _dataRepository.GetByEmployee(empId);
            return Ok(employeeAccruals);
        }
        // GET: api/EmployeeAccrual/eulee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<EmployeeAccrual> employeeAccruals = _dataRepository.GetAll();
            return Ok(employeeAccruals);
        }
        // GET: api/EmployeeAccrual/eulee/Vacation
        [HttpGet("{empId}/{accrualType}", Name = "GetByEmpIdAccrualType")]
        public IActionResult Get(string empId, string accrualType)
        {
            EmployeeAccrual employeeAccrual = _dataRepository.Get(empId, accrualType);
            if (employeeAccrual == null)
            {
                return NotFound("The Employee Accrual record couldn't be found.");
            }
            return Ok(employeeAccrual);
        }

    }
}
