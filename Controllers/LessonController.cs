using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainHub.Data;
using TrainHub.Models;

namespace TrainHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LessonController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLessons()
        {
            var lessons = _context.Lessons.ToList();
            return Ok(lessons);
        }

        [HttpGet("{id}")]
        public IActionResult getLesson(int id)
        {
            var exist = _context.Lessons.Find(id);
            if (exist == null)
            {
                return NotFound();
            }

            return Ok(exist);
        }

        // Lecture and admin only
        [Authorize(Roles = "Admin,Lecturer")]
        [HttpDelete("{id}")]
        public IActionResult DeleteLesson(int id)
        {
            var exist = _context.Lessons.Find(id);
            if (exist == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(exist);
            _context.SaveChanges();
            return Ok("Lesson Deleted !");
        }

        // Only lecture should be able to create a lesson
        [Authorize(Roles = "Lecturer")]
        [HttpPost]
        public IActionResult CreateLesson([FromBody] Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return Ok("Lesson created !");
        }

        // Only lecture
        [Authorize(Roles = "Lecturer")]
        [HttpPut("{id}")]
        public IActionResult UpdateLesson(int id, [FromBody] Lesson lesson)
        {
            var exist = _context.Lessons.Find(id);
            if (exist == null)
            {
                return NotFound();
            }
            exist.Title = lesson.Title;
            exist.Content = lesson.Content;
            exist.VideoUrl = lesson.VideoUrl;
            exist.LessonDuration = lesson.LessonDuration;
            exist.DateUpdated = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok("Lesson Updated !");
        }
    }
}
