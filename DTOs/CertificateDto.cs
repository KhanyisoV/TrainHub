using System.ComponentModel.DataAnnotations;

namespace TrainHub.DTOs
{
   
    public class CertificateDto
    {
        public int Id { get; set; }
        public int EnrollmentId { get; set; }
        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string PdfUrl { get; set; }

        public string StudentName { get; set; }  
        public string CourseTitle { get; set; }   
        public DateTime CompletionDate { get; set; } 
    }

    public class GenerateCertificateDto
    {
        [Required]
        public int EnrollmentId { get; set; }

    }

 
    public class VerifyCertificateDto
    {
        public bool IsValid { get; set; }
        public string CertificateNumber { get; set; }
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Message { get; set; } 
    }
}