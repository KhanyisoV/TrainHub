using System.ComponentModel.DataAnnotations;

namespace TrainHub.DTOs
{
    public class CourseDto
    {
        public class CourseListDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string LecturerName { get; set; }  
            public int LessonCount { get; set; }
            public int Duration { get; set; }



        }

        public class CourseDetailDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public string ImageUrl { get; set; }
            public string Level { get; set; }
            public int Duration { get; set; }
            public string InstructorName { get; set; }
            public int InstructorId { get; set; }

            public List<LessonSummaryDto> Lessons { get; set; }

            public int EnrollmentCount { get; set; }  
            public DateTime CreatedAt { get; set; }

        }

        public class CourseCreateDto

        {
            [Required]
            [StringLength(200)]
            public string Title { get; set; }

            [Required]
            [StringLength(2000)]
            public string Description { get; set; }

            [Required]
            public string Category { get; set; }

            [Range(1, 1000)]
            public int Duration { get; set; }

            [Range(0, 999999)]
            public decimal Price { get; set; }

            public string ImageUrl { get; set; }

            public string Level { get; set; }
        }

        public class CourseUpdateDto 
        {
            [Required]
            [StringLength(200)]
            public string Title { get; set; }

            [Required]
            [StringLength(2000)]
            public string Description { get; set; }

            [Required]
            public string Category { get; set; }

            [Range(1, 1000)]
            public int Duration { get; set; }

            [Range(0, 999999)]
            public decimal Price { get; set; }

            public string ImageUrl { get; set; }

            public string Level { get; set; }
        }
        public class LessonSummaryDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Duration { get; set; }
            public bool HasVideo { get; set; }
        }

    }
}
