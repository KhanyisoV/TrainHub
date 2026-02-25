using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TrainHub.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

        public string ProfilePictureUrl { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navi based on where the user is a Lecture or Student

        public ICollection<Course> LecturerCourses { get; set; }
        public ICollection<Enrollment> enrollments { get; set; }
        public ICollection<Progress> ProgressRecords { get; set; }
    }
}
