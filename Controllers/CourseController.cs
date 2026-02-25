using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainHub.Data;
using TrainHub.Models;

namespace TrainHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // Get a single course by its id
        [HttpGet("{Id}")]
        public IActionResult GetCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        // Get all Courses that are available in the system
        [HttpGet]
        public IActionResult GetAllCourses()
        {
            var courses = _context.Courses.ToList();
            return Ok(courses);
        }

        // Deleting a single corse by its id for the list
        // Only admin and lecture can delete a course
        [Authorize(Roles = "Admin,Lecturer")]
        [HttpDelete("{Id}")]
        public IActionResult DeleteCourse(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return Ok("Course deleted successfully.");
        }

        //Create a new course, this need to be role based ie only lecture and admin
        [Authorize(Roles = "Admin,Lecturer")]
        [HttpPost]
        public IActionResult CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course data is required.");
            }

            _context.Courses.Add(course);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCourse), new { courseId = course.Id }, course);
        }

        //Update course and only Lecture and admin can

        [Authorize(Roles = "Admin,Lecturer")]
        [HttpPut("{Id}")]
        public IActionResult UpdateCourse(int courseId, [FromBody] Course updatedCourse)
        {
            var existingCourse = _context.Courses.Find(courseId);
            if (existingCourse == null)
            {
                return NotFound();
            }

            existingCourse.Title = updatedCourse.Title;
            existingCourse.Description = updatedCourse.Description;
            existingCourse.LecturerId = updatedCourse.LecturerId;
            existingCourse.ImageUrl = updatedCourse.ImageUrl;
            existingCourse.Duration = updatedCourse.Duration;
            existingCourse.Price = updatedCourse.Price;
            existingCourse.Category = updatedCourse.Category;
            existingCourse.Level = updatedCourse.Level;
            existingCourse.isPublished = updatedCourse.isPublished;
            existingCourse.DateUpdated = DateTime.UtcNow;

            _context.Courses.Update(existingCourse);
            _context.SaveChanges();
            return Ok("Course updated successfully.");
        }
    }
}
