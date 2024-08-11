using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Entities;
using WellsFargo_BusinessEntities.Interfaces;
using WellsFargo_BusinessEntities.ModelsDTO;

namespace WellsFargo_Dapper_ServiceLayer
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository repository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository _repository, IMapper mapper)
        {
            repository = _repository;
            this._mapper = mapper;
        }
        /// <summary>
        /// To pass the details to EmployeeRepository to Add Employee Details
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployeeDetils(EmployeeDTO employeeDTO)
        {

            Employee obj = new Employee();
            _mapper.Map(employeeDTO, obj);
            repository.AddEmployeeDetils(obj);
            return true;
        }

        public bool UpdateEmployeeDetils(EmployeeDTO employeeDTO)
        {
            Employee obj = new Employee();
            _mapper.Map(employeeDTO, obj);
            repository.UpdateEmployeeDetils(obj);
            return true;
        }
        /// <summary>
        /// To pass the id to EmployeeRepository to Delete Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteEmployeeDetilsById(int id)
        {
            var emp = repository.DeleteEmployeeDetilsById(id);
            if (emp == false)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
        /// <summary>
        /// To Get All Employee Details
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDTO> GetAllEmployeeDetails()
        {
            var employee = repository.GetAllEmployeeDetails();

            return _mapper.Map<List<EmployeeDTO>>(employee);
        }
        /// <summary>
        /// To pass the id to EmployeeRepository to Get Employee Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<EmployeeDTO> GetEmployeeDetailsById(int id)
        {
            var employee = repository.GetEmployeeDetailsById(id);
            return _mapper.Map<List<EmployeeDTO>>(employee);
        }
    }
}
