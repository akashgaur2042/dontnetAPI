
using System.Collections.Generic;
using System.Linq;
using API.EmployeeModel;
using API.Business.IService;
using API.EmployeeDto;
using API.DataContext;


namespace API.Business.Service
{
    public class EmloyeeService : IEmployeeService
    {
        static List<Employee> EmployeesList = new List<Employee>();
        private readonly EmpManagementContext _empManagementContext;

        public EmloyeeService (EmpManagementContext empManagementContext){
            this._empManagementContext = empManagementContext;
        }

        public string test(){
            return "Hello";
        }

        public  dynamic add(Employee employee)
        {
        Employee empResp = employee;
          var result = this._empManagementContext.Employee.Add(empResp);
          this._empManagementContext.SaveChanges();
          
          return result;
        }

        public Employee Find(string key)
        {
             return this._empManagementContext
                .Employee.Where(e => e.employeeid.Equals(key))
                .SingleOrDefault();
        }

        public  IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees = this._empManagementContext.Employee.AsEnumerable();

            return employees;
        }

        public  void  Remove(string Id)
        {
            //  var employeeToRemove = EmployeesList.SingleOrDefault(r => r.employeeid == Id);
            // if (employeeToRemove != null)
            //    EmployeesList.Remove(employeeToRemove);

            var employeeToRemove= this._empManagementContext.Employee
            .Where(r=>r.employeeid.Equals(Id))
            .SingleOrDefault();
            if (employeeToRemove != null)
             this._empManagementContext.Remove(employeeToRemove);
             this._empManagementContext.SaveChanges();

        }

        public void Update(Employee employee)
        {
            
            // var employeeToUpdate = EmployeesList.SingleOrDefault(r => r.employeeid == employee.employeeid);
            var employeeToUpdate = this._empManagementContext.Employee
            .Where(r=>r.employeeid==employee.employeeid)
            .SingleOrDefault();
            if (employeeToUpdate != null)
            {
                employeeToUpdate.employeeid = employee.employeeid;
                employeeToUpdate.name = employee.name;
                employeeToUpdate.salary = employee.salary;
                employeeToUpdate.leaves = employee.leaves;
                
            }
            this._empManagementContext.SaveChanges();
        }

    }
}