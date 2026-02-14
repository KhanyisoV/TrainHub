using System.ComponentModel.DataAnnotations;

namespace TrainHub.DTOs
{
    
    public class ProgressDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }
        public string LessonTitle { get; set; }
        public int LessonOrder { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int TimeSpent { get; set; } 
    }

    public class MarkLessonCompleteDto
    {
        [Required]
        public int LessonId { get; set; }

        [Range(0, 1000)]
        public int TimeSpent { get; set; }  
    }
    public class EnrollmentProgressDto
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
        public int CompletionPercentage { get; set; }  

        public List<ProgressDto> LessonProgress { get; set; }

        public int? NextLessonId { get; set; }
        public string NextLessonTitle { get; set; }
    }

    public class UnmarkLessonDto
    {
        [Required]
        public int LessonId { get; set; }

    }

    public class StudentProgressReportDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public int CompletionPercentage { get; set; }
        public int TotalLessons { get; set; }
        public int CompletedLessons { get; set; }
        public int TotalTimeSpent { get; set; }  

        public DateTime? LastActivityDate { get; set; } 
        public string Status { get; set; }

        public List<ProgressDto> DetailedProgress { get; set; }
    }
}