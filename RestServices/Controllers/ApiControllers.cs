using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RestServices.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllers : Controller
    {
        private readonly AppDbContext _context;
        public ApiControllers(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>/get
        [HttpGet("get")]
        public IEnumerable<Student> Get()
        {
            //return StudentRegistration.GetInstance().GetAllStudents();
            return _context.Students.ToList();
        }

        // GET api/<controller>/get/5
        [HttpGet("get/{id}")]
        public Student Get(string registrationNumber)
        {
            //return StudentRegistration.GetInstance().GetStudent(id);
            return _context.Students.Single(s => s.RegistrationNumber == registrationNumber);
        }

        // POST api/<controller>/post
        [HttpPost("post")]
        public IActionResult Post([FromBody]Student student)
        {
            //if (StudentRegistration.GetInstance().Add(student))
            //    return true;
            //return false;
            _context.Students.Add(student);
            _context.SaveChanges();
            return StatusCode(201, student);
        }

        // PUT api/<controller>/post/5
        [HttpPut("post/{id}")]
        public IActionResult Put(string id, [FromBody]Student student)
        {
            //if (StudentRegistration.GetInstance().UpdateStudent(student))
            //    return true;
            //return false;
            _context.Students.Update(student);
            _context.SaveChanges();
            return StatusCode(202, student);
        }

        // DELETE api/<controller>/delete/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(string id)
        {
            //if (StudentRegistration.GetInstance().Remove(id))
            //    return true;
            //return false;
            _context.Students.Remove(_context.Students.Single(s => s.RegistrationNumber == id));
            _context.SaveChanges();
            return StatusCode(200);
        }
    }
}