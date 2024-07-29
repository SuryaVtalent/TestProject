using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebAPIFProject.DataAccess.IRepository;
using WebAPIFProject.Models;
using WebAPIProject.Test.DataAccessTest.Repository.Test;

namespace WebAPIProject.Test.DataAccessTest.Repository.Test
{
    public class EmpReposit : IEmpRepo
    {
        //Create MOCK Functionality 
        //Create Object Instance like in the EmpRepo DBContext

        public List<Employee> _db= new List<Employee>(); //This is Like DBContext we use this for List All Records
       
        public Task<List<Employee>> AllEmployees()
        {
            return Task.FromResult(_db);
        }

        public Task<int> DeleteEmployee(int EmpId)
        {
            Employee emp = null;  //Default it will be null

            foreach (Employee e in _db)
            {
                if (e.EmpId == EmpId)
                {
                    emp = e; break;
                }
            }
           _db.Remove(emp);
            return Task.FromResult(SaveChanges());
            
        }

        public Task<Employee> GetEmpByDeptNo(int DeptNo)
        {
            Employee emp = null;

            foreach (Employee e in _db)
            {
                if(e.DeptNo==DeptNo)
                {
                    emp = e; break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<Employee> GetEmpById(int EmpId)
        {
            Employee emp = null;

            foreach (Employee e in _db)
            {
                if (e.EmpId==EmpId)
                {
                    emp = e;  break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<Employee> GetEmpByPasswordandEmail(string Password, string Email)
        {
            Employee emp = null;
            foreach (Employee e in _db)
            {
                if (e.Email==Email && e.Password==Password)
                {
                    emp=e; break;
                }
            }
            return Task.FromResult(emp);
        }

        public Task<List<Employee>> GetEmpGender(string Gender)
        {
            List<Employee> lemp=new List<Employee> ();

            foreach (Employee e in _db)
            {
                if (e.Gender == Gender)
                {
                    lemp.Add(e);
                }
            }
            return Task.FromResult(lemp);
        }

        public Task<int> InsertEmployee(Employee Emp)
        {
            _db.Add(Emp);
            return Task.FromResult(SaveChanges());
        }

        public Task<int> UpdateEmployee(Employee Emp)
        {
            foreach (Employee e in _db)
            {
                if (e.EmpId==Emp.EmpId)
                {
                    e.EName = Emp.EName;e.Email = Emp.Email;e.Salary = Emp.Salary;e.Address = Emp.Address;
                    e.Phone = Emp.Phone;e.Password = Emp.Password;e.Gender = Emp.Gender;e.DeptNo = Emp.DeptNo;
                    break;
                }
            }
            return Task.FromResult(SaveChanges());
        }

        //This method is try to return integer 1 value;
        //Savechanges will be not available in Mock Testing so we created Method 
        public int SaveChanges() 
        {
            return 1;
        }

        //This Method is try to return All List of Records
        public int TotalRecords()
        {
            return _db.Count;
        }

    }
}
