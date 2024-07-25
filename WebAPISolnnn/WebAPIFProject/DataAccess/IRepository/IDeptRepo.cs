using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIFProject.Models;

namespace WebAPIFProject.DataAccess.IRepository
{
    public interface IDeptRepo
    {
        public Task<List<Department>>AllDepartments();
        public Task<Department> GetDepartmentById(int DeptNo);
        public Task<List<Department>> GetDeptLocation(string Location);

        public Task<int> InsertDepartment(Department Dept);
        public Task<int> UpdateDepartment(Department Dept);
        public Task<int> DeleteDepartment(int DeptNo);
    }
}
