using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork<Employee> _employee;

        public EmployeesController(IUnitOfWork<Employee> employee)
        {
            this._employee = employee;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                return Ok(await _employee.Entity.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeesById(int Id)
        {
            return await _employee.Entity.GetById(Id);
        }

    }
}
