using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Data;
using StudentAPI.Data.Models;
using StudentAPI.Services.Repositories;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpGet("All Students")]
        public IActionResult GetStudents()
        {
            var student =  appDbContext.Students.ToList();
            if(student == null)
            {
                return NotFound("Student data is null");
            }
             return Ok(student);       
        }
        [HttpPost("Create Student")]
        public IActionResult CreateStudent(Student student)
        {
            try
            {
                appDbContext.Add(student);
                appDbContext.SaveChanges();
                return Ok(student);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut("Update Student")]
        public IActionResult EditStudent(Student student)
        {
            if (student == null || student.Id == 0)
            {
                return BadRequest("Student Data is invalid..!!");
            }
            else if (student.Id == 0)
            {
                return BadRequest($"Student Id{student.Id} is invalid..");
            }
            try
            {
                var Student = appDbContext.Students.Find(student.Id);
                if (student == null)
                {
                    return NotFound($"Student not found with Id{student.Id}");
                }
                Student.Name = student.Name;
                Student.Standard = student.Standard;
                Student.Address = student.Address;     

                appDbContext.SaveChanges();
                return Ok("Student Details Updated..");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteStudent(int id)
        {
            var student = appDbContext.Students.Find(id);
            appDbContext.Remove(student);
            appDbContext.SaveChanges();
            return Ok("Deleted.");
        }
    }
}
