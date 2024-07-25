using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFProject.DataAccess.IRepository;
using WebAPIFProject.DBContext;
using WebAPIFProject.Models;

namespace WebAPIFProject.DataAccess.Repository
{
    public class DeptRepo : IDeptRepo
    {
        public DBContextt DeptRep;

        public DeptRepo(DBContextt _DeptRep)
        {
            DeptRep = _DeptRep;
        }
        public async Task<List<Department>> AllDepartments()
        {
          return await DeptRep.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentById(int DeptNo)
        {
         return await  DeptRep.Departments.FindAsync(DeptNo);
        }

        public async Task<List<Department>> GetDeptLocation(string Location)
        {
          return await DeptRep.Departments.Where(x => x.Location == Location).ToListAsync();
        }

        public async Task<int> InsertDepartment(Department Dept)
        {
           await DeptRep.Departments.AddAsync(Dept);
            return await DeptRep.SaveChangesAsync();
        }

        public async Task<int> UpdateDepartment(Department Dept)
        {
            DeptRep.Departments.Update(Dept);
            return await DeptRep.SaveChangesAsync();
        }

        public async Task<int> DeleteDepartment(int DeptNo)
        {
            var dept = DeptRep.Departments.Find(DeptNo);
            DeptRep.Departments.Remove(dept);
            return await DeptRep.SaveChangesAsync();
        }
    }
}
