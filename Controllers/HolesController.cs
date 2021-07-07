using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace HeresTheGreenAPI.Controllers
{
    [Route("api/Courses/{courseIdd}/[controller]")]
    [ApiController]
    public class HolesController : Controller
    {
        public HolesController()
        {
            
        }
        
        // POST: "/api/Courses/{courseId}/Holes
        [HttpPost]
        public IActionResult CreateHole()
        {
            return Ok();
        }

        // GET: "/api/Courses/{courseId}/Holes"
        [HttpGet]
        public IActionResult GetHoles()
        {
            return Ok();
        }

        // GET: "/api/Courses/{courseId}/Holes/{id}"
        [HttpGet("{id}")]
        public IActionResult GetHole(string id)
        {
            return Ok();
        }

        // PUT: "/api/Courses/{courseId}/Holes/{id}"
        [HttpPut("{id}")]
        public IActionResult UpdateHole(string id)
        {
            return Ok();
        }

        // DELETE: "/api/Courses/{courseId}/Holes/{id}"
        [HttpDelete("{id}")]
        public IActionResult DeleteHole(string id)
        {
            return Ok();
        }

        private bool HoleExists(string id)
        {
            return true;
        }
    }
}