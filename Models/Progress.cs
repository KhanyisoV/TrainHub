namespace TrainHub.Models
{
    public class Progress
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public int EnrollmentId { get; set; }
        public int LessonId { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int TimeSpent { get; set; }

        //nav

        public Lesson Lesson { get; set; }
        public Enrollment Enrollment { get; set; }
        public User User { get; set; }
    }
}
