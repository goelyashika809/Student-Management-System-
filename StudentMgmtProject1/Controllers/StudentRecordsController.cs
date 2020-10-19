using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentMgmtProject1.Models;
using StudentMgmtProject1.Repository;

namespace StudentMgmtProject1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRecordsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(StudentRecordsController));
        private IStudent repo;
        public StudentRecordsController(IStudent repo)
        {
            this.repo = repo;
        }

        [System.Web.Http.HttpGet]
        //[Route("Get")]
        public IActionResult Get()
        {
           
            var students = repo.GetAll();
            if (students == null)
            {
                return BadRequest();
            }
            return Ok(students);
            
        }

        [System.Web.Http.HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int id)
        {
            _log4net.Info("Get Api Initiated");
            var record = repo.GetById(id);
            if (record == null)
            {
                return BadRequest();
            }
            return Ok(record);
        }

        [System.Web.Http.HttpPost]
        [Route("PostNewStudent")]

        public IActionResult PostNewStudent(StudentRecords record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = repo.AddStudent(record);
            return Ok(response);

        }
       [System.Web.Http.HttpPut]
       [Route("UpdateStudentRecord")]
        
       public IActionResult UpdateStudentRecord(StudentRecords record)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Cannot save the changes!");
            }
            var response = repo.UpdateStudent(record);
            return Ok(response);

        }

        [System.Web.Http.HttpDelete]
        [Route("DeleteStudentRecord")]

        public IActionResult DeleteStudentRecord(int id)
        {
            var record = repo.GetById(id);
            if (record == null)
            {
                return BadRequest("Record Not Found!");
            }
            var response=repo.DeleteStudent(record);
            return Ok(response);
        }
    }

}
