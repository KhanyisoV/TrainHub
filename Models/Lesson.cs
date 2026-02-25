using System.ComponentModel.DataAnnotations;

namespace TrainHub.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string VideoUrl { get; set; }

        public int LessonDuration { get; set; }
        public string Content { get; set; }

        public int CourseId { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        //nav
        public ICollection<Progress> ProgressRecords { get; set; }
        public Course Course { get; set; }
    }
}
