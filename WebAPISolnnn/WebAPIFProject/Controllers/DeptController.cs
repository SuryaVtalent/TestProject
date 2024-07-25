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
    public class DeptController : ControllerBase
    {
        public IDeptRepo DeptRef;

        public DeptController(IDeptRepo _DeptRef)
        {
            DeptRef = _DeptRef;
        }

        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> InsertDepartment(Department Dept)
        {
            try
            {
              var count= await DeptRef.InsertDepartment(Dept);
                if (count>0)
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
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("AllDepartments")]
        public async Task<IActionResult> AllDepartments()
        {
            try
            {
                var DeptList = await DeptRef.AllDepartments();
                if (DeptList.Count > 0)
                {
                    return Ok(DeptList);
                }
                else
                {
                    return BadRequest("Records are not available");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int DeptNo)
        {
            try
            {
                var DNo = await DeptRef.GetDepartmentById(DeptNo);
                if (DNo !=null)
                {
                    return Ok(DNo);
                }
                else
                {
                    return BadRequest("Records  not Found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }

        [HttpGet]
        [Route("GetDeptLocation")]
        public async Task<IActionResult> GetDeptLocation(string Location)
        {
            try
            {
                var DList = await DeptRef.GetDeptLocation(Location);
                if (DList.Count>0)
                {
                    return Ok(DList);
                }
                else
                {
                    return BadRequest("Records  not Found");
                }
            }
            catch (Exception e)
            {
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }


        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment(Department Dept)
        {
            try
            {
                var count = await DeptRef.UpdateDepartment(Dept);
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
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int DeptNo)
        {
            try
            {
                var count = await DeptRef.DeleteDepartment(DeptNo);
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
                return BadRequest("Something went wrong " + e.Message + "Will resolve soon");
            }
        }



    }
}
