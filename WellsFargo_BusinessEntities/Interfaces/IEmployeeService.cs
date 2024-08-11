using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Entities;
using WellsFargo_BusinessEntities.ModelsDTO;

namespace WellsFargo_BusinessEntities.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployeeDetails();
        List<EmployeeDTO> GetEmployeeDetailsById(int id);
        bool AddEmployeeDetils(EmployeeDTO employee);
        bool UpdateEmployeeDetils(EmployeeDTO employee);
        bool DeleteEmployeeDetilsById(int id);
    }
}
