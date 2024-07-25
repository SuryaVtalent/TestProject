﻿using System;
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

        public List<Employee> _db= new List<Employee>();
        public Task<List<Employee>> AllEmployees()
        {
            return Task.FromResult(_db);
        }

        public Task<int> DeleteEmployee(int EmpId)
        {
            Employee emp = null;

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
            throw new NotImplementedException();
        }

        public Task<int> UpdateEmployee(Employee Emp)
        {
            throw new NotImplementedException();
        }


        public int SaveChanges()
        {
            return 1;
        }

        public int TotalRecords()
        {
            return _db.Count;
        }

    }
}