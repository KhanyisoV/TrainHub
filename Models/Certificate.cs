using System.ComponentModel.DataAnnotations;

namespace TrainHub.Models
{
    public class Certificate
    {

        [Key]
        public  int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime CompletionDate { get; set; }

        public int EnrollmentId { get; set; }

        //nav

        public Enrollment Enrollment { get; set; }
        public User Student { get; set; }

        public Course Course { get; set; }


    }
}
