using NUnit.Framework;
using Moq;
using AttendenceApi.Models;
using AttendenceApi.Controllers;
using AttendenceApi.Repository;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace NUnitStudentTestProject
{
    public class Tests
    {
        

        List<AttendeeRecords> record = new List<AttendeeRecords>();
        IQueryable<AttendeeRecords> AttendenceData;
        Mock<DbSet<AttendeeRecords>> mockset;
        Mock<Student1Context> arcontextmock;


        [SetUp]
        public void Setup()
        {
            record = new List<AttendeeRecords> {
            new AttendeeRecords{Attnid=0, Rollno=1, Subject="Hindi",Attendence="P"},
            new AttendeeRecords{Attnid=5,Rollno=8,Subject="English",Attendence="A"}
            };

            AttendenceData = record.AsQueryable();


            mockset = new Mock<DbSet<AttendeeRecords>>();
            mockset.As<IQueryable<AttendeeRecords>>().Setup(m => m.Provider).Returns(AttendenceData.Provider);
            mockset.As<IQueryable<AttendeeRecords>>().Setup(m => m.Expression).Returns(AttendenceData.Expression);
            mockset.As<IQueryable<AttendeeRecords>>().Setup(m => m.ElementType).Returns(AttendenceData.ElementType);
            mockset.As<IQueryable<AttendeeRecords>>().Setup(m => m.GetEnumerator()).Returns(AttendenceData.GetEnumerator());


            var mocksetcontext = new DbContextOptions<Student1Context>();
            arcontextmock = new Mock<Student1Context>(mocksetcontext);
            arcontextmock.Setup(x => x.AttendeeRecords).Returns(mockset.Object);
           // var mocksetcontext = new Mock<Student1Context>();
            //mocksetcontext.Setup(c => c.AttendeeRecords).Returns(mockset.Object);
           // _dbcontext = mocksetcontext.Object;




        }

        [Test]
        public void GetAllTest()
        {
            /*AttendeeRepository attendeerecord = new AttendeeRepository(_dbcontext);
            AttendeeRecordsController attenderecordobj = new AttendeeRecordsController(attendeerecord);
            var result = attenderecordobj.GetAllAttendees();
            var response = result as OkObjectResult;*/

            var attenrepo = new AttendeeRepository(arcontextmock.Object);
            var attendeelist = attenrepo.GetAll();

            Assert.AreEqual(2, attendeelist.Count());

        }

        [Test]
        public void GetByIdTestFail()
        {
            var arrepo = new AttendeeRepository(arcontextmock.Object);
            var arobj = arrepo.GetById(88);
            Assert.IsNull(arobj);
        }
    }
}