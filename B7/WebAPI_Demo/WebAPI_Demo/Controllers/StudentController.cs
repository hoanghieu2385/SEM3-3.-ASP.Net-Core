﻿using Microsoft.AspNetCore.Mvc;
using WebAPI_Demo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EduDbContext context;
        public StudentController(EduDbContext context)
        {
            this.context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            List<Student> students = new List<Student>();
            students = this.context.Students.ToList();

            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var student = context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            if(!ModelState.IsValid)
            {
                return (BadRequest(ModelState));
            }
            context.Students.Add(student);
            context.SaveChanges();

            return CreatedAtAction("GetById", new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
