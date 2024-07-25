using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIFProject.Models;

namespace WebAPIFProject.DataAccess.IRepository
{
    public interface IEmpRepo
    {

        public Task<List<Employee>> AllEmployees();
        public Task<Employee> GetEmpById(int EmpId);
        public Task<List<Employee>> GetEmpGender(string Gender);
        public Task<Employee> GetEmpByPasswordandEmail(string Password,string Email);
        public Task<Employee> GetEmpByDeptNo(int DeptNo);
        public Task<int> InsertEmployee(Employee Emp);
        public Task<int> UpdateEmployee(Employee Emp);
        public Task<int> DeleteEmployee(int EmpId);


    }
}
