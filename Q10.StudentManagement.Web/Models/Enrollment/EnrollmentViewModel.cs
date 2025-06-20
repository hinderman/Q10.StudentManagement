using System.ComponentModel.DataAnnotations;

namespace Q10.StudentManagement.Web.Models.Enrollment
{
    public class EnrollmentViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public bool State { get; set; }
    }
}
