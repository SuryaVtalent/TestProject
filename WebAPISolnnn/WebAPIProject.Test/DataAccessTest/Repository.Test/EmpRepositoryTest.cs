using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIFProject.Models;
using WebAPIProject.Test.DataAccessTest.Repository.Test;

namespace WebAPIProject.Test.DataAccessTest.Repository.Test
    //This Mock testing creating our own Repository without disturbing any Database 
{
    [TestClass]
    public class EmpRepositoryTest
    {
        [TestMethod]
       public async Task TestInsertEmployee()
        {
            //Create Object
            Employee emp = new Employee(){
                EmpId=1001,EName="Surya",
                Password="12345",
                Gender="Male",
                Phone="987653421",
                Email="surya@gmail.com",
                Salary=30000,
                Address="Hyderabad",
                DeptNo=10 
            };

            //Arrange
            //Create Instance
            EmpReposit obj = new EmpReposit();

            // Act
            var ActualRes = await  obj.InsertEmployee(emp);

            //Assert
            Assert.AreEqual(1, ActualRes);//1 Record Inserted
            Assert.AreEqual(1, obj.TotalRecords());//Records available
            Assert.IsNotNull(obj._db);//Is Empty 
            Assert.AreEqual(emp.EmpId,(await obj.GetEmpById(emp.EmpId)).EmpId);//By Single Employee
        }

        [TestMethod]
        public async Task TestUpdateEmployee()
        {
            //Before Updating Add Inserted Records
            Employee Iemp = new Employee() {
                EmpId = 1001,
                EName = "Surya",
                Password = "12345",
                Gender = "Male",
                Phone = "987653421",
                Email = "surya@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 10
            };

            //create object for Testing the Records Updated or not
            Employee emp = new Employee() {
                EmpId = 1001,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Female",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 20
            };

            //Arrange
            EmpReposit obj = new EmpReposit();
            await obj.InsertEmployee(Iemp);

            //Act
            var Actualres = await obj.UpdateEmployee(emp);

            //Assert
            Assert.AreEqual(1, Actualres);
            Assert.AreEqual(1, obj.TotalRecords());
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(emp.EmpId,(await obj.GetEmpById(emp.EmpId)).EmpId);
            Assert.AreEqual(emp.DeptNo,(await obj.GetEmpByDeptNo(emp.DeptNo)).DeptNo);
            
        }

        [TestMethod]
        public  async Task TestDeleteEmployee()
        {
            //Create object  Records for Testing
            Employee emp1 = new Employee() {
                EmpId = 1001,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Female",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 20
            };

            Employee emp2 = new Employee()
            {
                EmpId = 1001,
                EName = "Surya",
                Password = "123456",
                Gender = "Male",
                Phone = "9876534212",
                Email = "surya@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 10
            };



            //Arrange
            EmpReposit obj=new EmpReposit();
           await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            //Act
            var Actualres = await obj.DeleteEmployee(emp1.EmpId);

            //Assert
            Assert.AreEqual(1, Actualres);
            Assert.AreEqual(1, obj.TotalRecords());
            Assert.IsNotNull(obj._db);
        }

        [TestMethod]
        public async Task TestAllEmployees()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 1001,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Female",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 20
            };

            Employee emp2 = new Employee()
            {
                EmpId = 1002,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Male",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 29000,
                Address = "Hyderabad",
                DeptNo = 20
            };


            //Arrange
            EmpReposit obj = new EmpReposit();
           await obj.InsertEmployee(emp1);
           await obj.InsertEmployee(emp2);

            //Act
            var ActualRes = await obj.AllEmployees();

            //Assert
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,ActualRes.Count);
        }

        [TestMethod]
        public async Task TestGetEmpByPasswordandEmail()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 1001,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Female",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 20
            };

            Employee emp2 = new Employee()
            {
                EmpId = 1002,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Male",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 29000,
                Address = "Hyderabad",
                DeptNo = 20
            };
            //Arrange
            EmpReposit obj = new EmpReposit();
           await obj.InsertEmployee(emp1);
           await obj.InsertEmployee(emp2);

            //Act
            var Actualres = await obj.GetEmpByPasswordandEmail(emp1.Password,emp1.Email);

            //Assert
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2,obj.TotalRecords());
        }

        [TestMethod]
        public async Task TestGetEmpGender()
        {
            Employee emp1 = new Employee()
            {
                EmpId = 1001,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Female",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 30000,
                Address = "Hyderabad",
                DeptNo = 20
            };

            Employee emp2 = new Employee()
            {
                EmpId = 1002,
                EName = "Greeshma",
                Password = "123456",
                Gender = "Male",
                Phone = "9876534212",
                Email = "greeshma@gmail.com",
                Salary = 29000,
                Address = "Hyderabad",
                DeptNo = 20
            };
            //Arrange
            EmpReposit obj = new EmpReposit();
           await obj.InsertEmployee(emp1);
           await obj.InsertEmployee(emp2);

            //Act
            var Actualres =await obj.GetEmpGender(emp1.Gender);

            //Assert
            Assert.IsNotNull(obj._db);
            Assert.AreEqual (2,obj.TotalRecords());
        }

    }
}
