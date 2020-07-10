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
        private IEmployeeService _employeeService {get;set;}
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IEnumerable<Employee> GetAll()
        {
            return  _employeeService.GetAll();
        }
        [HttpGet("{id}", Name = "GetEmployees")]
        public IActionResult GetById([FromRoute] string id)
        {
            var employee = _employeeService.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public IActionResult Create([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            _employeeService.add(employee);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] string id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }
            var employeeObj = _employeeService.Find(id);
            if (employeeObj == null)
            {
                return NotFound();
            }
            _employeeService.Update(employee);
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _employeeService.Remove(id);
        }
    }
    }