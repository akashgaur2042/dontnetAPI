using System.Collections.Generic;
using API.EmployeeModel;

namespace API.Business.IService
{
    
    public interface IEmployeeService
    {
        void add(Employee employee);
        public IEnumerable<Employee> GetAll();
        Employee Find(string key);
       public void Remove(string Id);
       public void Update(Employee employee);

        public string test();
    }
}