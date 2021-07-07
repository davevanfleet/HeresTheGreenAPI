using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HeresTheGreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        public CoursesController()
        {
            
        }
        
        // POST: "/api/Courses
        [HttpPost]
        public IActionResult CreateCourse()
        {
            return Ok();
        }

        // GET: "/api/Courses"
        [HttpGet]
        public IActionResult GetCompanies()
        {
            return Ok();
        }

        // GET: "/api/Courses/{id}"
        [HttpGet("{id}")]
        public IActionResult GetCourse(string id)
        {
            return Ok();
        }

        // PUT: "/api/Courses/{id}"
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(string id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(string id)
        {
            return Ok();
        }

        private bool CourseExists(string id)
        {
            return true;
        }
    }
}