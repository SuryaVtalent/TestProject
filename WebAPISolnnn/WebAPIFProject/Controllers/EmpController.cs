using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIFProject.DataAccess.IRepository;
using WebAPIFProject.Models;

namespace WebAPIFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        public IEmpRepo EmpRef;

        public EmpController(IEmpRepo _EmRef)
        {
           EmpRef = _EmRef;
        }


        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> InsertEmployee(Employee Emp)
        {
            try
            {
                var count = await EmpRef.InsertEmployee(Emp);
                if (count >0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are not Inserted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("AllEmployees")]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
                var EmpList = await EmpRef.AllEmployees();
                if (EmpList.Count > 0)
                {
                    return Ok(EmpList);
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
        [Route("GetEmpById")]
        public async Task<IActionResult> GetEmpById(int EmpId)
        {
            try
            {
                var ENo = await EmpRef.GetEmpById(EmpId);
                if (ENo !=null)
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
        [Route("GetEmpGender")]
        public async Task<IActionResult> GetEmpGender(string Gender)
        {
            try
            {
                var EmpList = await EmpRef.GetEmpGender(Gender);
                if (EmpList.Count > 0)
                {
                    return Ok(EmpList);
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
                var En = await EmpRef.GetEmpByPasswordandEmail(Password,Email);
                if (En !=null)
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
                var En = await EmpRef.GetEmpByDeptNo(DeptNo);
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



        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(Employee Emp)
        {
            try
            {
                var count = await EmpRef.UpdateEmployee(Emp);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are not Updated");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(int EmpId)
        {
            try
            {
                var count = await EmpRef.DeleteEmployee(EmpId);
                if (count > 0)
                {
                    return Ok(count);
                }
                else
                {
                    return BadRequest("Records are not Deleted");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong" + e.Message + "Will resolve soon");
            }
        }

    }
}
