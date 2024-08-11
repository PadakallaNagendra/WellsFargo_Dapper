using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WellsFargo_BusinessEntities.Entities;
using WellsFargo_BusinessEntities.Interfaces;
using Dapper;
using WellsFargo_BusinessEntities.ModelsDTO;

namespace WellsFargo_Dapper_DatabaseLogic
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IConnectionFactory _factory;

        public EmployeeRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }
        public bool AddEmployeeDetils(Employee employee)
        {
            var sql = @"Insert into Employee Values(@FirstName,@LastName,@UserName,@Password,@Age,@Designation,@Address)";
            using (IDbConnection obj = _factory.GetMidLandConnection())
            {
               obj.Query<bool>(sql,new { FirstName=employee.FirstName,
                   LastName=employee.LastName,
                   UserName=employee.UserName,
                   Password=employee.Password,
                   Age=employee.Age,
                   Designation=employee.Designation,
                   Address=employee.Address

               });
                return true;
            }

        }

        public bool DeleteEmployeeDetilsById(int id)
        {
            var sql = @"Delete from Employee where EmpId=@employeeId";
            using (IDbConnection objjj = _factory.GetMidLandConnection())
            {
                objjj.Query<int>(sql, new { employeeId = id }).FirstOrDefault();
                return true;
            }
        }

        public List<Employee> GetAllEmployeeDetails()
        {
            List<Employee> result;
            var sql = @"select * from dbo.Employee";
            using (IDbConnection objjj = _factory.GetMidLandConnection())
            {
                result = objjj.Query<Employee>(sql).ToList();
                return result;
            }
        }

        public List<Employee> GetEmployeeDetailsById(int id)
        {
            List<Employee> result;
            var sql = @"select * from dbo.Mast_Employee_Details where Emp_Id=@employeeId";
            using (IDbConnection objjj = _factory.GetMidLandConnection())
            {
                result = objjj.Query<Employee>(sql, new { employeeId = id }).ToList();
                return result;
            }
        }

        public bool UpdateEmployeeDetils(Employee employee)
        {
            EmployeeDTO objemp = new EmployeeDTO()   //model class wise passing the data to dapper.
            {
                LastName = employee.LastName,
                UserName = employee.UserName,
                Password = employee.Password,
                Age = employee.Age,
                Designation = employee.Designation,
                Address = employee.Address
            };

            var sql = @"Update Mast_Employee_Details set 
                      Emp_Name=@EmployeeName,
                      Emp_salary=@EmployeeSalary,
                      Emp_status=@EmployeeStatus,
                      Emp_Designation=@EmployeeDesignation
                      where Emp_Id=@EmployeeId";
            using (IDbConnection objjj = _factory.GetMidLandConnection())
            {
                //Update Mast_Employee_Details set            //2nd way passing data
                //      Emp_Name = @EmpName,
                //      Emp_salary = @Empsalary,
                //      Emp_status = @Empstatus,
                //      Emp_Designation = @EmpDesignation
                //      where Emp_Id = @EmpId

                //objjj.Query<int>(sql, new { EmpId= empid, EmpName = obj.Emp_Name, Empsalary = obj.Emp_salary, Empstatus = obj.Emp_status, EmpDesignation = obj.Emp_Designation }).FirstOrDefault();
                objjj.Query<int>(sql, objemp).FirstOrDefault();
                return true;
            }
        }
    }
}
