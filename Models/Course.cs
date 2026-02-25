using System.ComponentModel.DataAnnotations;

namespace TrainHub.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string Category { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Level { get; set; } // beginer, Intermediate, advanced

        public bool isPublished { get; set; }

        public int LecturerId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        // nav

        public User Lecturer { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
