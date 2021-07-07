using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HeresTheGreenAPI.Models;

namespace HeresTheGreenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly CourseRepository _courseRepository;
        public CoursesController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        
        // POST: "/api/Courses
        [HttpPost]
        public ActionResult<Course> CreateCourse(Course course)
        {
            return _courseRepository.Create(course);
        }

        // GET: "/api/Courses"
        [HttpGet]
        public ActionResult<List<Course>> GetCourses()
        {
            return _courseRepository.GetCourses();
        }

        // GET: "/api/Courses/{id}"
        [HttpGet("{id}")]
        public ActionResult<Course> GetCourse(string id)
        {
            return _courseRepository.GetCourse(id);
        }

        // PUT: "/api/Courses/{id}"
        [HttpPut("{id}")]
        public ActionResult<Course> UpdateCourse(string id, Course courseIn)
        {
            var course = _courseRepository.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return _courseRepository.Update(id, courseIn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(string id)
        {
            var course = _courseRepository.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}