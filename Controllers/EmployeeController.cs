using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Business.IService;
using API.Business.Service;
using API.EmployeeModel;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService ;

        public EmployeeController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }


        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return this._employeeService.GetAll();
        }

        [HttpGet("{id}", Name = "GetEmployees")]
        public IActionResult GetById([FromRoute] string id)
        {
            var employee = this._employeeService.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return new ObjectResult(employee);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            _employeeService.add(employee);

            
            return CreatedAtRoute("GetEmployees", new { Controller = "Employee", id = employee.employeeid }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] string id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            var employeeObj = this._employeeService.Find(id);
            if (employeeObj == null)
            {
                return NotFound();
            }
            this._employeeService.Update(employee);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this._employeeService.Remove(id);
        }
    }
    }