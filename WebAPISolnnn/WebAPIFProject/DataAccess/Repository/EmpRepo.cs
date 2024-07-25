using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFProject.DataAccess.IRepository;
using WebAPIFProject.DBContext;
using WebAPIFProject.Models;

namespace WebAPIFProject.DataAccess.Repository
{
    public class EmpRepo:IEmpRepo
    {
        public DBContextt EmpRep;

        public EmpRepo(DBContextt empRep) {
            
            EmpRep = empRep;
        }

        public async Task<List<Employee>> AllEmployees()
        {
          return await EmpRep.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmpByDeptNo(int DeptNo)
        {
          return  await EmpRep.Employees.Where(x => x.DeptNo == DeptNo).SingleOrDefaultAsync();
        }

        public async Task<Employee> GetEmpById(int EmpId)
        {
            return await EmpRep.Employees.FindAsync(EmpId);
        }

        public async Task<Employee> GetEmpByPasswordandEmail(string Password, string Email)
        {
            return await EmpRep.Employees.Where(x => x.Password==Password && x.Email==Email).SingleOrDefaultAsync();
        }

        public async Task<List<Employee>> GetEmpGender(string Gender)
        {
            return await EmpRep.Employees.Where(x => x.Gender == Gender).ToListAsync();

        }

        public async Task<int> InsertEmployee(Employee Emp)
        {
           await EmpRep.Employees.AddAsync(Emp);
            return await EmpRep.SaveChangesAsync();
        }

        public async Task<int> UpdateEmployee(Employee Emp)
        {
            EmpRep.Employees.Update(Emp);
            return await EmpRep.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int EmpId)
        {
            var emp = EmpRep.Employees.Find(EmpId);
            EmpRep.Employees.Remove(emp);
            return await EmpRep.SaveChangesAsync();
        }
    }
}
