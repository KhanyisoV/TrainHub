using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TrainHub.Models
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public bool Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string PaymentStatus { get; set; }

        public decimal PaymentAmount { get; set; }

        //nav

        public User Student { get; set; }
        public Course Course { get; set; }

        public Certificate Certificate { get; set; }
        public ICollection<Progress> ProgressRecords { get; set; }
    }
}
