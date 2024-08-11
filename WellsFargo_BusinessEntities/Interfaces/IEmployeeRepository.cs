using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Entities;
using WellsFargo_BusinessEntities.ModelsDTO;

namespace WellsFargo_BusinessEntities.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployeeDetails();
        List<Employee> GetEmployeeDetailsById(int id);
        bool AddEmployeeDetils(Employee employee);
        bool UpdateEmployeeDetils(Employee employee);
        bool DeleteEmployeeDetilsById(int id);
    }
}
