using System.ComponentModel.DataAnnotations;

namespace TrainHub.DTOs
{
   
    public class LessonListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }  
        public bool HasVideo { get; set; }
        public bool IsCompleted { get; set; }  
    }

    public class LessonDetailDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; } 
        public string VideoUrl { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }

        public int? PreviousLessonId { get; set; }
        public int? NextLessonId { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime? CompletedAt { get; set; }
    }

    public class CreateLessonDto
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(10000)]
        public string Content { get; set; }

        [Url]
        public string VideoUrl { get; set; }

        [Range(1, 500)]
        public int Duration { get; set; }  
        public int? Order { get; set; }
    }

    public class UpdateLessonDto
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(10000)]
        public string Content { get; set; }

        [Url]
        public string VideoUrl { get; set; }

        [Range(1, 500)]
        public int Duration { get; set; }

        public int? Order { get; set; }
    }

    public class ReorderLessonsDto
    {
        [Required]
        public List<LessonOrderDto> Lessons { get; set; }
    }

    public class LessonOrderDto
    {
        [Required]
        public int LessonId { get; set; }

        [Required]
        public int NewOrder { get; set; }
    }

    public class LessonSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public int Duration { get; set; }
        public bool HasVideo { get; set; }

       
    }
}