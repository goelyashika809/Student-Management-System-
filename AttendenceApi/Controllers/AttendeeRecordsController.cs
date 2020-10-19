using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AttendenceApi.Models;
using AttendenceApi.Repository;

namespace AttendenceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeRecordsController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AttendeeRecordsController));
        private IAttendee repo;

        public AttendeeRecordsController(IAttendee repo)
        {
            this.repo = repo;
        }

        [HttpGet]
       //[Route("GetAllAttendees")]
        public IActionResult GetAllAttendees()
        {
            _log4net.Info("Get Api Initiated");
            var attendees = repo.GetAll();
            if (attendees == null)
            {
                return BadRequest();
            }
            return Ok(attendees);

        }

        [HttpGet]
        [Route("GetById")]

        public IActionResult GetById(int id)
        {
            var record = repo.GetById(id);
            if (record == null)
            {
                return BadRequest();
            }
            return Ok(record);
        }

        [HttpPost]
        [Route("PostNewAttendee")]

        public IActionResult PostNewAttendee(AttendeeRecords record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            var response = repo.AddAttendence(record);
            return Ok(response);

        }

        [HttpPut]
        [Route("UpdateAttendeeRecord")]

        public IActionResult UpdateAttendeeRecord(AttendeeRecords record)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest("Cannot save the changes!");
            }
            var response = repo.UpdateAttendence(record);
            return Ok(response);

        }

        [HttpDelete]
        [Route("DeleteAttendeeRecord")]

        public IActionResult DeleteAttendeeRecord(int id)
        {
            var record = repo.GetById(id);
            if (record == null)
            {
                return BadRequest("Record Not Found!");
            }
            var response = repo.DeleteAttendence(record);
            return Ok(response);
        }
    }
}
