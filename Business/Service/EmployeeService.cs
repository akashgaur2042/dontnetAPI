
using System.Collections.Generic;
using System.Linq;
using API.EmployeeModel;
using API.Business.IService;
using API.EmployeeDto;

namespace API.Business.Service
{
    public class EmloyeeService : IEmployeeService
    {
        static List<Employee> EmployeesList = new List<Employee>();
        
        public string test(){
            return "Hello";
        }

        public void add(Employee employee)
        {
          EmployeesList.Add(employee);
        }

        public Employee Find(string key)
        {
             return EmployeesList
                .Where(e => e.employeeid.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return EmployeesList;
        }

        public void Remove(string Id)
        {
             var employeeToRemove = EmployeesList.SingleOrDefault(r => r.employeeid == Id);
            if (employeeToRemove != null)
                EmployeesList.Remove(employeeToRemove);   
        }

        public void Update(Employee employee)
        {
            var employeeToUpdate = EmployeesList.SingleOrDefault(r => r.employeeid == employee.employeeid);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.employeeid = employee.employeeid;
                employeeToUpdate.name = employee.name;
                employeeToUpdate.salary = employee.salary;
                employeeToUpdate.leaves = employee.leaves;
                
            }
        }

    }
}