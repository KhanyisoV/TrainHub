using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainHub.Data;
using TrainHub.Models;

namespace TrainHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EnrollmentController(AppDbContext context)
        {
            _context = context;
        }

        // gets all enrollments in the system
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            var enrollments = _context.Enrollments.ToList();
            return Ok(enrollments);
        }

        // returns enrollment by id
        // admin and lecture can access this endpoints

        [Authorize(Roles = "Admin,Lecturer")]
        [HttpGet("{id}")]
        public IActionResult GetEnrollment(int id)
        {
            var exist = _context.Enrollments.Include(e => e.Course).FirstOrDefault(e => e.Id == id); // What i learnt

            //var exist = _context.Enrollments.Find(id); what i used to do...
            if (exist == null)
            {
                return NotFound();
            }

            return Ok(exist);
        }

        // i think all users should be able to delete, cause if you deregister for a course your enrollmrnt should also be cancelled...
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            var exist = _context.Enrollments.FirstOrDefault(e => e.Id == id);
            if (exist == null)
            {
                return NotFound();
            }

            _context.Enrollments.Remove(exist);
            _context.SaveChanges();
            return Ok("Enrollment deleted successfully.");
        }

        // I think all users should be able to create an enrollment, cause if you register for a course you need to create an enrollment for that course
        [HttpPost]
        public IActionResult CreateEnrollment([FromBody] Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return Ok("Enrollment created successfully.");
        }

        // I think only admin should be able to update the enrollment, cause they are the ones managing payments

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] Enrollment enrollment)
        {
            var exist = _context.Enrollments.FirstOrDefault(e => e.Id == id);
            if (exist == null)
            {
                return NotFound();
            }

            exist.Status = enrollment.Status;
            exist.PaymentStatus = enrollment.PaymentStatus;
            exist.PaymentAmount = enrollment.PaymentAmount;
            exist.UpdatedAt = DateTime.UtcNow;
            _context.SaveChanges();
            return Ok("Enrollment updated successfully.");
        }
    }
}
