using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFProject.DataAccess.IRepository;
using WebAPIFProject.Models;

namespace WebAPIFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqWebAPIController : ControllerBase
    {

        public IEmpRepo EmpRef;

        public LinqWebAPIController(IEmpRepo _EmpRef) 
        {
         EmpRef= _EmpRef;
        }

        [HttpGet]
        [Route("getEmpList")]
        public async Task<List<Employee>> getEmpList()
        {
            return await EmpRef.AllEmployees();
        }

        [HttpGet]
        [Route("AllEmployees")]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
                var ListEmps = await getEmpList();
                if (ListEmps.Count > 0)
                {
                    return Ok(ListEmps);
                }
                else
                {
                    return NotFound("Records are not available in database...!");
                }
            }
            catch (Exception ex)
            {
                // Log : Error Information [Exception Logging]
                return BadRequest("Somthing Went Wrong...!\n" + "Issue : " + ex.Message + ".\nWe will soleve this issue soon...!");
            }
        }


        [HttpGet]
        [Route("GetEmpById")]
        public async Task<IActionResult> GetEmpById(int EmpId)
        {
            try
            {
                var ENo = (from x in await getEmpList() where x.EmpId == EmpId select x).SingleOrDefault();
                if (ENo != null)
                {
                    return Ok(ENo);
                }
                else
                {
                    return BadRequest("Records are not available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpByPasswordandEmail")]
        public async Task<IActionResult> GetEmpByPasswordandEmail(string Password, string Email)
        {
            try
            {
                var En = (from x in await getEmpList() where x.Password==Password && x.Email==Email select x).SingleOrDefault();
                if (En != null)
                {
                    return Ok(En);
                }
                else
                {
                    return BadRequest("Records are not available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetEmpByDeptNo")]
        public async Task<IActionResult> GetEmpByDeptNo(int DeptNo)
        {
            try
            {
                var En = (from x in await getEmpList() where x.DeptNo==DeptNo select x).ToList();
                if (En != null)
                {
                    return Ok(En);
                }
                else
                {
                    return BadRequest("Records are not available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("EmployeeSalaryDescendingOrder")]
        public async Task<IActionResult> EmployeeSalaryDescendingOrder()
        {
            try
            {
                var empList = (from x in await getEmpList() orderby x.Salary descending select x).ToList();
                if(empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return BadRequest("Records not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "will resolve soon");
            }
        }

        [HttpGet]
        [Route("EmployeewithSomeColumns")]
        public async Task<IActionResult> EmployeewithSomeColumns()
        {
            try
            {
                var empList = (from x in await getEmpList() select new{x.EmpId,x.EName,x.Salary,x.Address }).ToList();
                if (empList.Count != 0)
                {
                    return Ok(empList);
                }
                else
                {
                    return BadRequest("Records not found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "will resolve soon");
            }
        }
    }
}
