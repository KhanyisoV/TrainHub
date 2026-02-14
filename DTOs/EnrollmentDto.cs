using System.ComponentModel.DataAnnotations;

namespace TrainHub.DTOs
{
    
    public class EnrollmentListDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseImageUrl { get; set; }
        public string InstructorName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; } 
        public int CompletionPercentage { get; set; }
        public DateTime? CompletionDate { get; set; }

        public bool HasCertificate { get; set; }
        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
    }


    public class EnrollmentDetailDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseDescription { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int CompletionPercentage { get; set; }

  
        public string PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }

      
        public List<LessonProgressDto> LessonProgress { get; set; }

       
        public CertificateDto Certificate { get; set; }
    }

    public class LessonProgressDto
    {
        public int LessonId { get; set; }
        public string LessonTitle { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

   
    public class EnrollInCourseDto
    {
        [Required]
        public int CourseId { get; set; }

    }

    public class AdminEnrollmentListDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public decimal PaymentAmount { get; set; }
        public int CompletionPercentage { get; set; }
    }

    
    public class UpdateEnrollmentStatusDto
    {
        [Required]
        public string Status { get; set; } 
    }
}