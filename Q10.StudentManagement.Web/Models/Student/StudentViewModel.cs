using System.ComponentModel.DataAnnotations;

namespace Q10.StudentManagement.Web.Models.Students
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Document { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }
    }
}
